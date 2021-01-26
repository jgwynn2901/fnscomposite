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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IAddress.cs 3     5/22/12 6:09p Gwynnj $ */
#endregion

using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject interface for address properties
	/// </summary>
	public interface IAddress
	{
		/// <summary>
		/// Gets or sets the address1.
		/// </summary>
		/// <value>The address1.</value>
		string Address1 { get; set; }
		/// <summary>
		/// Gets or sets the address2.
		/// </summary>
		/// <value>The address2.</value>
		string Address2 { get; set; }
		/// <summary>
		/// Gets or sets the address3.
		/// </summary>
		/// <value>The address3.</value>
		string Address3 { get; set; }
		/// <summary>
		/// Gets or sets the city.
		/// </summary>
		/// <value>The city.</value>
		string City { get; set; }
		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>The state.</value>
		string State { get; set; }
		/// <summary>
		/// Gets or sets the zip.
		/// </summary>
		/// <value>The zip.</value>
		string Zip { get; set; }
		/// <summary>
		/// Gets or sets the county.
		/// </summary>
		/// <value>The county.</value>
        string County { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        string Country { get; set; }
        /// <summary>
		/// Gets or sets the fips.
		/// </summary>
		/// <value>The fips.</value>
		string Fips { get; set; }

	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IAddress.cs $
 * 
 * 3     5/22/12 6:09p Gwynnj
 * additional updates required for AAA
 * 
 * 2     3/03/09 4:06p John.gwynn
 * fixed a weakness with Address derivative class
 * 
 * 1     10/21/07 3:35p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion