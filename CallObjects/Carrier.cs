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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Carrier.cs 2     3/17/08 10:38a John.gwynn $ */
#endregion

using System.Xml;


namespace FnsComposite.CallObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class Carrier : CallObjectBase, ICarrier
	{
		private const string _nodeTypeName = "CARRIER";
		/// <summary>
		/// Initializes a new instance of the <see cref="Carrier"/> class.
		/// </summary>
			public Carrier() : base(_nodeTypeName)
		{}
			/// <summary>
			/// Initializes a new instance of the <see cref="Carrier"/> class.
			/// </summary>
			/// <param name="node">The node.</param>
		public Carrier(XmlNode node): base(node)
		{}

		#region ICarrier Members

		/// <summary>
		/// Gets or sets the name of the carrier.
		/// </summary>
		/// <value>The name of the carrier.</value>
		public string CarrierName
		{
			get { return GetValue("NAME"); }
			set { SetValue("NAME", value); }
		}

		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		public new IAddress Address
		{
			get { return base.Address; }
		}

		/// <summary>
		/// Gets or sets the carrier number.
		/// </summary>
		/// <value>The carrier number.</value>
		public string CarrierNumber
		{
			get { return GetValue("CARRIER_NUMBER"); }
			set { SetValue("CARRIER_NUMBER", value); }
		}

		/// <summary>
		/// Gets or sets the naics.
		/// </summary>
		/// <value>The naics.</value>
		public string Naics
		{
			get { return GetValue("NAICS_CD"); }
			set { SetValue("NAICS_CD", value); }
		}

		/// <summary>
		/// Gets or sets the fein.
		/// </summary>
		/// <value>The fein.</value>
		public string Fein
		{
			get { return GetValue("FEIN"); }
			set { SetValue("FEIN", value); }
		}

		#endregion
	}
}
