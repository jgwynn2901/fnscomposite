using System.Runtime.InteropServices;

namespace FnsComposite.SegmentObjects
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Jurisdiction state segment. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    [ClassInterface(ClassInterfaceType.None), ComVisible(false)]
    public class JurisdictionStateSegment : Segment
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public JurisdictionStateSegment() : base("JURISDICTION_STATE")
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the policy. </summary>
        ///
        /// <value> The identifier of the policy. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the state. </summary>
        ///
        /// <value> The state. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the file transaction log. </summary>
        ///
        /// <value> The identifier of the file transaction log. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
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

        /// <summary>
        /// Sets the parent key.
        /// </summary>
        public override void SetParentKey(string key)
        {
                SetValue("POLICY_ID", key);
        }

    }
}
