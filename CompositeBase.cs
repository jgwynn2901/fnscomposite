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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CompositeBase.cs 23    8/22/12 2:36p Gwynnj $ */
#endregion

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace FnsComposite
{
  /// <summary>
  /// CompositeBase the single interface for primitives and composite types.
  /// </summary>
  /// <seealso cref="System.IDisposable" />
  /// <seealso cref="System.ICloneable" />
  /// <seealso cref="System.IComparable" />
  /// <seealso cref="CompositeBase" />
  [ClassInterface(ClassInterfaceType.None), ComVisible(false), Serializable]
  public abstract class CompositeBase : IDisposable, ICloneable, IComparable, IComparable<CompositeBase>
  {
    /// <summary>
    /// Every node has a name
    /// </summary>
    // ReSharper disable InconsistentNaming
    protected string m_name;
    /// <summary>
    /// depth of tree for formatting output
    /// </summary>
    protected int m_depth;
    /// <summary>
    /// every child should know its parent
    /// </summary>
    protected CompositeBase m_parent;

    /// <summary>
    /// xpath separator
    /// </summary>
    protected const string separator = "/";
    /// <summary>
    /// Xml encoding constant
    /// </summary>
    protected static string Ampersand = "&amp;";
    /// <summary>
    /// Xml encoding constant
    /// </summary>
    protected static string GreaterThan = "&gt;";
    /// <summary>
    /// Xml encoding constant
    /// </summary>
    protected static string LessThan = "&lt;";
    /// <summary>
    /// Xml encoding constant
    /// </summary>
    protected static string SingleQuote = "&apos;";
    /// <summary>
    /// Xml encoding constant
    /// </summary>
    protected static string DoubleQuote = "&quot;";

    /// <summary>
    /// The _disposed indicator
    /// </summary>
    protected bool _disposed;

    /// <summary>
    /// Gets or sets a value indicating whether [no output format].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [no output format]; otherwise, <c>false</c>.
    /// </value>
    public bool NoOutputFormat { get; set; }


    private readonly NameValueCollection _attributes = new NameValueCollection();

    /// <summary>
    /// Gets or sets a value indicating whether [no output format for JSON (so far)] .
    /// </summary>
    /// <value>
    ///   <c>true</c> if [no output format]; otherwise, <c>false</c>.
    /// </value>

    /// <summary>
    /// Gets or sets the last error meesage.
    /// </summary>
    /// <value>The last error.</value>
    public string LastError { get; protected set; }

    // ReSharper restore InconsistentNaming
    /// <summary>
    /// constructor requires a name
    /// </summary>
    /// <param name="name">The name.</param>
    protected CompositeBase(string name)
    {
      m_name = name;
      m_depth = 0;
      m_parent = null;

    }
    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeBase"/> class.
    /// </summary>
    protected CompositeBase()
      : this("CompositeBase")
    {
    }
    /// <summary>
    /// Accepts the specified visitor.
    /// </summary>
    /// <param name="visitor">The visitor.</param>
    public virtual void Accept(IVisitor visitor)
    {
      visitor.Visit(this);
    }
    /// <summary>
    /// Gets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name
    {
      get
      {
        return m_name;
      }
    }

    /// <summary>
    /// Gets or sets the depth.
    /// </summary>
    /// <value>The depth.</value>
    public int Depth
    {
      get
      {
        return m_depth;
      }
      set
      {
        m_depth = value;
      }
    }
    /// <summary>
    /// Gets a value indicating whether this instance is leaf.
    /// </summary>
    /// <value><c>true</c> if this instance is leaf; otherwise, <c>false</c>.</value>
    public virtual bool IsLeaf
    {
      get
      {
        return false;
      }
    }

    public virtual bool HasValidNode(string name)
    {
      return false;
    }

    /// <summary>
    /// Gets a value indicating whether this instance has changed.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has changed; otherwise, <c>false</c>.
    /// </value>
    public virtual bool HasChanged
    {
      get
      {
        return false;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="CompositeBase"/> is dirty.
    /// </summary>
    /// <value>
    ///   <c>true</c> if dirty; otherwise, <c>false</c>.
    /// </value>
    public bool Dirty { get; protected set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
    virtual public string Value
    {
      get
      {
        return string.Empty;
      }
      set
      {
        throw new NotImplementedException();
      }
    }
    /// <summary>
    /// Gets or sets the parent.
    /// </summary>
    /// <value>The parent.</value>
    public CompositeBase Parent
    {
      get
      {
        return m_parent;
      }
      set
      {
        m_parent = value;
      }
    }

    /// <summary>
    /// Gets the root node.
    /// </summary>
    public CompositeBase Root
    {
      get
      {
        var parent = m_parent;
        while (parent != null)
        {
          if (parent.m_parent == null)
            return parent;
          parent = parent.m_parent;
        }
        return this;
      }
    }
    /// <summary>
    /// Gets the path.
    /// </summary>
    /// <returns></returns>
    public string GetPath()
    {
      return GetPath(string.Empty);
    }

    /// <summary>
    /// Gets the full parent path name.
    /// </summary>
    public string ParentPath()
    {
      return m_parent != null ? string.Format("{0}:{1}", m_parent.ParentPath(), Name) : Name;
    }

    /// <summary>
    /// Parents the sans root i.e. no CALL:XXX.
    /// </summary>
    /// <returns></returns>
    public string ParentPathSansRoot()
    {
      if (m_parent != null && !string.IsNullOrEmpty(m_parent.ParentPathSansRoot()))
        return string.Format("{0}:{1}", m_parent.ParentPathSansRoot(), Name);
      return m_parent == null ? "" : Name;
    }

    /// <summary>
    /// Gets the fully qualified name (sans root)
    /// </summary>
    /// <value>The full name.</value>
    public string FullName
    {
      get
      {
        return m_parent != null ? ParentPathSansRoot() + ":" + Name : Name;
      }
    }

    /// <summary>
    /// Gets the xpath.
    /// </summary>
    /// <param name="path">The (child) path if any.</param>
    /// <returns></returns>
    public string GetPath(string path)
    {
      var results = path.Length > 0 ? string.Format("{0}{1}{2}", Name, separator, path) : Name;
      return m_parent != null ? m_parent.GetPath(results) : results;
    }
    /// <summary>
    /// Rollbacks this instance.
    /// </summary>
    public abstract void Rollback();

    /// <summary>
    /// Commits this instance.
    /// </summary>
    public abstract void Commit();
    /// <summary>
    /// Gets the <see cref="CompositeBase"/> with the specified name.
    /// </summary>
    /// <value></value>
    virtual public CompositeBase this[string name]
    {
      get
      {
        return null;
      }
    }


    /// <summary>
    /// ToXml
    /// </summary>
    /// <returns></returns>
    virtual public string ToXml()
    {
      return string.Empty;
    }
    /// <summary>
    /// SetValue
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public virtual void SetValue(string name,
                                string value)
    { }
    /// <summary>
    /// toString
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      return m_name;
    }
    /// <summary>
    /// Gets the XML parent open tags.
    /// </summary>
    /// <param name="xml">The XML.</param>
    /// <returns></returns>
    virtual protected string GetXmlParentOpenTags(string xml)
    {
      var results = string.Format("<{0}>{1}", m_name, xml);
      if (m_parent != null)
      {
        return m_parent.GetXmlParentOpenTags(results);
      }
      return results;
    }
    /// <summary>
    /// Gets the XML parent close tags.
    /// </summary>
    /// <param name="xml">The XML.</param>
    /// <returns></returns>
    virtual protected string GetXmlParentCloseTags(string xml)
    {
      var results = string.Format("{1}</{0}>", m_name, xml);
      if (m_parent != null)
      {
        return m_parent.GetXmlParentCloseTags(results);
      }
      return results;
    }
    /// <summary>
    /// Gets the XML with parent elements.
    /// </summary>
    /// <param name="xml">The XML.</param>
    /// <returns></returns>
    virtual protected string GetXmlWithParentElements(string xml)
    {
      return string.Format("{0}{1}", GetXmlParentOpenTags(xml), GetXmlParentCloseTags(string.Empty));
    }
    /// <summary>
    /// Gets the XML with parent elements.
    /// </summary>
    /// <returns></returns>
    virtual public string GetXmlWithParentElements()
    {
      if (m_parent != null)
      {
        return m_parent.GetXmlWithParentElements(ToXml());
      }
      return ToXml();
    }
    /// <summary>
    /// Gets the XML tree.
    /// </summary>
    /// <param name="nodeName">Name of the node.</param>
    /// <returns></returns>
    virtual public string GetXmlTree(string nodeName)
    {
      var node = this[nodeName];
      return node != null ? node.GetXmlWithParentElements() : string.Empty;
    }
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or
    /// resetting unmanaged resources.
    /// </summary>
    virtual public void Dispose()
    {
      Dispose(true);
    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources.
    /// </summary>
    /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    virtual protected void Dispose(bool disposing)
    {
      if (!disposing || _disposed) return;
      Parent = null; 
      GC.SuppressFinalize(this);
      _disposed = true;
    }
    /// <summary>
    /// Indents the tabs.
    /// </summary>
    /// <returns></returns>
    protected string IndentTabs()
    {
      return IndentTabs(0);
    }
    /// <summary>
    /// Indents the tabs.
    /// </summary>
    /// <param name="additions">The additions.</param>
    /// <returns></returns>
    protected string IndentTabs(int additions)
    {
      var results = new StringBuilder(m_depth + 2);
      var totalIndents = m_depth + additions;
      for (var i = 0; i < totalIndents; ++i)
      {
        results.Append("\t");
      }
      return results.ToString();
    }

    /// <summary>
    /// Adds an XML attribute to the node during serialization.
    /// </summary>
    protected void AddXmlAttribute(string attributeName, string attributeValue)
    {
      _attributes.Add(attributeName, attributeValue);
    }

    /// <summary>
    /// Gets the XML attributes for serialization.
    /// </summary>
    protected NameValueCollection Attributes { get { return _attributes; } }

    /// <summary>
    /// Camels the name of the case.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    static protected string CamelCaseName(string source)
    {
      var results = string.Empty;

      if (source.Length > 0)
      {
        results = string.Format("{0}{1}", source.Substring(0, 1).ToUpper(), source.Substring(1));
      }
      return results;
    }

    /// <summary>
    /// Decodes formatting applied in generation of tag.
    /// Must mach corresponding methods
    /// in CALLOBJECTLib
    /// </summary>
    protected static string DecodeName(string current)
    {
      var results = current;
      results = results.Replace("_amp", "&");
      results = results.Replace("_lt", "<");
      results = results.Replace("_gt", ">");
      results = results.Replace("_apos", "\'");
      results = results.Replace("_quot", "\"");
      results = results.Replace("_32", " ");
      results = results.Replace("_47", " ");
      results = results.Replace("_45", "-");
      results = results.Replace("_43", "+");
      results = results.Replace("_40", "(");
      results = results.Replace("_41", ")");
      //if (results[0] >= '_' && results[1] <= '_')
      //	results = results.Substring(2);

      return results;
    }
    /// <summary>
    /// Encodes formatting applied in generation of tag.
    /// Must mach corresponding methods
    /// in CALLOBJECTLib
    /// </summary>
    protected static string EncodeName(string current)
    {
      var results = current;
      results = results.Replace("&", "_amp");
      results = results.Replace("<", "_lt");
      results = results.Replace(">", "_gt");
      results = results.Replace("\'", "_apos");
      results = results.Replace("\"", "_quot");
      results = results.Replace(" ", "_32");
      results = results.Replace("/", "_47");
      results = results.Replace("-", "_45");
      results = results.Replace("+", "_43");
      results = results.Replace("(", "_40");
      results = results.Replace(")", "_41");
      // just in case numerics cannot be 1st position
      if (results[0] >= '0' && results[0] <= '9')
        results = "__" + results;

      return results;
    }

    /// <summary>
    /// Serializes the specified reader from Binary (BLOB).
    /// </summary>
    public abstract void Serialize(BinaryReader reader);

    /// <summary>
    /// Serializes the specified reader to Binary (BLOB).
    /// </summary>
    public abstract void Serialize(BinaryWriter writer);

    /// <summary>
    /// return a name value collection of everything.
    /// </summary>
    /// <returns></returns>
    public NameValueCollection ToNameValueCollection()
    {
      var visitor = new NameValueVistor();
      visitor.Visit(this);
      return visitor.Items;
    }

    public Dictionary<string, string> ToNameValueDictionary()
    {
      var visitor = new NodeNameValueVisitor();
      visitor.Visit(this);
      return visitor.Items;
    }

    protected static string DecodeValue(string current)
    {
      var results = current;
      results = results.Replace(Ampersand, "&");
      results = results.Replace(LessThan, "<");
      results = results.Replace(GreaterThan, ">");
      results = results.Replace(SingleQuote, "\'");
      results = results.Replace(DoubleQuote, "\"");
      return results;
    }
    /// <summary>
    /// Encodes the value.
    /// </summary>
    /// <param name="current">The current.</param>
    /// <returns></returns>
    protected static string EncodeValue(string current)
    {
      var results = current;
      if (Regex.IsMatch(current, "[<,>,&,\",']"))
      {
        results = results.Replace("&", Ampersand);
        results = results.Replace("<", LessThan);
        results = results.Replace(">", GreaterThan);
        results = results.Replace("\'", SingleQuote);
        results = results.Replace("\"", DoubleQuote);
      }
      return results;
    }

    /// <summary>
    /// Copies this instance (use this for ICloneable of the superclasses.)
    /// </summary>
    protected abstract CompositeBase Copy();


    #region ICloneable Members

    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// Override Copy to control specialization of the cloning process.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public object Clone()
    {
      return Copy();
    }

    #endregion

    #region IComparable<CompositeBase> Members

    /// <summary>
    /// To sort output
    /// </summary>
    /// <param name="obj">An object to compare with this instance.</param>
    /// <returns>
    /// 	<para>A 32-bit signed integer that indicates the relative order of the comparands.
    /// The return value has these meanings:</para>
    /// 	<list type="table">
    /// 		<listheader>
    /// 			<term>Value </term>
    /// 			<description>Meaning </description>
    /// 		</listheader>
    /// 		<item>
    /// 			<term> Less than zero </term>
    /// 			<description>This
    /// instance is less than <paramref name="obj"/>. </description>
    /// 		</item>
    /// 		<item>
    /// 			<term> Zero </term>
    /// 			<description>This
    /// instance is equal to <paramref name="obj"/>. </description>
    /// 		</item>
    /// 		<item>
    /// 			<term> Greater than zero </term>
    /// 			<description>This
    /// instance is greater than <paramref name="obj"/>. </description>
    /// 		</item>
    /// 	</list>
    /// </returns>
    /// <exception cref="T:System.ArgumentException">
    /// 	<paramref name="obj"/> is not the same type as this instance.</exception>
    public int CompareTo(object obj)
    {
      var source = obj as CompositeBase;
      return source != null ? CompareTo(source) : 1;
    }

    /// <summary>
    /// Compares the current object with another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>
    /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings:
    /// Value
    /// Meaning
    /// Less than zero
    /// This object is less than the <paramref name="other"/> parameter.
    /// Zero
    /// This object is equal to <paramref name="other"/>.
    /// Greater than zero
    /// This object is greater than <paramref name="other"/>.
    /// </returns>
    public int CompareTo(CompositeBase other)
    {
      return Compare(other);
    }

    /// <summary>
    /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
    /// <returns>
    /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
    /// </returns>
    /// <exception cref="T:System.NullReferenceException">
    /// The <paramref name="obj"/> parameter is null.
    /// </exception>
    public override bool Equals(object obj)
    {
      return CompareTo(obj) == 0;
    }

    /// <summary>
    /// Serves as a hash function for a particular type.
    /// </summary>
    /// <returns>
    /// A hash code for the current <see cref="T:System.Object"/>.
    /// </returns>
    public override int GetHashCode()
    {
// ReSharper disable NonReadonlyFieldInGetHashCode
      return m_name.GetHashCode();
// ReSharper restore NonReadonlyFieldInGetHashCode
    }

    /// <summary>
    /// Compares the specified source with itself.
    /// Override this method to implement IComparable
    /// </summary>
    protected virtual int Compare(CompositeBase source)
    {
      if (source == null) return -1;
      return string.Compare(m_name, source.m_name, StringComparison.Ordinal);
    }

    #endregion
  }
}// END CLASS DEFINITION CompositeBase
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CompositeBase.cs $
 * 
 * 23    8/22/12 2:36p Gwynnj
 * added Root to allow getvalue on nested elements i.e. from CALLER->
 * callr.Root.GetValue("ASI:XXX")
 * 
 * 22    5/21/12 1:11p Gwynnj
 * HasValidNode added
 * 
 * 21    3/02/12 10:28a Gwynnj
 * refactored Encode/Decode to base for visibility to siblings
 * 
 * 20    10/20/10 10:27p Gwynnj
 * Added suport for ToNameValueDictionary for use in node copy i.e.
 * Affirmative Entities
 * 
 * 19    6/28/10 3:27p Roberto.agit
 * bug fix for copy claim
 * 
 * 18    2/24/10 6:46p Gwynnj
 * Added TranOutcome and TranOutcomeSupport message objects for
 * communication with legacy message objects used by OutcomeViewer
 * 
 * 17    2/03/10 6:12p Gwynnj
 * Added ConditionalVisitor for extraction of existing call attributes
 * based on a given pattern using regex (non-xml)
 * 
 * 16    11/11/09 3:43p John.gwynn
 * segment compare is deep, composite is just name
 * 
 * 15    10/12/09 10:49a John.gwynn
 * modified the Html output to use css classes
 * 
 * 14    9/30/09 6:36p John.gwynn
 * Implemented IComparable for composites adding a virtual Compare method
 * for specialized equality and sorting .e.g. see the AhsSegment where two
 * segments are deemed equal if their upload keys are equal.
 * 
 * 13    9/29/09 5:12p John.gwynn
 * Added Validation Event support for Composite in general and Segment
 * classes.
 * 
 * 12    9/28/09 1:14p John.gwynn
 * Added support for ICloneable
 * 
 * 11    7/06/09 7:03p John.gwynn
 * Fixed strongly typed constructor for CallflowEvent objects (loading
 * from Xml) and added NamedValueCollection for set difference operations
 * 
 * 10    6/17/09 7:36a John.gwynn
 * serialization
 * 
 * 9     6/08/09 5:11p John.gwynn
 * Added Serialize support from BLOBS 
 * 
 * 8     5/04/09 6:56p John.gwynn
 * Refactored ICall interface
 * 
 * 7     5/04/09 3:55p John.gwynn
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * 6     2/03/09 3:30p John.gwynn
 * Added EncodeName/DecodeName in concert with Call methods to support
 * 
 * 5     3/16/08 3:33p John.gwynn
 * Implemented ISerializable
 * 
 * 4     8/26/07 10:05a John.gwynn
 * added support for GetXmlTree method to extract subtrees in xml
 * 
 * 3     4/20/07 5:17p John.gwynn
 * 
 * 2     4/17/07 3:41p John.gwynn
 * update current version synch to 1.1
 * 
 * 16    3/09/07 6:21p John.gwynn
 * first cut of the DbClassGen for DbBaseClass generation (Class
 * definition)
 * 
 * 15    3/06/07 6:35p John.gwynn
 * composite based Code generation support added 
 * 
 * 14    11/16/06 5:20p John.gwynn
 * Added NDoc comments and formatting
 * 
 * 13    10/27/06 5:08p John.gwynn
 * implemented IDispose
 * 
 * 12    10/09/06 4:54p John.gwynn
 * added CrLf to ToString()
 * 
 * 11    10/04/06 3:11p John.gwynn
 * 
 * 10    9/19/06 6:42p John.gwynn
 * Added HasChanged, Commit and Rollback for edits.
 * 
 * 9     6/03/06 2:37p John.gwynn
 * added header and log/history regions
 * 
 * 8     5/08/06 6:48p John.gwynn
 * Image file mispelling corrected
 * 
 * 7     4/20/06 11:54a John.gwynn
 * CLI Compliance modifications
 * 
 * 6     4/09/06 8:14p John.gwynn
 * FxCop and Resharper reformatting changes
 * 
 * 5     1/24/06 9:44p John.gwynn
 * added AddressExtractor visitor
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
