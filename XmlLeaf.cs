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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/XmlLeaf.cs 5     9/28/09 1:14p John.gwynn $ */
#endregion

using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace FnsComposite
{
  /// <summary>
  /// XmlLeaf encapsulates leaf nodes comprised of raw xlm markup
  /// </summary>
  [ClassInterface(ClassInterfaceType.None), ComVisible(false)]
  public class XmlLeaf : CompositeLeaf
  {
    private const string AmpersandReplace = "$_amp;";
    private const string GreaterThanReplace = "$_gt;";
    private const string LessThanReplace = "$_lt;";
    private const string SingleQuoteReplace = "$_apos;";
    private const string DoubleQuoteReplace = "$_quot;";

    /// <summary>
    /// Initializes a new instance of the <see cref="XmlLeaf"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    public XmlLeaf(string name, string value)
      : base(name, string.Empty, "xml")
    {
      // here we intercept and mark any already embedded special chars
      var results = EncodeExtendXmlValue(value);
      NodeValue = EncodeXmlValue(results);
    }
    /// <summary>
    /// Value
    /// </summary>
    /// <value>The value.</value>
    public override string Value
    {
      get
      {
        var results = DecodeXmlValue(NodeValue);
        return DecodeExtendXmlValue(results);
      }
      set
      {
        var results = EncodeExtendXmlValue(value);
        NodeValue = EncodeXmlValue(results);
      }
    }
    /// <summary>
    /// Encodes the XML value special chars.
    /// </summary>
    /// <param name="current">The current.</param>
    /// <returns></returns>
    private static string EncodeExtendXmlValue(string current)
    {
      var results = current;

      var encoding = new Regex(@"\$([_])");

      if (encoding.IsMatch(results)) return results;
      // BUGBUG: Im sure there's an elegant way to do this....
      results = results.Replace(Ampersand, AmpersandReplace);
      results = results.Replace(LessThan, LessThanReplace);
      results = results.Replace(GreaterThan, GreaterThanReplace);
      results = results.Replace(SingleQuote, SingleQuoteReplace);
      results = results.Replace(DoubleQuote, DoubleQuoteReplace);

      return results;
    }
    /// <summary>
    /// Decodes the XML value.
    /// </summary>
    /// <param name="current">The current.</param>
    /// <returns></returns>
    private static string DecodeExtendXmlValue(string current)
    {
      var results = current;
      var encoding = new Regex(@"\$([_])");

      if (!encoding.IsMatch(results)) return results;
      // BUGBUG: Im sure there's an elegant way to do this....
      results = results.Replace(AmpersandReplace, Ampersand);
      results = results.Replace(LessThanReplace, LessThan);
      results = results.Replace(GreaterThanReplace, GreaterThan);
      results = results.Replace(SingleQuoteReplace, SingleQuote);
      results = results.Replace(DoubleQuote, DoubleQuote);
      return results;
    }
  }
}
#region History
/*
 * $History: XmlLeaf.cs $
 * 
 * *****************  Version 5  *****************
 * User: John.gwynn   Date: 9/28/09    Time: 1:14p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite
 * Added support for ICloneable
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 5/29/07    Time: 7:05p
 * Updated in $/SourceCode/Components/VS.NET2005/FnsComposite
 * new MessageObject set of classes for OPM with some refactoring and
 * gebneral enhancements
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 4/20/07    Time: 5:17p
 * Updated in $/SourceCode/Components/VS.NET2005/FnsComposite
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 4/17/07    Time: 3:41p
 * Updated in $/SourceCode/Components/VS.NET2005/FnsComposite
 * update current version synch to 1.1
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 12/05/06   Time: 1:43p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * fixed the Xml type encoding/decoding
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 12/04/06   Time: 2:58p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * fixed a bug with the apostrophe constant
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 11/16/06   Time: 5:20p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * Added NDoc comments and formatting
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 11/14/06   Time: 10:33a
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * Subclass the CompositeLeaf for type == "xml" and added a layer of
 * encoding/decoding to preserve content with encoding prior to our
 * encoding so that the prior content will be preserved on output
 * correctly.
 */
#endregion
