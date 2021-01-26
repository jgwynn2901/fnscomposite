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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/CallflowEvent.cs 2     7/06/09 7:02p John.gwynn $ */
#endregion

using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class CallflowEvent : Composite, ICallflowEvent
	{
		private const string _nodeTypeName = "EVENT";
		/// <summary>
		/// Initializes a new instance of the <see cref="CallflowEvent"/> class.
		/// </summary>
		public CallflowEvent(): this("[-1]")
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="CallflowEvent"/> class.
		/// </summary>
		/// <param name="indexName">Name of the index.</param>
		public CallflowEvent(string indexName)
			: base(_nodeTypeName + indexName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="CallflowEvent"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="indexedName">Name of the indexed.</param>
		public CallflowEvent(XmlNode node, string indexedName)
			: base(node, indexedName)
		{}
		/// <summary>
		/// Copies from.
		/// </summary>
		/// <param name="source">The source.</param>
		public void CopyFrom (ICallflowEvent source)
		{
			EventName = source.EventName;
			RequestMessage = source.RequestMessage;
			ResponseMessage = source.ResponseMessage;
			StartTime = source.StartTime;
			EndTime = source.EndTime;
			Source = source.Source;
		}
		#region ICallflowEvent Members

		/// <summary>
		/// Gets or sets the name of the event.
		/// </summary>
		/// <value>The name of the event.</value>
		public string EventName
		{
			get { return GetValue("NAME"); }
			set { SetValue("NAME", value); }
		}

		/// <summary>
		/// Gets or sets the request message.
		/// </summary>
		/// <value>The request message.</value>
		public string RequestMessage
		{
			get { return GetValue("REQUEST"); }
			set { SetValue("REQUEST", value); }
		}

		/// <summary>
		/// Gets or sets the response message.
		/// </summary>
		/// <value>The response message.</value>
		public string ResponseMessage
		{
			get { return GetValue("RESPONSE"); }
			set { SetValue("RESPONSE", value); }
		}

		/// <summary>
		/// Gets or sets the start time.
		/// </summary>
		/// <value>The start time.</value>
		public string StartTime
		{
			get { return GetValue("START_TIME"); }
			set { SetValue("START_TIME", value); }
		}

		/// <summary>
		/// Gets or sets the end time.
		/// </summary>
		/// <value>The end time.</value>
		public string EndTime
		{
			get { return GetValue("END_TIME"); }
			set { SetValue("END_TIME", value); }
		}

		/// <summary>
		/// Gets or sets the source.
		/// </summary>
		/// <value>The source.</value>
		public string Source
		{
			get { return GetValue("SOURCE"); }
			set { SetValue("SOURCE", value); }
		}

		#endregion
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/CallflowEvent.cs $
 * 
 * 2     7/06/09 7:02p John.gwynn
 * Fixed strongly typed constructor for CallflowEvent objects (loading
 * from Xml) and added NamedValueCollection for set difference operations
 * 
 * 1     3/20/08 6:58p John.gwynn
 * Added support for CallflowEvents for explicating specific defined
 * events during the course of a given call
 */
#endregion