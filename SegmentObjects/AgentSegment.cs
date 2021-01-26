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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/AgentSegment.cs 8     9/21/10 6:30p Gwynnj $ */
#endregion

using System.Runtime.InteropServices;
using FnsComposite.CallObjects;
using FnsComposite.Interfaces;
using FnsComposite.SegmentObjects;

namespace FnsComposite
{
	/// <summary>
	/// Uif Segment class for the AGENT table
	/// </summary>
	[ComVisible(false)]
	public class AgentSegment : Segment, IAgent
	{
		private enum eParmList
		{
			AgentId = 0,
			FileTranLogId,
			BranchId,
			AgentBranchNum,
			AgentNumber,
			Status,
			TypeCd,
			AgentName,
			Address,
			City,
			State,
			Zip,
			Phone,
			Fax,
			FaxCd,
			Lat,
			Lon,
			EmailAddress,
			ContactType,
			NameFirst,
			NameMid,
			NameLast,
			PhoneExt,
			PrefInd,
			GatCode,
			UploadKey
		};
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="AgentSegment"/> class.
		/// </summary>
		public AgentSegment(): base("AGENT")
		{
			ColumnNames = new string[]
				{
					"AGENT_ID",
					"FILE_TRANSMISSION_LOG_ID",
					"BRANCH_ID",
					"AGENT_BRANCHNUM",
					"AGENT_NUMBER",
					"STATUS",
					"TYPECD",
					"NAME",
					"ADDRESS",
					"CITY",
					"STATE",
					"ZIPCODE",
					"PHONE",
					"FAX",
					"FAXCD",
					"LAT",
					"LON",
					"EMAIL_ADDRESS",
					"CONTACT_TYPE",
					EntityBase.FirstNameAttribute,
					"NAME_MI",
					EntityBase.LastNameAttribute,
					"PHONE_EXT",
					"PREF_IND",
					"GAT_CODE",
					"UPLOAD_KEY"
				};
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="AgentSegment"/> class.
		/// </summary>
		/// <param name="rec">The rec.</param>
		public AgentSegment(IAgent rec): this()
		{
			FileTranLogId = rec.FileTranLogId;
			BranchId = rec.BranchId;
			AgentBranchNum = rec.AgentBranchNum;
			AgentNumber = rec.AgentNumber;
			Status = rec.Status;
			TypeCd = rec.TypeCd;
			AgentName = rec.AgentName;
			Address = rec.Address;
			City = rec.City;
			State = rec.State;
			Zip = rec.Zip;
			Phone = rec.Phone;
			Fax = rec.Fax;
			FaxCd = rec.FaxCd;
			Lat = rec.Lat;
			Lon = rec.Lon;
			EmailAddress = rec.EmailAddress;
			ContactType = rec.ContactType;
			NameFirst = rec.NameFirst;
			NameMid = rec.NameMid;
			NameLast = rec.NameLast;
			Status = rec.Status;
			PhoneExt = rec.PhoneExt;
			PrefInd = rec.PrefInd;
			GatCode = rec.GatCode;
			UploadKey = rec.UploadKey;
		}
		#endregion
		#region AgentId
		/// <summary>
		/// Gets the agent id.
		/// </summary>
		/// <value>The agent id.</value>
		public string AgentId
		{
			get { return GetValue(ColumnNames[(int)eParmList.AgentId]); }
			set { SetValue(ColumnNames[(int)eParmList.AgentId], value); }
		}
		#endregion
		#region FileTranLogId
		/// <summary>
		/// Gets the file tran log id.
		/// </summary>
		/// <value>The file tran log id.</value>
		public string FileTranLogId
		{
			get { return GetValue(ColumnNames[(int)eParmList.FileTranLogId]); }
			set { SetValue(ColumnNames[(int)eParmList.FileTranLogId], value); }
		}
		#endregion
		#region AgentName
		/// <summary>
		/// Gets the file tran log id.
		/// </summary>
		/// <value>The file tran log id.</value>
		public string AgentName
		{
			get { return GetValue(ColumnNames[(int)eParmList.AgentName]); }
			set { SetValue(ColumnNames[(int)eParmList.AgentName], value); }
		}
		#endregion
		#region BranchId
		/// <summary>
		/// Gets the branch id.
		/// </summary>
		/// <value>The branch id.</value>
		public string BranchId
		{
			get { return GetValue(ColumnNames[(int)eParmList.BranchId]); }
			set { SetValue(ColumnNames[(int)eParmList.BranchId], value); }
		}
		#endregion
		#region AgentBranchNum
		/// <summary>
		/// Gets the agent branch num.
		/// </summary>
		/// <value>The agent branch num.</value>
		public string AgentBranchNum
		{
			get { return GetValue(ColumnNames[(int)eParmList.AgentBranchNum]); }
			set { SetValue(ColumnNames[(int)eParmList.AgentBranchNum], value); }
		}
		#endregion
		#region AgentNumber
		/// <summary>
		/// Gets the agent number.
		/// </summary>
		/// <value>The agent number.</value>
		public string AgentNumber
		{
			get { return GetValue(ColumnNames[(int)eParmList.AgentNumber]); }
			set { SetValue(ColumnNames[(int)eParmList.AgentNumber], value); }
		}
		#endregion
		#region Status
		/// <summary>
		/// Gets the status.
		/// </summary>
		/// <value>The status.</value>
		public string Status
		{
			get { return GetValue(ColumnNames[(int)eParmList.Status]); }
			set { SetValue(ColumnNames[(int)eParmList.Status], value); }
		}
		#endregion
		#region TypeCd
		/// <summary>
		/// Gets the type cd.
		/// </summary>
		/// <value>The type cd.</value>
		public string TypeCd
		{
			get { return GetValue(ColumnNames[(int)eParmList.TypeCd]); }
			set { SetValue(ColumnNames[(int)eParmList.TypeCd], value); }
		}
		#endregion
		#region Address
		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		public new string Address
		{
			get { return GetValue(ColumnNames[(int)eParmList.Address]); }
			set { SetValue(ColumnNames[(int)eParmList.Address], value); }
		}
		#endregion
		#region City
		/// <summary>
		/// Gets the city.
		/// </summary>
		/// <value>The city.</value>
		public string City
		{
			get { return GetValue(ColumnNames[(int)eParmList.City]); }
			set { SetValue(ColumnNames[(int)eParmList.City], value); }
		}
		#endregion
		#region State
		/// <summary>
		/// Gets the state.
		/// </summary>
		/// <value>The state.</value>
		public string State
		{
			get { return GetValue(ColumnNames[(int)eParmList.State]); }
			set { SetValue(ColumnNames[(int)eParmList.State], value); }
		}
		#endregion
		#region Zip
		/// <summary>
		/// Gets the zip.
		/// </summary>
		/// <value>The zip.</value>
		public string Zip
		{
			get { return GetValue(ColumnNames[(int)eParmList.Zip]); }
			set { SetValue(ColumnNames[(int)eParmList.Zip], value); }
		}
		#endregion
		#region Phone
		/// <summary>
		/// Gets the phone.
		/// </summary>
		/// <value>The phone.</value>
		public string Phone
		{
			get { return GetValue(ColumnNames[(int)eParmList.Phone]); }
			set { SetValue(ColumnNames[(int)eParmList.Phone], value); }
		}
		#endregion
		#region Fax
		/// <summary>
		/// Gets the fax.
		/// </summary>
		/// <value>The fax.</value>
		public string Fax
		{
			get { return GetValue(ColumnNames[(int)eParmList.Fax]); }
			set { SetValue(ColumnNames[(int)eParmList.Fax], value); }
		}
		#endregion
		#region FaxCd
		/// <summary>
		/// Gets the fax cd.
		/// </summary>
		/// <value>The fax cd.</value>
		public string FaxCd
		{
			get { return GetValue(ColumnNames[(int)eParmList.FaxCd]); }
			set { SetValue(ColumnNames[(int)eParmList.FaxCd], value); }
		}
		#endregion
		#region Lat
		/// <summary>
		/// Gets the lat.
		/// </summary>
		/// <value>The lat.</value>
		public string Lat
		{
			get { return GetValue(ColumnNames[(int)eParmList.Lat]); }
			set { SetValue(ColumnNames[(int)eParmList.Lat], value); }
		}
		#endregion
		#region Lon
		/// <summary>
		/// Gets the lon.
		/// </summary>
		/// <value>The lon.</value>
		public string Lon
		{
			get { return GetValue(ColumnNames[(int)eParmList.Lon]); }
			set { SetValue(ColumnNames[(int)eParmList.Lon], value); }
		}
		#endregion
		#region EmailAddress
		/// <summary>
		/// Gets the email address.
		/// </summary>
		/// <value>The email address.</value>
		public string EmailAddress
		{
			get { return GetValue(ColumnNames[(int)eParmList.EmailAddress]); }
			set { SetValue(ColumnNames[(int)eParmList.EmailAddress], value); }
		}
		#endregion
		#region ContactType
		/// <summary>
		/// Gets the type of the contact.
		/// </summary>
		/// <value>The type of the contact.</value>
		public string ContactType
		{
			get { return GetValue(ColumnNames[(int)eParmList.ContactType]); }
			set { SetValue(ColumnNames[(int)eParmList.ContactType], value); }
		}
		#endregion
		#region NameFirst
		/// <summary>
		/// Gets the name first.
		/// </summary>
		/// <value>The name first.</value>
		public string NameFirst
		{
			get { return GetValue(ColumnNames[(int)eParmList.NameFirst]); }
			set { SetValue(ColumnNames[(int)eParmList.NameFirst], value); }
		}
		#endregion
		#region NameMid
		/// <summary>
		/// Gets the name mid.
		/// </summary>
		/// <value>The name mid.</value>
		public string NameMid
		{
			get { return GetValue(ColumnNames[(int)eParmList.NameMid]); }
			set { SetValue(ColumnNames[(int)eParmList.NameMid], value); }
		}
		#endregion
		#region NameLast
		/// <summary>
		/// Gets the name last.
		/// </summary>
		/// <value>The name last.</value>
		public string NameLast
		{
			get { return GetValue(ColumnNames[(int)eParmList.NameLast]); }
			set { SetValue(ColumnNames[(int)eParmList.NameLast], value); }
		}
		#endregion
		#region PhoneExt
		/// <summary>
		/// Gets the phone ext.
		/// </summary>
		/// <value>The phone ext.</value>
		public string PhoneExt
		{
			get { return GetValue(ColumnNames[(int)eParmList.PhoneExt]); }
			set { SetValue(ColumnNames[(int)eParmList.PhoneExt], value); }
		}
		#endregion
		#region PrefInd
		/// <summary>
		/// Gets the pref ind.
		/// </summary>
		/// <value>The pref ind.</value>
		public string PrefInd
		{
			get { return GetValue(ColumnNames[(int)eParmList.PrefInd]); }
			set { SetValue(ColumnNames[(int)eParmList.PrefInd], value); }
		}
		#endregion
		#region GatCode
		/// <summary>
		/// Gets the gat code.
		/// </summary>
		/// <value>The gat code.</value>
		public string GatCode
		{
			get { return GetValue(ColumnNames[(int)eParmList.GatCode]); }
			set { SetValue(ColumnNames[(int)eParmList.GatCode], value); }
		}
		#endregion
		#region UploadKey
		/// <summary>
		/// Gets the upload key.
		/// </summary>
		/// <value>The upload key.</value>
		public string UploadKey
		{
			get { return GetValue(ColumnNames[(int)eParmList.UploadKey]); }
			set { SetValue(ColumnNames[(int)eParmList.UploadKey], value); }
		}
		#endregion	
	}
}

#region History
/*
 * $History: AgentSegment.cs $
 * 
 * *****************  Version 8  *****************
 * User: Gwynnj       Date: 9/21/10    Time: 6:30p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Created EntityBase to factor the IPerson interface
 * 
 * *****************  Version 7  *****************
 * User: John.gwynn   Date: 9/26/09    Time: 12:46p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added IAccountHierarchyStep interface
 * 
 * *****************  Version 6  *****************
 * User: John.gwynn   Date: 5/04/09    Time: 3:55p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * *****************  Version 5  *****************
 * User: Jenny.cheung Date: 11/06/07   Time: 5:19p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 10/22/07   Time: 6:08p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 10/21/07   Time: 8:17a
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Modified segment namespace started work on CallObject types
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 9/24/07    Time: 5:34p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * merged with 2003 changes
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 7/10/07    Time: 5:35p
 * Created in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * created SegmentObjects folder
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
 * User: John.gwynn   Date: 10/27/06   Time: 5:05p
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * -unfinished segment class for the AGENT table
 */
#endregion
