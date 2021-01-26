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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/CarrierSegment.cs 10    3/02/10 5:28p Gwynnj $ */
#endregion

using System;
using System.Runtime.InteropServices;

namespace FnsComposite.SegmentObjects
{
	/// <summary>
	/// 
	/// </summary>
	public interface ICarrier
	{
		/// <summary>
		/// Gets the carrier id.
		/// </summary>
		/// <value>The carrier id.</value>
		string CarrierId { get; set; }

		/// <summary>
		/// Gets or sets the file tran log id.
		/// </summary>
		/// <value>The file tran log id.</value>
		string FileTranLogId { get; set; }

		/// <summary>
		/// Gets or sets the full name.
		/// </summary>
		/// <value>The full name.</value>
		string FullName { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		string Title { get; set; }

		/// <summary>
		/// Gets or sets the type of the business.
		/// </summary>
		/// <value>The type of the business.</value>
		string BusinessType { get; set; }

		/// <summary>
		/// Gets or sets the address1.
		/// </summary>
		/// <value>The address1.</value>
		string Address1 { get; set; }

		/// <summary>
		/// Gets or sets the address2.
		/// </summary>
		/// <value>The address2.</value>
		string Address2 { get; set; }

		/// <summary>
		/// Gets or sets the city.
		/// </summary>
		/// <value>The city.</value>
		string City { get; set; }

		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>The state.</value>
		string State { get; set; }

		/// <summary>
		/// Gets or sets the zip.
		/// </summary>
		/// <value>The zip.</value>
		string Zip { get; set; }

		/// <summary>
		/// Gets or sets the phone.
		/// </summary>
		/// <value>The phone.</value>
		string Phone { get; set; }

		/// <summary>
		/// Gets or sets the fein.
		/// </summary>
		/// <value>The fein.</value>
		string Fein { get; set; }

		/// <summary>
		/// Gets or sets the carrier number.
		/// </summary>
		/// <value>The carrier number.</value>
		string CarrierNumber { get; set; }

		/// <summary>
		/// Gets or sets the bureau code.
		/// </summary>
		/// <value>The bureau code.</value>
		string BureauCode { get; set; }

		/// <summary>
		/// Gets or sets the upload key.
		/// </summary>
		/// <value>The upload key.</value>
		string UploadKey { get; set; }
	}

	/// <summary>
	/// CarrierSegment encapsulated data assigned to CARRIER table 
	/// for InputProcessManager.
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public class CarrierSegment : Segment, ICarrier
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CarrierSegment"/> class.
		/// </summary>
		public CarrierSegment() :base("CARRIER")
		{}

		/// <summary>
		/// Copies data from ICarrier.
		/// </summary>
		public static CarrierSegment CopyFrom (ICarrier source)
		{
			return new CarrierSegment
			              	{
			              		CarrierId = source.CarrierId,
			              		CarrierNumber = source.CarrierNumber,
			              		FileTranLogId = source.FileTranLogId,
			              		FullName = source.FullName,
			              		Title = source.Title,
			              		BusinessType = source.BusinessType,
			              		Address1 = source.Address1,
			              		Address2 = source.Address2,
			              		City = source.City,
			              		State = source.State,
			              		Zip = source.Zip,
			              		Phone = source.Phone,
			              		Fein = source.Fein,
			              		BureauCode = source.BureauCode,
			              		UploadKey = source.UploadKey
			              	};
		}

		#region CarrierId
		
		/// <summary>
		/// Gets the carrier id.
		/// </summary>
		/// <value>The carrier id.</value>
		public string CarrierId
		{
			get
			{
				return GetValue("CARRIER_ID");				
			}
			set
			{
				SetValue("CARRIER_ID", value);
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
		#region FullName
		/// <summary>
		/// Gets or sets the full name.
		/// </summary>
		/// <value>The full name.</value>
        public new string FullName
		{
			get
			{
				return GetValue("NAME");				
			}
			set
			{
				SetValue("NAME", value);
			}
		}
		#endregion
		#region Title
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title
		{
			get
			{
				return GetValue("TITLE");				
			}
			set
			{
				SetValue("TITLE", value);
			}
		}
		#endregion
		#region BusinessType
		/// <summary>
		/// Gets or sets the type of the business.
		/// </summary>
		/// <value>The type of the business.</value>
		public string BusinessType
		{
			get
			{
				return GetValue("BUSINESS_TYPE");				
			}
			set
			{
				SetValue("BUSINESS_TYPE", value);
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
				return GetValue("ADDRESS1");				
			}
			set
			{
				SetValue("ADDRESS1", value);
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
		#region Fein
		/// <summary>
		/// Gets or sets the fein.
		/// </summary>
		/// <value>The fein.</value>
		public string Fein
		{
			get
			{
				return GetValue("FEIN");				
			}
			set
			{
				SetValue("FEIN", value);
			}
		}
		#endregion
		#region CarrierNumber
		/// <summary>
		/// Gets or sets the carrier number.
		/// </summary>
		/// <value>The carrier number.</value>
		public string CarrierNumber
		{
			get
			{
				return GetValue("CARRIER_NUMBER");				
			}
			set
			{
				SetValue("CARRIER_NUMBER", value);
			}
		}
		#endregion
		#region BureauCode
		/// <summary>
		/// Gets or sets the bureau code.
		/// </summary>
		/// <value>The bureau code.</value>
		public string BureauCode
		{
			get
			{
				return GetValue("BUREAU_CD");				
			}
			set
			{
				SetValue("BUREAU_CD", value);
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
		#region AhsId	
		/// <summary>
		/// Gets or sets the upload key.
		/// N.B. trhis is not included or necessary for the CARRIER
		/// schema but is used to genrate proper paret keys for each
		/// POLICY child segment.
		/// </summary>
		/// <value>The AccountHierarchyStepId of the parent segment.</value>
		public string AhsId
		{
			get
			{
				return GetValue("ACCNT_HRCY_STEP_ID");				
			}
			set
			{
				SetValue("ACCNT_HRCY_STEP_ID", value);
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
			if (key.Length > 0 && AhsId.Length == 0)
			{
				if(Parent.Name.Equals("ACCOUNT_HIERARCHY_STEP"))
				{
					AhsId = key;
				}
				else
				{
					throw new ApplicationException(string.Format("AhsPolicySegment SetParentKey unsupported parent segment {0}",
					                                             Parent.Name));
				}
			}
			if(CarrierId.Length > 0)
			{
				// now propagate to children our key
				foreach(Segment segment in SegmentList)
				{
					segment.SetParentKey(CarrierId);
				}
			}
		}
		/// <summary>
		/// Clears the parent key.
		/// </summary>
		public override void ClearParentKey()
		{
			AhsId = string.Empty;
		}
		/// <summary>
		/// Clears the key.
		/// </summary>
		public override void ClearKey()
		{
			CarrierId = string.Empty;
		}
	}
}

#region History
/*
 * $History: CarrierSegment.cs $
 * 
 * *****************  Version 10  *****************
 * User: Gwynnj       Date: 3/02/10    Time: 5:28p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * cleared out build warnings
 * 
 * *****************  Version 9  *****************
 * User: John.gwynn   Date: 10/27/09   Time: 12:39p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * created ICarrier interface for dto -N.B. will need to move to
 * FnsInterfaces
 * 
 * *****************  Version 8  *****************
 * User: John.gwynn   Date: 9/26/09    Time: 12:46p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added IAccountHierarchyStep interface
 * 
 * *****************  Version 7  *****************
 * User: Jenny.cheung Date: 11/06/07   Time: 5:20p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * 
 * *****************  Version 6  *****************
 * User: John.gwynn   Date: 10/21/07   Time: 8:17a
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Modified segment namespace started work on CallObject types
 * 
 * *****************  Version 5  *****************
 * User: John.gwynn   Date: 9/24/07    Time: 5:35p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * merged with 2003 changes
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 7/10/07    Time: 5:32p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite
 * Added new Interfaces for OPM, ported 1.1 interfaces and segment
 * updates.  
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 4/20/07    Time: 5:17p
 * Updated in $/SourceCode/Components/VS.NET2005/FnsComposite
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 4/17/07    Time: 3:41p
 * Updated in $/SourceCode/Components/VS.NET2005/FnsComposite
 * update current version synch to 1.1
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 11/16/06   Time: 5:20p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * Added NDoc comments and formatting
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 10/27/06   Time: 5:09p
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * Segment class for the CARRIER table (InputProcessManager)
 */
#endregion
