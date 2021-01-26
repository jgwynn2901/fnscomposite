using System;
using System.Runtime.InteropServices;


namespace FnsComposite.SegmentObjects
{
	/// <summary>
	/// Alternate Name Segment
	/// </summary>
	[ComVisible(false)]
	public class ANILocationCodeSegment : Segment
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="ANILocationCodeSegment"/> class.
		/// </summary>
		public ANILocationCodeSegment():base ("ANI_LOCATION_CODE")
		{ }

		#region LocationCodeId

		/// <summary>
		/// Gets or sets the location code id.
		/// </summary>
		/// <value>The location code id.</value>
		public string LocationCodeId
		{
			get
			{
				return GetValue("ANI_LOCATION_CODE_ID");

			}
			set
			{
				SetValue("ANI_LOCATION_CODE_ID", value);
			}
            
		}
		#endregion

		#region ACCNT_HRCY_STEP_ID

		/// <summary>
		/// Gets or sets the ACCN t_ HRC y_ STE p_ ID.
		/// </summary>
		/// <value>The ACCN t_ HRC y_ STE p_ ID.</value>
		public string ACCNT_HRCY_STEP_ID
		{
			get
			{
				return GetValue("ACCNT_HRCY_STEP_ID");
			}
			set
			{
				SetValue("ACCNT_HRCY_STEP_ID",value);
			}

		}
		#endregion

		#region AccountNumber

		/// <summary>
		/// Gets or sets the account number.
		/// </summary>
		/// <value>The account number.</value>
		public string AccountNumber
		{
			get
			{
				return GetValue("ACCOUNT_NUMBER");

			}
			set
			{
				SetValue("ACCOUNT_NUMBER",value);
			}
		}
		#endregion

		#region FileTranLogId
		/// <summary>
		/// Gets or sets the file tran log id.
		/// </summary>
		/// <value>The file tran log id.</value>
		public string FileTranLogId
		{
			get
			{
				return GetValue("FILE_TRANSMISSION_LOG_ID");
			}
			set
			{
				SetValue("FILE_TRANSMISSION_LOG_ID", value);
			}
		}
		#endregion


		#region CodingValue5

		/// <summary>
		/// Gets or sets the coding value5.
		/// </summary>
		/// <value>The coding value5.</value>
		public string CodingValue5
		{
			get
			{
				return GetValue("CodingValue5");
			}
			set
			{
				SetValue("CodingValue5", value);
			}
		}
		#endregion
		#region CodingValue4

		/// <summary>
		/// Gets or sets the coding value4.
		/// </summary>
		/// <value>The coding value4.</value>
		public string CodingValue4
		{
			get
			{
				return GetValue("CodingValue4");
			}
			set
			{
				SetValue("CodingValue4", value);
			}
		}
		#endregion
		#region CodingValue3

		/// <summary>
		/// Gets or sets the coding value3.
		/// </summary>
		/// <value>The coding value3.</value>
		public string CodingValue3
		{
			get
			{
				return GetValue("CodingValue3");
			}
			set
			{
				SetValue("CodingValue3", value);
			}
		}
		#endregion
		#region CodingValue2
		/// <summary>
		/// Gets or sets the coding value2.
		/// </summary>
		/// <value>The coding value2.</value>
		public string CodingValue2
		{
			get
			{
				return GetValue("CodingValue2");
			}
			set
			{
				SetValue("CodingValue2", value);
			}
		}
		#endregion
		#region CodingValue1


		/// <summary>
		/// Gets or sets the coding value1.
		/// </summary>
		/// <value>The coding value1.</value>
		public string CodingValue1
		{
			get
			{
				return GetValue("CodingValue1");
			}
			set
			{
				SetValue("CodingValue1", value);
			}
		}
		#endregion
        
		#region CodingDesc5


		/// <summary>
		/// Gets or sets the coding desc5.
		/// </summary>
		/// <value>The coding desc5.</value>
		public string CodingDesc5
		{
			get
			{
				return GetValue("CodingDesc5");
			}
			set
			{
				SetValue("CodingDesc5", value);
			}
		}
		#endregion

		#region CodingDesc4


		/// <summary>
		/// Gets or sets the coding desc4.
		/// </summary>
		/// <value>The coding desc4.</value>
		public string CodingDesc4
		{
			get
			{
				return GetValue("CodingDesc4");
			}
			set
			{
				SetValue("CodingDesc4", value);
			}
		}
		#endregion

		#region CodingDesc3


		/// <summary>
		/// Gets or sets the coding desc3.
		/// </summary>
		/// <value>The coding desc3.</value>
		public string CodingDesc3
		{
			get
			{
				return GetValue("CodingDesc3");
			}
			set
			{
				SetValue("CodingDesc3", value);
			}
		}
		#endregion
		#region CodingDesc2


		/// <summary>
		/// Gets or sets the coding desc2.
		/// </summary>
		/// <value>The coding desc2.</value>
		public string CodingDesc2
		{
			get
			{
				return GetValue("CodingDesc2");
			}
			set
			{
				SetValue("CodingDesc2", value);
			}
		}
		#endregion
		#region CodingDesc1


		/// <summary>
		/// Gets or sets the coding desc1.
		/// </summary>
		/// <value>The coding desc1.</value>
		public string CodingDesc1
		{
			get
			{
				return GetValue("CodingDesc1");
			}
			set
			{
				SetValue("CodingDesc1", value);
			}
		}
		#endregion
		#region Type1
		/// <summary>
		/// Gets or sets the type1.
		/// </summary>
		/// <value>The type1.</value>
		public string Type1
		{
			get
			{
				return GetValue("Type1");
			}
			set
			{
				SetValue("Type1",value);
			}
		}
		#endregion
		#region Type2
		/// <summary>
		/// Gets or sets the type2.
		/// </summary>
		/// <value>The type2.</value>
		public string Type2
		{
			get
			{
				return GetValue("Type2");
			}
			set
			{
				SetValue("Type2", value);
			}
		}
		#endregion
		#region Type3
		/// <summary>
		/// Gets or sets the type3.
		/// </summary>
		/// <value>The type3.</value>
		public string Type3
		{
			get
			{
				return GetValue("Type3");
			}
			set
			{
				SetValue("Type3", value);
			}
		}
		#endregion
		#region Type4
		/// <summary>
		/// Gets or sets the type4.
		/// </summary>
		/// <value>The type4.</value>
		public string Type4
		{
			get
			{
				return GetValue("Type4");
			}
			set
			{
				SetValue("Type4", value);
			}
		}
		#endregion
		#region Type5
		/// <summary>
		/// Gets or sets the type5.
		/// </summary>
		/// <value>The type5.</value>
		public string Type5
		{
			get
			{
				return GetValue("Type5");
			}
			set
			{
				SetValue("Type5", value);
			}
		}
		#endregion

		#region Last_CodeValue


		/// <summary>
		/// Gets or sets the last_ code value.
		/// </summary>
		/// <value>The last_ code value.</value>
		public string Last_CodeValue
		{
			get
			{
				return GetValue("Last_CodeValue");
       
			}
			set
			{
				SetValue("Last_CodeValue", value);
			}
		}
		#endregion


		#region Last_CodeDescription


		/// <summary>
		/// Gets or sets the last_ code description.
		/// </summary>
		/// <value>The last_ code description.</value>
		public string Last_CodeDescription
		{
			get
			{
				return GetValue("Last_CodeDescription");
             
			}
			set
			{
				SetValue("Last_CodeDescription", value);
			}
		}
		#endregion

		#region UploadKey


		/// <summary>
		/// Gets or sets the upload key.
		/// </summary>
		/// <value>The upload key.</value>
		public string UploadKey
		{
			get
			{
				return GetValue("UPLOAD_KEY");
			}
			set
			{
				SetValue("UPLOAD_KEY", value);
			}
		}
		#endregion
		/// <summary>
		/// Sets the parent key.
		/// </summary>
		/// <param name="key"></param>
		public override void SetParentKey(string key)
		{
			// either we are being called by our parent
			if (key.Length > 0 && ACCNT_HRCY_STEP_ID.Length == 0)
			{
				if (Parent.Name.Equals("ACCOUNT_HIERARCHY_STEP"))
				{
					ACCNT_HRCY_STEP_ID = key;
				}
				else
				{
					throw new ApplicationException(string.Format("AlternateNamesSegment SetParentKey unsupported parent segment {0}",
					                                             Parent.Name));
				}
			}
			if (LocationCodeId.Length > 0)
			{
				// now propagate to children our key
				foreach (Segment segment in SegmentList)
				{
					segment.SetParentKey(LocationCodeId);
				}
			}
		}



	}
}