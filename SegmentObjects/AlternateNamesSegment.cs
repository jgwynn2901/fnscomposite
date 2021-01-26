using System;
using System.Runtime.InteropServices;
using FnsComposite.SegmentObjects;


namespace FnsComposite
{
    /// <summary>
    /// Alternate Name Segment
    /// </summary>
	[ComVisible(false)]
	public class AlternateNamesSegment : Segment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlternateNamesSegment"/> class.
        /// </summary>
        public AlternateNamesSegment():base ("ALTERNATE_NAME")
        {}

        #region AltNameId
        /// <summary>
        /// Gets or sets the alt name id.
        /// </summary>
        /// <value>The alt name id.</value>
        public string AltNameId
        {
            get
            {
                return GetValue("ALTERNATE_NAME_ID");

            }
            set
            {
                SetValue("ALTERNATE_NAME_ID", value);
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

        #region AltName
        /// <summary>
        /// Gets or sets the name of the alt.
        /// </summary>
        /// <value>The name of the alt.</value>
        public string AltName
        {
            get
            {
                return GetValue("NAME");

            }
            set
            {
                SetValue("NAME",value);
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

        #region SequenceNumber

        /// <summary>
        /// Gets or sets the sequence number.
        /// </summary>
        /// <value>The sequence number.</value>
        public string SequenceNumber
        {
            get
            {
                return GetValue("SEQUENCE_NUMBER");
            }
            set
            {
                SetValue("SEQUENCE_NUMBER", value);
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
            if (AltNameId.Length > 0)
            {
                // now propagate to children our key
                foreach (Segment segment in SegmentList)
                {
                    segment.SetParentKey(AltNameId);
                }
            }
        }



    }
}