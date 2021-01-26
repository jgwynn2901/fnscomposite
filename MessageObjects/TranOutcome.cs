using System;

namespace FnsComposite.MessageObjects
{
    /// <summary>
    /// This class mimics the legacy TranOutcome message 
    /// and is used for communication with the OutcomeViewer.
    /// </summary>
    public class TranOutcome : Composite
    {
        private readonly string[] _fields = {
                                      "CREATE_TIME",
                                      "ACTION",
                                      "TRAN_OUTCOME_ID",
                                      "CALL_ID",
                                      "STATUS",
                                      "TYPE",
                                      "LAST_ERROR",
                                      "START_TIME",
                                      "LAST_MOD_TIME"
                                  };
        /// <summary>
        /// Initializes a new instance of the <see cref="TranOutcome"/> class.
        /// </summary>
        public TranOutcome() : base ("TRAN_OUTCOME")
        {
            AddXmlAttribute("type", "SUBSCRIPTION");
            AddLeafNode(new DefaultValueLeaf(_fields[0], DateTime.Now.ToString()));
            AddLeafNode(new DefaultValueLeaf(_fields[1], "SUBSCRIBE"));
            Add(_fields[2], string.Empty);
            Add(_fields[3], string.Empty);
            AddLeafNode(new DefaultValueLeaf(_fields[4], "UNPROCESSED"));
            Add(_fields[5], string.Empty);
            Add(_fields[6], string.Empty);
            AddLeafNode(new DefaultValueLeaf(_fields[7], DateTime.Now.ToString()));
            AddLeafNode(new DefaultValueLeaf(_fields[8], DateTime.Now.ToString()));
            base.Commit();
        }

        /// <summary>
        /// Gets or sets the CreateTime.
        /// </summary>
        public string CreateTime { get { return GetValue(_fields[0]); } }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        public string Action { get { return GetValue(_fields[1]); } set { SetValue(_fields[1], value); } }

        /// <summary>
        /// Gets or sets the tran outcome id.
        /// </summary>
        public string TranOutcomeId { get { return GetValue(_fields[2]); } set { SetValue(_fields[2], value); } }

        /// <summary>
        /// Gets or sets the call id.
        /// </summary>
        public string CallId { get { return GetValue(_fields[3]); } set { SetValue(_fields[3], value); } }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get { return GetValue(_fields[4]); }
            set 
            {
                Remove(_fields[4]); 
                SetValue(_fields[4], value); 
            }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get { return GetValue(_fields[5]); } set { SetValue(_fields[5], value); } }

        /// <summary>
        /// Gets or sets the last error meesage.
        /// </summary>
        public new string LastError { get { return GetValue(_fields[6]); } set { SetValue(_fields[6], value); } }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        public string StartTime { get { return GetValue(_fields[7]); }
            set
            {
                Remove(_fields[7]);
                SetValue(_fields[7], value);
            }
        }

        /// <summary>
        /// Gets or sets the last mod time.
        /// </summary>
        public string LastModTime { get { return GetValue(_fields[8]); }
            set
            {
                Remove(_fields[8]);
                SetValue(_fields[8], value);
            }
        }

    }
}
