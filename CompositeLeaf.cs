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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CompositeLeaf.cs 26    5/17/12 12:21p Gwynnj $ */
#endregion

using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace FnsComposite
{
  /// <summary>
  /// Leaf Node for Composite graph (Leaf node has a Value)
  /// </summary>
  [ClassInterface(ClassInterfaceType.None), ComVisible(false), Serializable]
  public class CompositeLeaf	: CompositeBase
  {
    private string _lastValue;
    /// <summary>
    /// holds the leaf value 
    /// </summary>	
// ReSharper disable InconsistentNaming
        [CLSCompliant(false)]
    protected string _nodeValue;
// ReSharper restore InconsistentNaming
    /// <summary>
    /// this is the node type
    /// </summary>
    private string _nodeType;

        /// <summary>
    /// use this constructor
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    public CompositeLeaf(string name, string value) :this (name, value, "string")
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeLeaf"/> class.
    /// </summary>
    /// <param name="source">The source.</param>
    public CompositeLeaf(CompositeLeaf source) :this (source.Name, source.Value, source._nodeType)
    {
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="CompositeLeaf"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    /// <param name="type">The type.</param>
    public CompositeLeaf(string name, string value, string type) :base (name)
    {
      _nodeType = type;
      _nodeValue = EncodeValue(value);
      _lastValue = string.Empty;
    }
    /// <summary>
    /// default constructor
    /// </summary>
    public CompositeLeaf() : this("CompositeLeaf","")
    {
    }
    /// <summary>
    /// Operator == 
    /// </summary>
    /// <param name="a">leaf A</param>
    /// <param name="b">leaf B.</param>
    /// <returns></returns>
    public static bool operator ==(CompositeLeaf a, CompositeLeaf b)
    {
      if (((object)a) == null && ((object)b) == null) return true;
      if ((((object)a) == null) || (((object)b) == null)) return false;

      return a.CompareTo(b)==0;
    }
    /// <summary>
    /// Operator !=s the specified a.
    /// </summary>
    /// <param name="a">A.</param>
    /// <param name="b">The b.</param>
    /// <returns></returns>
    public static bool operator !=(CompositeLeaf a, CompositeLeaf b)
    {
      return !(a == b);
    }
    /// <summary>
    /// Calls CompareTo on the specified object.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    public override bool Equals(object source)
    {
      return CompareTo(source) == 0;
    }

    /// <summary>
    /// Gets or sets the node value.
    /// </summary>
    protected string NodeValue
    {
      get { return _nodeValue;}
      set { _nodeValue = value; }
    }

    /// <summary>
    /// Gets or sets the type of the node.
    /// </summary>
    protected string NodeType
    {
      get { return _nodeType; }
      set { _nodeType = value; }
    }


    /// <summary>
    /// Serves as a hash function for a particular type, suitable
    /// for use in hashing algorithms and data structures like a hash table.
    /// </summary>
    /// <returns>
    /// A hash code for the current <see cref="T:System.Object"/>.
    /// </returns>
    public override int GetHashCode ()
    {
      return Name.GetHashCode();
    }
    /// <summary>
    /// Value
    /// </summary>
    /// <value>The value.</value>
    public override string Value 
    {
      get 
      {
        return DecodeValue(_nodeValue);
      }
      set
      {
        if(_nodeValue.Length > 0 && !_nodeValue.Equals(value))
        {
          _lastValue = _nodeValue;
        }
        _nodeValue = EncodeValue(value);
      }
    }

    /// <summary>
    /// property ValueType
    /// </summary>
    /// <value>The type of the value.</value>
    public string ValueType 
    {
      get 
      {
        return _nodeType;
      }
      set
      {
        _nodeType = value;
      }
    }
    /// <summary>
    /// IsLeaf node simple test
    /// </summary>
    /// <value><c>true</c> if this instance is leaf; otherwise, <c>false</c>.</value>
    public override bool IsLeaf
    {
      get
      {
        return true;
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
                return _lastValue.Length > 0 && !_nodeValue.Equals(_lastValue);
       }
    }

    /// <summary>
    /// toString
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      var results = new StringBuilder();
      for(int i=0;i< m_depth;++i)
      {
        results.Append("\t");
      }
      results.Append(m_name);
      results.Append("=");
      results.Append(_nodeValue);
      return results.ToString();
    }
    /// <summary>
    /// convert to string with xml tags
    /// </summary>
    /// <returns></returns>
    public override string ToXml()
    {
      var results = new StringBuilder();

      results.Append("<");
      var tagName = EncodeName(m_name);
      
      results.Append(tagName);
      if (_nodeType != "string") // BUGBUG string is default
                results.AppendFormat(" type=\"{0}\"", _nodeType);

            foreach (string key in Attributes.Keys)
                results.AppendFormat(" {0}=\"{1}\"", key, Attributes[key]);

      results.Append(">");
            results.Append(_nodeValue);
      results.Append("</");
      results.Append(tagName);
      results.Append(">");

      return results.ToString();
    }

    /// <summary>
    /// Rollbacks this instance.
    /// </summary>
    public override void Rollback()
    {
      if(_lastValue.Length > 0)
      {
        _nodeValue = _lastValue;
        _lastValue = string.Empty;
      }
    }

    /// <summary>
    /// Commits this instance.
    /// </summary>
    public override void Commit()
    {
      _lastValue = string.Empty;
    }
    /// <summary>
    /// Creates the leaf method.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    /// <param name="type">The type.</param>
    /// <returns></returns>
    static public CompositeLeaf CreateLeafFactoryMethod (string name, string value, string type)
    {
      if(type.Length > 0)
      {
        switch (type)
        {
          case "xml":
            //return new XmlLeaf(name, value);
          case "Property":
            return new Property(name, value, "string");
        }
      }
      return new CompositeLeaf(name, value);
    }
    /// <summary>
    /// Encodes the XML value special chars.
    /// </summary>
    /// <param name="current">The current.</param>
    /// <returns></returns>
    protected static string EncodeXmlValue (string current)
    {
      string results = current;
      
      var encoding = new Regex("[&<>'\"]");
      
      if (encoding.IsMatch(results)) // do we have something to worry about?
      {
        var alreadyEncoded = new Regex("&([a,l,g,p,q,#])"); // we don't want to encode if already done
        if(!alreadyEncoded.IsMatch(current))
        {
          results = EncodeValue(results);	
        }
      }
      return results;
    }
    /// <summary>
    /// Decodes the XML value.
    /// </summary>
    /// <param name="current">The current.</param>
    /// <returns></returns>
    protected static string DecodeXmlValue (string current)
    {
      string results = current;
      var encoding = new Regex("&([a,l,g,p,q,#])");
      
      if (encoding.IsMatch(results))
      {
        results = DecodeValue(results);
      }
      return results;
    }
    /// <summary>
    /// Serialize to HTML.
    /// </summary>
    /// <param name="backgroungToggle">if set to <c>true</c> [backgroung toggle].</param>
    /// <returns></returns>
    internal string ToHtml(ref bool backgroungToggle)
    {
      var results = string.Format("<li{0}><b>{1}</b>={2}</li>",
                backgroungToggle ? " class=\"Alternate\"" : "", m_name, Value);
      backgroungToggle = !backgroungToggle;
      return results;
    }

    /// <summary>
    /// Toes the json.
    /// </summary>
    /// <param name="jsonWriter">The json writer.</param>
    [CLSCompliant(false)]
        public virtual void ToJson(JsonWriter jsonWriter) 
    {
      jsonWriter.WritePropertyName(Name);
      jsonWriter.WriteValue(Value);
    }

    /// <summary>
    /// Serializes the specified reader from Binary (BLOB).
    /// </summary>
    public override void Serialize(System.IO.BinaryReader reader)
    {
      var converterName = new CStringConverter(reader);
      var converterValue = new CStringConverter(reader);

      m_name = converterName.Contents;
      Value = converterValue.Contents;
    }

    /// <summary>
    /// Serializes the specified reader to Binary (BLOB).
    /// </summary>
    /// <param name="writer"></param>
    public override void Serialize(System.IO.BinaryWriter  writer)
    {
      CStringConverter.Write(writer, m_name);
      CStringConverter.Write(writer, Value);
    }

    /// <summary>
    /// Copies this instance.
    /// </summary>
    /// <returns></returns>
    protected override CompositeBase Copy()
    {
      return new CompositeLeaf(this);
    }
  }

    /// <summary>
    /// used to simulate the default value for message objects
    /// </summary>
    internal class DefaultValueLeaf : CompositeLeaf
    {
        internal DefaultValueLeaf(string name, string value) : base(name, value)
        {
            AddXmlAttribute("Default",  "1");
        }
    }
}// END CLASS DEFINITION CompositeLeaf
#region Log
/*
* $Log: /SourceCode/Components/FNS2005/FnsComposite/CompositeLeaf.cs $
 * 
 * 26    5/17/12 12:21p Gwynnj
 * added support fr involved parties array for AAA
 * 
 * 25    3/28/12 8:00a Gwynnj
 * fixed HasChanged for Leaf nodes where they were not reporting real
 * changes.
 * 
 * 24    3/02/12 10:30a Gwynnj
 * _nodeValue is now protected for raw access in Column derived type
 * 
 * 23    3/01/12 2:21p Gwynnj
 * rollback
 * 
 * 22    3/01/12 2:14p Gwynnj
 * escaped the element values in ToXml
 * 
 * 21    11/16/10 11:26a Gwynnj
 * ToHtml added inline style fixes for IE
 * 
 * 20    2/24/10 6:46p Gwynnj
 * Added TranOutcome and TranOutcomeSupport message objects for
 * communication with legacy message objects used by OutcomeViewer
 * 
 * 19    11/11/09 3:43p John.gwynn
 * segment compare is deep, composite is just name
 * 
 * 18    10/12/09 10:49a John.gwynn
 * modified the Html output to use css classes
 * 
 * 17    9/30/09 6:36p John.gwynn
 * Implemented IComparable for composites adding a virtual Compare method
 * for specialized equality and sorting .e.g. see the AhsSegment where two
 * segments are deemed equal if their upload keys are equal.
 * 
 * 16    9/28/09 1:14p John.gwynn
 * Added support for ICloneable
 * 
 * 15    6/17/09 7:36a John.gwynn
 * serialization
 * 
 * 14    6/08/09 5:11p John.gwynn
 * Added Serialize support from BLOBS 
 * 
 * 13    5/19/09 1:57p John.gwynn
 * added JSON serialiation
 * 
 * 12    5/04/09 3:55p John.gwynn
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * 11    3/20/09 5:50p John.gwynn
 * added JSON serialize OUT - in not quite ready
 * 
 * 10    2/03/09 3:30p John.gwynn
 * Added EncodeName/DecodeName in concert with Call methods to support
 * 
 * 9     4/14/08 1:38p John.gwynn
 * upgraded to nunit 2.4.7
 * 
 * 8     4/08/08 3:33p John.gwynn
 * Fix for bug in encode/decode (added encode to the constructor) now all
 * values are encoded and decoded except when ToXml is called...
 * 
 * 7     11/07/07 12:13p John.gwynn
 * Added ToHtml (with raw styles for now)
 * 
 * 6     10/01/07 11:23a John.gwynn
 * added symmetric encode decode and fix to Property
 * 
 * 5     9/27/07 6:49p John.gwynn
 * 
 * 4     9/24/07 5:34p John.gwynn
 * merged with 2003 changes
 * 
 * 3     4/20/07 5:17p John.gwynn
 * 
 * 2     4/17/07 3:41p John.gwynn
 * update current version synch to 1.1
 * 
 * 16    3/06/07 6:35p John.gwynn
 * composite based Code generation support added 
 * 
 * 15    2/23/07 3:02p John.gwynn
 * 
 * 14    2/21/07 11:39a John.gwynn
 * added Operator == and comparison operators as well as Copy
 * constructors...
 * 
 * 13    12/05/06 1:43p John.gwynn
 * fixed the Xml type encoding/decoding
 * 
 * 12    12/04/06 2:58p John.gwynn
 * fixed a bug with the apostrophe constant
 * 
 * 11    11/16/06 5:20p John.gwynn
 * modified EncodeXmlValue to be strict in its encoding for ToXml()
 * 
 * 10    11/14/06 10:35a John.gwynn
 * Modified the type == "xml" state with balanced encoding/decoding 
 * 
 * 9     9/19/06 6:42p John.gwynn
 * Added HasChanged, Commit and Rollback for edits.
 * 
 * 8     4/20/06 11:54a John.gwynn
 * CLI Compliance modifications
 * 
 * 7     4/09/06 8:14p John.gwynn
 * FxCop and Resharper reformatting changes
 * 
 * 6     1/18/06 5:35p John.gwynn
 * Value now converts <> from &lt; etc.
 * 
 * 5     1/18/06 2:45p John.gwynn
 * handle Xml special characters in data
 * 
 * 4     1/17/06 4:09p John.gwynn
 * SetTypedValue support for XML as call values 
 * 
 * 3     12/17/05 12:11a John.gwynn
 * added support for visitor
 * 
 * 2     12/10/05 9:43p John.gwynn
 * added ToString an ToXml and sort
 * 
 * 1     12/09/05 1:48p John.gwynn
*/
#endregion
