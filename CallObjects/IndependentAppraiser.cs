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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IndependentAppraiser.cs 1     5/03/08 7:55p John.gwynn $ */
#endregion

using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject eSurance Independent Appraiser implementation
	/// </summary>
	public class IndependentAppraiser : CallObjectBase, IIndependentAppraiser
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IndependentAppraiser"/> class.
		/// </summary>
		public IndependentAppraiser()
			: base("INDEPENDENT_APPRAISER")
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="IndependentAppraiser"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public IndependentAppraiser(XmlNode node)
			: base(node)
		{}

		#region IIndependentAppraiser Members

		/// <summary>
		/// Gets or sets the name of the appraiser.
		/// </summary>
		/// <value>The name of the appraiser.</value>
		public string AppraiserName
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
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IndependentAppraiser.cs $
 * 
 * 1     5/03/08 7:55p John.gwynn
 * added Estar, IndependentAppraiser and Staf for phase III
 */
#endregion