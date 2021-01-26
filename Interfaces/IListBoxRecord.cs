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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/IListBoxRecord.cs 1     10/30/07 7:12p John.gwynn $ */
#endregion


namespace FnsComposite.Interfaces
{
	/// <summary>
	/// interface for generic listbox code and text
	/// </summary>
	public interface IListBoxRecord
	{
		/// <summary>
		/// Gets or sets the text field.
		/// </summary>
		/// <value>The text field.</value>
		string TextField { get; set;}
		/// <summary>
		/// Gets or sets the value field.
		/// </summary>
		/// <value>The value field.</value>
		string ValueField { get; set;}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/IListBoxRecord.cs $
 * 
 * 1     10/30/07 7:12p John.gwynn
 * Support for new Business Rule evaluator
 */
#endregion