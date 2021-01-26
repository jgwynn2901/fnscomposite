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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/AccountUserSegment.cs 2     5/04/09 3:55p John.gwynn $ */
#endregion

using System;
using System.Runtime.InteropServices;
using FnsComposite.SegmentObjects;

namespace FnsComposite
{
	/// <summary>
	/// UsersSegment encapsulated data assigned to  Account User table 
	/// for InputProcessManager.
	/// </summary>
	[ComVisible(false)]
	public class AccountUsersSegment : Segment
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AccountUsersSegment"/> class.
		/// </summary>
		public AccountUsersSegment() :base("ACCOUNT_USER")
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
	
		#region Ahsid
		/// <summary>
		/// Gets or sets the ACCNT_HRCY_STEP_ID.
		/// </summary>
		/// <value>The ACCNT_HRCY_STEP_ID.</value>
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
		#region FileTransLogId
		/// <summary>
		/// Gets or sets the FileTransLogId.
		/// </summary>
		/// <value>The FileTransLogId .</value>
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
			// either we are being called by our parent
		
				if((Parent.Name.Equals("USERS")) && (key.Length > 0))
				{
				UserId = key;
				}
			
				else
				{
					throw new ApplicationException(string.Format("AccountUserSegment SetParentKey unsupported parent segment {0}",
						Parent.Name));
				}
			
		}
			#endregion
	}
}
#region History
/*
 * $History: AccountUserSegment.cs $
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 5/04/09    Time: 3:55p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * *****************  Version 1  *****************
 * User: Jenny.cheung Date: 11/06/07   Time: 5:20p
 * Created in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * 
 * *****************  Version 2  *****************
 * User: Jenny.cheung Date: 6/19/07    Time: 9:59a
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * 
 * *****************  Version 1  *****************
 * User: Jenny.cheung Date: 5/24/07    Time: 5:47p
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * created for future use for cedar hill user setup
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
