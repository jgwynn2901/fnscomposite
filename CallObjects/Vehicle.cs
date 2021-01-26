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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Vehicle.cs 15    5/22/12 6:09p Gwynnj $ */
#endregion

using System;
using System.Collections.Generic;
using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Implements vehicle for CallObjects	
	/// </summary>
	public class Vehicle : CallObjectBase, IVehicle
	{
		private const string NodeTypeName = "VEHICLE";
		private readonly List<ICoverage> _coverageList = new List<ICoverage>();
		/// <summary>
		/// Initializes a new instance of the <see cref="Vehicle"/> class.
		/// </summary>
		public Vehicle(): base(NodeTypeName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vehicle"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Vehicle(XmlNode node) : base (node)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vehicle"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="indexedName">Overrides for types with indexes i.e. VEHICLE[0]</param>
		public Vehicle(XmlNode node, string indexedName) : base (node, indexedName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vehicle"/> class.
		/// </summary>
		/// <param name="indexName">Name of the index.</param>
		public Vehicle(string indexName): base(NodeTypeName+indexName)
		{}
		/// <summary>
		/// Gets or sets the year.
		/// </summary>
		/// <value>The year.</value>
		public string Year
		{
			get { return GetValue("YEAR"); }
			set { SetValue("YEAR", value); }
		}

		/// <summary>
		/// Gets or sets the make.
		/// </summary>
		/// <value>The make.</value>
		public string Make
		{
			get { return GetValue("MAKE"); }
			set { SetValue("MAKE", value); }
		}

		/// <summary>
		/// Gets or sets the model.
		/// </summary>
		/// <value>The model.</value>
		public string Model
		{
			get { return GetValue("MODEL"); }
			set { SetValue("MODEL", value); }
		}

		/// <summary>
		/// Gets or sets the vin.
		/// </summary>
		/// <value>The vin.</value>
		public string Vin
		{
			get { return GetValue("VIN"); }
			set { SetValue("VIN", value); }
		}

		/// <summary>
		/// Gets or sets the vehicle number.
		/// </summary>
		/// <value>The vehicle number.</value>
		public string VehicleNumber
		{
			get { return GetValue("VEHICLE_NUMBER"); }
			set { SetValue("VEHICLE_NUMBER", value); }
		}

		/// <summary>
		/// Gets or sets the damage flag.
		/// </summary>
		/// <value>The damage flag.</value>
		public string DamageFlag
		{
			get { return GetValue("DAMAGE_FLG"); }
			set { SetValue("DAMAGE_FLG", value); }
		}

		/// <summary>
		/// Gets or sets the drivable flag.
		/// </summary>
		/// <value>The drivable flag.</value>
		public string DrivableFlag
		{
			get { return GetValue("DRIVEABLE_FLG"); }
			set { SetValue("DRIVEABLE_FLG", value); }
		}

        public string SegmentDescription
        {
            get { return GetValue("SEGMENT_DESCRIPTION"); }
            set { SetValue("SEGMENT_DESCRIPTION", value); }
        }

		/// <summary>
		/// Gets the owner.
		/// </summary>
		/// <value>The owner.</value>
		public IOwner Owner
		{
			get
			{
				Owner node = GetObject<Owner>("OWNER") as Owner;
				if (node == null)
				{
					throw new ApplicationException("CallObject error retrieving type: Owner");
				}
				return node;
			}
		}

		/// <summary>
		/// Gets the driver.
		/// </summary>
		/// <value>The driver.</value>
		public IDriver Driver
		{
			get
			{
				Driver node = GetObject<Driver>("DRIVER") as Driver;
				if (node == null)
				{
					throw new ApplicationException("CallObject error retrieving type: Driver");
				}
				return node;
			}
		}

		#region IVehicle Members

		/// <summary>
		/// Gets the passengers.
		/// </summary>
		/// <value>The passengers.</value>
		public List<IPassenger> Passengers
		{
			get
			{
				var passengerList = new List<IPassenger>();
				foreach (Passenger p in GetEnumerator<Passenger>())
				{
					passengerList.Add(p);
				}
				return passengerList;
			}
		}
		/// <summary>
		/// Gets the witnesses.
		/// </summary>
		/// <value>The witnesses.</value>
		public List<IWitness> Witnesses
		{
			get
			{
				var witnessList = new List<IWitness>();
				foreach (Witness p in GetEnumerator<Witness>())
				{
					witnessList.Add(p);
				}
				return witnessList;
			}
		}

        /// <summary>
        /// Gets the property.
        /// </summary>
        public List<Thirdparty> ThirdParty
        {
            get
            {
                var list = new List<Thirdparty>();
                foreach (Thirdparty p in GetEnumerator<Thirdparty>())
                {
                    list.Add(p);
                }
                return list;
            }
        }

        public List<Property> Property
        {
            get
            {
                var list = new List<Property>();
                foreach (Property p in GetEnumerator<Property>())
                {
                    list.Add(p);
                }
                return list;
            }
        }
		/// <summary>
		/// Gets the coverages.
		/// </summary>
		/// <value>The coverages.</value>
		public List<ICoverage> Coverages
		{
			get
			{
				//List<ICoverage> coverageList = new List<ICoverage>();
				//foreach (Coverage p in GetEnumerator<Coverage>())
				//{
				//	coverageList.Add(p);
				//}
				return _coverageList;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance has passengers.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has passengers; otherwise, <c>false</c>.
		/// </value>
		public bool HasPassengers
		{
			get { return ObjectList.Contains("PASSENGER[0]"); }
		}

		/// <summary>
		/// Gets a value indicating whether this instance has witnesses.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has witnesses; otherwise, <c>false</c>.
		/// </value>
		public bool HasWitnesses
		{
			get { return ObjectList.Contains("WITNESS[0]"); }
		}

		/// <summary>
		/// Creates the new coverage.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		public ICoverage CreateCoverage(int index)
		{
			ICoverage coverage = new Coverage(string.Format("[{0}]", index));
			Add(coverage as Composite);
			_coverageList.Add(coverage);
			return coverage;
		}

		/// <summary>
		/// Gets a value indicating whether this instance has coverages.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has coverages; otherwise, <c>false</c>.
		/// </value>
		public bool HasCoverages
		{
			get { return ObjectList.Contains("COVERAGE[0]"); }
		}

		#endregion
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Vehicle.cs $
 * 
 * 15    5/22/12 6:09p Gwynnj
 * additional updates required for AAA
 * 
 * 14    9/01/11 11:47a Sharmad
 * JCER-0300
 * 
 * 13    9/28/09 1:14p John.gwynn
 * Added support for ICloneable
 * 
 * 12    2/12/08 4:45p John.gwynn
 * added WebNavigation (support for eSurance) 
 * 
 * 11    2/10/08 6:52p John.gwynn
 * xml bugs fixed and added CreateCoverage for vehicle
 * 
 * 10    2/08/08 3:10p John.gwynn
 * Added (CalObject) Coverage and fixed a bug loading Xml array elements
 * from Call Xml
 * 
 * 9     1/16/08 6:39p John.gwynn
 * added CallObjectBase to override SetValue
 * 
 * 8     11/28/07 11:22a John.gwynn
 * Added CallObject.Property and interface
 * 
 * 7     11/19/07 3:09p John.gwynn
 * Added Witnesses to Vehcle
 * 
 * 6     11/19/07 1:42p John.gwynn
 * added HasWitnesses to vehicle interface
 * 
 * 5     11/18/07 11:43a John.gwynn
 * Added HasPassengers flag to IVehicle
 * 
 * 4     10/30/07 7:12p John.gwynn
 * Support for new Business Rule evaluator
 * 
 * 3     10/22/07 6:08p John.gwynn
 * 
 * 2     10/21/07 3:53p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion