#region Header
/**************************************************************************
* First Notice Systems
* 529 Main Street
* Boston, MA 02129
* (617) 886 2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 1993-2006 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Composite.cs 52    7/24/12 12:48p Gwynnj $ */
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using FnsComposite.CallObjects;
using FnsComposite.Interfaces;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace FnsComposite
{
    /// <summary>
    /// Summary description for Composite.
    /// </summary>
    public class Composite : CompositeBase, IEnumerable, IComposite, ISerializable
    {
        private const string ClassName = "Composite";
        internal const string CallRoot = "CALL";
        internal const string ObjectRoot = "Object";

        /// <summary>
        /// Delimit the xpath/callObject naming of attribute/elements
        /// </summary>
        protected static readonly string Delimiter = @"/\:"; // BUGBUG: move to configuration

        private const string ArrayValueDefaultName = "Value";

        /// <summary>
        /// Support for OnValidate
        /// </summary>
        public delegate void ValidationEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Gets a value indicating whether this instance is root.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is root; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool IsRoot => Name == CallRoot || Name == ObjectRoot;

        /// <summary>
        /// Occurs when [validation].
        /// </summary>
        public event ValidationEventHandler Validation;

        /// <summary>
        /// Raises the validate event.
        /// Override when you need to include args
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnValidate(EventArgs e)
        {
            Validation?.Invoke(this, e);

            // propagate 
            foreach (Composite node in GetEnumerator<Composite>())
                node.OnValidate(e);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        public virtual bool Validate()
        {
            try
            {
                OnValidate(EventArgs.Empty);
                return true;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Binary serialization constant
        /// </summary>
        [CLSCompliant(false)]
        protected const uint AttributeType = 32771;

        /// <summary>
        /// Binary serialization constant
        /// </summary>
        [CLSCompliant(false)]
        protected const uint ObjectType = 32769;

        /// <summary>
        /// Binary serialization constant
        /// </summary>
        [CLSCompliant(false)]
        protected const uint HeaderIndicator = 65535;

        /// <summary>
        /// Binary serialization constant
        /// </summary>
        [CLSCompliant(false)]
        protected const ushort LongTagIndicator = 32767;

        /// <summary>
        /// Gets the object list.
        /// </summary>
        protected Hashtable ObjectList { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance has added since last commit.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has added since last commit; otherwise, <c>false</c>.
        /// </value>
        protected bool HasAddedSinceLastCommit { get; set; }

        /// <summary>
        /// Internal enumerator for IEnumerable implementation
        /// </summary>
        public struct CompositeEnumerator : IEnumerator
        {
            //private CompositeBase _root;

            private readonly ArrayList _arrayList;
            private int _currentIndex;

            /// <summary>
            /// Initializes a new instance of the <see cref="CompositeEnumerator"/> class.
            /// </summary>
            /// <param name="aNode">A node.</param>
            public CompositeEnumerator(CompositeBase aNode)
            {
                //_root = aNode;
                _currentIndex = -1;
                _arrayList = new ArrayList();
                var enumList = ((Composite)aNode).ObjectList.GetEnumerator();
                while (enumList.MoveNext())
                {
                    _arrayList.Add(enumList.Value);
                }
                _arrayList.Sort();
            }
            /// <summary>
            /// Sets the enumerator to its initial position, which is before
            /// the first element in the collection.
            /// </summary>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
            public void Reset()
            {
                _currentIndex = -1;
            }
            /// <summary>
            /// Gets the current.
            /// </summary>
            /// <value>The current.</value>
            public object Current => _currentIndex < _arrayList.Count ? _arrayList[_currentIndex] : null;

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            /// 	<see langword="true"/> if the enumerator was successfully advanced to the next element;
            /// <see langword="false"/> if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
            public bool MoveNext()
            {
                return ++_currentIndex < _arrayList.Count;
            }
        }
        /// <summary>
        /// Returns an enumerator that can iterate through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/>
        /// that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return new CompositeEnumerator(this);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Composite"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Composite(string name)
          : base(name)
        {
            ObjectList = new Hashtable();
            HasAddedSinceLastCommit = false;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Composite"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public Composite(Composite source)
          : base(source.Name)
        {
            ObjectList = new Hashtable();
            HasAddedSinceLastCommit = false;
            foreach (CompositeBase node in source)
            {
                var newNode = CompositeFactory.CreateCopy(node);
                if (newNode != null)
                    ObjectList.Add(newNode.Name, newNode);

            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Composite"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        protected Composite(SerializationInfo info)
          : this(ClassName)
        {
            var xmlData = info.GetValue(ClassName, typeof(string)) as string;
            if (!string.IsNullOrEmpty(xmlData))
            {
                LoadFromXml(xmlData);
            }
        }

        /// <summary>
        /// Serializes the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public override void Serialize(BinaryReader reader)
        {
            var converter = new CStringConverter(reader);
            m_name = converter.Contents;

            var childCount = (int)WordReader.ReadCount(reader);

            for (var i = 0; i < childCount; ++i)
            {
                var key = new CStringConverter(reader);

                var shortTag = (ushort)reader.ReadInt16();
                uint objectTag;

                if (shortTag == LongTagIndicator)
                    objectTag = (uint)reader.ReadInt32();
                else
                    objectTag = shortTag;

                switch (objectTag)
                {
                    case HeaderIndicator:
                        {
                            var node = new CompositeLeaf();
                            node.Serialize(reader);
                            Add(node.Name, node.Value);

                        }
                        break;
                    case AttributeType:
                        {
                            var node = new CompositeLeaf();
                            node.Serialize(reader);
                            Add(node.Name, node.Value);
                        }
                        break;
                    case ObjectType:
                        {
                            var node = CompositeFactory.CreateInstance(key.ToString());
                            node.Serialize(reader);
                            Add(node);
                        }
                        break;
                    default:
                        throw new ApplicationException("Unexpected tag in binary Serialization");
                }

            }
        }

        /// <summary>
        /// Serializes the specified reader to Binary (BLOB).
        /// </summary>
        /// <param name="writer"></param>
        public override void Serialize(BinaryWriter writer)
        {
            CStringConverter.Write(writer, m_name);
            WordReader.WriteCount(writer, ObjectList.Count);
            foreach (CompositeBase node in ObjectList.Values)
            {
                // key
                CStringConverter.Write(writer, node.Name);
                if (node.IsLeaf)
                    writer.Write((ushort)AttributeType);
                else
                    writer.Write((ushort)ObjectType);

                node.Serialize(writer);
            }
        }

        /// <summary>
        /// Operator == test for equivalent content.
        /// </summary>
        /// <param name="a">a source node</param>
        /// <param name="b">b compare to node</param>
        /// <returns></returns>
        public static bool operator ==(Composite a, Composite b)
        {
            if ((object)a == null && (object)b == null)
            {
                return true;
            }
            if ((object)a == null || (object)b == null)
            {
                return false;
            }
            return (a.Equals(b) && b.Equals(a));
        }
        /// <summary>
        /// Operator != test for not equivalent content.
        /// </summary>
        /// <param name="a">a source node</param>
        /// <param name="b">b compare to node</param>
        /// <returns></returns>
        public static bool operator !=(Composite a, Composite b)
        {
            return !(a == b);
        }
        /// <summary>
        /// deep cCompare content for equality the specified source.
        /// </summary>
        /// <param name="source">The source to compare.</param>
        /// <returns></returns>
        public override bool Equals(object source)
        {
            return CompareTo(source) == 0;
        }
        /// <summary>
        /// Serves as a hash function for a particular type, suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or
        /// resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
        {
            ObjectList.Clear();
            ObjectList = null;
            base.Dispose();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Composite"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public Composite(XmlNode node)
          : this(DecodeName(node.Name))
        {
            if (node.HasChildNodes)
            {
                ProcessChildren(node);
            }
            ResetDepth();
        }
        /// <summary>
        /// Reloads from XML.
        /// </summary>
        /// <param name="node">The node.</param>
        public void ReloadFromXML(XmlNode node)
        {
            if (node.HasChildNodes)
            {
                ProcessChildren(node);
            }
            ResetDepth();
        }

        #region IComposite Members

        /// <summary>
        /// serialize to HTML.
        /// </summary>
        /// <returns></returns>
        public string ToHtml()
        {
            var results = new StringBuilder();
            if (Parent == null)
            {
                results.AppendLine("<style type=\"text/css\">");
                results.AppendLine("ul { list-style-type:circle; font-family: Verdana, sans-serif; }");
                results.AppendLine("li.Alternate {	background-color: #CCFFFF; }");
                results.AppendLine("</style>");
            }
            results.AppendFormat("<ul{0}><h3>{1}</h3>", Parent == null ? " class=\"CallList\"" : "", Name);
            // First process this nodes attributes if any
            var childElements = Enumerable.ToList(GetEnumerator<CompositeLeaf>().Cast<CompositeLeaf>());

            if (childElements.Count > 0)
            {
                childElements.Sort();
                var toggle = childElements.Count % 2 == 0;
                foreach (var leaf in childElements)
                    results.AppendLine(leaf.ToHtml(ref toggle));
            }
            // now propagate to the child nodes
            var childNodes = Enumerable.ToList(GetEnumerator<Composite>().Cast<Composite>());

            if (childNodes.Count > 0)
            {
                childNodes.Sort();
                foreach (var node in childNodes)
                    results.Append(node.ToHtml());
            }
            results.Append("</ul>");

            return results.ToString();
        }

        #endregion

        /// <summary>
        /// Gets the leaf node count.
        /// </summary>
        /// <returns></returns>
        public int GetLeafNodeCount()
        {
            var resultsCount = 0;

            foreach (CompositeBase c in this)
            {
                if (!c.IsLeaf)
                {
                    var cc = (Composite)c;
                    resultsCount += cc.GetLeafNodeCount();
                }
                else
                {
                    ++resultsCount;
                }
            }
            return resultsCount;
        }

        /// <summary>
        /// propagate to full depth of tree
        /// </summary>
        /// <param name="node">the node</param>
        private void ProcessChildren(XmlNode node)
        {
            if (!node.HasChildNodes) return;
            //string strIndex = String.Empty;

            // iterate the children and get the skinny
            var aChildNode = node.FirstChild;
            // ignore _ARRAY's
            while (null != aChildNode)
            {
                switch (aChildNode.NodeType)
                {
                    case XmlNodeType.Text:
                        Value = aChildNode.Value;
                        aChildNode = null;
                        break;
                    case XmlNodeType.Element:
                        if (HasIndex(aChildNode))
                        {
                            var newNode =
                                CompositeFactory.CreateInstance(DecodeName(aChildNode.Name), aChildNode, $"[{GetIndex(aChildNode)}]");
                            Add(newNode);
                            newNode.ProcessChildren(aChildNode);
                        }
                        else
                        {
                            var elementType = HasType(aChildNode);
                            if (elementType.Length > 0 && elementType.Equals("xml"))
                            {
                                Add(DecodeName(aChildNode.Name), GetXmlText(aChildNode), elementType);
                            }
                            else
                            {
                                if (HasText(aChildNode))
                                {
                                    if (elementType.Length > 0)
                                    {
                                        Add(DecodeName(aChildNode.Name), GetText(aChildNode), elementType);
                                    }
                                    else
                                    {
                                        Add(DecodeName(aChildNode.Name), GetText(aChildNode));
                                    }
                                }
                                else
                                {
                                    if (aChildNode.Name.IndexOf("_ARRAY", StringComparison.Ordinal) == -1)
                                    {
                                        Add(CompositeFactory.CreateInstance(DecodeName(aChildNode.Name), aChildNode));
                                    }
                                    else
                                    {
                                        ProcessChildren(aChildNode);
                                    }
                                }
                            }
                        }
                        break;
                }
                // ReSharper disable PossibleNullReferenceException
                aChildNode = aChildNode.NextSibling;
                // ReSharper restore PossibleNullReferenceException
            }
        }
        /// <summary>
        /// Determines whether the specified element has text.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// 	<c>true</c> if the specified element has text; otherwise, <c>false</c>.
        /// </returns>
        private static bool HasText(XmlNode element)
        {
            var results = false;
            // iterate the children and get the skinny
            var aChildNode = element.FirstChild;
            while (null != aChildNode)
            {
                if (XmlNodeType.Text == aChildNode.NodeType)
                {
                    results = true;
                    break;
                }
                aChildNode = aChildNode.NextSibling;
            }
            return results;
        }

        /// <summary>
        /// Determines whether the specified element has index.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// 	<c>true</c> if the specified element has index; otherwise, <c>false</c>.
        /// </returns>
        private static bool HasIndex(XmlNode element)
        {
            var results = false;
            // iterate the children and get the skinny
            var attrColl = element.Attributes;
            if (null == attrColl) return false;
            var ienum = attrColl.GetEnumerator();
            while (ienum.MoveNext())
            {
                var attr = (XmlAttribute)ienum.Current;
                if (attr != null && attr.Name != "index") continue;
                results = true;
                break;
            }
            return results;
        }
        /// <summary>
        /// Determines whether the specified element has type.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        private static string HasType(XmlNode element)
        {
            var results = string.Empty;
            // iterate the children and get the skinny
            var attrColl = element.Attributes;
            if (null == attrColl) return results;
            var ienum = attrColl.GetEnumerator();
            while (ienum.MoveNext())
            {
                var attr = (XmlAttribute)ienum.Current;
                if (attr != null && attr.Name != "type") continue;
                results = attr?.InnerText;
                break;
            }
            return results;
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        private static string GetText(XmlNode element)
        {
            var results = string.Empty;
            // iterate the children and get the skinny
            var aChildNode = element.FirstChild;
            while (null != aChildNode)
            {
                if (XmlNodeType.Text == aChildNode.NodeType)
                {
                    results = aChildNode.Value;
                    break;
                }
                aChildNode = aChildNode.NextSibling;
            }
            return results;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is indexed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is indexed; otherwise, <c>false</c>.
        /// </value>
        protected bool IsIndexed => m_name.IndexOf('[') > -1;

        /// <summary>
        /// Gets the name of the object sans index.
        /// </summary>
        /// <value>The name of the object.</value>
        protected string ObjectName => IsIndexed ? m_name.Substring(0, m_name.IndexOf('[')) : m_name;

        /// <summary>
        /// Gets the XML text.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        private static string GetXmlText(XmlNode element)
        {
            return element.InnerXml;
        }
        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        private static string GetIndex(XmlNode element)
        {
            var results = string.Empty;
            // iterate the children and get the skinny
            var attrColl = element.Attributes;
            if (null == attrColl) return results;
            var ienum = attrColl.GetEnumerator();
            while (ienum.MoveNext())
            {
                var attr = (XmlAttribute)ienum.Current;
                if (attr != null && attr.Name != "index") continue;
                results = attr?.Value;
                break;
            }
            return results;
        }
        /// <summary>
        /// Resets the depth.
        /// </summary>
        public void ResetDepth()
        {
            foreach (CompositeBase c in this)
            {
                c.Depth = Depth + 1;
                if (!c.IsLeaf)
                {
                    var cc = (Composite)c;
                    cc.ResetDepth();
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Composite"/> class.
        /// </summary>
        /// <param name="node">The o node.</param>
        /// <param name="strIndex">Index of the STR.</param>
        public Composite(XmlNode node, string strIndex)
          : this(node.Name + strIndex)
        {
            if (node.HasChildNodes)
            {
                ProcessChildren(node);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Composite"/> class.
        /// </summary>
        public Composite()
          : this(ClassName)
        {
        }
        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool Add(string name, string value)
        {
            return Add(name, value, string.Empty);
        }

        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public bool Add(string name, string value, string type)
        {
            var results = false;
            var split = name.Split(Delimiter.ToCharArray());
            var node = this;

            var len = split.GetLength(0);
            for (var i = 0; i < len; ++i)
            {
                // if we are at the last remove
                if (i + 1 == len)
                {
                    results = node.AddAt(split[i], value, type);
                    break;
                }
                Composite oNode2;
                if (null == (oNode2 = (Composite)node.GetNode(split[i])))
                {
                    // we need to add this node 
                    oNode2 = node.FullName == "Object" ? new Composite(split[i]) : CompositeFactory.CreateInstance(split[i]);
                    node.Add(oNode2);
                }
                node = oNode2;
            }
            return results;
        }

        public override bool HasValidNode(string name)
        {
            var split = name.Split(Delimiter.ToCharArray());
            var node = this;

            var len = split.GetLength(0);
            for (var i = 0; i < len; ++i)
            {
                // if we are at the last remove
                if (i + 1 == len)
                {
                    if (name == node.Name)
                        return node.ObjectList.Count > 0;
                    if (null == (node = (Composite)node.GetNode(split[i])))
                        return false;
                    return node.ObjectList.Count > 0;
                }
                Composite oNode2;
                if (null == (oNode2 = (Composite)node.GetNode(split[i])))
                {
                    return false;
                }
                node = oNode2;
            }
            return false;
        }


        /// <summary>
        /// Adds the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        public void Add(NameValueCollection items)
        {
            foreach (var key in items.AllKeys)
                Add(key, items[key], string.Empty);
        }

        /// <summary>
        /// Removes the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public bool Remove(string name)
        {
            var results = false;
            var split = name.Split(Delimiter.ToCharArray());
            var node = this;

            var len = split.GetLength(0);
            for (var i = 0; i < len; ++i)
            {
                // if we are at the last remove
                if (i + 1 == len)
                {
                    results = node.RemoveAt(split[i]);
                    break;
                }
                if (Name == split[i])
                    continue;
                if (null == (node = node.GetNode(split[i]) as Composite))
                    break;
            }
            return results;
        }
        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="oValue">The value.</param>
        /// <returns></returns>
        public virtual bool Add(Composite oValue)
        {
            const bool results = true;
            //;

            if (ObjectList.ContainsKey(oValue.Name))
            {
                var node = ObjectList[oValue.Name] as Composite;
                if (node != null)
                {
                    node.CopyChildren(oValue);
                }
                // else bugbug log info/warning do nothing?
            }
            else
            {
                lock (ObjectList.SyncRoot)
                {
                    oValue.Depth = Depth + 1;
                    oValue.Parent = this;
                    ObjectList.Add(oValue.Name, oValue);
                    HasAddedSinceLastCommit = true;
                }
            }
            return results;
        }
        /// <summary>
        /// Copies the children.
        /// </summary>
        /// <param name="source">The source.</param>
        public void CopyChildren(Composite source)
        {
            foreach (CompositeBase comp in source)
            {
                if (comp.IsLeaf)
                {
                    AddAt(comp.Name, comp.Value);
                }
                else
                {
                    var current = comp as Composite;
                    if (ObjectList.ContainsKey(comp.Name))
                    {
                        var child = ObjectList[comp.Name] as Composite;
                        if (child != null && current != null)
                        {
                            child.CopyChildren(current);
                        }
                    }
                    else
                    {
                        if (current != null)
                        {
                            var newChild = CompositeFactory.CreateInstance(current.Name);
                            newChild.CopyChildren(current);
                            Add(newChild);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// toString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var results = new StringBuilder();

            results.Append("\r\n");

            for (var i = 0; i < m_depth; ++i)
            {
                results.Append("\t");
            }
            //results.Append("[");
            results.Append(m_name);
            //results.Append("]");

            var arrayLeafList = new ArrayList();
            var arrayList = new ArrayList();

            var enumList = ObjectList.GetEnumerator();

            while (enumList.MoveNext())
            {
                // first process leaf type
                if (!IsAComposite(enumList.Value))
                {
                    arrayLeafList.Add(enumList.Value);
                }
                else
                {
                    arrayList.Add(enumList.Value);
                }
            }
            arrayLeafList.Sort();
            arrayList.Sort();

            foreach (var leaf in arrayLeafList)
            {
                results.Append("\r\n");
                results.Append(leaf);
            }

            foreach (var leaf in arrayList)
            {
                results.Append("\r\n");
                results.Append(leaf);
            }

            return results.ToString();
        }
        /// <summary>
        /// Gets the <see cref="CompositeBase"/> with the specified name.
        /// </summary>
        /// <value></value>
        public override CompositeBase this[string name]
        {
            get
            {
                CompositeBase oRet = null;
                var split = name.Split(Delimiter.ToCharArray());
                var node = this;

                var len = split.GetLength(0);
                for (var i = 0; i < len; ++i)
                {
                    // if we are at the last return its getNode
                    if (i + 1 == len)
                    {
                        oRet = node.GetNode(split[i]);
                        break;
                    }
                    if (null == (node = (Composite)node.GetNode(split[i])))
                    {
                        break;
                    }
                }
                return oRet;
            }
        }

        /// <summary>
        /// SetValue
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override void SetValue(string name, string value)
        {
            Add(name, value);
        }

        /// <summary>
        /// Gets the node count.
        /// </summary>
        public int GetNodeCount(string name)
        {

            var delimiterIndex = GetDelimterIndexOf(name);

            if (delimiterIndex > -1)
            {
                var parentName = name.Substring(0, delimiterIndex);
                var node = GetNode(parentName) as Composite;
                return node == null ? 0 : node.GetNodeCount(name.Substring(delimiterIndex + 1));
            }
            var result = 0;
            for (var index = 0; ; ++index)
            {
                if (GetNode(name + "[" + index + "]") == null) break;
                ++result;
            }
            return result;
        }

        private static int GetDelimterIndexOf(string name)
        {
            foreach (var c in Delimiter.ToCharArray())
                if (name.IndexOf(c) > -1)
                    return name.IndexOf(c);
            return -1;
        }

        /// <summary>
        /// convert to string in xml format
        /// </summary>
        /// <returns></returns>
        public override string ToXml()
        {
            var results = new StringBuilder();
            var tagName = EncodeName(m_name);

            if (tagName.Length > 0)
            {
                results.Append("<");
                if (tagName.IndexOf("[", StringComparison.Ordinal) > 0)
                {
                    var iStart = tagName.IndexOf("[", StringComparison.Ordinal);
                    var iEnd = tagName.IndexOf("]", StringComparison.Ordinal);
                    var name = tagName.Substring(0, iStart);
                    var strIndex = tagName.Substring(iStart + 1, iEnd - iStart - 1);
                    results.Append(name);
                    results.Append(" index=\"");
                    results.Append(strIndex);
                    results.Append("\"");
                }
                else
                    results.Append(tagName);

                foreach (string key in Attributes.Keys)
                    results.AppendFormat(" {0}=\"{1}\"", key, Attributes[key]);

                results.Append(">");

                var enumList = ObjectList.GetEnumerator();
                while (enumList.MoveNext())
                {
                    // first process leaf type
                    if (((CompositeBase)enumList.Value).IsLeaf)
                    {
                        //results.Append("\n");
                        results.Append(((CompositeLeaf)enumList.Value).ToXml());
                    }
                }
                var strArrayNames = string.Empty;

                enumList.Reset();
                while (enumList.MoveNext()) //process all non-array nodes
                {
                    if (IsAComposite(enumList.Value))
                    {
                        var aNode = enumList.Value as Composite;
                        if (aNode != null)
                        {
                            if (aNode.Name.IndexOf("[", StringComparison.Ordinal) == -1)
                            {
                                results.Append(aNode.ToXml());
                            }
                            else
                            {
                                var iStart = aNode.Name.IndexOf("[", StringComparison.Ordinal);
                                var name = aNode.Name.Substring(0, iStart);
                                if (strArrayNames.IndexOf(name, StringComparison.Ordinal) == -1)
                                {
                                    results.Append(ProcessArrayNodeGroup(name));
                                    strArrayNames += name;
                                }
                            }
                        }
                    }
                }
                results.Append("</");
                if (tagName.IndexOf("[", StringComparison.Ordinal) > 0)
                {
                    var iStart = tagName.IndexOf("[", StringComparison.Ordinal);
                    var name = tagName.Substring(0, iStart);
                    results.Append(name);
                }
                else
                {
                    results.Append(tagName);
                }
                results.Append(">");
            }
            return results.ToString();
        }
        /// <summary>
        /// Clear all lists
        /// </summary>
        public void ClearAll()
        {
            foreach (CompositeBase c in this)
            {
                if (c.IsLeaf) continue;
                var cc = (Composite)c;
                cc.ClearAll();
            }
            ObjectList.Clear();
            HasAddedSinceLastCommit = false;
        }

        /// <summary>
        /// Get Node by name this levels children only
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected CompositeBase GetNode(string name)
        {
            if (name == m_name)
                return this;
            var node = (CompositeBase)ObjectList[name];
            return node;
        }


        /// <summary>
        /// Removes at.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        protected bool RemoveAt(string name)
        {
            var results = ObjectList.ContainsKey(name);
            if (results)
            {
                ObjectList.Remove(name);
                HasAddedSinceLastCommit = true;
            }
            return results;
        }
        /// <summary>
        /// Add leaf node
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        protected bool AddAt(string name, string value)
        {
            return AddAt(name, value, string.Empty);
        }
        /// <summary>
        /// Adds at.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        protected bool AddAt(string name, string value, string type)
        {
            const bool results = true;

            if (ObjectList.ContainsKey(name))
            {
                var leafNode = ObjectList[name] as CompositeLeaf;
                if (leafNode == null)
                {
                    // we have a situation where we are setting a value to an existing Composite
                    // we are either going to convert the node to a leaf or remove it completely
                    // in either case we delete the existing node
                    ObjectList.Remove(name);
                    // first determine if twe are setting Empty string
                    if (value.Length > 0)
                    {
                        leafNode = CompositeLeaf.CreateLeafFactoryMethod(name, value, type);
                        leafNode.Parent = this;
                        ObjectList.Add(name, leafNode);
                    }
                }
                else
                {
                    leafNode.Value = value;
                }
            }
            else
            {
                AddLeafNode(CompositeLeaf.CreateLeafFactoryMethod(name, value, type));
            }
            return results;
        }

        /// <summary>
        /// Adds the leaf node.
        /// </summary>
        /// <param name="node">The node.</param>
        protected void AddLeafNode(CompositeLeaf node)
        {
            node.Depth = Depth + 1;
            node.Parent = this;
            ObjectList.Add(node.Name, node);
            HasAddedSinceLastCommit = true;
        }

        /// <summary>
        /// Gets the value by name.
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>the named value or empty string</returns>
        public string GetValue(string name)
        {
            var results = string.Empty;
            if (null != this[name])
                results = this[name].Value;

            return results;
        }
        /// <summary>
        /// preface arrays with an indicator node
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private string ProcessArrayNodeGroup(string name)
        {
            var results = new StringBuilder();

            results.Append("<");
            results.Append(name);
            results.Append("_ARRAY");
            results.Append(">");
            var enumList = ObjectList.GetEnumerator();
            var nodeList = new List<Composite>();
            while (enumList.MoveNext())
            {
                if (IsAComposite(enumList.Value))
                {
                    var aNode = (Composite)enumList.Value;
                    if (aNode.Name.IndexOf("[", StringComparison.Ordinal) > -1 && aNode.Name.IndexOf(name, StringComparison.Ordinal) > -1)
                        nodeList.Add(aNode);
                }
            }

            foreach (var node in nodeList.OrderBy(a => a.Name))
                results.Append(node.ToXml());

            results.Append("</");
            results.Append(name);
            results.Append("_ARRAY");
            results.Append(">");

            return results.ToString();
        }
        /// <summary>
        /// give the string up until the last delimiter
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns>
        /// Name if no delimiter otherwise prefixed object name
        /// </returns>
        protected static string ExtractObjectName(string name, string delimiter)
        {
            var indexOfLastDelimiter = name.LastIndexOf(delimiter, StringComparison.Ordinal);
            return indexOfLastDelimiter > -1 ? name.Substring(0, indexOfLastDelimiter) : name;
        }
        /// <summary>
        /// Extracts the name of the first indexed object.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        protected static string ExtractFirstIndexedObjectName(string name)
        {
            var indexOfLastDelimiter = name.IndexOf("]:", StringComparison.Ordinal);
            return indexOfLastDelimiter > -1 ? name.Substring(0, indexOfLastDelimiter + 1) : name;
        }
        /// <summary>
        /// Extracts the object value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        protected static string ExtractObjectValue(string name, string delimiter)
        {
            var indexOfLastDelimiter = name.LastIndexOf(delimiter, StringComparison.Ordinal);
            return indexOfLastDelimiter > -1 ? name.Substring(indexOfLastDelimiter + 1) : name;
        }

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        public override void Rollback()
        {
            // BUGBUG: we need to track the adds and provide rollback
            // for now only leaf nodes are fully supported JJG
            HasAddedSinceLastCommit = false;
            foreach (CompositeBase c in this)
            {
                c.Rollback();
            }
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public override void Commit()
        {
            HasAddedSinceLastCommit = false;
            foreach (CompositeBase c in this)
            {
                c.Commit();
            }
        }
        /// <summary>
        /// Gets a value indicating whether this instance has changed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has changed; otherwise, <c>false</c>.
        /// </value>
        public override bool HasChanged
        {
            get
            {
                // process the leaves
                var found = HasAddedSinceLastCommit;
                if (!found)
                {
                    if (this.Cast<CompositeBase>().Any(c => c.IsLeaf && c.HasChanged))
                    {
                        found = true;
                    }
                    // check the remaining branches
                    if (found) return true;
                    foreach (var c in from CompositeBase c in this where !c.IsLeaf select c)
                    {
                        found = c.HasChanged;
                        if (found)
                        {
                            break;
                        }
                    }
                }
                return found;
            }
        }
        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        protected Composite GetObject<T>(string name)
          where T : Composite, IComposite, new()
        {
            lock (this)
            {
                var node = this[name] as T;
                if (node == null)
                {
                    node = new T();
                    Add(node);
                }
                return node;
            }
        }
        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>The address.</value>
        public IAddress Address => new Address(this);

        /// <summary>
        /// Gets the enumerator of type<typeparam name="T">must be subclass of Composite</typeparam>.
        /// </summary>
        /// <returns>Custom enumerator</returns>
        public IEnumerable GetEnumerator<T>()
          where T : CompositeBase
        {
            return this.OfType<T>().Cast<object>();
        }

        /// <summary>
        /// Determines whether [is A composite] [the specified node].
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>
        /// 	<c>true</c> if [is A composite] [the specified node]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsAComposite(object node)
        {
            var results = false;
            // now do the nodes
            var thisType = node.GetType();
            var targetType = Type.GetType("FnsComposite.Composite");

            while (thisType != null)
            {
                if (thisType == targetType)
                {
                    results = true;
                    break;
                }
                thisType = thisType.BaseType;
            }
            return results;
        }
        /// <summary>
        /// Loads from XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        public void LoadFromXml(string xml)
        {
            try
            {
                var document = new XmlDocument();
                document.LoadXml(xml);
                if (document.DocumentElement != null)
                {
                    m_name = document.DocumentElement.Name;
                    ReloadFromXML(document.DocumentElement);
                }
            }
            catch (Exception ex)
            {
                SetValue("LASTERROR", ex.Message);
            }
        }

        ///<summary>
        ///Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> with the data needed to serialize the target object.
        ///</summary>
        ///
        ///<param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"></see>) for this serialization. </param>
        ///<param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> to populate with data. </param>
        ///<exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(ClassName, ToXml());
        }

        #region Json Support

        /// <summary>
        /// serialize to json.
        /// </summary>
        public virtual string ToJson()
        {
            return GetJson();
        }

        private string GetJson()
        {
            var results = new StringBuilder();
            using (var sw = new StringWriter(results))
            {
                using (JsonWriter jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = NoOutputFormat ? Formatting.None : Formatting.Indented;
                    jsonWriter.WriteStartObject();
                    ToJson(jsonWriter, -1);
                    jsonWriter.WriteEndObject();
                }
            }
            return results.ToString();
        }

        private void ToJson(JsonWriter jsonWriter, int index)
        {
            var arrayGroups = new Dictionary<string, int>();

            if (!IsRoot)
            {
                if (index < 0)
                {
                    jsonWriter.WritePropertyName(Name);
                    jsonWriter.WriteStartObject();
                }
            }

            foreach (CompositeLeaf leaf in GetEnumerator<CompositeLeaf>())
                leaf.ToJson(jsonWriter);

            foreach (Composite node in GetEnumerator<Composite>())
            {
                // first output normal children
                if (!node.IsIndexed)
                    node.ToJson(jsonWriter, -1);
                else // keep track of arrays
                {
                    if (arrayGroups.ContainsKey(node.ObjectName))
                        arrayGroups[node.ObjectName]++;
                    else
                        arrayGroups.Add(node.ObjectName, 1);
                }
            }

            // now process arrays if any
            if (arrayGroups.Count > 0)
            {
                foreach (var key in arrayGroups.Keys)
                {
                    jsonWriter.WritePropertyName(key);
                    jsonWriter.WriteStartArray();
                    for (var i = 0; i < arrayGroups[key]; ++i)
                    {
                        jsonWriter.WriteStartObject();
                        var child = (Composite)ObjectList[$"{key}[{i}]"];
                        child.ToJson(jsonWriter, i);
                        jsonWriter.WriteEndObject();
                    }
                    jsonWriter.WriteEndArray();
                }
            }
            if (IsRoot) return;
            if (index < 0)
            {
                jsonWriter.WriteEndObject();
            }
        }

        /// <summary>
        /// serialize from json.
        /// </summary>
        public virtual void LoadFromJson(string json)
        {
            using (JsonReader jsonReader = new JsonTextReader(new StringReader(json)))
            {
                FromJson(jsonReader);
            }
        }

        private void FromJson(JsonReader jsonReader)
        {
            var notDone = true;
            var currentProperty = "";

            while (notDone && jsonReader.Read())
            {
                switch (jsonReader.TokenType)
                {
                    case JsonToken.PropertyName:
                        currentProperty = jsonReader.Value.ToString();
                        break;

                    case JsonToken.String:
                    case JsonToken.Integer:
                    case JsonToken.Date:
                    case JsonToken.Float:
                        Add(DecodeName(currentProperty), jsonReader.Value.ToString());
                        break;

                    case JsonToken.StartArray:
                        ProcessJsonArray(jsonReader, currentProperty);
                        currentProperty = "";  // ignore encapsulating object name
                        break;

                    case JsonToken.StartObject:
                        if (currentProperty.Length > 0 && currentProperty != m_name && currentProperty != ArrayValueDefaultName)
                        {
                            var newNode = GetOrAddNode(DecodeName(currentProperty));
                            newNode.FromJson(jsonReader);
                        }
                        break;

                    case JsonToken.EndObject:
                        notDone = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or creates node by name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private Composite GetOrAddNode(string name)
        {
            Composite results;
            if (null != (results = (Composite)GetNode(name))) return results;
            results = CompositeFactory.CreateInstance(name);
            Add(results);
            return results;
        }

        private void ProcessJsonArray(JsonReader jsonReader, string currentProperty)
        {
            var notDone = true;
            var currentIndex = 0;

            while (notDone && jsonReader.Read())
            {
                switch (jsonReader.TokenType)
                {
                    case JsonToken.PropertyName:
                        notDone = jsonReader.Value.ToString().Equals(ArrayValueDefaultName);
                        break;

                    case JsonToken.String:
                    case JsonToken.Integer:
                    case JsonToken.Date:
                    case JsonToken.Float:
                        Add(DecodeName(currentProperty), jsonReader.Value.ToString());
                        break;

                    case JsonToken.StartArray:
                        ProcessJsonArray(jsonReader, currentProperty);
                        currentProperty = "";  // ignore encapsulating object name
                        break;

                    case JsonToken.StartObject:
                        var nodeName = $"{currentProperty}[{currentIndex++}]";
                        var newNode = GetOrAddNode(DecodeName(nodeName));
                        Add(newNode);
                        newNode.FromJson(jsonReader);
                        break;

                    case JsonToken.EndArray:
                        notDone = false;
                        break;
                }
            }
        }

        #endregion

        /// <summary>
        /// Copies this instance (override this for ICloneable support of the superclasses.)
        /// </summary>
        /// <returns></returns>
        protected override CompositeBase Copy()
        {
            return new Composite(this);
        }

        public int? GetValueAsInt(string column)
        {
            if (int.TryParse(GetValue(column), out var result))
                return result;
            return null;
        }

        public T Merge<T>(T source) where T : Composite
        {
            foreach (CompositeLeaf leaf in source.GetEnumerator<CompositeLeaf>())
            {
                var current = GetValue(leaf.Name);
                if (string.IsNullOrEmpty(current))
                    SetValue(leaf.Name, leaf.Value);
            }
            foreach (Composite node in source.GetEnumerator<Composite>())
            {
                Add(node);
            }
            return this as T;
        }
    }
}
#region Log
/*
* $Log: /SourceCode/Components/FNS2005/FnsComposite/Composite.cs $
 * 
 * 52    7/24/12 12:48p Gwynnj
 * CopyChildren made public because it is useful when reindexing array
 * items.
 * 
 * 51    5/31/12 8:35p Gwynnj
 * extended merge to deep merge.
 * 
 * 50    5/22/12 6:41p Gwynnj
 * Added support for Merge for concating Multiple role entities for AAA.
 * 
 * 49    5/21/12 1:11p Gwynnj
 * HasValidNode added
 * 
 * 48    4/26/11 8:06a Gwynnj
 * added GetValueAsInt
 * 
 * 47    4/13/11 12:29p Gwynnj
 * indexed arrays are now sorted for xml output
 * 
 * 46    11/16/10 11:26a Gwynnj
 * ToHtml added inline style fixes for IE
 * 
 * 45    10/20/10 10:27p Gwynnj
 * Added suport for ToNameValueDictionary for use in node copy i.e.
 * Affirmative Entities
 * 
 * 44    9/21/10 6:29p Gwynnj
 * Created EntityBase to factor the IPerson interface
 * 
 * 43    4/15/10 7:07a Gwynnj
 * Minor edits
 * 
 * 42    3/02/10 5:28p Gwynnj
 * cleared out build warnings
 * 
 * 41    2/24/10 6:46p Gwynnj
 * Added TranOutcome and TranOutcomeSupport message objects for
 * communication with legacy message objects used by OutcomeViewer
 * 
 * 40    1/12/10 5:13p Gwynnj
 * Added GetNodeCount for indexed elements
 * 
 * 39    1/05/10 3:53p John.gwynn
 * bug in GetValue to test for self
 * 
 * 38    11/11/09 2:20p John.gwynn
 * Compare reverted to simple name comparison
 * 
 * 37    10/12/09 10:49a John.gwynn
 * modified the Html output to use css classes
 * 
 * 36    9/30/09 6:36p John.gwynn
 * Implemented IComparable for composites adding a virtual Compare method
 * for specialized equality and sorting .e.g. see the AhsSegment where two
 * segments are deemed equal if their upload keys are equal.
 * 
 * 35    9/29/09 5:12p John.gwynn
 * Added Validation Event support for Composite in general and Segment
 * classes.
 * 
 * 34    9/28/09 1:14p John.gwynn
 * Added support for ICloneable
 * 
 * 33    7/06/09 7:03p John.gwynn
 * Fixed strongly typed constructor for CallflowEvent objects (loading
 * from Xml) and added NamedValueCollection for set difference operations
 * 
 * 32    6/17/09 7:36a John.gwynn
 * serialization
 * 
 * 31    6/11/09 2:47p John.gwynn
 * We have the Binary load nailed.
 * 
 * 30    6/09/09 5:50p John.gwynn
 * updates for the Serialization code  - more cases found of variation
 * 
 * 29    6/08/09 5:11p John.gwynn
 * Added Serialize support from BLOBS 
 * 
 * 28    5/19/09 1:57p John.gwynn
 * added JSON serialiation
 * 
 * 27    5/04/09 6:55p John.gwynn
 * Refactored ICall interface
 * 
 * 26    3/20/09 5:50p John.gwynn
 * added JSON serialize OUT - in not quite ready
 * 
 * 25    3/03/09 4:06p John.gwynn
 * fixed a weakness with Address derivative class
 * 
 * 24    2/23/09 5:20p John.gwynn
 * fixed bug in Remove
 * 
 * 23    2/03/09 3:30p John.gwynn
 * Added EncodeName/DecodeName in concert with Call methods to support
 * 
 * 22    1/30/09 10:56a John.gwynn
 * added synchronization on Add 
 * 
 * 21    5/24/08 4:06p John.gwynn
 * fixed a bug in ToXml
 * 
 * 20    5/23/08 7:52p John.gwynn
 * Added Remove to the IComposite interface
 * 
 * 19    3/17/08 10:38a John.gwynn
 * minor comment and resharper edits
 * 
 * 18    3/16/08 3:32p John.gwynn
 * Implemented ISerializable
 * 
 * 17    3/02/08 1:10p John.gwynn
 * refactored LoadFromXml
 * 
 * 16    2/10/08 6:51p John.gwynn
 * xml bugs fixed and added CreateCoverage for vehicle
 * 
 * 15    2/08/08 3:10p John.gwynn
 * Added (CalObject) Coverage and fixed a bug loading Xml array elements
 * from Call Xml
 * 
 * 14    2/04/08 6:46p John.gwynn
 * Added AhsId and LastError 
 * 
 * 13    11/07/07 12:13p John.gwynn
 * Added ToHtml (with raw styles for now)
 * 
 * 12    10/22/07 6:08p John.gwynn
 * 
 * 11    10/21/07 3:50p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 * 
 * 10    10/01/07 12:06p John.gwynn
 * 
 * 9     8/28/07 11:22a John.gwynn
 * modified the LoadFromXml to Copy [retain] elements that alread exist
 * (rather than overwriting them)
 * 
 * 8     8/27/07 7:10p John.gwynn
 * Added CopyChildren
 * 
 * 7     8/26/07 10:05a John.gwynn
 * added support for GetXmlTree method to extract subtrees in xml
 * 
 * 6     8/02/07 5:16p John.gwynn
 * Update bugs from OPM work andthe SetValue o Empty string is more
 * robust...
 * 
 * 5     7/26/07 6:13p John.gwynn
 * scoped index to private
 * 
 * 4     5/29/07 7:05p John.gwynn
 * new MessageObject set of classes for OPM with some refactoring and
 * gebneral enhancements
 * 
 * 3     4/20/07 5:17p John.gwynn
 * 
 * 2     4/17/07 3:41p John.gwynn
 * update current version synch to 1.1
 * 
 * 25    2/21/07 4:16p John.gwynn
 * added checks for null in operator ==
 * 
 * 24    2/21/07 2:44p John.gwynn
 * Equals evaluates to Is A Subset Of whereas == will compare each to each
 * for set equality
 * 
 * 23    2/21/07 11:39a John.gwynn
 * added Operator == and comparison operators as well as Copy
 * constructors...
 * 
 * 22    11/30/06 10:54a John.gwynn
 * Fixed a parsing bug for Xml constructors
 * 
 * 21    11/16/06 5:20p John.gwynn
 * Added NDoc comments and formatting
 * 
 * 20    11/14/06 10:31a John.gwynn
 * Overloaded the Add (string name, string value) with Add (string name,
 * string value, string type) to extend the Leaf node classes i.e. XmlLeaf
 * 
 * 19    10/27/06 5:08p John.gwynn
 * Implemented IDispose
 * 
 * 18    10/09/06 4:54p John.gwynn
 * added CrLf to ToString()
 * 
 * 17    9/26/06 12:46p John.gwynn
 * added Commit, Rollback and HasChanged functionality
 * 
 * 16    9/19/06 6:42p John.gwynn
 * Added HasChanged, Commit and Rollback for edits.
 * 
 * 15    9/17/06 7:40p John.gwynn
 * updates to support Treeviews
 * 
 * 14    6/03/06 4:50p John.gwynn
 * added RegexprExtractor and support for counting leaf nodes and strong
 * name file
 * 
 * 13    4/20/06 11:54a John.gwynn
 * CLI Compliance modifications
 * 
 * 12    4/09/06 8:14p John.gwynn
 * FxCop and Resharper reformatting changes
 * 
 * 11    1/18/06 2:45p John.gwynn
 * handle Xml special characters in data
 * 
 * 10    1/17/06 4:09p John.gwynn
 * SetTypedValue support for XML as call values 
 * 
 * 9     1/15/06 8:09p John.gwynn
 * finalized overflow attribute structure
 * 
 * 8     1/15/06 12:06a John.gwynn
 * Implemented ICall (start)
 * 
 * 7     1/04/06 11:23p John.gwynn
 * added overflow support
 * 
 * 6     12/26/05 1:11a John.gwynn
 * added _ARRAY handling to conform to ICall
 * 
 * 5     12/17/05 6:11p John.gwynn
 * XmlDocument constructor support added
 * 
 * 4     12/17/05 12:11a John.gwynn
 * added support for visitor
 * 
 * 3     12/11/05 7:13p John.gwynn
 * added iterators
 * 
 * 2     12/10/05 9:43p John.gwynn
 * added ToString an ToXml and sort
 * 
 * 1     12/09/05 1:47p John.gwynn
*/
#endregion
