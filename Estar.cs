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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Estar.cs 2     5/04/09 3:55p John.gwynn $ */
#endregion

using System.Runtime.InteropServices;
using System.Xml;
using FnsComposite.CallObjects;

namespace FnsComposite
{
	/// <summary>
	/// CallObject eSurance STAFF implementation
	/// </summary>
	[ComVisible(false)]
	public class Estar : CallObjectBase, IEstar
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Estar"/> class.
		/// </summary>
		public Estar(): base("ESTAR")
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Estar"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Estar(XmlNode node): base(node)
		{}

		#region IEstar Members

		/// <summary>
		/// Gets or sets the name of the shop.
		/// </summary>
		/// <value>The name of the shop.</value>
		public string ShopName
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
		/// Gets or sets the phone.
		/// </summary>
		/// <value>The phone.</value>
		public string Phone
		{
			get { return GetValue("PHONE"); }
			set { SetValue("PHONE", value); }
		}

		/// <summary>
		/// Gets or sets the fax.
		/// </summary>
		/// <value>The fax.</value>
		public string Fax
		{
			get { return GetValue("FAX"); }
			set { SetValue("FAX", value); }
		}

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		public string Type
		{
			get { return GetValue("TYPE"); }
			set { SetValue("TYPE", value); }
		}

		/// <summary>
		/// Gets or sets the appraiser code.
		/// </summary>
		/// <value>The appraiser code.</value>
		public string AppraiserCode
		{
			get { return GetValue("ESTAR_APPRAISER_CODE"); }
			set { SetValue("ESTAR_APPRAISER_CODE", value); }
		}
		#endregion
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/Estar.cs $
 * 
 * 2     5/04/09 3:55p John.gwynn
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * 1     5/03/08 7:54p John.gwynn
 * added Estar, IndependentAppraiser and Staf for phase III
 */
#endregion