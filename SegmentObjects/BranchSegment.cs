using System.Runtime.InteropServices;

namespace FnsComposite.SegmentObjects
{
	/// <summary>
	/// Summary description for BranchSegment.
	/// </summary>
	[ComVisible(false)]
	public class BranchSegment : Segment
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BranchSegment"/> class.
		/// </summary>
		public BranchSegment() : base("BRANCH")
		{}
		#region Ahsid
		/// <summary>
		/// Gets or sets the ACCOUNT_HIERARCHY_LOAD_ID.
		/// </summary>
		/// <value>The ACCOUNT_HIERARCHY_LOAD_ID.</value>
		public string Ahsid
		{
			get
			{
				return GetValue("ACCOUNT_HIERARCHY_LOAD_ID");				
			}
			set
			{
				SetValue("ACCOUNT_HIERARCHY_LOAD_ID", value);
			}
		}
		#endregion
		#region BranchNumber
		/// <summary>
		/// Gets or sets the branch number.
		/// </summary>
		/// <value>The branch number.</value>
		public string BranchNumber
		{
			get
			{
				return GetValue("BRANCH_NUMBER");				
			}
			set
			{
				SetValue("BRANCH_NUMBER", value);
			}
		}
		#endregion
		#region BranchType
		/// <summary>
		/// Gets or sets the type of the branch.
		/// </summary>
		/// <value>The type of the branch.</value>
		public string BranchType
		{
			get
			{
				return GetValue("BRANCH_TYPE");				
			}
			set
			{
				SetValue("BRANCH_TYPE", value);
			}
		}
		#endregion
		#region OfficeNumber
		/// <summary>
		/// Gets or sets the office number.
		/// </summary>
		/// <value>The office number.</value>
		public string OfficeNumber
		{
			get
			{
				return GetValue("OFFICE_NUMBER");				
			}
			set
			{
				SetValue("OFFICE_NUMBER", value);
			}
		}
		#endregion
		#region OfficeName
		/// <summary>
		/// Gets or sets the name of the office.
		/// </summary>
		/// <value>The name of the office.</value>
		public string OfficeName
		{
			get
			{
				return GetValue("OFFICE_NAME");				
			}
			set
			{
				SetValue("OFFICE_NAME", value);
			}
		}
		#endregion
		#region Address1
		/// <summary>
		/// Gets or sets the address1.
		/// </summary>
		/// <value>The address1.</value>
		public string Address1
		{
			get
			{
				return GetValue("ADDRESS_1");				
			}
			set
			{
				SetValue("ADDRESS_1", value);
			}
		}
		#endregion
		#region Address2
		/// <summary>
		/// Gets or sets the address2.
		/// </summary>
		/// <value>The address2.</value>
		public string Address2
		{
			get
			{
				return GetValue("ADDRESS_2");				
			}
			set
			{
				SetValue("ADDRESS_2", value);
			}
		}
		#endregion
		#region City
		/// <summary>
		/// Gets or sets the city.
		/// </summary>
		/// <value>The city.</value>
		public string City
		{
			get
			{
				return GetValue("CITY");				
			}
			set
			{
				SetValue("CITY", value);
			}
		}
		#endregion
		#region State
		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>The state.</value>
		public string State
		{
			get
			{
				return GetValue("STATE");				
			}
			set
			{
				SetValue("STATE", value);
			}
		}
		#endregion
		#region Zip
		/// <summary>
		/// Gets or sets the zip.
		/// </summary>
		/// <value>The zip.</value>
		public string Zip
		{
			get
			{
				return GetValue("ZIP");				
			}
			set
			{
				SetValue("ZIP", value);
			}
		}
		#endregion
		#region Country
		/// <summary>
		/// Gets or sets the country.
		/// </summary>
		/// <value>The country.</value>
		public string Country
		{
			get
			{
				return GetValue("COUNTRY");				
			}
			set
			{
				SetValue("COUNTRY", value);
			}
		}
		#endregion
		#region Phone
		/// <summary>
		/// Gets or sets the phone.
		/// </summary>
		/// <value>The phone.</value>
		public string Phone
		{
			get
			{
				return GetValue("PHONE");				
			}
			set
			{
				SetValue("PHONE", value);
			}
		}
		#endregion
		#region Fax
		/// <summary>
		/// Gets or sets the fax.
		/// </summary>
		/// <value>The fax.</value>
		public string Fax
		{
			get
			{
				return GetValue("FAX");				
			}
			set
			{
				SetValue("FAX", value);
			}
		}
		#endregion
		#region ContactLastName
		/// <summary>
		/// Gets or sets the name of the contact last.
		/// </summary>
		/// <value>The name of the contact last.</value>
		public string ContactLastName
		{
			get
			{
				return GetValue("CONTACT_L_NAME");				
			}
			set
			{
				SetValue("CONTACT_L_NAME", value);
			}
		}
		#endregion
		#region ContacFirstName
		/// <summary>
		/// Gets or sets the name of the contac first.
		/// </summary>
		/// <value>The name of the contac first.</value>
		public string ContacFirstName
		{
			get
			{
				return GetValue("CONTACT_F_NAME");				
			}
			set
			{
				SetValue("CONTACT_F_NAME", value);
			}
		}
		#endregion
		#region EmailAddress
		/// <summary>
		/// Gets or sets the email address.
		/// </summary>
		/// <value>The email address.</value>
		public string EmailAddress
		{
			get
			{
				return GetValue("EMAIL_ADDRESS");				
			}
			set
			{
				SetValue("EMAIL_ADDRESS", value);
			}
		}
		#endregion
		#region AltContactLastName
		/// <summary>
		/// Gets or sets the name of the alt contact last.
		/// </summary>
		/// <value>The name of the alt contact last.</value>
		public string AltContactLastName
		{
			get
			{
				return GetValue("ALT_CONTACT_L_NAME");				
			}
			set
			{
				SetValue("ALT_CONTACT_L_NAME", value);
			}
		}
		#endregion
		#region AltContacFirstName
			/// <summary>
			/// Gets or sets the name of the alt contac first.
			/// </summary>
			/// <value>The name of the alt contac first.</value>
			public string AltContacFirstName
		{
			get
			{
				return GetValue("ALT_CONTACT_F_NAME");				
			}
			set
			{
				SetValue("ALT_CONTACT_F_NAME", value);
			}
		}
		#endregion

	}
}
