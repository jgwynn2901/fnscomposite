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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IDriver.cs 2     5/01/08 4:13p John.gwynn $ */
#endregion


using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject interface for Driver nodes
	/// </summary>
	public interface IDriver : IComposite, IPerson
	{
		/// <summary>
		/// Gets or sets the SSN.
		/// </summary>
		/// <value>The SSN.</value>
		string Ssn { get; set; }
		/// <summary>
		/// Gets or sets the license number.
		/// </summary>
		/// <value>The license number.</value>
		string LicenseNumber { get; set; }
		/// <summary>
		/// Gets or sets the state of the license.
		/// </summary>
		/// <value>The state of the license.</value>
		string LicenseState { get; set; }
		/// <summary>
		/// Gets or sets the injury flag.
		/// </summary>
		/// <value>The injury flag.</value>
		string InjuryFlag { get; set; }
		/// <summary>
		/// Gets or sets the gender.
		/// </summary>
		/// <value>The gender.</value>
		string Gender { get; set; }
		/// <summary>
		/// Gets or sets the email address.
		/// </summary>
		/// <value>The email address.</value>
		string EmailAddress { get; set; }
		/// <summary>
		/// Gets or sets the driver listed.
		/// </summary>
		/// <value>The driver listed.</value>
		string DriverListed { get; set; }
		/// <summary>
		/// Gets or sets the birth date.
		/// </summary>
		/// <value>The birth date.</value>
		string BirthDate { get; set; }
		/// <summary>
		/// Gets or sets the attorney insurance flag.
		/// </summary>
		/// <value>The attorney insurance flag.</value>
		string AttorneyInsuranceFlag { get; set; }

    ICitation Citation { get; }
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IDriver.cs $
 * 
 * 2     5/01/08 4:13p John.gwynn
 * refactored IPerson interface and added support for Contact
 * 
 * 1     10/21/07 3:40p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion