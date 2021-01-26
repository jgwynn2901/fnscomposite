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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Branch.cs 4     9/21/10 6:29p Gwynnj $ */
#endregion

using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Implements CallObjects Branch
	/// </summary>
	public class Branch : CallObjectBase, IBranch
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Branch"/> class.
		/// </summary>
		public Branch(): base("BRANCH")
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Branch"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Branch(XmlNode node) : base (node)
		{}

		/// <summary>
		/// Gets or sets the name of the branch office.
		/// </summary>
		/// <value>The name of the branch office.</value>
		public string BranchOfficeName
		{
			get { return GetValue("BRANCH_OFFICE_NAME"); }
			set { SetValue("BRANCH_OFFICE_NAME", value); }
		}

    public string BranchOfficeNumber
    {
      get { return GetValue("BRANCH_OFFICE_NUMBER"); }
      set { SetValue("BRANCH_OFFICE_NUMBER", value); }
    }

    public string BranchOfficeType
    {
      get { return GetValue("BRANCH_OFFICE_TYPE"); }
      set { SetValue("BRANCH_OFFICE_TYPE", value); }
    }

	  public string ContactNameFirst
    {
      get { return GetValue("CONTACT_NAME_FIRST"); }
      set { SetValue("CONTACT_NAME_FIRST", value); }
    }
    public string ContactTitle
    {
      get { return GetValue("CONTACT_TITLE"); }
      set { SetValue("CONTACT_TITLE", value); }
    }
	  public string ContactNameLast
    {
      get { return GetValue("CONTACT_NAME_LAST"); }
      set { SetValue("CONTACT_NAME_LAST", value); }
    }
	  public string EmailAddress
    {
      get { return GetValue("EMAIL_ADDRESS"); }
      set { SetValue("EMAIL_ADDRESS", value); }
    }
	  public string Fein
    {
      get { return GetValue("FEIN"); }
      set { SetValue("FEIN", value); }
    }
	  public string OfficeHours
    {
      get { return GetValue("OFFICE_HOURS"); }
      set { SetValue("OFFICE_HOURS", value); }
    }

	  /// <summary>
		/// Gets or sets the branch number.
		/// </summary>
		/// <value>The branch number.</value>
		public string BranchNumber
		{
			get { return GetValue("BRANCH_NUMBER"); }
			set { SetValue("BRANCH_NUMBER", value); }
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
		/// Gets or sets the phone home.
		/// </summary>
		/// <value>The phone home.</value>
		public string PhoneFax
		{
			get { return GetValue("PHONE_FAX"); }
			set { SetValue("PHONE_FAX", value); }
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
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Branch.cs $
 * 
 * 4     9/21/10 6:29p Gwynnj
 * Created EntityBase to factor the IPerson interface
 * 
 * 3     1/16/08 6:39p John.gwynn
 * added CallObjectBase to override SetValue
 * 
 * 2     10/22/07 6:08p John.gwynn
 * 
 * 1     10/21/07 3:32p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion