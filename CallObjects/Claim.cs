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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Claim.cs 15    9/13/11 2:12p Sharmad $ */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;

namespace FnsComposite.CallObjects
{
  /// <summary>
  /// Implements CallObjects Claim node
  /// </summary>
  public class Claim : CallObjectBase, IClaim
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Claim"/> class.
    /// </summary>
    public Claim()
      : base("CLAIM")
    { }
    /// <summary>
    /// Initializes a new instance of the <see cref="Claim"/> class.
    /// </summary>
    /// <param name="node">The node.</param>
    public Claim(XmlNode node)
      : base(node)
    { }

    /// <summary>
    /// Gets or sets the claim number.
    /// </summary>
    /// <value>The claim number.</value>
    public string ClaimNumber
    {
      get { return GetValue("CLAIM_NUMBER"); }
      set { SetValue("CLAIM_NUMBER", value); }
    }

    /// <summary>
    /// Gets or sets the loss date.
    /// </summary>
    /// <value>The loss date.</value>
    public string LossDate
    {
      get { return GetValue("LOSS_DATE"); }
      set { SetValue("LOSS_DATE", value); }
    }

    /// <summary>
    /// Gets or sets the loss time.
    /// </summary>
    /// <value>The loss time.</value>
    public string LossTime
    {
      get { return GetValue("LOSS_TIME"); }
      set { SetValue("LOSS_TIME", value); }
    }

    /// <summary>
    /// Gets the policy.
    /// </summary>
    /// <value>The policy.</value>
    public IPolicy Policy
    {
      get
      {
        var node = GetObject<Policy>("POLICY") as Policy;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: Policy");
        }
        return node;
      }
    }

    /// <summary>
    /// Gets the insured.
    /// </summary>
    /// <value>The insured.</value>
    public IInsured Insured
    {
      get
      {
        var node = GetObject<Insured>("INSURED") as Insured;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: Insured");
        }
        return node;
      }
    }

    /// <summary>
    /// Gets the account.
    /// </summary>
    /// <value>
    /// The account.
    /// </value>
    /// <exception cref="System.ApplicationException">CallObject error retrieving type: Account</exception>
    public IAccount Account
    {
      get
      {
        var node = GetObject<Account>("ACCOUNT") as Account;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: Account");
        }
        return node;
      }
    }

    /// <summary>
    /// Gets the risk location.
    /// </summary>
    /// <value>
    /// The risk location.
    /// </value>
    /// <exception cref="System.ApplicationException">CallObject error retrieving type: Risk Location</exception>
    public IRiskLocation RiskLocation
    {
      get
      {
        var node = GetObject<RiskLocation>("RISK_LOCATION") as IRiskLocation;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: Risk Location");
        }
        return node;
      }
    }

    /// <summary>
    /// Gets the loss location.
    /// </summary>
    /// <value>The loss location.</value>
    public ILossLocation LossLocation
    {
      get
      {
        var node = GetObject<LossLocation>("LOSS_LOCATION") as LossLocation;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: LossLocation");
        }
        return node;
      }
    }

    #region IClaim Members

    /// <summary>
    /// Gets the branch.
    /// </summary>
    /// <value>The branch.</value>
    public IBranch Branch
    {
      get
      {
        var node = GetObject<Branch>("BRANCH") as Branch;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: Branch");
        }
        return node;
      }
    }

    /// <summary>
    /// Gets the estar.
    /// </summary>
    /// <value>The estar.</value>
    public IEstar Estar
    {
      get
      {
        var node = GetObject<Estar>("ESTAR") as Estar;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: Estar");
        }
        return node;
      }
    }

    /// <summary>
    /// Gets the staff.
    /// </summary>
    /// <value>The staff.</value>
    public IStaff Staff
    {
      get
      {
        var node = GetObject<Staff>("STAFF") as Staff;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: Staff");
        }
        return node;
      }
    }

    /// <summary>
    /// Gets the appraiser.
    /// </summary>
    /// <value>The appraiser.</value>
    public IIndependentAppraiser Appraiser
    {
      get
      {
        var node = GetObject<IndependentAppraiser>("INDEPENDENT_APPRAISER") as IndependentAppraiser;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: IndependentAppraiser");
        }
        return node;
      }
    }

    public IRental Rental
    {
      get
      {
        var node = GetObject<Rental>("RENTAL") as Rental;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: Rental");
        }
        return node;
      }
    }

    #endregion
    /// <summary>
    /// Gets the other vehicles.
    /// </summary>
    /// <value>The other vehicles.</value>
    [ComVisible(false)]
    public List<IVehicle> OtherVehicles
    {
      get
      {
        return Enumerable.ToList(GetEnumerator<Vehicle>().Cast<Vehicle>().Cast<IVehicle>());
      }
    }

    /// <summary>
    /// Gets the vendor referrals.
    /// </summary>
    /// <value>The vendor referrals.</value>
    [ComVisible(false)]
    public List<IVendorReferral> VendorReferrals
    {
      get
      {
        return Enumerable.ToList(GetEnumerator<VendorReferral>().Cast<VendorReferral>().Cast<IVendorReferral>());
      }
    }

    [ComVisible(false)]
    public List<IAdjuster> Adjuster
    {
      get
      {
        return Enumerable.ToList(GetEnumerator<Adjuster>().Cast<Adjuster>().Cast<IAdjuster>());
      }
    }
    /// <summary>
    /// Creates the vendor referral.
    /// </summary>
    /// <param name="vendorName">Name of the vendor.</param>
    /// <returns></returns>
    public IVendorReferral CreateVendorReferral(string vendorName)
    {
      var subscript = string.Format("[{0}]", GeVendorReferralCount());
      var vendor = new VendorReferral(subscript) { VendorName = vendorName };
      Add(vendor);
      return vendor;
    }

    /// <summary>
    /// Gets the employee.
    /// </summary>
    /// <value>
    /// The employee.
    /// </value>
    /// <exception cref="ApplicationException">CallObject error retrieving type: Branch</exception>
    public IEmployee Employee
    {
      get
      {
        var node = GetObject<Employee>("EMPLOYEE") as Employee;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: Branch");
        }
        return node;
      }
    }

    /// <summary>
    /// Creates the web navigation record.
    /// </summary>
    /// <param name="pageName">Name of the page.</param>
    /// <param name="callId">The call id.</param>
    public string CreateWebNavigationRecord(string pageName, string callId)
    {
      var subscript = string.Format("[{0}]", GetWebNavigationCount());
      var nav = new WebNavigation(subscript)
      {
        CallId = callId,
        PageName = pageName,
        TimeStampBegin = DateTime.Now.ToString("s")
      };
      Add(nav);
      return subscript;
    }

    public void UpdateWebNavigationRecord(string pageName, string callId, string subscript)
    {

      var nav = new WebNavigation(subscript)
      {
        CallId = callId,
        PageName = pageName,
        TimeStamp = DateTime.Now.ToString("s")
      };
      Add(nav);

    }
    /// <summary>
    /// Gets the web navigation count.
    /// </summary>
    /// <returns></returns>
    public int GetWebNavigationCount()
    {
      return GetEnumerator<WebNavigation>().Cast<object>().Count();
    }
    /// <summary>
    /// Ges the vendor referral count.
    /// </summary>
    /// <returns></returns>
    public int GeVendorReferralCount()
    {
      return GetEnumerator<VendorReferral>().Cast<object>().Count();
    }
  }
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Claim.cs $
 * 
 * 15    9/13/11 2:12p Sharmad
 * dsha-0025
 * 
 * 14    6/23/11 3:36p Sharmad
 * claim handler project
 * 
 * 13    2/23/11 10:24a Sharmad
 * dms: rental node
 * 
 * 12    5/04/09 3:55p John.gwynn
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * 11    11/05/08 6:39p John.gwynn
 * Updated STAFF to remove lowercase reference in Claim class.
 * 
 * 10    5/03/08 7:56p John.gwynn
 * added Estar, IndependentAppraiser and Staf for phase III
 * 
 * 9     2/28/08 7:47p John.gwynn
 * Added ASI and Carrier support
 * 
 * 8     2/18/08 8:31p John.gwynn
 * Moved Witness to CallObjects, Added ThirdParty to Insured and fixed
 * Passenger missing constructor
 * 
 * 7     2/15/08 3:31p John.gwynn
 * added VendorReferral class (eSurance ie. ESTAR) 
 * 
 * 6     2/12/08 4:45p John.gwynn
 * added WebNavigation (support for eSurance) 
 * 
 * 5     1/16/08 6:39p John.gwynn
 * added CallObjectBase to override SetValue
 * 
 * 4     10/30/07 7:12p John.gwynn
 * Support for new Business Rule evaluator
 * 
 * 3     10/23/07 11:36a John.gwynn
 * Implemented Claim.OtherVehicles
 * 
 * 2     10/22/07 6:08p John.gwynn
 * 
 * 1     10/21/07 3:33p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion