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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/UserSegment.cs 6     9/22/10 12:23p Gwynnj $ */
#endregion

using System;
using System.Runtime.InteropServices;
using FnsComposite.CallObjects;
using FnsComposite.SegmentObjects;

namespace FnsComposite
{
	/// <summary>
	/// UsersSegment encapsulated data assigned to  User table 
	/// for InputProcessManager.
	/// </summary>
	[ComVisible(false)]
	public class UsersSegment : Segment
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UsersSegment"/> class.
		/// </summary>
		public UsersSegment() :base("USERS")
		{}
		#region UserId
		
		/// <summary>
		/// Gets the user id.
		/// </summary>
		/// <value>The  user id.</value>
		public string UserId
		{
			get
			{
				return GetValue("USER_ID");				
			}
			set
			{
				SetValue("USER_ID", value);
			}
		}
		#endregion
		#region SITEID
		/// <summary>
		/// Gets or sets the SITEID.
		/// </summary>
		/// <value>The SITEID.</value>
		public string SITEID
		{
			get
			{
				return GetValue("SITE_ID");				
			}
			set
			{
				SetValue("SITE_ID", value);
			}
		}
		#endregion
		#region FULLNAME
		/// <summary>
		/// Gets or sets the Full Name.
		/// </summary>
		/// <value>The Full Name.</value>
		[CLSCompliant(false)]
        public string FULLNAME
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
		#region PASSWORD
		/// <summary>
		/// Gets or sets the PASSWORD.
		/// </summary>
		/// <value>The PASSWORD.</value>
		public string PASSWORD
		{
			get
			{
				return GetValue("PASSWORD");				
			}
			set
			{
				SetValue("PASSWORD", value);
			}
		}
		#endregion
		#region CREATED_DT
		/// <summary>
		/// Gets or sets the CREATED_DT.
		/// </summary>
		/// <value>The CREATED_DT.</value>
		public string CREATED_DT
		{
			get
			{
				return GetValue("CREATED_DT");				
			}
			set
			{
				SetValue("CREATED_DT", value);
			}
		}
		#endregion
		#region ACTIVE
		/// <summary>
		/// Gets or sets the ACTIVE
		/// </summary>
		/// <value>The ACTIVE.</value>
		public string ACTIVE
		{
			get
			{
				return GetValue("ACTIVE");				
			}
			set
			{
				SetValue("ACTIVE", value);
			}
		}
		#endregion
		#region LASTNAME
		/// <summary>
		/// Gets or sets the LASTNAME.
		/// </summary>
		/// <value>The LASTNAME.</value>
		public string LASTNAME
		{
			get
			{
				return GetValue("LAST_NAME");				
			}
			set
			{
				SetValue("LAST_NAME", value);
			}
		}
		#endregion
		#region FIRSTNAME
		/// <summary>
		/// Gets or sets the FIRSTNAME.
		/// </summary>
		/// <value>The FIRSTNAME.</value>
		public string FIRSTNAME
		{
			get
			{
				return GetValue("FIRST_NAME");				
			}
			set
			{
				SetValue("FIRST_NAME", value);
			}
		}
		#endregion
		#region ADDRESS1
		/// <summary>
		/// Gets or sets the ADDRESS1.
		/// </summary>
		/// <value>The ADDRESS1.</value>
		public string ADDRESS1
		{
			get
			{
				return GetValue(CallObjects.Address.AddressLine1);				
			}
			set
			{
				SetValue(CallObjects.Address.AddressLine1, value);
			}
		}
		#endregion
		#region ADDRESS2
		/// <summary>
		/// Gets or sets the ADDRESS2.
		/// </summary>
		/// <value>The ADDRESS2.</value>
		public string ADDRESS2
		{
			get
			{
				return GetValue("ADDRESS_LINE2");				
			}
			set
			{
				SetValue("ADDRESS_LINE2", value);
			}
		}
		#endregion
		#region CITY
		/// <summary>
		/// Gets or sets the CITY.
		/// </summary>
		/// <value>The CITY.</value>
		public string CITY
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
		#region STATE
		/// <summary>
		/// Gets or sets the STATE.
		/// </summary>
		/// <value>The STATE.</value>
		public string STATE
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
		#region ZIPCODE
		/// <summary>
		/// Gets or sets the ZIPCODE.
		/// </summary>
		/// <value>The ZIPCODE.</value>
		public string ZIPCODE
		{
			get
			{
				return GetValue("ZIP_CODE");				
			}
			set
			{
				SetValue("ZIP_CODE", value);
			}
		}
		#endregion
		#region PHONE_WORK_EXTENSION
		/// <summary>
		/// Gets or sets the PHONE_WORK_EXTENSION.
		/// </summary>
		/// <value>The PHONE_WORK_EXTENSION.</value>
		public string PHONE_WORK_EXTENSION
		{
			get
			{
				return GetValue("PHONE_WORK_EXTENSION");				
			}
			set
			{
				SetValue("PHONE_WORK_EXTENSION", value);
			}
		}
		#endregion
		#region FAX_NUMBER
		/// <summary>
		/// Gets or sets the FAX_NUMBER.
		/// </summary>
		/// <value>The FAX_NUMBER.</value>
		public string FAX_NUMBER
		{
			get
			{
				return GetValue("FAX_NUMBER");				
			}
			set
			{
				SetValue("FAX_NUMBER", value);
			}
		}
		#endregion
		#region PHONEWORK
		/// <summary>
		/// Gets or sets the PHONE NUMBER.
		/// </summary>
		/// <value>The PHONE NUMBER.</value>
		public string PHONEWORK
		{
			get
			{
				return GetValue(EntityBase.WorkPhoneAttribute);				
			}
			set
			{
				SetValue(EntityBase.WorkPhoneAttribute, value);
			}
		}
		#endregion
		#region EMAIL_ADDRESS
		/// <summary>
		/// Gets or sets the EMAIL_ADDRESS.
		/// </summary>
		/// <value>The EMAIL_ADDRESS.</value>
		public string EMAIL_ADDRESS
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
		#region CALLER_TYPE
		/// <summary>
		/// Gets or sets the CALLER TYPE.
		/// </summary>
		/// <value>The CALLER TYPE.</value>
		public string CALLER_TYPE
		{
			get
			{
				return GetValue("CALLER_TYPE");				
			}
			set
			{
				SetValue("CALLER_TYPE", value);
			}
		}
		#endregion
		#region CALLER_DEPARTMENT
		/// <summary>
		/// Gets or sets the CALLER_DEPARTMENT.
		/// </summary>
		/// <value>The CALLER_DEPARTMENT.</value>
		public string CALLER_DEPARTMENT
		{
			get
			{
				return GetValue("CALLER_DEPARTMENT");				
			}
			set
			{
				SetValue("CALLER_DEPARTMENT", value);
			}
		}
		#endregion
		#region SUPERVISOR_NAME
		/// <summary>
		/// Gets or sets the SUPERVISOR_NAME.
		/// </summary>
		/// <value>The SUPERVISOR_NAME.</value>
		public string SUPERVISOR_NAME
		{
			get
			{
				return GetValue("SUPERVISOR_NAME");				
			}
			set
			{
				SetValue("SUPERVISOR_NAME", value);
			}
		}
		#endregion
		#region SUPERVISOR_PHONE_WORK
		/// <summary>
		/// Gets or sets the SUPERVISOR_PHONE_WORK.
		/// </summary>
		/// <value>The SUPERVISOR_PHONE_WORK.</value>
		public string SUPERVISOR_PHONE_WORK
		{
			get
			{
				return GetValue("SUPERVISOR_PHONE_WORK");				
			}
			set
			{
				SetValue("SUPERVISOR_PHONE_WORK", value);
			}
		}
		#endregion
		#region SUPERVISOR_PHONE_EXTENSION
		/// <summary>
		/// Gets or sets the SUPERVISOR_PHONE_EXTENSION.
		/// </summary>
		/// <value>The SUPERVISOR_PHONE_EXTENSION.</value>
		public string SUPERVISOR_PHONE_EXTENSION
		{
			get
			{
				return GetValue("SUPERVISOR_PHONE_EXTENSION");				
			}
			set
			{
				SetValue("SUPERVISOR_PHONE_EXTENSION", value);
			}
		}
		#endregion
		#region ACTIVE_START_DATE
		/// <summary>
		/// Gets or sets the ACTIVE_START_DATE.
		/// </summary>
		/// <value>The ACTIVE_START_DATE.</value>
		public string ACTIVE_START_DATE
		{
			get
			{
				return GetValue("ACTIVE_START_DATE");				
			}
			set
			{
				SetValue("ACTIVE_START_DATE", value);
			}
		}
		#endregion
		#region ACTIVE_END_DATE
		/// <summary>
		/// Gets or sets the ACTIVE_END_DATE.
		/// </summary>
		/// <value>The ACTIVE_END_DATE.</value>
		public string ACTIVE_END_DATE
		{
			get
			{
				return GetValue("ACTIVE_END_DATE");				
			}
			set
			{
				SetValue("ACTIVE_END_DATE", value);
			}
		}
		#endregion
		#region PASSWORD_CREATION_DATE
		/// <summary>
		/// Gets or sets the PASSWORD_CREATION_DATE.
		/// </summary>
		/// <value>The PASSWORD_CREATION_DATE.</value>
		public string PASSWORD_CREATION_DATE
		{
			get
			{
				return GetValue("PASSWORD_CREATION_DATE");				
			}
			set
			{
				SetValue("PASSWORD_CREATION_DATE", value);
			}
		}
		#endregion
		#region PASSWORD_END_DATE
		/// <summary>
		/// Gets or sets the PASSWORD_END_DATE.
		/// </summary>
		/// <value>The PASSWORD_END_DATE.</value>
		public string PASSWORD_END_DATE
		{
			get
			{
				return GetValue("PASSWORD_END_DATE");				
			}
			set
			{
				SetValue("PASSWORD_END_DATE", value);
			}
		}
		#endregion
		#region LAST_CHANGE_DATE
		/// <summary>
		/// Gets or sets the LAST_CHANGE_DATE.
		/// </summary>
		/// <value>The LAST_CHANGE_DATE.</value>
		public string LAST_CHANGE_DATE
		{
			get
			{
				return GetValue("LAST_CHANGE_DATE");				
			}
			set
			{
				SetValue("LAST_CHANGE_DATE", value);
			}
		}
		#endregion
		#region NEW_USER
		/// <summary>
		/// Gets or sets the NEW_USER.
		/// </summary>
		/// <value>The NEW_USER.</value>
		public string NEW_USER
		{
			get
			{
				return GetValue("NEW_USER");				
			}
			set
			{
				SetValue("NEW_USER", value);
			}
		}
		#endregion
		#region INTERNET_USER
		/// <summary>
		/// Gets or sets the INTERNET_USER.
		/// </summary>
		/// <value>The INTERNET_USER.</value>
		public string INTERNET_USER
		{
			get
			{
				return GetValue("INTERNET_USER");				
			}
			set
			{
				SetValue("INTERNET_USER", value);
			}
		}
		#endregion
		#region REUSE
		/// <summary>
		/// Gets or sets the REUSE.
		/// </summary>
		/// <value>The REUSE.</value>
		public string REUSE
		{
			get
			{
				return GetValue("REUSE");				
			}
			set
			{
				SetValue("REUSE", value);
			}
		}
		#endregion
		#region FileTransLogId
		/// <summary>
		/// Gets or sets the REUSE.
		/// </summary>
		/// <value>The REUSE.</value>
		public string FileTransLogId
		{
			get
			{
				return GetValue("File_Transmission_Log_Id");				
			}
			set
			{
				SetValue("File_Transmission_Log_Id", value);
			}
		}
		#endregion
		/// <summary>
		/// Sets the parent key.
		/// </summary>
		/// <param name="key"></param>
		public override void SetParentKey(string key)
		{
	
			if(UserId.Length > 0)
			{
				foreach(Segment segment in SegmentList)
				{
					segment.SetParentKey(UserId);
				}
			}
		}
	}
}
#region History
/*
 * $History: UserSegment.cs $
 * 
 * *****************  Version 6  *****************
 * User: Gwynnj       Date: 9/22/10    Time: 12:23p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added address constants
 * 
 * *****************  Version 5  *****************
 * User: Gwynnj       Date: 9/21/10    Time: 6:30p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Created EntityBase to factor the IPerson interface
 * 
 * *****************  Version 4  *****************
 * User: Gwynnj       Date: 3/02/10    Time: 5:28p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * cleared out build warnings
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 9/26/09    Time: 12:46p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added IAccountHierarchyStep interface
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
 * *****************  Version 3  *****************
 * User: Jenny.cheung Date: 6/19/07    Time: 9:59a
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 5/17/07    Time: 4:09p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * PolicyLoader suport for default constructor
 * 
 * *****************  Version 1  *****************
 * User: Jenny.cheung Date: 5/17/07    Time: 11:40a
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * Created for crawford cedar hill
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
