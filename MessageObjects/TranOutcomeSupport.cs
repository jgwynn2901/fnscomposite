using System;

namespace FnsComposite.MessageObjects
{
    /// <summary>
    /// This class mimics the legacy TranOutcomeSupport message 
    /// and is used for communication with the OutcomeViewer.
    /// </summary>
    public class TranOutcomeSupport : Composite
    {
        private readonly string[] _fields = {
                                      "CREATE_TIME",
                                      "IDLE_SPEED",
                                      "LAST_IDLE",
                                      "MODULE",
                                      "START_TIME",
                                      "TRAN_DONE",
                                      "TRAN_FAILED",
                                      "MAIN_THREAD_ID",
                                      "PROCESS_ID"
                                  };

        /// <summary>
        /// Initializes a new instance of the <see cref="TranOutcomeSupport"/> class.
        /// </summary>
        public TranOutcomeSupport() : base("TRAN_OUTCOME_SUPPORT")
        {
            AddLeafNode(new DefaultValueLeaf(_fields[0], DateTime.Now.ToString()));
            Add(_fields[1], string.Empty);
            Add(_fields[2], string.Empty);
            Add(_fields[3], string.Empty);
            AddLeafNode(new DefaultValueLeaf(_fields[4], DateTime.Now.ToString()));
            Add(_fields[5], string.Empty);
            Add(_fields[6], string.Empty);
            Add(_fields[7], string.Empty);
            Add(_fields[8], string.Empty);
            base.Commit();
        }

        /// <summary>
        /// Gets or sets the idle speed.
        /// </summary>
        public string CreateTime { get { return GetValue(_fields[0]); } }

        /// <summary>
        /// Gets or sets the idle speed.
        /// </summary>
        /// <value>The idle speed.</value>
        public string IdleSpeed { get { return GetValue(_fields[1]); } set { SetValue(_fields[1], value); } }

        /// <summary>
        /// Gets or sets the last idle.
        /// </summary>
        /// <value>The last idle.</value>
        public string LastIdle { get { return GetValue(_fields[2]); } set { SetValue(_fields[2], value); } }

        /// <summary>
        /// Gets or sets the module.
        /// </summary>
        public string Module { get { return GetValue(_fields[3]); } set { SetValue(_fields[3], value); } }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        public string StartTime { get { return GetValue(_fields[4]); } set { SetValue(_fields[4], value); } }

        /// <summary>
        /// Gets or sets the tran done.
        /// </summary>
        public string TranDone { get { return GetValue(_fields[5]); } set { SetValue(_fields[5], value); } }

        /// <summary>
        /// Gets or sets the tran failed.
        /// </summary>
        public string TranFailed { get { return GetValue(_fields[6]); } set { SetValue(_fields[6], value); } }

        /// <summary>
        /// Gets or sets the main thread id.
        /// </summary>
        public string MainThreadId { get { return GetValue(_fields[7]); } set { SetValue(_fields[7], value); } }

        /// <summary>
        /// Gets or sets the process id.
        /// </summary>
        public string ProcessId { get { return GetValue(_fields[8]); } set { SetValue(_fields[8], value); } }
    }
}
