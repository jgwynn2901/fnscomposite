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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Caller.cs 6     9/21/10 6:29p Gwynnj $ */
#endregion

using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Implements CallObjects Caller node
	/// </summary>
	public class Caller : EntityBase, ICaller
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Caller"/> class.
		/// </summary>
		public Caller(): base("CALLER")
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Caller"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Caller(XmlNode node) : base (node)
		{}

		#region ICaller Members

		
		/// <summary>
		/// Gets or sets the type of the caller.
		/// </summary>
		/// <value>The type of the caller.</value>
		public string CallerType
		{
			get { return GetValue("CALLER_TYPE"); }
			set { SetValue("CALLER_TYPE", value); }
		}

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

		#endregion
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Caller.cs $
 * 
 * 6     9/21/10 6:29p Gwynnj
 * Created EntityBase to factor the IPerson interface
 * 
 * 5     5/12/08 7:59p John.gwynn
 * fixed a bug with the CopyFrom not copying Address.State
 * 
 * 4     5/04/08 7:59p John.gwynn
 * fixed a bug in the CopyFrom method
 * 
 * 3     5/02/08 11:20a John.gwynn
 * added CopyFrom(IInsured) for Caller and Contact 
 * 
 * 2     5/01/08 4:13p John.gwynn
 * refactored IPerson interface and added support for Contact
 * 
 * 1     10/22/07 6:08p John.gwynn
 */
#endregion