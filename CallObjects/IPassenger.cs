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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IPassenger.cs 1     10/21/07 3:45p John.gwynn $ */
#endregion

using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject interface for [Vehicle] passenger
	/// </summary>
	public interface IPassenger :IComposite
	{
		/// <summary>
		/// Gets or sets the name first.
		/// </summary>
		/// <value>The name first.</value>
		string NameFirst { get; set; }
		/// <summary>
		/// Gets or sets the name last.
		/// </summary>
		/// <value>The name last.</value>
		string NameLast { get; set; }
		/// <summary>
		/// Gets or sets the name mid.
		/// </summary>
		/// <value>The name mid.</value>
		string NameMid { get; set; }
		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		IAddress Address { get; }
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
		/// Gets or sets the owner flag.
		/// </summary>
		/// <value>The owner flag.</value>
		string OwnerFlag { get; set; }
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
		/// <summary>
		/// Gets or sets the phone home.
		/// </summary>
		/// <value>The phone home.</value>
		string PhoneHome { get; set; }
		/// <summary>
		/// Gets or sets the phone work.
		/// </summary>
		/// <value>The phone work.</value>
		string PhoneWork { get; set; }
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IPassenger.cs $
 * 
 * 1     10/21/07 3:45p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion