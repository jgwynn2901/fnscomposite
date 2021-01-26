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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Address.cs 7     5/22/12 6:09p Gwynnj $ */
#endregion

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Implements CallObjects Address
	/// </summary>
	public class Address : IAddress
	{
		private readonly Composite _base;

		public const string AddressLine1 = "ADDRESS_LINE1";
		public const string AddressLine2 = "ADDRESS_LINE2";
		public const string AddressLine3 = "ADDRESS_LINE3";
		public const string AddressCity = "ADDRESS_CITY";
		public const string AddressState = "ADDRESS_STATE";
		public const string AddressZip = "ADDRESS_ZIP";
		public const string AddressCounty = "ADDRESS_COUNTY";
		public const string AddressCountry = "ADDRESS_COUNTRY";
		public const string AddressFips = "ADDRESS_FIPS";

		/// <summary>
		/// Initializes a new instance of the <see cref="Address"/> class.
		/// </summary>
		internal Address(Composite parent)
		{
			_base = parent;
		}
		/// <summary>
		/// Gets or sets the address1.
		/// </summary>
		/// <value>The address1.</value>
		public string Address1
		{
			get { return _base.GetValue(AddressLine1); }
			set { _base.SetValue(AddressLine1, value); }
		}

		/// <summary>
		/// Gets or sets the address2.
		/// </summary>
		/// <value>The address2.</value>
		public string Address2
		{
			get { return _base.GetValue(AddressLine2); }
			set { _base.SetValue(AddressLine2, value); }
		}

		/// <summary>
		/// Gets or sets the address3.
		/// </summary>
		/// <value>The address3.</value>
		public string Address3
		{
			get { return _base.GetValue(AddressLine3); }
			set { _base.SetValue(AddressLine3, value); }
		}

		/// <summary>
		/// Gets or sets the city.
		/// </summary>
		/// <value>The city.</value>
		public string City
		{
			get { return _base.GetValue(AddressCity); }
			set { _base.SetValue(AddressCity, value); }
		}

		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>The state.</value>
		public string State
		{
			get { return _base.GetValue(AddressState); }
			set { _base.SetValue(AddressState, value); }
		}

		/// <summary>
		/// Gets or sets the zip.
		/// </summary>
		/// <value>The zip.</value>
		public string Zip
		{
			get { return _base.GetValue(AddressZip); }
			set { _base.SetValue(AddressZip, value); }
		}

		/// <summary>
		/// Gets or sets the county.
		/// </summary>
		/// <value>The county.</value>
		public string County
		{
			get { return _base.GetValue(AddressCounty); }
			set { _base.SetValue(AddressCounty, value); }
		}

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country
        {
            get { return _base.GetValue(AddressCountry); }
            set { _base.SetValue(AddressCountry, value); }
        }

		/// <summary>
		/// Gets or sets the fips.
		/// </summary>
		/// <value>The fips.</value>
		public string Fips
		{
			get { return _base.GetValue(AddressFips); }
			set { _base.SetValue(AddressFips, value); }
		}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Address.cs $
 * 
 * 7     5/22/12 6:09p Gwynnj
 * additional updates required for AAA
 * 
 * 6     12/14/10 4:01p Gwynnj
 * added AddressCountry
 * 
 * 5     9/22/10 12:23p Gwynnj
 * Added address constants
 * 
 * 4     3/03/09 4:06p John.gwynn
 * fixed a weakness with Address derivative class
 * 
 * 3     1/16/08 6:39p John.gwynn
 * added CallObjectBase to override SetValue
 * 
 * 2     10/22/07 6:08p John.gwynn
 * 
 * 1     10/21/07 3:31p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion