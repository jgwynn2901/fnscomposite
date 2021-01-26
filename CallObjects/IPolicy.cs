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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IPolicy.cs 3     2/28/08 7:47p John.gwynn $ */
#endregion

using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Interface to Policy data for CallObjects
	/// </summary>
	public interface IPolicy : IComposite
	{
		/// <summary>
		/// Gets or sets the policy number.
		/// </summary>
		/// <value>The policy number.</value>
		string PolicyNumber { get; set; }

		/// <summary>
		/// Gets or sets the type of the policy.
		/// </summary>
		/// <value>The type of the policy.</value>
		string PolicyType { get; set; }

		/// <summary>
		/// Gets or sets the effective date.
		/// </summary>
		/// <value>The effective date.</value>
		string EffectiveDate { get; set; }

		/// <summary>
		/// Gets or sets the expiration date.
		/// </summary>
		/// <value>The expiration date.</value>
		string ExpirationDate { get; set; }
		/// <summary>
		/// Gets the carrier.
		/// </summary>
		/// <value>The carrier.</value>
		ICarrier Carrier { get;}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IPolicy.cs $
 * 
 * 3     2/28/08 7:47p John.gwynn
 * Added ASI and Carrier support
 * 
 * 2     10/21/07 3:53p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion