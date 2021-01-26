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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IContact.cs 2     5/02/08 11:20a John.gwynn $ */
#endregion
using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject interface for CONTACT
	/// </summary>
	public interface IContact : IComposite, IPerson
	{
		/// <summary>
		/// Copies from.
		/// </summary>
		/// <param name="insured">The insured.</param>
		void CopyFrom(IInsured insured);
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IContact.cs $
 * 
 * 2     5/02/08 11:20a John.gwynn
 * added CopyFrom(IInsured) for Caller and Contact 
 * 
 * 1     5/01/08 4:13p John.gwynn
 * refactored IPerson interface and added support for Contact
 */
#endregion