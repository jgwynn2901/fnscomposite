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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/MessageObject.cs 9     9/29/09 5:12p John.gwynn $ */
#endregion

using System;
using System.Diagnostics;
using System.Messaging;
using System.Runtime.InteropServices;
using System.Xml;

namespace FnsComposite.MessageObjects
{
	/// <summary>
	/// Base class for Msmq based extensible objects
	/// </summary>
	[ComVisible(false)]
	public class MessageObject : Composite, IMessageObject
	{
		private DateTime _lastModifiedDate;
		/// <summary>
		/// Initializes a new instance of the <see cref="MessageObject"/> class.
		/// </summary>
		public MessageObject()
			: this("MessageObject")
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="MessageObject"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		public MessageObject(string name) : base(name)
		{
			SetValue("CreateDateTime", DateTime.Now.ToString());
			_lastModifiedDate = DateTime.Now;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="MessageObject"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public MessageObject(XmlNode node) :base (node)
		{}
		/// <summary>
		/// Gets the last modified.
		/// </summary>
		/// <value>The last modified.</value>
		public DateTime LastModified
		{
			get { return _lastModifiedDate; }
		}

		/// <summary>
		/// Gets or sets the action.
		/// </summary>
		/// <value>The action.</value>
		public string Action
		{
			get { return GetValue("Action"); }
			set { SetValue("Action", value); }
		}

		/// <summary>
		/// Gets or sets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public string Instance
		{
			get { return GetValue("Instance"); }
			set { SetValue("Instance", value); }
		}

		/// <summary>
		/// Gets the create date time.
		/// </summary>
		/// <value>The create date time.</value>
		public string CreateDateTime
		{
			get { return GetValue("CreateDateTime"); }
		}

		/// <summary>
		/// Gets or sets the source.
		/// </summary>
		/// <value>The source.</value>
		public string Source
		{
			get { return GetValue("Source"); }
			set { SetValue("Source", value); }
		}

		/// <summary>
		/// Gets or sets the destination.
		/// </summary>
		/// <value>The destination.</value>
		public string Destination
		{
			get { return GetValue("Destination"); }
			set { SetValue("Destination", value); }
		}

		/// <summary>
		/// Gets the id.
		/// </summary>
		/// <value>The id.</value>
		virtual public string Id
		{
			get { return GetValue("Id"); }
			set { SetValue("Id", value); }
		}

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public string Status
		{
			get { return GetValue("Status"); }
			set { SetValue("Status", value); }
		}

		/// <summary>
		/// Gets or sets the last error.
		/// </summary>
		/// <value>The last error.</value>
		public new string LastError
		{
			get { return GetValue("LastError"); }
			set { SetValue("LastError", value); }
		}
		/// <summary>
		/// Sends this instance.
		/// </summary>
		/// <returns></returns>
		public bool Send()
		{
			return SendDirect(Destination);
		}
		/// <summary>
		/// Touches this instance.
		/// </summary>
		public void Touch ()
		{
			_lastModifiedDate = DateTime.Now;
		}
		/// <summary>
		/// Sends the direct.
		/// </summary>
		/// <param name="destinationQ">The destination Q.</param>
		/// <returns></returns>
		public bool SendDirect(string destinationQ)
		{
			bool results = false;
			try
			{
				using (MessageQueueTransaction transaction = new MessageQueueTransaction())
				{
					transaction.Begin();
					if (!MessageQueue.Exists(destinationQ))
					{
						MessageQueue.Create(destinationQ, true);
					}
					MessageQueue queue = new MessageQueue(destinationQ);
					// Set the formatter.
					queue.Formatter = new ActiveXMessageFormatter();
					System.Messaging.Message message = new System.Messaging.Message();
					message.Body = ToXml();
					message.Label = Name;
					message.Formatter = queue.Formatter;
					queue.Send(message, transaction);
					transaction.Commit();
					results = true;
				}
			}
			catch (MessageQueueException ex)
			{
				Trace.WriteLine(string.Format("SendDirect() MessageQueueException: {0}", ex.Message));
			}
			catch (InvalidOperationException ex)
			{
				Trace.WriteLine(string.Format("SendDirect() InvalidOperationException: {0}", ex.Message));
			}

			catch (Exception ex)
			{
				Trace.WriteLine(string.Format("SendDirect() Exception: {0}", ex.Message));
			}
			return results;
		}

		/// <summary>
		/// Receives this instance.
		/// </summary>
		/// <returns></returns>
		public bool Receive()
		{
			return ReceiveDirect(Destination);
		}


		/// <summary>
		/// Receives the direct.
		/// </summary>
		/// <param name="destinationQ">The destination Q.</param>
		/// <returns></returns>
		public bool ReceiveDirect(string destinationQ)
		{
			bool results = false;
			try
			{
				using (MessageQueueTransaction transaction = new MessageQueueTransaction())
				{
					transaction.Begin();
					if (!MessageQueue.Exists(destinationQ))
					{
						MessageQueue.Create(destinationQ, true);
					}
					MessageQueue queue = new MessageQueue(destinationQ);
					// Set the formatter.
					queue.Formatter = new ActiveXMessageFormatter();
					System.Messaging.Message message = queue.Receive(transaction);
					LoadFromXml((string)message.Body);

					transaction.Commit();
					results = true;
				}
			}
			catch (MessageQueueException ex)
			{
				Trace.WriteLine(string.Format("Send() MessageQueueException: {0}", ex.Message));
			}
			catch (InvalidOperationException ex)
			{
				Trace.WriteLine(string.Format("Send() InvalidOperationException: {0}", ex.Message));
			}
			catch (Exception ex)
			{
				Trace.WriteLine(string.Format("Send() Exception: {0}", ex.Message));
			}
			return results;
		}

		/// <summary>
		/// Updates the state.
		/// </summary>
		/// <param name="state">The state.</param>
		/// <returns></returns>
		public virtual bool UpdateState(IMessageObject state)
		{
			throw new NotImplementedException();
		}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/MessageObject.cs $
 * 
 * 9     9/29/09 5:12p John.gwynn
 * Added Validation Event support for Composite in general and Segment
 * classes.
 * 
 * 8     5/04/09 3:55p John.gwynn
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * 7     3/02/08 2:50p John.gwynn
 * refactored LoadFromXml to eliminate code duplicaton
 * 
 * 6     9/27/07 6:49p John.gwynn
 * 
 * 5     9/24/07 5:34p John.gwynn
 * merged with 2003 changes
 * 
 * 4     8/02/07 5:16p John.gwynn
 * Update bugs from OPM work andthe SetValue o Empty string is more
 * robust...
 * 
 * 3     6/14/07 3:44p John.gwynn
 * updates for Outcome and Outcome step and new Subscription message
 * 
 * 2     6/11/07 5:01p John.gwynn
 * messageObjects source state managers for Opm
 * 
 * 1     5/29/07 7:05p John.gwynn
 * new MessageObject set of classes for OPM with some refactoring and
 * gebneral enhancements
 */
#endregion