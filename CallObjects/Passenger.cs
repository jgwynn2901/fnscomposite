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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Passenger.cs 4     9/21/10 6:29p Gwynnj $ */
#endregion

using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Implements CallObjects Passenger
	/// </summary>
	public class Passenger : EntityBase, IPassenger
	{
		private const string NodeTypeName = "PASSENGER";
		/// <summary>
		/// Initializes a new instance of the <see cref="Passenger"/> class.
		/// </summary>
		public Passenger()
			: base(NodeTypeName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Passenger"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Passenger(XmlNode node): base(node)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Passenger"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="indexedName">Name of the indexed.</param>
		public Passenger(XmlNode node, string indexedName) : base(node, indexedName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Passenger"/> class.
		/// </summary>
		/// <param name="indexName">Name of the index.</param>
		public Passenger(string indexName)
			: base(NodeTypeName + indexName)
		{}
		#region IPassenger Members

		/// <summary>
		/// Gets or sets the SSN.
		/// </summary>
		/// <value>The SSN.</value>
		public string Ssn
		{
			get { return GetValue("SSN"); }
			set { SetValue("SSN", value); }
		}

		/// <summary>
		/// Gets or sets the license number.
		/// </summary>
		/// <value>The license number.</value>
		public string LicenseNumber
		{
			get { return GetValue("LICENSE_NUMBER"); }
			set { SetValue("LICENSE_NUMBER", value); }
		}

		/// <summary>
		/// Gets or sets the state of the license.
		/// </summary>
		/// <value>The state of the license.</value>
		public string LicenseState
		{
			get { return GetValue("LICENSE_STATE"); }
			set { SetValue("LICENSE_STATE", value); }
		}

		/// <summary>
		/// Gets or sets the injury flag.
		/// </summary>
		/// <value>The injury flag.</value>
		public string InjuryFlag
		{
			get { return GetValue("INJURY_FLG"); }
			set { SetValue("INJURY_FLG", value); }
		}

		/// <summary>
		/// Gets or sets the gender.
		/// </summary>
		/// <value>The gender.</value>
		public string Gender
		{
			get { return GetValue("GENDER"); }
			set { SetValue("GENDER", value); }
		}

		/// <summary>
		/// Gets or sets the email address.
		/// </summary>
		/// <value>The email address.</value>
		public string EmailAddress
		{
			get { return GetValue("EMAIL_ADDRESS"); }
			set { SetValue("EMAIL_ADDRESS", value); }
		}

		/// <summary>
		/// Gets or sets the owner flag.
		/// </summary>
		/// <value>The owner flag.</value>
		public string OwnerFlag
		{
			get { return GetValue("OWNER_FLG"); }
			set { SetValue("OWNER_FLG", value); }
		}

		/// <summary>
		/// Gets or sets the birth date.
		/// </summary>
		/// <value>The birth date.</value>
		public string BirthDate
		{
			get { return GetValue("BIRTH_DT"); }
			set { SetValue("BIRTH_DT", value); }
		}

		/// <summary>
		/// Gets or sets the attorney insurance flag.
		/// </summary>
		/// <value>The attorney insurance flag.</value>
		public string AttorneyInsuranceFlag
		{
			get { return GetValue("ATTORNEY_INSURANCE_FLG"); }
			set { SetValue("ATTORNEY_INSURANCE_FLG", value); }
		}

		#endregion
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Passenger.cs $
 * 
 * 4     9/21/10 6:29p Gwynnj
 * Created EntityBase to factor the IPerson interface
 * 
 * 3     2/18/08 8:31p John.gwynn
 * Moved Witness to CallObjects, Added ThirdParty to Insured and fixed
 * Passenger missing constructor
 * 
 * 2     1/16/08 6:39p John.gwynn
 * added CallObjectBase to override SetValue
 * 
 * 1     10/30/07 7:12p John.gwynn
 * Support for new Business Rule evaluator
 */
#endregion