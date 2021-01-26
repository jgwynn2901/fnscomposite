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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/LocationUserSegment.cs 3     1/06/10 6:43p Gwynnj $ */
#endregion

using System;
using System.Runtime.InteropServices;
using FnsComposite.CallObjects;
using FnsComposite.SegmentObjects;

namespace FnsComposite
{
	/// <summary>
	/// LocationUserSegment encapsulated data assigned to Location User table 
	/// for InputProcessManager.
	/// </summary>
	[ComVisible(false)]
	public class LocationUserSegment : Segment
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LocationUserSegment"/> class.
		/// </summary>
		public LocationUserSegment() :base("LOCATIONS_USER")
		{}
		#region LocationuserId
		
		/// <summary>
		/// Gets the location user id.
		/// </summary>
		/// <value>The location user id.</value>
		public string LocationuserId
		{
			get
			{
				return GetValue("LOCATION_USER_ID");				
			}
			set
			{
				SetValue("LOCATION_USER_ID", value);
			}
		}
		#endregion
		#region Ahsid
		/// <summary>
		/// Gets or sets the AHSID.
		/// </summary>
		/// <value>The AHSID.</value>
		public string Ahsid
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
		#region LocationAhsid
		/// <summary>
		/// Gets or sets the Location AHSID.
		/// </summary>
		/// <value>The Location AHSID.</value>
		public string LocationAhsid
		{
			get
			{
				return GetValue("LOCATION_AHSID");				
			}
			set
			{
				SetValue("LOCATION_AHSID", value);
			}
		}
		#endregion
		#region UserID
		/// <summary>
		/// Gets or sets the Account User Id.
		/// </summary>
		/// <value>The Account User Id.</value>
		public string UserID
		{
			get
			{
				return GetValue("Account_User_ID");				
			}
			set
			{
				SetValue("Account_User_ID", value);
			}
		}
		#endregion
		#region LOB
		/// <summary>
		/// Gets or sets the LOB.
		/// </summary>
		/// <value>The LOB.</value>
		public string LOB
		{
			get
			{
				return GetValue(CallObject.LobCdAttributeName);				
			}
			set
			{
				SetValue(CallObject.LobCdAttributeName, value);
			}
		}
		#endregion
		#region FnsClientCode
		/// <summary>
		/// Gets or sets the FNS CLIENT CODE
		/// </summary>
		/// <value>The FNS CLIENT CODE.</value>
		public string FnsClientCode
		{
			get
			{
				return GetValue("FNS_CLIENT_CD");				
			}
			set
			{
				SetValue("FNS_CLIENT_CD", value);
			}
		}
		#endregion
		#region UserName
		/// <summary>
		/// Gets or sets the FULL NAME.
		/// </summary>
		/// <value>The FULL NAME.</value>
		public string UserName
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
		#region PhoneNumber
		/// <summary>
		/// Gets or sets the PHONE NUMBER.
		/// </summary>
		/// <value>The PHONE NUMBER.</value>
		public string PhoneNumber
		{
			get
			{
				return GetValue("PHONENUMBER");				
			}
			set
			{
				SetValue("PHONENUMBER", value);
			}
		}
		#endregion
		#region Greeting
		/// <summary>
		/// Gets or sets the GREETING.
		/// </summary>
		/// <value>The GREETING.</value>
		public string Greeting
		{
			get
			{
				return GetValue("GREETING");				
			}
			set
			{
				SetValue("GREETING", value);
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
		/// <summary>
		/// Sets the parent key.
		/// </summary>
		/// <param name="key"></param>
		public override void SetParentKey(string key)
		{
			// either we are being called by our parent
		
				
				if((Parent.Name.Equals("USERS")) && (key.Length > 0))
				{
					UserID = key;
				}
				else if (Parent.Name.Equals("ACCOUNT_HIERARCHY_STEP"))
				{
					LocationAhsid = key;
					
				}
				else
				{
					throw new ApplicationException(string.Format("LocationUserSegment SetParentKey unsupported parent segment {0}",
						Parent.Name));
				}
	

		}
				
	}
}
#region History
/*
 * $History: LocationUserSegment.cs $
 * 
 * *****************  Version 3  *****************
 * User: Gwynnj       Date: 1/06/10    Time: 6:43p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added several constants for CallObject namespace
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 5/04/09    Time: 3:55p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * *****************  Version 1  *****************
 * User: Jenny.cheung Date: 11/07/07   Time: 9:13a
 * Created in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * 
 * *****************  Version 4  *****************
 * User: Jenny.cheung Date: 6/19/07    Time: 9:59a
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * 
 * *****************  Version 3  *****************
 * User: Jenny.cheung Date: 6/05/07    Time: 2:41p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * removed unused field
 * 
 * *****************  Version 2  *****************
 * User: Jenny.cheung Date: 5/18/07    Time: 1:42p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * Added file transmission log id
 * 
 * *****************  Version 1  *****************
 * User: Jenny.cheung Date: 5/17/07    Time: 11:37a
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * created for craw cedar hill user setup
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
