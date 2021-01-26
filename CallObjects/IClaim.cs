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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IClaim.cs 9     9/13/11 2:12p Sharmad $ */
#endregion

using System.Collections.Generic;
using System.Runtime.InteropServices;
using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject Claim interface
	/// </summary>
	public interface IClaim : IComposite
	{
		/// <summary>
		/// Gets or sets the claim number.
		/// </summary>
		/// <value>The claim number.</value>
		string ClaimNumber { get; set; }
		/// <summary>
		/// Gets or sets the loss date.
		/// </summary>
		/// <value>The loss date.</value>
		string LossDate { get; set; }
		/// <summary>
		/// Gets or sets the loss time.
		/// </summary>
		/// <value>The loss time.</value>
		string LossTime { get; set; }
		/// <summary>
		/// Gets the policy.
		/// </summary>
		/// <value>The policy.</value>
		IPolicy Policy { get; }
    /// <summary>
    /// Gets the account.
    /// </summary>
    /// <value>
    /// The account.
    /// </value>
    IAccount Account { get; }
    /// <summary>
		/// Gets the insured.
		/// </summary>
		/// <value>The insured.</value>
    IInsured Insured { get; }
    /// <summary>
    /// Gets the risk location.
    /// </summary>
    /// <value>
    /// The risk location.
    /// </value>
    IRiskLocation RiskLocation { get; }
		/// <summary>
		/// Gets the loss location.
		/// </summary>
		/// <value>The loss location.</value>
		ILossLocation LossLocation { get; }
		/// <summary>
		/// Gets the branch.
		/// </summary>
		/// <value>The branch.</value>
		IBranch Branch { get; }
		/// <summary>
		/// Gets the estar.
		/// </summary>
		/// <value>The estar.</value>
		IEstar Estar { get; }
		/// <summary>
		/// Gets the staff.
		/// </summary>
		/// <value>The staff.</value>
		IStaff Staff { get; }
		/// <summary>
		/// Gets the appraiser.
		/// </summary>
		/// <value>The appraiser.</value>
		IIndependentAppraiser Appraiser { get; }
        /// <summary>
        /// Gets the Rental.
        /// </summary>
        /// <value>The Rental.</value>
        IRental Rental { get; }


        [ComVisible(false)]
        List<IAdjuster> Adjuster { get; }
		/// <summary>
		/// Gets the other vehicles.
		/// </summary>
		/// <value>The other vehicles.</value>
		[ComVisible(false)]
		List<IVehicle> OtherVehicles { get; }
		/// <summary>
		/// Gets the vendor referrals.
		/// </summary>
		/// <value>The vendor referrals.</value>
		[ComVisible(false)]
		List<IVendorReferral> VendorReferrals { get; }
		/// <summary>
		/// Creates the vendor referral.
		/// </summary>
		/// <param name="vendorName">Name of the vendor.</param>
		/// <returns></returns>
		IVendorReferral CreateVendorReferral(string vendorName);

    /// <summary>
    /// Gets the employee.
    /// </summary>
    /// <value>
    /// The employee.
    /// </value>
    IEmployee Employee { get; }

		/// <summary>
		/// Creates the web navigation record.
		/// </summary>
		/// <param name="pageName">Name of the page.</param>
		/// <param name="callId">The call id.</param>
		string CreateWebNavigationRecord(string pageName, string callId);
        void UpdateWebNavigationRecord(string pageName, string callId, string subscript);
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IClaim.cs $
 * 
 * 9     9/13/11 2:12p Sharmad
 * dsha-0025
 * 
 * 8     6/23/11 3:37p Sharmad
 * clam handler display project
 * 
 * 7     2/23/11 10:24a Sharmad
 * dms: rental node
 * 
 * 6     5/03/08 7:56p John.gwynn
 * added Estar, IndependentAppraiser and Staf for phase III
 * 
 * 5     2/18/08 8:31p John.gwynn
 * Moved Witness to CallObjects, Added ThirdParty to Insured and fixed
 * Passenger missing constructor
 * 
 * 4     2/15/08 3:31p John.gwynn
 * added VendorReferral class (eSurance ie. ESTAR) 
 * 
 * 3     2/12/08 4:45p John.gwynn
 * added WebNavigation (support for eSurance) 
 * 
 * 2     10/22/07 6:08p John.gwynn
 * 
 * 1     10/21/07 3:39p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion
