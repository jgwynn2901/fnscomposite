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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IStaff.cs 2     11/07/08 1:09p Deepika.sharma $ */
#endregion

using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject eSurance STAFF interface
	/// </summary>
	public interface IStaff : IComposite
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
		/// Gets or sets the appointment date.
		/// </summary>
		/// <value>The appointment date.</value>
		string AppointmentDate { get; set; }
		/// <summary>
		/// Gets or sets the Appraiser Code
		/// </summary>
		/// <value>The appraiser Code.</value>
		string AppraiserCode { get; set;}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IStaff.cs $
 * 
 * 2     11/07/08 1:09p Deepika.sharma
 * A-JUC2
 * 
 * 1     5/03/08 7:55p John.gwynn
 * added Estar, IndependentAppraiser and Staf for phase III
 */
#endregion