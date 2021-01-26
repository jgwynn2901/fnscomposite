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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IVehicle.cs 9     5/22/12 6:09p Gwynnj $ */
#endregion

using System.Collections.Generic;
using System.Runtime.InteropServices;
using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject intercface for Vehicle objects
	/// </summary>
	public interface IVehicle : IComposite
	{
		/// <summary>
		/// Gets or sets the year.
		/// </summary>
		/// <value>The year.</value>
		string Year { get; set; }
		/// <summary>
		/// Gets or sets the make.
		/// </summary>
		/// <value>The make.</value>
		string Make { get; set; }
		/// <summary>
		/// Gets or sets the model.
		/// </summary>
		/// <value>The model.</value>
		string Model { get; set; }
		/// <summary>
		/// Gets or sets the vin.
		/// </summary>
		/// <value>The vin.</value>
		string Vin { get; set; }
		/// <summary>
		/// Gets or sets the vehicle number.
		/// </summary>
		/// <value>The vehicle number.</value>
		string VehicleNumber { get; set; }
		/// <summary>
		/// Gets or sets the damage flag.
		/// </summary>
		/// <value>The damage flag.</value>
		string DamageFlag { get; set; }
		/// <summary>
		/// Gets or sets the drivable flag.
		/// </summary>
		/// <value>The drivable flag.</value>
		string DrivableFlag { get; set; }

        string SegmentDescription { get; set; }
		/// <summary>
		/// Gets the owner.
		/// </summary>
		/// <value>The owner.</value>
		IOwner Owner { get; }
		/// <summary>
		/// Gets the driver.
		/// </summary>
		/// <value>The driver.</value>
		IDriver Driver { get; }
		/// <summary>
		/// Gets the passengers.
		/// </summary>
		/// <value>The passengers.</value>
		[ComVisible(false)]
		List<IPassenger> Passengers { get; }
		/// <summary>
		/// Gets the witnesses.
		/// </summary>
		/// <value>The witnesses.</value>
		[ComVisible(false)]
		List<IWitness> Witnesses { get; }
        /// <summary>
        /// Gets the property.
        /// </summary>
        List<Property> Property { get; }
        /// <summary>
        /// Gets the third party.
        /// </summary>
        List<Thirdparty> ThirdParty { get; }
        /// <summary>
		/// Gets the coverages.
		/// </summary>
		/// <value>The coverages.</value>
		[ComVisible(false)]
		List<ICoverage>Coverages { get; }
		/// <summary>
		/// Gets a value indicating whether this instance has passengers.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has passengers; otherwise, <c>false</c>.
		/// </value>
		bool HasPassengers { get;}
		/// <summary>
		/// Gets a value indicating whether this instance has witnesses.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has witnesses; otherwise, <c>false</c>.
		/// </value>
		bool HasWitnesses { get;}

		/// <summary>
		/// Creates the new coverage.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		ICoverage CreateCoverage(int index);

	

	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IVehicle.cs $
 * 
 * 9     5/22/12 6:09p Gwynnj
 * additional updates required for AAA
 * 
 * 8     9/01/11 11:47a Sharmad
 * JCER-0300
 * 
 * 7     2/10/08 6:51p John.gwynn
 * xml bugs fixed and added CreateCoverage for vehicle
 * 
 * 6     2/08/08 3:10p John.gwynn
 * Added (CalObject) Coverage and fixed a bug loading Xml array elements
 * from Call Xml
 * 
 * 5     11/19/07 3:16p John.gwynn
 * Added Witnesses property to vehicle interface
 * 
 * 4     11/19/07 1:42p John.gwynn
 * added HasWitnesses to vehicle interface
 * 
 * 3     11/18/07 11:43a John.gwynn
 * Added HasPassengers flag to IVehicle
 * 
 * 2     10/30/07 7:12p John.gwynn
 * Support for new Business Rule evaluator
 * 
 * 1     10/21/07 3:46p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion