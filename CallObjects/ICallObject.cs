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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ICallObject.cs 10    6/27/09 2:01p John.gwynn $ */
#endregion

using System.Collections.Generic;
using System.Runtime.InteropServices;
using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Public interface for the CallObject root node
	/// </summary>
	public interface ICallObject : IComposite
	{
		/// <summary>
		/// Gets or sets the ACCNT_HRCY_STEP_ID.
		/// </summary>
		/// <value>The ahs id.</value>
		string AhsId { get; set;}
		/// <summary>
		/// Gets or sets the call id.
		/// </summary>
		/// <value>The call id.</value>
		string CallId { get; set; }
		/// <summary>
		/// Gets or sets the line of business.
		/// </summary>
		/// <value>The line of business.</value>
		string LineOfBusiness { get; set; }
		/// <summary>
		/// Gets or sets the call start date.
		/// </summary>
		/// <value>The call start date.</value>
		string CallStartDate { get; set; }
		/// <summary>
		/// Gets or sets the call start time.
		/// </summary>
		/// <value>The call start time.</value>
		string CallStartTime { get; set; }
		/// <summary>
		/// Gets or sets the call end date.
		/// </summary>
		/// <value>The call end date.</value>
		string CallEndDate { get; set; }
		/// <summary>
		/// Gets or sets the call edn time.
		/// </summary>
		/// <value>The call edn time.</value>
		string CallEndTime { get; set; }
		/// <summary>
		/// Gets or sets the client id.
		/// </summary>
		/// <value>The client id.</value>
		string ClientId { get; set; }
		/// <summary>
		/// Gets or sets the carrier code.
		/// </summary>
		/// <value>The carrier code.</value>
		string CarrierCode { get; set; }
		/// <summary>
		/// Gets or sets the instance.
		/// </summary>
		/// <value>The instance.</value>
		string Instance { get; set; }
		/// <summary>
		/// Gets or sets the call status.
		/// </summary>
		/// <value>The call status.</value>
		string CallStatus { get; set; }
		/// <summary>
		/// Gets or sets the user id.
		/// </summary>
		/// <value>The user id.</value>
		string UserId { get; set; }
		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>The name of the user.</value>
		string UserName { get; set; }
		/// <summary>
		/// Gets or sets the session key.
		/// </summary>
		/// <value>The session key.</value>
		string SessionKey { get; set; }
		/// <summary>
		/// Gets or sets the name of the server.
		/// </summary>
		/// <value>The name of the server.</value>
		string ServerName { get; set; }
		/// <summary>
		/// Gets or sets the internet user.
		/// </summary>
		/// <value>The internet user.</value>
		string InternetUser { get; set; }

		/// <summary>
		/// Adds the event.
		/// </summary>
		/// <param name="callEvent">The call event.</param>
		void AddEvent (ICallflowEvent callEvent);
		/// <summary>
		/// Gets the claim.
		/// </summary>
		/// <value>The claim.</value>
		IClaim Claim { get; }
		/// <summary>
		/// Gets the contact.
		/// </summary>
		/// <value>The contact.</value>
		IContact Contact { get; }
		/// <summary>
		/// Gets the caller.
		/// </summary>
		/// <value>The caller.</value>
		ICaller Caller { get; }
		/// <summary>
		/// Gets the ASI node.
		/// </summary>
		/// <value>The asi.</value>
		IAsi Asi { get; }
		/// <summary>
		/// Gets the events.
		/// </summary>
		/// <value>The events.</value>
		[ComVisible(false)]
		List<ICallflowEvent> Events { get; }

		/// <summary>
		/// Clears this instance contents.
		/// </summary>
		void Clear();

    /// <summary>
    /// Gets the tree.
    /// </summary>
    /// <param name="node">The node.</param>
    /// <returns></returns>
	  string GetTree(string node);

	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ICallObject.cs $
 * 
 * 10    6/27/09 2:01p John.gwynn
 * LoadFromXml removed in favor of the older LoadFromXML 
 * 
 * 9     5/02/08 10:12a Deepika.sharma
 * dms: added comvisible false to fix the warning
 * 
 * 8     5/01/08 4:13p John.gwynn
 * refactored IPerson interface and added support for Contact
 * 
 * 7     4/08/08 3:33p John.gwynn
 * Fix for bug in encode/decode (added encode to the constructor) now all
 * values are encoded and decoded except when ToXml is called...
 * 
 * 6     3/20/08 6:58p John.gwynn
 * Added support for CallflowEvents for explicating specific defined
 * events during the course of a given call
 * 
 * 5     3/06/08 6:59p John.gwynn
 * Added CallEndDate and CallEndTime
 * 
 * 4     2/28/08 7:47p John.gwynn
 * Added ASI and Carrier support
 * 
 * 3     2/04/08 6:46p John.gwynn
 * Added AhsId and LastError 
 * 
 * 2     10/30/07 7:12p John.gwynn
 * Support for new Business Rule evaluator
 * 
 * 1     10/22/07 6:08p John.gwynn
 */
#endregion