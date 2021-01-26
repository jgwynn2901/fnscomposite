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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ThirdParty.cs 3     9/21/10 6:30p Gwynnj $ */
#endregion

using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class Thirdparty : CallObjectBase, IWitness
	{
		private const string _nodeTypeName = "THIRDPARTY";
		/// <summary>
		/// Initializes a new instance of the <see cref="Thirdparty"/> class.
		/// </summary>
		public Thirdparty()
			: base(_nodeTypeName)
		{ }
		/// <summary>
		/// Initializes a new instance of the <see cref="Thirdparty"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Thirdparty(XmlNode node)
			: base(node)
		{ }
		/// <summary>
		/// Initializes a new instance of the <see cref="Thirdparty"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="indexedName">Name of the indexed.</param>
		public Thirdparty(XmlNode node, string indexedName)
			: base(node, indexedName)
		{ }
		/// <summary>
		/// Initializes a new instance of the <see cref="Thirdparty"/> class.
		/// </summary>
		/// <param name="indexName">Name of the index.</param>
			public Thirdparty(string indexName)
			: base(_nodeTypeName + indexName)
		{ }

		/// <summary>
		/// Gets or sets the name first.
		/// </summary>
		/// <value>The name first.</value>
		public string NameFirst
		{
			get { return GetValue(EntityBase.FirstNameAttribute); }
			set { SetValue(EntityBase.FirstNameAttribute, value); }
		}

		/// <summary>
		/// Gets or sets the name last.
		/// </summary>
		/// <value>The name last.</value>
		public string NameLast
		{
			get { return GetValue(EntityBase.LastNameAttribute); }
			set { SetValue(EntityBase.LastNameAttribute, value); }
		}

		/// <summary>
		/// Gets or sets the name mid.
		/// </summary>
		/// <value>The name mid.</value>
		public string NameMid
		{
			get { return GetValue(EntityBase.MiddleNameAttribute); }
			set { SetValue(EntityBase.MiddleNameAttribute, value); }
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

		/// <summary>
		/// Gets or sets the phone home.
		/// </summary>
		/// <value>The phone home.</value>
		public string PhoneHome
		{
			get { return GetValue(EntityBase.HomePhoneAttribute); }
			set { SetValue(EntityBase.HomePhoneAttribute, value); }
		}

		/// <summary>
		/// Gets or sets the phone work.
		/// </summary>
		/// <value>The phone work.</value>
		public string PhoneWork
		{
			get { return GetValue(EntityBase.WorkPhoneAttribute); }
			set { SetValue(EntityBase.WorkPhoneAttribute, value); }
		}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ThirdParty.cs $
 * 
 * 3     9/21/10 6:30p Gwynnj
 * Created EntityBase to factor the IPerson interface
 * 
 * 2     2/18/08 8:31p John.gwynn
 * Moved Witness to CallObjects, Added ThirdParty to Insured and fixed
 * Passenger missing constructor
 * 
 * 1     2/18/08 8:15p John.gwynn
 */
#endregion