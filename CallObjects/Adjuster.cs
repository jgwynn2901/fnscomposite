#region Header
/**************************************************************************
* First Notice Systems
* 95 Wells Avenue
* Newton, MA 02459
* (617) 886-2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 2008 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Adjuster.cs 2     10/12/11 3:03p Gwynnj $ */
#endregion

using System.Xml;


namespace FnsComposite.CallObjects
{
    /// <summary>
    /// CallObject eSurance STAFF implementation
    /// </summary>
    
    public class Adjuster : CallObjectBase, IAdjuster
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Estar"/> class.
        /// </summary>
        public Adjuster()
            : base("ADJUSTER")
        { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Estar"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public Adjuster(XmlNode node)
            : base(node)
        { }

        public Adjuster(XmlNode node, string indexedName) : base (node, indexedName)
		{}

        public Adjuster(string indexName)
			: base("ADJUSTER" + indexName)
		{}

        #region IAdjuster Members

       

        /// <summary>
        /// Gets or sets the name of the shop.
        /// </summary>
        /// <value>The name of the shop.</value>
        public string AdjusterName
        {
            get { return GetValue("NAME"); }
            set { SetValue("NAME", value); }
        }
        public string Email
        {
            get { return GetValue("EMAIL"); }
            set { SetValue("EMAIL", value); }
        }
        public string Phone
        {
            get { return GetValue("PHONE"); }
            set { SetValue("PHONE", value); }
        }
        public string Schedule
        {
            get { return GetValue("SCHEDULE"); }
            set { SetValue("SCHEDULE", value); }
        }
        public string Branch
        {
            get { return GetValue("BRANCH"); }
            set { SetValue("BRANCH", value); }
        }
        public string TimeZone
        {
            get { return GetValue("TIMEZONE"); }
            set { SetValue("TIMEZONE", value); }
        }
        public string Primary
        {
            get { return GetValue("PRIMARY"); }
            set { SetValue("PRIMARY", value); }
        }
       

        #endregion
    }
   }
