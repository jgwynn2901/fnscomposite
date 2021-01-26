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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IIndependentAppraiser.cs 1     5/03/08 7:54p John.gwynn $ */
#endregion

using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject eSurance Independent Appraiser interface
	/// </summary>
	public interface IIndependentAppraiser : IComposite
	{
		/// <summary>
		/// Gets or sets the name of the appraiser.
		/// </summary>
		/// <value>The name of the appraiser.</value>
		string AppraiserName { get; set; }
		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		IAddress Address { get; }
		/// <summary>
		/// Gets or sets the phone.
		/// </summary>
		/// <value>The phone.</value>
		string Phone { get; set; }
		/// <summary>
		/// Gets or sets the fax.
		/// </summary>
		/// <value>The fax.</value>
		string Fax { get; set; }
		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		string Type { get; set; }
		/// <summary>
		/// Gets or sets the appraiser code.
		/// </summary>
		/// <value>The appraiser code.</value>
		string AppraiserCode { get; set; }
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IIndependentAppraiser.cs $
 * 
 * 1     5/03/08 7:54p John.gwynn
 * added Estar, IndependentAppraiser and Staf for phase III
 */
#endregion