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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ICarrier.cs 1     2/28/08 7:47p John.gwynn $ */
#endregion

using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Carrier node interface
	/// </summary>
	public interface ICarrier : IComposite
	{
		/// <summary>
		/// Gets or sets the name of the carrier.
		/// </summary>
		/// <value>The name of the carrier.</value>
		string CarrierName { get; set; }
		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		IAddress Address { get; }
		/// <summary>
		/// Gets or sets the carrier number.
		/// </summary>
		/// <value>The carrier number.</value>
		string CarrierNumber { get; set; }
		/// <summary>
		/// Gets or sets the naics.
		/// </summary>
		/// <value>The naics.</value>
		string Naics { get; set; }
		/// <summary>
		/// Gets or sets the fein.
		/// </summary>
		/// <value>The fein.</value>
		string Fein { get; set; }

	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ICarrier.cs $
 * 
 * 1     2/28/08 7:47p John.gwynn
 * Added ASI and Carrier support
 */
#endregion