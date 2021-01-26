#region Header
/**************************************************************************
* First Notice Systems
* 95 Wells Avenue
* Newton, MA 02459
* (617) 886-2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 2007 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IProperty.cs 1     11/28/07 11:22a John.gwynn $ */
#endregion

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject interface for [Property] 
	/// </summary>
	public interface IProperty
	{
		/// <summary>
		/// Gets the owner.
		/// </summary>
		/// <value>The owner.</value>
		IOwner Owner { get;}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IProperty.cs $
 * 
 * 1     11/28/07 11:22a John.gwynn
 * Added CallObject.Property and interface
 */
#endregion