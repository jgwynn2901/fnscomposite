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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/AhsSegment.cs 18    9/21/10 6:30p Gwynnj $ */
#endregion

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using FnsComposite.CallObjects;
using FnsComposite.Interfaces;

namespace FnsComposite.SegmentObjects
{
	/// <summary>
	/// AhsSegment encapsulated data assigned to ACCOUNT_HIERARCHY_STEP table 
	/// for InputProcessManager segment loader processing.  AhsSegment
	/// will usually be associated to (child of)a AhsSegment in cases where
	/// we are building a tree hence the use of Composite design pattern
	/// </summary>
	[ComVisible(false)]
	public class AhsSegment : Segment, IAccountHierarchyStep
	{
		ArrayList _ahsSegments;
		ArrayList _policySegments;

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="AhsSegment"/> class.
		/// </summary>
		public AhsSegment() :base("ACCOUNT_HIERARCHY_STEP")
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="AhsSegment"/> class.
		/// </summary>
		/// <param name="source">The source.</param>
		// ReSharper disable SuggestBaseTypeForParameter
		public AhsSegment(AhsSegment source) :base(source)
		{}
        // ReSharper restore SuggestBaseTypeForParameter

		/// <summary>
		/// Initializes a new instance of the <see cref="AhsSegment"/> class.
		/// </summary>
		/// <param name="source">The source.</param>
		public AhsSegment(IAccountHierarchyStep source)
			: base("ACCOUNT_HIERARCHY_STEP")
		{
			AhsId = source.AhsId;
			ParentNodeId = source.ParentNodeId;
			ClientNodeId = source.ClientNodeId;
			FullName = source.FullName;
			AhsType = source.AhsType;
			FirstName = source.FirstName;
			LastName = source.LastName;
			MidInitial = source.MidInitial;
			UploadKey = source.UploadKey;
			Address1 = source.Address1;
			Address2 = source.Address2;
			Address3 = source.Address3;
			City = source.City;
			State = source.State;
			Zip = source.Zip;
			Phone = source.Phone;
			AltPhone = source.AltPhone;
			Fax = source.Fax;
			AltFax = source.AltFax;
			Fips = source.Fips;
			County = source.County;
			Country = source.Country;
			NatureOfBusiness = source.NatureOfBusiness;
			SecName = source.SecName;
			SecCode = source.SecCode;
			LocName = source.LocName;
			DivisionName = source.DivisionName;
			DivisionCode = source.DivisionCode;
			LocationCode = source.LocationCode;
			ActiveStatus = source.ActiveStatus;
			Fein = source.Fein;
			NodeTypeId = source.NodeTypeId;
			NodeLevel = source.NodeLevel;
			Sic = source.Sic;
			Suid = source.Suid;
			FileTranLogId = source.FileTranLogId;
			DepartmentName = source.DepartmentName;
			DepartmentCode = source.DepartmentCode;
			SpecificDestinationFlag = source.SpecificDestinationFlag;
			NameShort = source.NameShort;
			ActecCode = source.ActecCode;
			AccountFromDate = source.AccountFromDate;
			AccountToDate = source.AccountToDate;
			AccountName = source.AccountName;
			AccountPassword = source.AccountPassword;
			EmailAddress = source.EmailAddress;
			NaicsCode = source.NaicsCode;
			AgentBillingMethod = source.AgentBillingMethod;
			AgentPaymentType = source.AgentPaymentType;
		}
		#endregion
		
		#region public string AhsId
		/// <summary>
		/// Gets the ahs id.
		/// </summary>
		/// <value>The ahs id.</value>
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
		#region public string ParentNodeId
		/// <summary>
		/// Gets or sets the parent node id.
		/// </summary>
		/// <value>The parent node id.</value>
		public string ParentNodeId
		{
			get
			{
				return GetValue("PARENT_NODE_ID");				
			}
			set
			{
				SetValue("PARENT_NODE_ID", value);
			}
		}
		#endregion
		#region public string ClientNodeId
		/// <summary>
		/// Gets or sets the client node id.
		/// </summary>
		/// <value>The client node id.</value>
		public string ClientNodeId
		{
			get
			{
				return GetValue("CLIENT_NODE_ID");				
			}
			set
			{
				SetValue("CLIENT_NODE_ID", value);
			}
		}
		#endregion
		#region public string FullName
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
		#region public string AhsType
		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		public string AhsType
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
		#region public string FirstName
		/// <summary>
		/// Gets or sets the name of the first.
		/// </summary>
		/// <value>The name of the first.</value>
		public string FirstName
		{
			get
			{
				return GetValue(EntityBase.FirstNameAttribute);				
			}
			set
			{
				SetValue(EntityBase.FirstNameAttribute, value);
			}
		}
		#endregion
		#region public string LastName
		/// <summary>
		/// Gets or sets the name of the last.
		/// </summary>
		/// <value>The name of the last.</value>
		public string LastName
		{
			get
			{
				return GetValue(EntityBase.LastNameAttribute);				
			}
			set
			{
				SetValue(EntityBase.LastNameAttribute, value);
			}
		}
		#endregion
		#region public string MidInitial
		/// <summary>
		/// Gets or sets the mid initial.
		/// </summary>
		/// <value>The mid initial.</value>
		public string MidInitial
		{
			get
			{
				return GetValue("NAME_MI");				
			}
			set
			{
				SetValue("NAME_MI", value);
			}
		}
		#endregion
		#region public string UploadKey
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
		#region public string Address1
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
		#region public string Address2
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
		#region public string Address3
		/// <summary>
		/// Gets or sets the address3.
		/// </summary>
		/// <value>The address3.</value>
		public string Address3
		{
			get
			{
				return GetValue("ADDRESS_3");				
			}
			set
			{
				SetValue("ADDRESS_3", value);
			}
		}
		#endregion
		#region public string City
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
		#region public string State
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
		#region public string Zip
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
		#region public string Phone
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
		#region public string AltPhone
		/// <summary>
		/// Gets or sets the alt phone.
		/// </summary>
		/// <value>The alt phone.</value>
		public string AltPhone
		{
			get
			{
				return GetValue("ALT_PHONE");				
			}
			set
			{
				SetValue("ALT_PHONE", value);
			}
		}
		#endregion
		#region public string Fax
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
		#region public string AltFax
		/// <summary>
		/// Gets or sets the alt fax.
		/// </summary>
		/// <value>The alt fax.</value>
		public string AltFax
		{
			get
			{
				return GetValue("ALT_FAX");				
			}
			set
			{
				SetValue("ALT_FAX", value);
			}
		}
		#endregion
		#region public string Fips
		/// <summary>
		/// Gets or sets the fips.
		/// </summary>
		/// <value>The fips.</value>
		public string Fips
		{
			get
			{
				return GetValue("FIPS");				
			}
			set
			{
				SetValue("FIPS", value);
			}
		}
		#endregion
		#region public string County
		/// <summary>
		/// Gets or sets the county.
		/// </summary>
		/// <value>The county.</value>
		public string County
		{
			get
			{
				return GetValue("COUNTY");				
			}
			set
			{
				SetValue("COUNTY", value);
			}
		}
		#endregion
		#region public string Country
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
		#region public string NatureOfBusiness
		/// <summary>
		/// Gets or sets the nature of business.
		/// </summary>
		/// <value>The nature of business.</value>
		public string NatureOfBusiness
		{
			get
			{
				return GetValue("NATURE_OF_BUSINESS");				
			}
			set
			{
				SetValue("NATURE_OF_BUSINESS", value);
			}
		}
		#endregion
		#region public string SecName
		/// <summary>
		/// Gets or sets the name of the sec.
		/// </summary>
		/// <value>The name of the sec.</value>
		public string SecName
		{
			get
			{
				return GetValue("SEC_NAME");				
			}
			set
			{
				SetValue("SEC_NAME", value);
			}
		}
		#endregion
		#region public string SecCode
		/// <summary>
		/// Gets or sets the sec code.
		/// </summary>
		/// <value>The sec code.</value>
		public string SecCode
		{
			get
			{
				return GetValue("SEC_CD");				
			}
			set
			{
				SetValue("SEC_CD", value);
			}
		}
		#endregion
		#region public string LocName
		/// <summary>
		/// Gets or sets the name of the loc.
		/// </summary>
		/// <value>The name of the loc.</value>
		public string LocName
		{
			get
			{
				return GetValue("LOC_NAME");				
			}
			set
			{
				SetValue("LOC_NAME", value);
			}
		}
		#endregion
		#region public string DivisionName
		/// <summary>
		/// Gets or sets the name of the division.
		/// </summary>
		/// <value>The name of the division.</value>
		public string DivisionName
		{
			get
			{
				return GetValue("DIVISION_NAME");				
			}
			set
			{
				SetValue("DIVISION_NAME", value);
			}
		}
		#endregion
		#region public string DivisionCode
		/// <summary>
		/// Gets or sets the division code.
		/// </summary>
		/// <value>The division code.</value>
		public string DivisionCode
		{
			get
			{
				return GetValue("DIVISION_CD");				
			}
			set
			{
				SetValue("DIVISION_CD", value);
			}
		}
		#endregion
		#region public string LocationCode
		/// <summary>
		/// Gets or sets the location code.
		/// </summary>
		/// <value>The location code.</value>
		public string LocationCode
		{
			get
			{
				return GetValue("LOCATION_CODE");				
			}
			set
			{
				SetValue("LOCATION_CODE", value);
			}
		}
		#endregion
		#region public string ActiveStatus
		/// <summary>
		/// Gets or sets the active status.
		/// </summary>
		/// <value>The active status.</value>
		public string ActiveStatus
		{
			get
			{
				return GetValue("ACTIVE_STATUS");				
			}
			set
			{
				SetValue("ACTIVE_STATUS", value);
			}
		}
		#endregion
		#region public string Fein
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
		#region public string NodeTypeId
		/// <summary>
		/// Gets or sets the node type id.
		/// </summary>
		/// <value>The node type id.</value>
		public string NodeTypeId
		{
			get
			{
				return GetValue("NODE_TYPE_ID");				
			}
			set
			{
				SetValue("NODE_TYPE_ID", value);
			}
		}
		#endregion
		#region public string NodeLevel
		/// <summary>
		/// Gets or sets the node level.
		/// </summary>
		/// <value>The node level.</value>
		public string NodeLevel
		{
			get
			{
				return GetValue("NODE_LEVEL");				
			}
			set
			{
				SetValue("NODE_LEVEL", value);
			}
		}
		#endregion
		#region public string Sic
		/// <summary>
		/// Gets or sets the sic.
		/// </summary>
		/// <value>The sic.</value>
		public string Sic
		{
			get
			{
				return GetValue("SIC");				
			}
			set
			{
				SetValue("SIC", value);
			}
		}
		#endregion
		#region public string Suid
		/// <summary>
		/// Gets or sets the suid.
		/// </summary>
		/// <value>The suid.</value>
		public string Suid
		{
			get
			{
				return GetValue("SUID");				
			}
			set
			{
				SetValue("SUID", value);
			}
		}
		#endregion
		#region public string FileTranLogId
		/// <summary>
		/// Gets or sets the file tran log id.
		/// </summary>
		/// <value>The file tran log id.</value>
		public string FileTranLogId
		{
			get
			{
				return GetValue("FILE_TRAN_LOG_ID");				
			}
			set
			{
				SetValue("FILE_TRAN_LOG_ID", value);
			}
		}
		#endregion
		#region public string DepartmentName
		/// <summary>
		/// Gets or sets the name of the department.
		/// </summary>
		/// <value>The name of the department.</value>
		public string DepartmentName
		{
			get
			{
				return GetValue("DEPT_NAME");				
			}
			set
			{
				SetValue("DEPT_NAME", value);
			}
		}
		#endregion
		#region public string DepartmentCode
		/// <summary>
		/// Gets or sets the department code.
		/// </summary>
		/// <value>The department code.</value>
		public string DepartmentCode
		{
			get
			{
				return GetValue("DEPT_CD");				
			}
			set
			{
				SetValue("DEPT_CD", value);
			}
		}
		#endregion
		#region public string SpecificDestinationFlag
		/// <summary>
		/// Gets or sets the specific destination flag.
		/// </summary>
		/// <value>The specific destination flag.</value>
		public string SpecificDestinationFlag

		{
			get
			{
				return GetValue("SPECIFIC_DESTINATION_FLAG");
			}
			set
			{
				SetValue("SPECIFIC_DESTINATION_FLAG",value);
			}
		}
		#endregion
		#region public string NameShort
		/// <summary>
		/// Gets or sets the name short.
		/// </summary>
		/// <value>The name short.</value>
		public string NameShort
		{
			get
			{
				return GetValue("NAME_SHORT");				
			}
			set
			{
				SetValue("NAME_SHORT", value);
			}
		}
		#endregion
		#region public string ActecCode
		/// <summary>
		/// Gets or sets the actec code.
		/// </summary>
		/// <value>The actec code.</value>
		public string ActecCode
		{
			get
			{
				return GetValue("ACTEC_CD");				
			}
			set
			{
				SetValue("ACTEC_CD", value);
			}
		}
		#endregion
		#region public string AccountFromDate
		/// <summary>
		/// Gets or sets the account from date.
		/// </summary>
		/// <value>The account from date.</value>
		public string AccountFromDate
		{
			get
			{
				return GetValue("ACCOUNT_FROM_DATE");				
			}
			set
			{
				SetValue("ACCOUNT_FROM_DATE", value);
			}
		}
		#endregion
		#region public string AccountToDate
		/// <summary>
		/// Gets or sets the account to date.
		/// </summary>
		/// <value>The account to date.</value>
		public string AccountToDate
		{
			get
			{
				return GetValue("ACCOUNT_TO_DATE");				
			}
			set
			{
				SetValue("ACCOUNT_TO_DATE", value);
			}
		}
		#endregion
		#region public string AccountName
		/// <summary>
		/// Gets or sets the name of the account.
		/// </summary>
		/// <value>The name of the account.</value>
		public string AccountName
		{
			get
			{
				return GetValue("ACCOUNT_NAME");				
			}
			set
			{
				SetValue("ACCOUNT_NAME", value);
			}
		}
		#endregion
		#region public string AccountPassword
		/// <summary>
		/// Gets or sets the account password.
		/// </summary>
		/// <value>The account password.</value>
		public string AccountPassword

		{
			get
			{
				return GetValue("ACCOUNT_PASSWORD");
			}
			set
			{
				SetValue("ACCOUNT_PASSWORD",value);
			}
		}
		#endregion
		#region public string EmailAddress
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
		#region public string NaicsCode
		/// <summary>
		/// Gets or sets the naics code.
		/// </summary>
		/// <value>The naics code.</value>
		public string NaicsCode
		{
			get
			{
				return GetValue("NAICS_CD");				
			}
			set
			{
				SetValue("NAICS_CD", value);
			}
		}
		#endregion
		#region public string AgentBillingMethod
		/// <summary>
		/// Gets or sets the agent billing method.
		/// </summary>
		/// <value>The agent billing method.</value>
		public string AgentBillingMethod
		{
			get
			{
				return GetValue("AGENT_BILLING_METHOD");				
			}
			set
			{
				SetValue("AGENT_BILLING_METHOD", value);
			}
		}
		#endregion
		#region public string AgentPaymentType
		/// <summary>
		/// Gets or sets the type of the agent payment.
		/// </summary>
		/// <value>The type of the agent payment.</value>
		public string AgentPaymentType
		{
			get
			{
				return GetValue("AGENT_PAYMENT_TYPE");				
			}
			set
			{
				SetValue("AGENT_PAYMENT_TYPE", value);
			}
		}
		#endregion

		/// <summary>
		/// Gets the ahs segment children i.e. Insured/Risk Location etc.
		/// </summary>
		public IEnumerable<AhsSegment> AhsChildren
		{
			get
			{
				foreach (var segment in SegmentList)
				{
					if (segment is AhsSegment)
						yield return segment as AhsSegment;
				}
				yield break;
			}
		}


		#region public string GetAhsEnumerator
		/// <summary>
		/// Gets the ahs enumerator.
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetAhsEnumerator() 
		{ 
			_ahsSegments = new ArrayList();
			foreach (Segment segment in SegmentList)
			{
				if(segment.Name.Equals(Name))
				{
					_ahsSegments.Add(segment);
				}
			}
			return _ahsSegments.GetEnumerator();
		}
		#endregion
		#region public IEnumerator GetPolicyEnumerator
		/// <summary>
		/// Gets the policy enumerator.
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetPolicyEnumerator() 
		{ 
			_policySegments = new ArrayList();
			foreach (Segment segment in SegmentList)
			{
				if(segment.Name.Equals("POLICY"))
				{
					_policySegments.Add(segment);
				}
			}
			return _policySegments.GetEnumerator();
		}
		#endregion
		#region public override void SetParentKey
		/// <summary>
		/// Sets the parent key for all child objects
		/// BUGBUG: when moving to 2.0 replace the Arraylist
		/// with type-safe generics and built in iteration
		/// </summary>
		public override void SetParentKey(string key)
		{
			if (key.Length > 0 && Parent != null && !AhsId.Equals(key))
			{
				ParentNodeId = key;
			}
			if(AhsId.Length > 0)
			{
				// now propagate to children our key
				foreach(Segment segment in SegmentList)
				{
					segment.SetParentKey(AhsId);
				}
			}
		}
		#endregion

		/// <summary>
		/// Copies this instance (override this for ICloneable support of the superclasses.)
		/// </summary>
		/// <returns></returns>
		protected override CompositeBase Copy()
		{
			return new AhsSegment(this);
		}

		/// <summary>
		/// Compares the specified node.  N.B. for our purposes
		/// the segments are equal if the upload key is equal.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <returns></returns>
		protected override int Compare(CompositeBase node)
		{
			if (string.IsNullOrEmpty(UploadKey))
				return base.Compare(node);

			var source = node as AhsSegment;
			return source != null ? UploadKey.CompareTo(source.UploadKey) : 1;
		}

		/// <summary>
		/// Provide validation for the segment by overriding this method.
		/// </summary>
		protected override void ValidationMethod(object sender, EventArgs e)
		{
			Trace.WriteLine("ValidationMethod entered.", Name);

			if (Parent != null && Parent.Name != Name)
				throw new ApplicationException(string.Format("Parent must be of type: {0} not {1}",Name, Parent.Name));

			if(string.IsNullOrEmpty(UploadKey))
				throw new ApplicationException("Upload key is a required field.");
			if (!string.IsNullOrEmpty(AhsId))
				throw new ApplicationException("AhsId must be empty.");
			if (!IsNullOrLong(FileTranLogId))
				throw new ApplicationException("FileTranLogId is a numeric field: " + FileTranLogId);
			if (!IsNullOrLong(ParentNodeId))
				throw new ApplicationException("ParentNodeId is a numeric field: " + ParentNodeId);
			if (!string.IsNullOrEmpty(ClientNodeId) && !IsNullOrLong(ClientNodeId))
				throw new ApplicationException("ClientNodeId is a required numeric field.");
			if (!(State.Length == 0 || State.Length == 2))
				throw new ApplicationException("State must be 2 char code: " + State);

			if (Phone.Length > 0)
				Phone = (FormatPhoneField(Phone));

			if (Fax.Length > 0)
				Fax = (FormatPhoneField(Fax));

			if (AltPhone.Length > 0)
				AltPhone = (FormatPhoneField(AltPhone));

			if (AltFax.Length > 0)
				AltFax = (FormatPhoneField(AltFax));

			if (LocName.Length > 80)
				LocName = LocName.Substring(0, 80);
		}

	}
}

#region History
/*
 * $History: AhsSegment.cs $
 * 
 * *****************  Version 18  *****************
 * User: Gwynnj       Date: 9/21/10    Time: 6:30p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Created EntityBase to factor the IPerson interface
 * 
 * *****************  Version 17  *****************
 * User: Gwynnj       Date: 3/02/10    Time: 5:28p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * cleared out build warnings
 * 
 * *****************  Version 16  *****************
 * User: John.gwynn   Date: 10/29/09   Time: 1:11p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Moved ValidationMethod to base class as an override for adding
 * validation at the (sub)class definition.
 * 
 * *****************  Version 15  *****************
 * User: John.gwynn   Date: 10/28/09   Time: 5:21p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Removed redundant IAccountHeirarchyStep interface
 * 
 * *****************  Version 14  *****************
 * User: John.gwynn   Date: 10/27/09   Time: 6:57p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added AhsChildren as IEnumerable for linq support
 * 
 * *****************  Version 13  *****************
 * User: John.gwynn   Date: 9/30/09    Time: 6:36p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Implemented IComparable for composites adding a virtual Compare method
 * for specialized equality and sorting .e.g. see the AhsSegment where two
 * segments are deemed equal if their upload keys are equal.
 * 
 * *****************  Version 12  *****************
 * User: John.gwynn   Date: 9/29/09    Time: 5:12p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added Validation Event support for Composite in general and Segment
 * classes.
 * 
 * *****************  Version 11  *****************
 * User: John.gwynn   Date: 9/28/09    Time: 7:30p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * added some rudimentary formatting 
 * 
 * *****************  Version 10  *****************
 * User: John.gwynn   Date: 9/28/09    Time: 1:14p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added support for ICloneable
 * 
 * *****************  Version 9  *****************
 * User: John.gwynn   Date: 9/26/09    Time: 12:46p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added IAccountHierarchyStep interface
 * 
 * *****************  Version 8  *****************
 * User: Jenny.cheung Date: 8/12/08    Time: 1:37p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * rolled back
 * 
 * *****************  Version 7  *****************
 * User: Jenny.cheung Date: 8/11/08    Time: 12:59p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added Dissemination Flag due to Sedgwick' s Dissemination SOW
 * 
 * *****************  Version 6  *****************
 * User: Jenny.cheung Date: 11/06/07   Time: 5:19p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * 
 * *****************  Version 5  *****************
 * User: John.gwynn   Date: 10/21/07   Time: 8:17a
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Modified segment namespace started work on CallObject types
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 9/24/07    Time: 5:34p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * merged with 2003 changes
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
 * *****************  Version 5  *****************
 * User: John.gwynn   Date: 3/14/07    Time: 5:13p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * added SpecificDestinationFlag
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 2/27/07    Time: 3:24p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * Extended the AhsSegment class
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 2/21/07    Time: 4:16p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * added checks for null in operator ==
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 11/14/06   Time: 10:28a
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * Address3 had a typo that was fixed
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 10/27/06   Time: 5:06p
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * Segment class for the AHS table (InputProcessManager)
 */
#endregion
