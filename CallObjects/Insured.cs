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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Insured.cs 6     9/21/10 6:29p Gwynnj $ */
#endregion

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Implements CallObjects Insured
	/// </summary>
	public class Insured : EntityBase, IInsured
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Insured"/> class.
		/// </summary>
		public Insured(): base("INSURED")
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Insured"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Insured(XmlNode node) : base (node)
		{}

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string InsuredName
		{
			get { return GetValue("NAME"); }
			set { SetValue("NAME", value); }
		}

    public string CompanyName
    {
      get { return InsuredName; }
      set { InsuredName = value; }
    }

    public string LocationCode
    {
      get { return GetValue("LOCATION_CODE"); }
      set { SetValue("LOCATION_CODE", value); }
    }
        
		#region IInsured Members

		/// <summary>
		/// Gets the Insured Vehicle.
		/// </summary>
		/// <value>The vehicle.</value>
		public IVehicle Vehicle
		{
			get 
			{
				Vehicle node = GetObject<Vehicle>("VEHICLE") as Vehicle;
				if (node == null)
				{
					throw new ApplicationException("CallObject error retrieving type: Claim");
				}
				return node;
			}
		}

		/// <summary>
		/// Gets the third parties.
		/// </summary>
		/// <value>The third parties.</value>
		[ComVisible(false)]
		public List<IWitness> ThirdParties
		{
			get
			{
				List<IWitness> thirdPartyList = new List<IWitness>();
				foreach (Thirdparty p in GetEnumerator<Thirdparty>())
				{
					thirdPartyList.Add(p);
				}
				return thirdPartyList;
			}
		}
		#endregion
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Insured.cs $
 * 
 * 6     9/21/10 6:29p Gwynnj
 * Created EntityBase to factor the IPerson interface
 * 
 * 5     2/28/08 7:47p John.gwynn
 * Added ASI and Carrier support
 * 
 * 4     2/18/08 8:31p John.gwynn
 * Moved Witness to CallObjects, Added ThirdParty to Insured and fixed
 * Passenger missing constructor
 * 
 * 3     1/16/08 6:39p John.gwynn
 * added CallObjectBase to override SetValue
 * 
 * 2     10/22/07 6:08p John.gwynn
 * 
 * 1     10/21/07 3:43p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion