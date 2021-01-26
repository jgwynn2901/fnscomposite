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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/IMessageObjectFactory.cs 1     6/11/07 5:01p John.gwynn $ */
#endregion
namespace FnsComposite.MessageObjects
{
	/// <summary>
	/// Manages creation of MessageObject based classes from Xml
	/// </summary>
	public interface IMessageObjectFactory
	{
		/// <summary>
		/// Creates the message object.
		/// </summary>
		/// <param name="messageObjectXml">The message object XML.</param>
		/// <returns></returns>
		IMessageObject CreateMessageObject(string messageObjectXml);
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/IMessageObjectFactory.cs $
 * 
 * 1     6/11/07 5:01p John.gwynn
 * messageObjects source state managers for Opm
 */
#endregion