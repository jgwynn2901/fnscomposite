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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ICoverage.cs 2     3/18/11 11:10a Sharmad $ */
#endregion

using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// encapsulates the standard vehicle coverage attributes
	/// </summary>
	public interface ICoverage : IComposite
	{
		/// <summary>
		/// Gets or sets the type of the coverage.
		/// </summary>
		/// <value>The type of the coverage.</value>
		string CoverageType { get; set; }
		/// <summary>
		/// Gets or sets the deductible1.
		/// </summary>
		/// <value>The deductible1.</value>
		string Deductible1 { get; set; }
		/// <summary>
		/// Gets or sets the deductible2.
		/// </summary>
		/// <value>The deductible2.</value>
		string Deductible2 { get; set; }
		/// <summary>
		/// Gets or sets the limit1.
		/// </summary>
		/// <value>The limit1.</value>
		string Limit1 { get; set; }
		/// <summary>
		/// Gets or sets the limit2.
		/// </summary>
		/// <value>The limit2.</value>
		string Limit2 { get; set; }
        string ReceivedStartDt { get; set; }
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ICoverage.cs $
 * 
 * 2     3/18/11 11:10a Sharmad
 * EFIG-0131
 * 
 * 1     2/08/08 3:10p John.gwynn
 * Added (CalObject) Coverage and fixed a bug loading Xml array elements
 * from Call Xml
 */
#endregion