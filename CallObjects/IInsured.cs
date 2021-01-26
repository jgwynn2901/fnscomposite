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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IInsured.cs 5     5/01/08 4:13p John.gwynn $ */
#endregion

using System.Collections.Generic;
using System.Runtime.InteropServices;
using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject Insured interface
	/// </summary>
  public interface IInsured : IComposite, ICompany
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		string InsuredName { get; set; }
		/// <summary>
		/// Gets the vehicle.
		/// </summary>
		/// <value>The vehicle.</value>
		IVehicle Vehicle { get; }
		/// <summary>
		/// Gets the third parties.
		/// </summary>
		/// <value>The third parties.</value>
		[ComVisible(false)]
		List<IWitness> ThirdParties { get;}
		 
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IInsured.cs $
 * 
 * 5     5/01/08 4:13p John.gwynn
 * refactored IPerson interface and added support for Contact
 * 
 * 4     2/28/08 7:47p John.gwynn
 * Added ASI and Carrier support
 * 
 * 3     2/18/08 8:31p John.gwynn
 * Moved Witness to CallObjects, Added ThirdParty to Insured and fixed
 * Passenger missing constructor
 * 
 * 2     10/22/07 6:08p John.gwynn
 * 
 * 1     10/21/07 3:41p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion