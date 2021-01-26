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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IPerson.cs 2     5/03/08 7:56p John.gwynn $ */
#endregion

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject interface to encapsulate personal details
	/// </summary>
	public interface IPerson
	{
		/// <summary>
		/// Gets or sets the name first.
		/// </summary>
		/// <value>The name first.</value>
		string NameFirst { get; set; }
		/// <summary>
		/// Gets or sets the name last.
		/// </summary>
		/// <value>The name last.</value>
		string NameLast { get; set; }
		/// <summary>
		/// Gets or sets the name mid.
		/// </summary>
		/// <value>The name mid.</value>
		string NameMid { get; set; }
		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		IAddress Address { get;}
		/// <summary>
		/// Gets or sets the phone home.
		/// </summary>
		/// <value>The phone home.</value>
		string PhoneHome { get; set; }
		/// <summary>
		/// Gets or sets the phone work.
		/// </summary>
		/// <value>The phone work.</value>
		string PhoneWork { get; set; }
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IPerson.cs $
 * 
 * 2     5/03/08 7:56p John.gwynn
 * added Estar, IndependentAppraiser and Staf for phase III
 */
#endregion