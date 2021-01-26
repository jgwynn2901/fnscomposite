using System.Xml;

namespace FnsComposite.CallObjects
{
    public class Role : CallObjectBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvolvedParty"/> class.
        /// </summary>
        public Role(int index)
            : base("Role["+ index + "]")
		{}

        /// <summary>
        /// Initializes a new instance of the <see cref="InvolvedParty"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public Role(XmlNode node)
            : base(node)
		{}

        public string AssignedRole
        {
            get { return GetValue("AssignedRole"); }
            set { SetValue("AssignedRole", value); }
        }
    }
}
