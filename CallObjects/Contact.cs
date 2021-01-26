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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Contact.cs 4     9/21/10 6:29p Gwynnj $ */
#endregion

using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Implements CallObjects Contact node
	/// </summary>
	public class Contact : EntityBase, IContact
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Contact"/> class.
		/// </summary>
		public Contact(): base("CONTACT")
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Contact"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Contact(XmlNode node): base(node)
		{}

		
		/// <summary>
		/// Copies from.
		/// </summary>
		/// <param name="insured">The insured.</param>
		public void CopyFrom(IInsured insured)
		{
			if (insured == null) return;
			NameFirst = insured.NameFirst;
			NameLast = insured.NameLast;
			NameMid = insured.NameMid;
			Address.Address1 = insured.Address.Address1;
			Address.Address2 = insured.Address.Address2;
			Address.Address3 = insured.Address.Address3;
			Address.City = insured.Address.City;
			Address.State = insured.Address.State;
			Address.County = insured.Address.County;
			Address.Fips = insured.Address.Fips;
			Address.Zip = insured.Address.Zip;
			PhoneHome = insured.PhoneHome;
			PhoneWork = insured.PhoneWork;
		}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Contact.cs $
 * 
 * 4     9/21/10 6:29p Gwynnj
 * Created EntityBase to factor the IPerson interface
 * 
 * 3     5/12/08 7:59p John.gwynn
 * fixed a bug with the CopyFrom not copying Address.State
 * 
 * 2     5/02/08 11:20a John.gwynn
 * added CopyFrom(IInsured) for Caller and Contact 
 * 
 * 1     5/01/08 4:13p John.gwynn
 * refactored IPerson interface and added support for Contact
 */
#endregion