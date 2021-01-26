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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/MessageObjectFactory.cs 2     5/04/09 3:55p John.gwynn $ */
#endregion
using System;
using System.Runtime.InteropServices;
using System.Xml;

namespace FnsComposite.MessageObjects
{
	/// <summary>
	/// Factory method pattern for MessageObject class instantiation 
	/// </summary>
	[ComVisible(false)]
	public class MessageObjectFactory : IMessageObjectFactory
	{
		/// <summary>
		/// Creates the message object.
		/// </summary>
		/// <param name="messageObjectXml">The message object XML.</param>
		/// <returns></returns>
		public virtual IMessageObject CreateMessageObject(string messageObjectXml)
		{
			try
			{
				XmlDocument document = new XmlDocument();
				document.LoadXml(messageObjectXml);
				IMessageObject obj = new MessageObject(document.DocumentElement);
				switch (obj.Name)
				{
					case "OutcomeStep":
						return new OutcomeStep(messageObjectXml);
					case "Outcome":
						return new Outcome(messageObjectXml);
					default:
						return obj;						
				}
			}
			catch (Exception ex)
			{
				throw new Exception("CreateMessageObject(): " + ex.Message, ex);
			}
		}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/MessageObjectFactory.cs $
 * 
 * 2     5/04/09 3:55p John.gwynn
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * 1     6/11/07 5:01p John.gwynn
 * messageObjects source state managers for Opm
 */
#endregion