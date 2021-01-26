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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/ContactSegment.cs 5     9/22/10 12:23p Gwynnj $ */
#endregion

using System;
using System.Runtime.InteropServices;
using FnsComposite.SegmentObjects;

namespace FnsComposite
{
	/// <summary>
	/// ContactSegment encapsulated data assigned to CONTACT table 
	/// for InputProcessManager.
	/// </summary>
	[ComVisible(false)]
	public class ContactSegment : Segment
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ContactSegment"/> class.
		/// </summary>
		public ContactSegment() :base("CONTACT")
		{}
		#region ContactId
		
		/// <summary>
		/// Gets the contact id.
		/// </summary>
		/// <value>The contact id.</value>
		public string ContactId
		{
			get
			{
				return GetValue("CONTACT_ID");				
			}
			set
			{
				SetValue("CONTACT_ID", value);
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
		#region Type
		/// <summary>
		/// Gets or sets the type of the business.
		/// </summary>
		/// <value>The type of the business.</value>
		public string Type
		{
			get
			{
				return GetValue("TYPE");				
			}
			set
			{
				SetValue("TYPE", value);
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
				return GetValue(CallObjects.Address.AddressLine1);				
			}
			set
			{
				SetValue(CallObjects.Address.AddressLine1, value);
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
				return GetValue("ADDRESS_LINE2");				
			}
			set
			{
				SetValue("ADDRESS_LINE2", value);
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
		#region Fax
		/// <summary>
		/// Gets or sets the fax.
		/// </summary>
		/// <value>The fax.</value>
		public string FAX
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
		#region Email
		/// <summary>
		/// Gets or sets the Email.
		/// </summary>
		/// <value>The Email.</value>
		public string Email
		{
			get
			{
				return GetValue("Email");				
			}
			set
			{
				SetValue("Email", value);
			}
		}
		#endregion
		#region Description
		/// <summary>
		/// Gets or sets the Description.
		/// </summary>
		/// <value>The Description.</value>
		public string Description
		{
			get
			{
				return GetValue("DESCRIPTION");				
			}
			set
			{
				SetValue("DESCRIPTION", value);
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
		#region Country	
		/// <summary>
		/// Gets or sets the Country.
		/// </summary>
		/// <value>The Country.</value>
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
		#region Enable_Flg	
		/// <summary>
		/// Gets or sets the Enable Flag.
		/// </summary>
		/// <value>The Enable Flag.</value>
		public string Enable_Flg
		{
			get
			{
				return GetValue("ENABLE_FLG");				
			}
			set
			{
				SetValue("ENABLE_FLG", value);
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
			if(ContactId.Length > 0)
			{
				// now propagate to children our key
				foreach(Segment segment in SegmentList)
				{
					segment.SetParentKey(ContactId);
				}
			}
		}
	}
}
#region History
/*
 * $History: ContactSegment.cs $
 * 
 * *****************  Version 5  *****************
 * User: Gwynnj       Date: 9/22/10    Time: 12:23p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added address constants
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
 * *****************  Version 1  *****************
 * User: Jenny.cheung Date: 5/09/07    Time: 2:52p
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * Added ContactSegment for Esis Actec Load
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
