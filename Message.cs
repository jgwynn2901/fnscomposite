#region Header
/**************************************************************************
* First Notice Systems
* 95 Wells Avenue
* Newton, MA 02459
* (617) 886-2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 2007 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Message.cs 2     5/04/09 3:55p John.gwynn $ */
#endregion

using System;
using System.Runtime.InteropServices;

namespace FnsComposite
{
	/// <summary>
	/// Summary description for Message.
	/// </summary>
	[ComVisible(false)]
	public class Message : Composite
	{
		private const string _messageName = "MESSAGE";
		private const string _messageBody = "LOG_MESSAGE";
		private const string _componentName = "COMPONENT_NAME";
		/// <summary>
		/// Initializes a new instance of the <see cref="Message"/> class.
		/// </summary>
		/// <param name="component">The component.</param>
		/// <param name="message">The message.</param>
		public Message(string component, string message) : base(_messageName)
		{
			Add(_componentName, component);
			Add(_messageBody, message);
		}
		/// <summary>
		/// Gets the body.
		/// </summary>
		/// <value>The body.</value>
		public string MessageBody
		{
			get
			{
				if(this[_messageBody] != null)
				{
					return this[_messageBody].Value;
				}
				return string.Empty;
			}
		}
		/// <summary>
		/// Gets the component.
		/// </summary>
		/// <value>The component.</value>
		public string Component
		{
			get
			{
				if(this[_componentName] != null)
				{
					return this[_componentName].Value;
				}
				return string.Empty;
			}
		}
	}
}
#region History
/*
 * $History: Message.cs $
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 5/04/09    Time: 3:55p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * *****************  Version 1  *****************
 * User: Jenny.cheung Date: 11/07/07   Time: 9:14a
 * Created in $/SourceCode/Components/FNS2005/FnsComposite
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 5/18/07    Time: 11:48a
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * modified MESSAGE component names to correspond with legacy version
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 5/10/07    Time: 6:08p
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * Added support for messages in the PolicyLoader
 */
#endregion