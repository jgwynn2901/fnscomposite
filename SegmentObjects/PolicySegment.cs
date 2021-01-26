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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/PolicySegment.cs 9     1/06/10 6:43p Gwynnj $ */
#endregion

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using FnsComposite.CallObjects;
using IPolicy = FnsComposite.Interfaces.IPolicy;

namespace FnsComposite.SegmentObjects
{
    /// <summary>
    /// PolicySegment encapsulated data assigned to POLICY table 
    /// for InputProcessManager segment loader processing.  PolicySegment
    /// will usually be associated to (child of)a AhsSegment which will
    /// manage assigning the correct AhsSegment Fk
    /// </summary>
    [ClassInterface(ClassInterfaceType.None), ComVisible(false)]
    public class PolicySegment : Segment, IPolicy
    {
        private const string ParentName = "ACCOUNT_HIERARCHY_STEP";
        /// <summary>
        /// Initializes a new instance of the <see cref="PolicySegment"/> class.
        /// </summary>
        public PolicySegment()
            : base("POLICY")
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PolicySegment"/> class.
        /// </summary>
        /// <param name="rec">The rec.</param>
        public PolicySegment(IPolicy rec)
            : this()
        {
            AhsId = rec.AhsId;
            LineOfBusiness = rec.LineOfBusiness;
            CarrierId = rec.CarrierId;
            AgentId = rec.AgentId;
            CompanyCode = rec.CompanyCode;
            PolicyNumber = rec.PolicyNumber;
            EffectiveDate = rec.EffectiveDate;
            ExpirationDate = rec.ExpirationDate;
            Description = rec.Description;
            CoverageCodes = rec.CoverageCodes;
            PolicyType = rec.PolicyType;
            DivisionCode = rec.DivisionCode;
            FileTranLogId = rec.FileTranLogId;
            UploadKey = rec.UploadKey;
            //OriginalEffectiveDate = rec.OriginalEffectiveDate;
            //CancellationDate = rec.CancellationDate;
        }

        #region PolicyId
        /// <summary>
        /// Gets the policy id.
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
        #region CarrierId
        /// <summary>
        /// Gets or sets the carrier id.
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
        #region AgentId
        /// <summary>
        /// Gets or sets the agent id.
        /// </summary>
        /// <value>The agent id.</value>
        public string AgentId
        {
            get
            {
                return GetValue("AGENT_ID");
            }
            set
            {
                SetValue("AGENT_ID", value);
            }
        }
        #endregion
        #region CompanyCode
        /// <summary>
        /// Gets or sets the company code.
        /// </summary>
        /// <value>The company code.</value>
        public string CompanyCode
        {
            get
            {
                return GetValue("COMPANY_CODE");
            }
            set
            {
                SetValue("COMPANY_CODE", value);
            }
        }
        #endregion
        #region PolicyNumber
        /// <summary>
        /// Gets or sets the policy number.
        /// </summary>
        /// <value>The policy number.</value>
        public string PolicyNumber
        {
            get
            {
                return GetValue("POLICY_NUMBER");
            }
            set
            {
                SetValue("POLICY_NUMBER", value);
            }
        }
        #endregion
        #region EffectiveDate
        /// <summary>
        /// Gets or sets the effective date.
        /// </summary>
        /// <value>The effective date.</value>
        public string EffectiveDate
        {
            get
            {
                return GetValue("EFFECTIVE_DATE");
            }
            set
            {
                SetValue("EFFECTIVE_DATE", value);
            }
        }
        #endregion
        #region ExpirationDate
        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>The expiration date.</value>
        public string ExpirationDate
        {
            get
            {
                return GetValue("EXPIRATION_DATE");
            }
            set
            {
                SetValue("EXPIRATION_DATE", value);
            }
        }
        #endregion
        #region Description
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get
            {
                return GetValue("POLICY_DESC");
            }
            set
            {
                SetValue("POLICY_DESC", value);
            }
        }
        #endregion
        #region CoverageCodes
        /// <summary>
        /// Gets or sets the coverage codes.
        /// </summary>
        /// <value>The coverage codes.</value>
        public string CoverageCodes
        {
            get
            {
                return GetValue("POLICY_COV_CODES");
            }
            set
            {
                SetValue("POLICY_COV_CODES", value);
            }
        }
        #endregion
        #region PolicyType
        /// <summary>
        /// Gets or sets the type of the policy.
        /// </summary>
        /// <value>The type of the policy.</value>
        public string PolicyType
        {
            get
            {
                return GetValue("POLICY_TYPE");
            }
            set
            {
                SetValue("POLICY_TYPE", value);
            }
        }
        #endregion
        #region DivisionCode
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
        #region FileTranLogId
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

        //public string OriginalEffectiveDate
        //{
        //    get
        //    {
        //        return GetValue("ORIGINAL_EFFECTIVE_DATE");
        //    }
        //    set
        //    {
        //        SetValue("ORIGINAL_EFFECTIVE_DATE", value);
        //    }
        //}

        //public string CancellationDate
        //{
        //    get
        //    {
        //        return GetValue("CANCELLATION_DATE");
        //    }
        //    set
        //    {
        //        SetValue("CANCELLATION_DATE", value);
        //    }
        //}

        /// <summary>
        /// Sets the parent key for all child objects
        /// BUGBUG: when moving to 2.0 replace the Arraylist
        /// with type-safe generics and built in iteration
        /// </summary>
        public override void SetParentKey(string key)
        {
            // either we are being called by our parent
            if (key.Length > 0 && AhsId.Length == 0)
            {
                if (Parent.Name.Equals("ACCOUNT_HIERARCHY_STEP"))
                {
                    AhsId = key;
                }
                else if (Parent.Name.Equals("CARRIER"))
                {
                    CarrierId = key;
                    AhsId = ((CarrierSegment)Parent).AhsId;
                }
                else
                {
                    throw new ApplicationException(string.Format("PolicySegment SetParentKey unsupported parent segment {0}",
                                                                 Parent.Name));
                }
            }
            // or are propagating to our children
            if (PolicyId.Length > 0)
            {
                foreach (Segment segment in SegmentList)
                {
                    segment.SetParentKey(PolicyId);
                }
            }
        }
        /// <summary>
        /// Clears the parent key.
        /// </summary>
        public override void ClearParentKey()
        {
            AhsId = string.Empty;
            CarrierId = string.Empty;
        }
        /// <summary>
        /// Clears the key.
        /// </summary>
        public override void ClearKey()
        {
            PolicyId = string.Empty;
        }

        /// <summary>
        /// Validations for the policy record data.
        /// </summary>
        protected override void ValidationMethod(object sender, EventArgs e)
        {
            Trace.WriteLine("ValidationMethod entered.", Name);

            if (Parent == null)
                throw new ApplicationException(string.Format("Parent is missing for type: {0}", Name));

            if (!(Parent.Name == ParentName || Parent.Name == "CARRIER"))
                throw new ApplicationException(string.Format("Parent must be of type: {0} not {1}", ParentName, Parent.Name));

            if (string.IsNullOrEmpty(UploadKey))
                throw new ApplicationException("Upload key is a required field.");
            if (string.IsNullOrEmpty(EffectiveDate))
                throw new ApplicationException("Effective Date is a required field.");
            if (string.IsNullOrEmpty(ExpirationDate))
                throw new ApplicationException("Expiration Date is a required field.");
            if (!IsNullOrDateTime(EffectiveDate))
                throw new ApplicationException("Effective Date is a date field: " + EffectiveDate);
            if (!IsNullOrDateTime(ExpirationDate))
                throw new ApplicationException("Expiration Date is a date field: " + ExpirationDate);
            if (!IsNullOrLong(CarrierId))
                throw new ApplicationException("CarrierId is a numeric field: " + CarrierId);

        }
    }
}

#region History
/*
 * $History: PolicySegment.cs $
 * 
 * *****************  Version 9  *****************
 * User: Gwynnj       Date: 1/06/10    Time: 6:43p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added several constants for CallObject namespace
 * 
 * *****************  Version 8  *****************
 * User: John.gwynn   Date: 10/29/09   Time: 1:11p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Moved ValidationMethod to base class as an override for adding
 * validation at the (sub)class definition.
 * 
 * *****************  Version 7  *****************
 * User: John.gwynn   Date: 10/27/09   Time: 1:18p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * bug with validation for Policy segment can have Carrier as a parent
 * 
 * *****************  Version 6  *****************
 * User: John.gwynn   Date: 9/29/09    Time: 5:12p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added Validation Event support for Composite in general and Segment
 * classes.
 * 
 * *****************  Version 5  *****************
 * User: John.gwynn   Date: 9/26/09    Time: 12:46p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added IAccountHierarchyStep interface
 * 
 * *****************  Version 4  *****************
 * User: Jenny.cheung Date: 11/07/07   Time: 9:13a
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 10/21/07   Time: 8:17a
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Modified segment namespace started work on CallObject types
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 9/24/07    Time: 5:35p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * merged with 2003 changes
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 7/10/07    Time: 5:37p
 * Created in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * updates to SegmentObjects folder
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
 * User: John.gwynn   Date: 10/27/06   Time: 5:07p
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * Segment class for the POLICY table (InputProcessManager)
 */
#endregion