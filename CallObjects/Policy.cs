#region Header
/**************************************************************************
* First Notice Systems
* 529 Main Street
* Boston, MA 02129
* (617) 886 2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 2006 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Policy.cs 5     4/24/08 5:03p Jenny.cheung $ */
#endregion

using System;
using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Implements the Policy interface for CallObjects
	/// and provides access to Policy aggregates 
	/// </summary>
	public class Policy : CallObjectBase, IPolicy
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Policy"/> class.
		/// </summary>
		public Policy() :base("POLICY")
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Policy"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Policy(XmlNode node): base(node)
		{ }
		/// <summary>
		/// Gets or sets the policy number.
		/// </summary>
		/// <value>The policy number.</value>
		public string PolicyNumber
		{
			get
			{
				return GetValue("POLICY_NUMBER");
			}
			set
			{
				SetValue("POLICY_NUMBER", value);
			}
		}
		/// <summary>
		/// Gets or sets the type of the policy.
		/// </summary>
		/// <value>The type of the policy.</value>
		public string PolicyType
		{
			get
			{
				return GetValue("POLICY_TYPE");
			}
			set
			{
				SetValue("POLICY_TYPE", value);
			}
		}
		/// <summary>
		/// Gets or sets the effective date.
		/// </summary>
		/// <value>The effective date.</value>
		public string EffectiveDate
		{
			get
			{
				return GetValue("EFFECTIVE_DATE");
			}
			set
			{
				SetValue("EFFECTIVE_DATE", value);
			}
		}
		/// <summary>
		/// Gets or sets the expiration date.
		/// </summary>
		/// <value>The expiration date.</value>
		public string ExpirationDate
		{
			get
			{
				return GetValue("EXPIRATION_DATE");
			}
			set
			{
                SetValue("EXPIRATION_DATE", value);
			}
		}

		#region IPolicy Members

		/// <summary>
		/// Gets the carrier.
		/// </summary>
		/// <value>The carrier.</value>
		public ICarrier Carrier
		{
			get
			{
				Carrier node = GetObject<Carrier>("CARRIER") as Carrier;
				if (node == null)
				{
					throw new ApplicationException("CallObject error retrieving type: Claim");
				}
				return node;
			}
		}
		#endregion
	}
}
#region History
/*
 * $History: Policy.cs $
 * 
 * *****************  Version 5  *****************
 * User: Jenny.cheung Date: 4/24/08    Time: 5:03p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/CallObjects
 * fixed a minor bug for Expiration_Date string
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 2/28/08    Time: 7:47p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/CallObjects
 * Added ASI and Carrier support
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 1/16/08    Time: 6:39p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/CallObjects
 * added CallObjectBase to override SetValue
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 10/21/07   Time: 3:53p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/CallObjects
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 10/21/07   Time: 8:17a
 * Created in $/SourceCode/Components/FNS2005/FnsComposite/CallObjects
 * Modified segment namespace started work on CallObject types
 */
#endregion