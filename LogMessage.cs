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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/LogMessage.cs 2     5/04/09 3:55p John.gwynn $ */
#endregion

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace FnsComposite
{
	/// <summary>
	/// Summary description for LogMessage.
	/// </summary>
	[ComVisible(false)]
	public class LogMessage : Composite
	{
		private ArrayList _messageList = new ArrayList();
		/// <summary>
		/// Initializes a new instance of the <see cref="LogMessage"/> class.
		/// </summary>
		public LogMessage() :this(string.Empty) {}
		/// <summary>
		/// Initializes a new instance of the <see cref="LogMessage"/> class.
		/// </summary>
		/// <param name="xml">The XML.</param>
		public LogMessage(string xml) : base ("MESSAGE_LIST")
		{
			try
			{
				XmlDocument document = new XmlDocument();
				document.LoadXml(xml);

				// BUGBUG: add check for CALL node
				ReloadFromXML(document.DocumentElement);
			}
			catch(Exception ex)
			{
				//m_oErrLog.log("LoadFromXML(): " + ex.Message, 3, m_strServiceName);
				//Re-throw outside
				//throw new Exception(, ex);
				Trace.WriteLine("PolicyLoader() constructor: " + ex.Message);
			}
		}
		/// <summary>
		/// Adds the message.
		/// </summary>
		/// <param name="component">The component.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		public bool AddMessage (string component, string message)
		{
			_messageList.Add( new Message(component, message));
			return true;
		}
		/// <summary>
		/// Gets the messages.
		/// </summary>
		/// <returns></returns>
		public new IEnumerator GetEnumerator()
		{
			return _messageList.GetEnumerator();
		}
		/// <summary>
		/// convert to string in xml format
		/// </summary>
		/// <returns></returns>
		public override string ToXml()
		{
			StringBuilder results = new StringBuilder();

			results.Append("<");
			results.Append(m_name);
			results.Append(">");
			
			foreach (Message message in _messageList)
			{
				results.Append(message.ToXml());
			}
			results.Append("</");
			results.Append(m_name);
			results.Append(">");

			return results.ToString();
		}
	}
}
#region History
/*
 * $History: LogMessage.cs $
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
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 5/10/07    Time: 6:08p
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * Added support for messages in the PolicyLoader
 */
#endregion