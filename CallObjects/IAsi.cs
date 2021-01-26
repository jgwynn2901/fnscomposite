#region Header
/**************************************************************************
* First Notice Systems
* 95 Wells Avenue
* Newton, MA 02459
* (617) 886-2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 2008 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IAsi.cs 1     2/28/08 7:47p John.gwynn $ */
#endregion

using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject interface for ASI collection
	/// we may not truly need this yet but it is here to provide
	/// a complete object model for the ASI elements and future 
	/// behaviour modifications enhancements 
	/// </summary>
	public interface IAsi : IComposite
	{
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IAsi.cs $
 * 
 * 1     2/28/08 7:47p John.gwynn
 * Added ASI and Carrier support
 */
#endregion