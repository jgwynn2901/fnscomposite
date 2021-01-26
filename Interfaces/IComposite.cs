#region Header
/**************************************************************************
* First Notice Systems
* 529 Main Street
* Boston, MA 02129
* (617) 886 2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 2007 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/IComposite.cs 10    4/15/10 7:07a Gwynnj $ */
#endregion

using System.Xml;

namespace FnsComposite.Interfaces
{
  public interface ICompositeBase
  {
    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns></returns>
    string GetValue(string name);

    /// <summary>
    /// Sets the value.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    void SetValue(string name, string value);
  }

  /// <summary>
	/// 
	/// </summary>
  public interface IComposite : ICompositeBase
	{
		/// <summary>
		/// Removes the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		bool Remove(string name);

		/// <summary>
		/// serialize to XML.
		/// </summary>
		/// <returns></returns>
		string ToXml();

		/// <summary>
		/// Reloads from XML.
		/// </summary>
		/// <param name="node">The node.</param>
// ReSharper disable InconsistentNaming
		void ReloadFromXML(XmlNode node);
// ReSharper restore InconsistentNaming

		/// <summary>
		/// serialize to HTML.
		/// </summary>
		/// <returns></returns>
		string ToHtml();

		/// <summary>
		/// serialize to json.
		/// </summary>
		/// <returns>Json</returns>
		string ToJson();

		/// <summary>
		/// serialize from json.
		/// </summary>
		/// <param name="json">The json.</param>
		void LoadFromJson(string json);

		/// <summary>
		/// Clears all children.
		/// </summary>
		void ClearAll();

		/// <summary>
		/// Accepts the specified visitor.
		/// </summary>
		/// <param name="visitor">The visitor.</param>
		void Accept(IVisitor visitor);

		/// <summary>
		/// Gets the XML tree.
		/// </summary>
		/// <param name="nodeName">Name of the node.</param>
		/// <returns></returns>
		string GetXmlTree(string nodeName);
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/IComposite.cs $
 * 
 * 10    4/15/10 7:07a Gwynnj
 * Minor edits
 * 
 * 9     5/19/09 1:58p John.gwynn
 * added JSON serialiation
 * 
 * 8     5/05/09 1:26p John.gwynn
 * 
 * 7     5/04/09 6:56p John.gwynn
 * Refactored ICall interface
 * 
 * 6     3/20/09 5:50p John.gwynn
 * added JSON serialize OUT - in not quite ready
 * 
 * 5     6/12/08 8:50p John.gwynn
 * added ClearAll to reset nodes
 * 
 * 4     5/23/08 7:53p John.gwynn
 * Added Remove to the IComposite interface
 * 
 * 3     11/07/07 12:13p John.gwynn
 * Added ToHtml (with raw styles for now)
 * 
 * 2     10/23/07 11:36a John.gwynn
 * Implemented Claim.OtherVehicles
 */
#endregion