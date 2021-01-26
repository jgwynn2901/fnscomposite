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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/ITranOutcomeStep.cs 1     7/10/07 5:32p John.gwynn $ */
#endregion
namespace FnsComposite.Interfaces
{
	/// <summary>
	/// Defines contract for anyone supporting transmission outcome step records
	/// </summary>
	public interface ITranOutcomeStep
	{
		/// <summary>
		/// Gets the outcome step id.
		/// </summary>
		/// <value>The outcome step id.</value>
		string OutcomeStepId { get; }
		/// <summary>
		/// Gets the outcome id.
		/// </summary>
		/// <value>The outcome id.</value>
		string OutcomeId { get; }
		/// <summary>
		/// Gets the sequence step id.
		/// </summary>
		/// <value>The sequence step id.</value>
		string SequenceStepId { get; }
		/// <summary>
		/// Gets the destination string.
		/// </summary>
		/// <value>The destination string.</value>
		string DestinationString { get; }
		/// <summary>
		/// Gets the type of the transmission.
		/// </summary>
		/// <value>The type of the transmission.</value>
		string TransmissionType { get; }
		/// <summary>
		/// Gets the name of the server.
		/// </summary>
		/// <value>The name of the server.</value>
		string ServerName { get; }
		/// <summary>
		/// Gets the sequence.
		/// </summary>
		/// <value>The sequence.</value>
		string Sequence { get; }
		/// <summary>
		/// Gets the retry count.
		/// </summary>
		/// <value>The retry count.</value>
		string RetryCount { get; }
		/// <summary>
		/// Gets the retry wait time.
		/// </summary>
		/// <value>The retry wait time.</value>
		string RetryWaitTime { get; }
		/// <summary>
		/// Gets the page count.
		/// </summary>
		/// <value>The page count.</value>
		string PageCount { get; }
		/// <summary>
		/// Gets the status.
		/// </summary>
		/// <value>The status.</value>
		string Status { get; }
		/// <summary>
		/// Gets the error text.
		/// </summary>
		/// <value>The error text.</value>
		string ErrorText { get; }
		/// <summary>
		/// Gets the resubmitted FLG.
		/// </summary>
		/// <value>The resubmitted FLG.</value>
		string ResubmittedFlg { get; }
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/ITranOutcomeStep.cs $
 * 
 * 1     7/10/07 5:32p John.gwynn
 * Added new Interfaces for OPM, ported 1.1 interfaces and segment
 * updates.  
 */
#endregion