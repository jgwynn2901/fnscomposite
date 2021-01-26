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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ICaller.cs 3     5/02/08 11:20a John.gwynn $ */
#endregion

using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject interface for Caller
	/// </summary>
	public interface ICaller : IComposite, IPerson
	{
		/// <summary>
		/// Gets or sets the type of the caller.
		/// </summary>
		/// <value>The type of the caller.</value>
		string CallerType { get; set; }

		/// <summary>
		/// Copies from.
		/// </summary>
		/// <param name="insured">The insured.</param>
		void CopyFrom(IInsured insured);
	}
		
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ICaller.cs $
 * 
 * 3     5/02/08 11:20a John.gwynn
 * added CopyFrom(IInsured) for Caller and Contact 
 * 
 * 2     5/01/08 4:13p John.gwynn
 * refactored IPerson interface and added support for Contact
 * 
 * 1     10/21/07 3:38p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion