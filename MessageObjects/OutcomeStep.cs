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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/OutcomeStep.cs 5     5/04/09 3:55p John.gwynn $ */
#endregion

using System;
using System.Runtime.InteropServices;
using System.Xml;
using FnsComposite.Interfaces;

namespace FnsComposite.MessageObjects
{
	/// <summary>
	/// Manages the OutcomeStep attributes 
	/// </summary>
	[ComVisible(false)]
	public class OutcomeStep : MessageObject, ITranOutcomeStep
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="OutcomeStep"/> class.
		/// </summary>
		public OutcomeStep() :this(string.Empty)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="OutcomeStep"/> class.
		/// </summary>
		/// <param name="outcomeXml">The outcome XML.</param>
		public OutcomeStep(string outcomeXml) :base("OutcomeStep")
		{
			if (outcomeXml.Length > 0)
			{
				LoadFromXml(outcomeXml);
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="OutcomeStep"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public OutcomeStep(XmlNode node): base(node)
		{}
		/// <summary>
		/// Gets or sets the outcome step id.
		/// </summary>
		/// <value>The outcome step id.</value>
		public string OutcomeStepId
		{
			get { return Id; }
			set { Id = value; }
		}
		/// <summary>
		/// Gets or sets the sequence step id.
		/// </summary>
		/// <value>The sequence step id.</value>
		public string SequenceStepId
		{
			get { return GetValue("SequenceStepId"); }
			set { SetValue("SequenceStepId", value); }
		}
		/// <summary>
		/// Gets or sets the TransmissionOutcome id.
		/// </summary>
		/// <value>The TransmissionOutcome id.</value>
		public string OutcomeId
		{
			get { return GetValue("OutcomeId"); }
			set { SetValue("OutcomeId", value); }
		}
		/// <summary>
		/// Gets or sets the CallId.
		/// </summary>
		/// <value>The call id.</value>
		public string CallId
		{
			get { return GetValue("CallId"); }
			set { SetValue("CallId", value); }
		}
		/// <summary>
		/// Gets or sets the destination string.
		/// </summary>
		/// <value>The destination string.</value>
		public string DestinationString
		{
			get { return GetValue("DestinationString"); }
			set { SetValue("DestinationString", value); }
		}
		/// <summary>
		/// Gets or sets the type of the transmission.
		/// </summary>
		/// <value>The type of the transmission.</value>
		public string TransmissionType
		{
			get { return GetValue("TransmissionType"); }
			set { SetValue("TransmissionType", value); }
		}
		/// <summary>
		/// Gets or sets the name of the server.
		/// </summary>
		/// <value>The name of the server.</value>
		public string ServerName
		{
			get { return GetValue("ServerName"); }
			set { SetValue("ServerName", value); }
		}
		/// <summary>
		/// Gets the sequence.
		/// </summary>
		/// <value>The sequence.</value>
		public string Sequence
		{
			get { return GetValue("Sequence"); }
			set { SetValue("Sequence", value); }
		}
		/// <summary>
		/// Gets the retry count.
		/// </summary>
		/// <value>The retry count.</value>
		public string RetryCount
		{
			get { return GetValue("RetryCount"); }
			set { SetValue("RetryCount", value); }
		}
		/// <summary>
		/// Gets the retry wait time.
		/// </summary>
		/// <value>The retry wait time.</value>
		public string RetryWaitTime
		{
			get { return GetValue("RetryWaitTime"); }
			set { SetValue("RetryWaitTime", value); }
		}
		/// <summary>
		/// Gets the page count.
		/// </summary>
		/// <value>The page count.</value>
		public string PageCount
		{
			get { return GetValue("PageCount"); }
			set { SetValue("PageCount", value); }
		}
		/// <summary>
		/// Gets the error text.
		/// </summary>
		/// <value>The error text.</value>
		public string ErrorText
		{
			get { return GetValue("ErrorText"); }
			set { SetValue("ErrorText", value); }
		}
		/// <summary>
		/// Gets the resubmitted FLG.
		/// </summary>
		/// <value>The resubmitted FLG.</value>
		public string ResubmittedFlg
		{
			get { return GetValue("ResubmittedFlg"); }
			set { SetValue("ResubmittedFlg", value); }
		}
		/// <summary>
		/// Updates the state.
		/// </summary>
		/// <param name="state">The state.</param>
		/// <returns></returns>
		public override bool UpdateState(IMessageObject state)
		{
			bool result = false;
			Outcome source = state as Outcome;
			if (source != null)
			{
				Status = source.Status;
				LastError = source.LastError;
				result = true;
			}
			return result;
		}

	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/OutcomeStep.cs $
 * 
 * 5     5/04/09 3:55p John.gwynn
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * 4     3/02/08 2:50p John.gwynn
 * refactored LoadFromXml to eliminate code duplicaton
 * 
 * 3     10/21/07 3:55p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 * 
 * 2     7/10/07 5:32p John.gwynn
 * Added new Interfaces for OPM, ported 1.1 interfaces and segment
 * updates.  
 * 
 * 1     6/14/07 3:44p John.gwynn
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