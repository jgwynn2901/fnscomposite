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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/IMessageObject.cs 5     9/27/07 6:49p John.gwynn $ */
#endregion

namespace FnsComposite.MessageObjects
{
	/// <summary>
	/// Minimum interface for message based composite classes
	/// BUGBUG: investigate the idea of ExtensibleObjects
	/// </summary>
	public interface IMessageObject
	{
		/// <summary>
		/// Gets or sets the action.
		/// </summary>
		/// <value>The action.</value>
		string Action { get; set; }
		/// <summary>
		/// Gets or sets the instance.
		/// </summary>
		/// <value>The instance.</value>
		string Instance { get; set;}
		/// <summary>
		/// Gets the create date time.
		/// </summary>
		/// <value>The create date time.</value>
		string CreateDateTime { get;}
		/// <summary>
		/// Gets or sets the source.
		/// </summary>
		/// <value>The source.</value>
		string Source { get; set; }
		/// <summary>
		/// Gets or sets the destination.
		/// </summary>
		/// <value>The destination.</value>
		string Destination { get; set; }
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		string Name { get; }
		/// <summary>
		/// Gets the objects defined id.
		/// </summary>
		/// <value>The id.</value>
		string Id { get; }
		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		string Status { get; set;}
		/// <summary>
		/// Gets or sets the last error.
		/// </summary>
		/// <value>The last error.</value>
		string LastError { get; set; }
		/// <summary>
		/// Sends this instance to the Destination queue.
		/// </summary>
		/// <returns></returns>
		bool Send();
		/// <summary>
		/// Sends the object to a queue directly.
		/// </summary>
		/// <param name="queue">The queue.</param>
		/// <returns></returns>
		bool SendDirect(string queue);
		/// <summary>
		/// Receives this instance from the Destination queue.
		/// </summary>
		/// <returns></returns>
		bool Receive();
		/// <summary>
		/// Receives the object from a specified queue directly.
		/// </summary>
		/// <param name="queue">The queue.</param>
		/// <returns></returns>
		bool ReceiveDirect(string queue);
		/// <summary>
		/// Updates the state.
		/// </summary>
		/// <param name="state">The state.</param>
		/// <returns></returns>
		bool UpdateState(IMessageObject state);
		/// <summary>
		/// serialize to XML.
		/// </summary>
		/// <returns></returns>
		string ToXml();
		/// <summary>
		/// Touches this instance.
		/// </summary>
		void Touch();
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/IMessageObject.cs $
 * 
 * 5     9/27/07 6:49p John.gwynn
 * 
 * 4     8/02/07 5:16p John.gwynn
 * Update bugs from OPM work andthe SetValue o Empty string is more
 * robust...
 * 
 * 3     6/14/07 3:44p John.gwynn
 * updates for Outcome and Outcome step and new Subscription message
 */
#endregion