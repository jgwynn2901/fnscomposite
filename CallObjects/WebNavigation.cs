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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/WebNavigation.cs 3     9/13/11 2:12p Sharmad $ */
#endregion

using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Web Navigation records
	/// </summary>
	public class WebNavigation  : CallObjectBase, IWebNavigation
	{
		private const string NodeTypeName = "WEB_NAVIGATION";
		/// <summary>
		/// Initializes a new instance of the <see cref="WebNavigation"/> class.
		/// </summary>
		public WebNavigation(): base(NodeTypeName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="WebNavigation"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public WebNavigation(XmlNode node) : base (node)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="WebNavigation"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="indexedName">Overrides for types with indexes i.e. WEB_NAVIGATION[0]</param>
		public WebNavigation(XmlNode node, string indexedName) : base (node, indexedName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="WebNavigation"/> class.
		/// </summary>
		/// <param name="indexName">Name of the index.</param>
		public WebNavigation(string indexName): base(NodeTypeName+indexName)
		{}

		#region IWebNavigation Members

		/// <summary>
		/// Gets or sets the name of the page.
		/// </summary>
		/// <value>The name of the page.</value>
		public string PageName
		{
			get { return GetValue("PAGE_NAME"); }
			set { SetValue("PAGE_NAME", value); }
		}

		/// <summary>
		/// Gets or sets the time stamp.
		/// </summary>
		/// <value>The time stamp.</value>
		public string TimeStamp
		{
			get { return GetValue("TIME_STAMP"); }
			set { SetValue("TIME_STAMP", value); }
		}

        public string TimeStampBegin
        {
            get { return GetValue("TIME_STAMP_BEGIN"); }
            set { SetValue("TIME_STAMP_BEGIN", value); }
        }

		/// <summary>
		/// Gets or sets the call id.
		/// </summary>
		/// <value>The call id.</value>
		public string CallId
		{
            get { return GetValue(CallObject.CallIdAttributeName); }
            set { SetValue(CallObject.CallIdAttributeName, value); }
		}

		#endregion
	}
}
