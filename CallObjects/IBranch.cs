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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IBranch.cs 1     10/21/07 3:36p John.gwynn $ */
#endregion

using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject interface for Branch
	/// </summary>
	public interface IBranch : IComposite
	{
		/// <summary>
		/// Gets or sets the name of the branch office.
		/// </summary>
		/// <value>The name of the branch office.</value>
    string BranchOfficeName { get; set; }
    string BranchOfficeNumber { get; set; }
    string BranchOfficeType { get; set; }
    string ContactNameFirst { get; set; }
    string ContactNameLast { get; set; }
    string EmailAddress { get; set; }
    string Fein { get; set; }
    string OfficeHours { get; set; }
    string ContactTitle { get; set; }
    /// <summary>
		/// Gets or sets the branch number.
		/// </summary>
		/// <value>The branch number.</value>
		string BranchNumber { get; set; }
		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		IAddress Address { get; }
		/// <summary>
		/// Gets or sets the phone home.
		/// </summary>
		/// <value>The phone home.</value>
		string PhoneFax { get; set; }
		/// <summary>
		/// Gets or sets the phone work.
		/// </summary>
		/// <value>The phone work.</value>
		string PhoneWork { get; set; }
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IBranch.cs $
 * 
 * 1     10/21/07 3:36p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion