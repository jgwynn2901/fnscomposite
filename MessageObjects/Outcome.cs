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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/Outcome.cs 6     2/24/10 6:46p Gwynnj $ */
#endregion

using System;
using System.Runtime.InteropServices;
using System.Xml;
using FnsComposite.Interfaces;

namespace FnsComposite.MessageObjects
{
	/// <summary>
	/// Manages the TransmissionOutcome state 
	/// </summary>
	[ComVisible(false)]
	public class Outcome : MessageObject, ITransmissionOutcome
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Outcome"/> class.
		/// </summary>
		public Outcome() : this(string.Empty)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Outcome"/> class.
		/// </summary>
		/// <param name="outcomeXml">The outcome XML.</param>
		public Outcome(string outcomeXml) : base("Outcome")
		{
			if (outcomeXml.Length > 0)
			{
				LoadFromXml(outcomeXml);
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Outcome"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Outcome(XmlNode node): base(node)
		{}
		/// <summary>
		/// Gets or sets the TransmissionOutcome id.
		/// </summary>
		/// <value>The TransmissionOutcome id.</value>
		public string OutcomeId
		{
			get { return Id; }
			set { Id = value; }
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
		/// Gets or sets the routing plan id.
		/// </summary>
		/// <value>The routing plan id.</value>
		public string RoutingPlanId
		{
			get { return GetValue("RoutingPlanId"); }
			set { SetValue("RoutingPlanId", value); }
		}
		/// <summary>
		/// Gets or sets the specific destination id.
		/// </summary>
		/// <value>The specific destination id.</value>
		public string SpecificDestinationId
		{
			get { return GetValue("SpecificDestinationId"); }
			set { SetValue("SpecificDestinationId", value); }
		}

		/// <summary>
		/// Gets the last error text.
		/// </summary>
		/// <value>The last error text.</value>
		public string LastErrorText
		{
			get { return GetValue("LastErrorText"); }
			set { SetValue("LastErrorText", value); }
		}

		/// <summary>
		/// Gets the specific destination id.
		/// </summary>
		/// <value>The specific destination id.</value>
		public string LastDestinationString
		{
			get { return GetValue("LastDestinationString"); }
			set { SetValue("LastDestinationString", value); }
		}

		/// <summary>
		/// Updates the state.
		/// </summary>
		/// <param name="state">The state.</param>
		/// <returns></returns>
		public override bool UpdateState(IMessageObject state)
		{
			var result = false;
			var source = state as Outcome;
			if(source != null)
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
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/MessageObjects/Outcome.cs $
 * 
 * 6     2/24/10 6:46p Gwynnj
 * Added TranOutcome and TranOutcomeSupport message objects for
 * communication with legacy message objects used by OutcomeViewer
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
 * 1     6/11/07 5:01p John.gwynn
 * messageObjects source state managers for Opm
 */
#endregion