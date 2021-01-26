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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ICallflowEvent.cs 1     3/20/08 6:58p John.gwynn $ */
#endregion

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// 
	/// </summary>
	public interface ICallflowEvent
	{
		/// <summary>
		/// Gets or sets the name of the event.
		/// </summary>
		/// <value>The name of the event.</value>
		string EventName { get; set; }
		/// <summary>
		/// Gets or sets the request message.
		/// </summary>
		/// <value>The request message.</value>
		string RequestMessage { get; set; }
		/// <summary>
		/// Gets or sets the response message.
		/// </summary>
		/// <value>The response message.</value>
		string ResponseMessage { get; set; }
		/// <summary>
		/// Gets or sets the start time.
		/// </summary>
		/// <value>The start time.</value>
		string StartTime { get; set; }
		/// <summary>
		/// Gets or sets the end time.
		/// </summary>
		/// <value>The end time.</value>
		string EndTime { get; set; }
		/// <summary>
		/// Gets or sets the source.
		/// </summary>
		/// <value>The source.</value>
		string Source { get; set; }
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ICallflowEvent.cs $
 * 
 * 1     3/20/08 6:58p John.gwynn
 * Added support for CallflowEvents for explicating specific defined
 * events during the course of a given call
 */
#endregion