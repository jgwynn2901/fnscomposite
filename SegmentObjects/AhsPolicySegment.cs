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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/AhsPolicySegment.cs 10    1/06/10 6:43p Gwynnj $ */
#endregion

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using FnsComposite.CallObjects;
using IPolicy=FnsComposite.Interfaces.IPolicy;

namespace FnsComposite.SegmentObjects
{
	/// <summary>
	/// AhsPolicySegment encapsulated data assigned to AHS_POLICY table 
	/// for InputProcessManager segment loader processing.  AhsPolicySegment
	/// will usually be associated to (child of)a PolicySegment which will
	/// manage assigning the correct AhsSegment Fk
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]	
	public class AhsPolicySegment : Segment
	{
		private const string ParentAhsName = "ACCOUNT_HIERARCHY_STEP";
		private const string ParentPolicyName = "POLICY";
		/// <summary>
		/// Initializes a new instance of the <see cref="AhsPolicySegment"/> class.
		/// </summary>
		public AhsPolicySegment() :base("AHS_POLICY")
		{
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="AhsPolicySegment"/> class from an IPolicy.
		/// </summary>
		/// <param name="rec">The rec.</param>
		public AhsPolicySegment(IPolicy rec): this()
		{
			AhsId = rec.AhsId;
			LineOfBusiness = rec.LineOfBusiness;
			ActiveStartDate = rec.EffectiveDate;
			ActiveEndDate = rec.ExpirationDate;
		}
		
		#region AhsPolicyId
		/// <summary>
		/// Gets the ahs id.
		/// </summary>
		/// <value>The ahs id.</value>
		public string AhsPolicyId
		{
			get
			{
				return GetValue("AHS_POLICY_ID");
			}
			set
			{
				SetValue("AHS_POLICY_ID", value);
			}
		}
		#endregion
		#region AhsId
		/// <summary>
		/// Gets or sets the ahs id.
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
		#region PolicyId
		/// <summary>
		/// Gets or sets the policy id.
		/// </summary>
		/// <value>The policy id.</value>
		public string PolicyId
		{
			get
			{
				return GetValue("POLICY_ID");				
			}
			set
			{
				SetValue("POLICY_ID", value);
			}
		}
		#endregion
		#region LineOfBusiness
		/// <summary>
		/// Gets or sets the line of business.
		/// </summary>
		/// <value>The line of business.</value>
		public string LineOfBusiness
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
		#region ActiveStartDate
		/// <summary>
		/// Gets or sets the active start date.
		/// </summary>
		/// <value>The active start date.</value>
		public string ActiveStartDate
		{
			get
			{
				return GetValue("ACTIVE_START_DT");				
			}
			set
			{
				SetValue("ACTIVE_START_DT", value);
			}
		}
		#endregion
		#region ActiveEndDate
		/// <summary>
		/// Gets or sets the active end date.
		/// </summary>
		/// <value>The active end date.</value>
		public string ActiveEndDate
		{
			get
			{
				return GetValue("ACTIVE_END_DT");				
			}
			set
			{
				SetValue("ACTIVE_END_DT", value);
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
			if (key.Length > 0)
			{
				if (Parent.Name.Equals(ParentAhsName))
				{
					AhsId = key;
				}
				else if (Parent.Name.Equals("POLICY"))
				{
					PolicyId = key;
					AhsId = ((PolicySegment) Parent).AhsId;
				}
				else if (Parent.Name.Equals("AHS_POLICY")) // we can chain multiple instances
				{
					PolicyId = ((AhsPolicySegment) Parent).PolicyId;
					AhsId = ((AhsPolicySegment) Parent).AhsId;
				}
				else
				{
					throw new ApplicationException(string.Format("AhsPolicySegment SetParentKey unsupported parent segment {0}",
					                                             Parent.Name));
				}
			}
		}
		/// <summary>
		/// Clears the parent key.
		/// </summary>
		public override void ClearParentKey()
		{
			AhsId = string.Empty;
			PolicyId = string.Empty;
		}
		/// <summary>
		/// Clears the key.
		/// </summary>
		public override void ClearKey()
		{
			AhsPolicyId = string.Empty;
		}

		/// <summary>
		/// Validations for the policy record data.
		/// </summary>
		protected override void ValidationMethod(object sender, EventArgs e)
		{
			Trace.WriteLine("ValidationMethod entered.", Name);

			if (Parent == null)
				throw new ApplicationException(string.Format("Parent is missing for type: {0}", Name)); 

			if (Parent.Name != ParentPolicyName && Parent.Name != ParentAhsName)
				throw new ApplicationException(string.Format("Parent must be of type: {0} or {1} not {2}", 
					ParentPolicyName, ParentAhsName, Parent.Name));

			if (string.IsNullOrEmpty(LineOfBusiness))
				throw new ApplicationException("LineOfBusiness is a required field.");
			if (string.IsNullOrEmpty(ActiveStartDate))
				throw new ApplicationException("ActiveStartDate is a required field.");
			if (string.IsNullOrEmpty(ActiveEndDate))
				throw new ApplicationException("ActiveEndDate is a required field.");
			if (!IsNullOrDateTime(ActiveStartDate))
				throw new ApplicationException("ActiveStartDate is a date field: " + ActiveStartDate);
			if (!IsNullOrDateTime(ActiveEndDate))
				throw new ApplicationException("ActiveEndDate is a date field: " + ActiveEndDate);
			if (!IsNullOrLong(FileTranLogId))
				throw new ApplicationException("FileTranLogId is a numeric field: " + FileTranLogId);
		}
	}
}

#region History
/*
 * $History: AhsPolicySegment.cs $
 * 
 * *****************  Version 10  *****************
 * User: Gwynnj       Date: 1/06/10    Time: 6:43p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added several constants for CallObject namespace
 * 
 * *****************  Version 9  *****************
 * User: John.gwynn   Date: 11/03/09   Time: 3:01p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * fixed a bug in AhsPolicySegment.SetParentKey
 * 
 * *****************  Version 8  *****************
 * User: John.gwynn   Date: 10/29/09   Time: 1:11p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Moved ValidationMethod to base class as an override for adding
 * validation at the (sub)class definition.
 * 
 * *****************  Version 7  *****************
 * User: John.gwynn   Date: 9/29/09    Time: 5:12p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added Validation Event support for Composite in general and Segment
 * classes.
 * 
 * *****************  Version 6  *****************
 * User: Jenny.cheung Date: 11/06/07   Time: 5:19p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * 
 * *****************  Version 5  *****************
 * User: John.gwynn   Date: 9/24/07    Time: 5:34p
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
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 2/21/07    Time: 2:36p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * allow for multiple segments
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 11/16/06   Time: 5:20p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * Added NDoc comments and formatting
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 10/27/06   Time: 5:06p
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * Segment class for the AHS_POLICY table (InputProcessManager)
 */
#endregion
