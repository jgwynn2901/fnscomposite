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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IVendorReferral.cs 3     2/23/11 10:23a Sharmad $ */
#endregion

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// interface for Vendor referral objects (part of IClaim)
	/// </summary>
	public interface IVendorReferral
	{
		/// <summary>
		/// Gets or sets the name of the vendor.
		/// </summary>
		/// <value>The name of the vendor.</value>
		string VendorName { get; set; }
		/// <summary>
		/// Gets or sets the vendor number.
		/// </summary>
		/// <value>The vendor number.</value>
		string VendorNumber { get; set; }
		/// <summary>
		/// Gets or sets the type of the vendor.
		/// </summary>
		/// <value>The type of the vendor.</value>
		string VendorType { get; set; }
		/// <summary>
		/// Gets or sets the day phone.
		/// </summary>
		/// <value>The day phone.</value>
		string DayPhone { get; set; }
		/// <summary>
		/// Gets a value indicating whether this instance is eligible.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is eligible; otherwise, <c>false</c>.
		/// </value>
		bool IsEligible { get;}
        /// <summary>
        /// Gets a value indicating service type.
        /// </summary>
        /// <value>
        string ServiceType { get; }
		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		IAddress Address { get; }
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IVendorReferral.cs $
 * 
 * 3     2/23/11 10:23a Sharmad
 * added servicetype
 * 
 * 2     11/18/08 10:40a John.gwynn
 * Added IsEligible flag for VendorReferral eligibility logic
 * 
 * 1     2/15/08 3:31p John.gwynn
 * added VendorReferral class (eSurance ie. ESTAR) 
 */
#endregion
