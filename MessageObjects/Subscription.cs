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
*
* Created by: John Gwynn
* Created: Tuesday, June 12, 2007
***************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/Subscription.cs 4     5/04/09 3:55p John.gwynn $ */
#endregion

using System;
using System.Runtime.InteropServices;

namespace FnsComposite.MessageObjects
{
	/// <summary>
	/// generic message object to subscribe or unsubscribe to a particular message 
	/// type and (optional) state
	/// </summary>
	[ComVisible(false)]
	class Subscription : MessageObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Subscription"/> class.
		/// </summary>
		public Subscription() : this(string.Empty)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Subscription"/> class.
		/// </summary>
		/// <param name="outcomeXml">The outcome XML.</param>
		public Subscription(string outcomeXml) : base("Subscription")
		{
			if (outcomeXml.Length > 0)
			{
				LoadFromXml(outcomeXml);
			}
		}
		/// <summary>
		/// Gets or sets the event.
		/// </summary>
		/// <value>The event.</value>
		public string Event
		{
			get { return GetValue("Event"); }
			set { SetValue("Event", value); }
		}

	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/Subscription.cs $
 * 
 * 4     5/04/09 3:55p John.gwynn
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * 3     3/02/08 2:50p John.gwynn
 * refactored LoadFromXml to eliminate code duplicaton
 * 
 * 2     10/01/07 11:47a John.gwynn
 * Action override unnecessary
 * 
 * 1     6/14/07 3:44p John.gwynn
 * updates for Outcome and Outcome step and new Subscription message
 */
#endregion