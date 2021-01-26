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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/ITransmissionOutcome.cs 1     7/10/07 5:32p John.gwynn $ */
#endregion
namespace FnsComposite.Interfaces
{
	/// <summary>
	/// Defines contract for anyone supporting transmission outcome records
	/// </summary>
	public interface ITransmissionOutcome
	{
		/// <summary>
		/// Gets the outcome id.
		/// </summary>
		/// <value>The outcome id.</value>
		string OutcomeId { get; }
		/// <summary>
		/// Gets the call id.
		/// </summary>
		/// <value>The call id.</value>
		string CallId { get; }
		/// <summary>
		/// Gets the routing plan id.
		/// </summary>
		/// <value>The routing plan id.</value>
		string RoutingPlanId { get; }
		/// <summary>
		/// Gets the specific destination id.
		/// </summary>
		/// <value>The specific destination id.</value>
		string SpecificDestinationId { get; }
		/// <summary>
		/// Gets the status.
		/// </summary>
		/// <value>The status.</value>
		string Status { get; }
		/// <summary>
		/// Gets the last error text.
		/// </summary>
		/// <value>The last error text.</value>
		string LastErrorText { get; }
		/// <summary>
		/// Gets the specific destination id.
		/// </summary>
		/// <value>The specific destination id.</value>
		string LastDestinationString { get; }
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/ITransmissionOutcome.cs $
 * 
 * 1     7/10/07 5:32p John.gwynn
 * Added new Interfaces for OPM, ported 1.1 interfaces and segment
 * updates.  
 */
#endregion