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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/VendorReferral.cs 3     2/23/11 10:22a Sharmad $ */
#endregion

using System;
using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class VendorReferral : CallObjectBase, IVendorReferral
	{
		private const string _nodeTypeName = "VENDOR_REFERRAL";

		/// <summary>
		/// Initializes a new instance of the <see cref="VendorReferral"/> class.
		/// </summary>
		public VendorReferral()
			: base(_nodeTypeName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="VendorReferral"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public VendorReferral(XmlNode node) : base (node)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="VendorReferral"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="indexedName">Name of the indexed.</param>
			public VendorReferral(XmlNode node, string indexedName) : base (node, indexedName)
		{}
			/// <summary>
			/// Initializes a new instance of the <see cref="VendorReferral"/> class.
			/// </summary>
			/// <param name="indexName">Name of the index.</param>
		public VendorReferral(string indexName)
			: base(_nodeTypeName + indexName)
		{}

		/// <summary>
		/// Gets or sets the name of the vendor.
		/// </summary>
		/// <value>The name of the vendor.</value>
		public string VendorName
		{
			get { return GetValue("NAME"); }
			set { SetValue("NAME", value); }
		}

		/// <summary>
		/// Gets or sets the vendor number.
		/// </summary>
		/// <value>The vendor number.</value>
		public string VendorNumber
		{
			get { return GetValue("VENDOR_ID"); }
			set { SetValue("VENDOR_ID", value); }
		}

		/// <summary>
		/// Gets or sets the type of the vendor.
		/// </summary>
		/// <value>The type of the vendor.</value>
		public string VendorType
		{
			get { return GetValue("VENDOR_TYPE"); }
			set { SetValue("VENDOR_TYPE", value); }
		}

		/// <summary>
		/// Gets or sets the day phone.
		/// </summary>
		/// <value>The day phone.</value>
		public string DayPhone
		{
			get { return GetValue("PHONE_DAY"); }
			set { SetValue("PHONE_DAY", value); }
		}

		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		public new IAddress Address
		{
			get { return base.Address; }
		}

		#region IVendorReferral Members


		/// <summary>
		/// Gets a value indicating whether this instance is eligible.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is eligible; otherwise, <c>false</c>.
		/// </value>
		public bool IsEligible
		{
			get { return GetValue("VENDOR_ELIGIBLE").Equals("Y", StringComparison.InvariantCultureIgnoreCase); }
		}

        public string  ServiceType
        {
            get { return GetValue("SERVICE_TYPE"); }
        }

		#endregion
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/VendorReferral.cs $
 * 
 * 3     2/23/11 10:22a Sharmad
 * Added servicetype
 * 
 * 2     11/18/08 10:40a John.gwynn
 * Added IsEligible flag for VendorReferral eligibility logic
 * 
 * 1     2/15/08 3:31p John.gwynn
 * added VendorReferral class (eSurance ie. ESTAR) 
 */
#endregion
