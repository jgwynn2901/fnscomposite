#region Header
/**************************************************************************
 * First Notice Systems
 * 529 Main Street
 * Boston, MA 02129
 * (617) 886 2600
 *
 * Proprietary Source Code -- Distribution restricted
 *
 * Copyright (c) 2007 by First Notice Systems
 **************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/IAccountHierarchyStep.cs 2     10/28/09 5:21p John.gwynn $ */
#endregion


namespace FnsComposite.Interfaces
{
	/// <summary>
	/// Summary description for IAccountHierarchyStep.
	/// </summary>
	public interface IAccountHierarchyStep
	{
		/// <summary>
		/// Gets the ahs id.
		/// </summary>
		string AhsId { get; }
		/// <summary>
		/// Gets the parent node id.
		/// </summary>
		/// <value>The parent node id.</value>
		string ParentNodeId {get;}
		/// <summary>
		/// Gets the client node id.
		/// </summary>
		/// <value>The client node id.</value>
		string ClientNodeId {get;}
		/// <summary>
		/// Gets the full name.
		/// </summary>
		/// <value>The full name.</value>
		string FullName {get;}
		/// <summary>
		/// Gets the type of the ahs.
		/// </summary>
		/// <value>The type of the ahs.</value>
		string AhsType {get;}
		/// <summary>
		/// Gets the name of the first.
		/// </summary>
		/// <value>The name of the first.</value>
		string FirstName {get;}
		/// <summary>
		/// Gets the name of the last.
		/// </summary>
		/// <value>The name of the last.</value>
		string LastName {get;}
		/// <summary>
		/// Gets the mid initial.
		/// </summary>
		/// <value>The mid initial.</value>
		string MidInitial {get;}
		/// <summary>
		/// Gets the upload key.
		/// </summary>
		/// <value>The upload key.</value>
		string UploadKey {get;}
		/// <summary>
		/// Gets the address1.
		/// </summary>
		/// <value>The address1.</value>
		string Address1 {get;}
		/// <summary>
		/// Gets the address2.
		/// </summary>
		/// <value>The address2.</value>
		string Address2 {get;}
		/// <summary>
		/// Gets the address3.
		/// </summary>
		/// <value>The address3.</value>
		string Address3 {get;}
		/// <summary>
		/// Gets the city.
		/// </summary>
		/// <value>The city.</value>
		string City {get;}
		/// <summary>
		/// Gets the state.
		/// </summary>
		/// <value>The state.</value>
		string State {get;}
		/// <summary>
		/// Gets the zip.
		/// </summary>
		/// <value>The zip.</value>
		string Zip {get;}
		/// <summary>
		/// Gets the phone.
		/// </summary>
		/// <value>The phone.</value>
		string Phone {get;}
		/// <summary>
		/// Gets the alt phone.
		/// </summary>
		/// <value>The alt phone.</value>
		string AltPhone {get;}
		/// <summary>
		/// Gets the fax.
		/// </summary>
		/// <value>The fax.</value>
		string Fax {get;}
		/// <summary>
		/// Gets the alt fax.
		/// </summary>
		/// <value>The alt fax.</value>
		string AltFax {get;}
		/// <summary>
		/// Gets the fips.
		/// </summary>
		/// <value>The fips.</value>
		string Fips {get;}
		/// <summary>
		/// Gets the county.
		/// </summary>
		/// <value>The county.</value>
		string County {get;}
		/// <summary>
		/// Gets the country.
		/// </summary>
		/// <value>The country.</value>
		string Country {get;}
		/// <summary>
		/// Gets the nature of business.
		/// </summary>
		/// <value>The nature of business.</value>
		string NatureOfBusiness {get;}
		/// <summary>
		/// Gets the name of the sec.
		/// </summary>
		/// <value>The name of the sec.</value>
		string SecName {get;}
		/// <summary>
		/// Gets the sec code.
		/// </summary>
		/// <value>The sec code.</value>
		string SecCode {get;}
		/// <summary>
		/// Gets the name of the loc.
		/// </summary>
		/// <value>The name of the loc.</value>
		string LocName {get;}
		/// <summary>
		/// Gets the name of the division.
		/// </summary>
		/// <value>The name of the division.</value>
		string DivisionName {get;}
		/// <summary>
		/// Gets the division code.
		/// </summary>
		/// <value>The division code.</value>
		string DivisionCode {get;}
		/// <summary>
		/// Gets the location code.
		/// </summary>
		/// <value>The location code.</value>
		string LocationCode {get;}
		/// <summary>
		/// Gets the active status.
		/// </summary>
		/// <value>The active status.</value>
		string ActiveStatus {get;}
		/// <summary>
		/// Gets the fein.
		/// </summary>
		/// <value>The fein.</value>
		string Fein {get;}
		/// <summary>
		/// Gets the node type id.
		/// </summary>
		/// <value>The node type id.</value>
		string NodeTypeId {get;}
		/// <summary>
		/// Gets the node level.
		/// </summary>
		/// <value>The node level.</value>
		string NodeLevel {get;}
		/// <summary>
		/// Gets the sic.
		/// </summary>
		/// <value>The sic.</value>
		string Sic {get;}
		/// <summary>
		/// Gets the suid.
		/// </summary>
		/// <value>The suid.</value>
		string Suid {get;}
		/// <summary>
		/// Gets the file tran log id.
		/// </summary>
		/// <value>The file tran log id.</value>
		string FileTranLogId {get;}
		/// <summary>
		/// Gets the name of the department.
		/// </summary>
		/// <value>The name of the department.</value>
		string DepartmentName {get;}
		/// <summary>
		/// Gets the department code.
		/// </summary>
		/// <value>The department code.</value>
		string DepartmentCode {get;}
		/// <summary>
		/// Gets the specific destination flag.
		/// </summary>
		/// <value>The specific destination flag.</value>
		string SpecificDestinationFlag {get;}
		/// <summary>
		/// Gets the name short.
		/// </summary>
		/// <value>The name short.</value>
		string NameShort {get;}
		/// <summary>
		/// Gets the actec code.
		/// </summary>
		/// <value>The actec code.</value>
		string ActecCode {get;}
		/// <summary>
		/// Gets the account from date.
		/// </summary>
		/// <value>The account from date.</value>
		string AccountFromDate {get;}
		/// <summary>
		/// Gets the account to date.
		/// </summary>
		/// <value>The account to date.</value>
		string AccountToDate {get;}
		/// <summary>
		/// Gets the name of the account.
		/// </summary>
		/// <value>The name of the account.</value>
		string AccountName {get;}
		/// <summary>
		/// Gets the account password.
		/// </summary>
		/// <value>The account password.</value>
		string AccountPassword {get;}
		/// <summary>
		/// Gets the email address.
		/// </summary>
		/// <value>The email address.</value>
		string EmailAddress {get;}
		/// <summary>
		/// Gets the naics code.
		/// </summary>
		/// <value>The naics code.</value>
		string NaicsCode {get;}
		/// <summary>
		/// Gets the agent billing method.
		/// </summary>
		/// <value>The agent billing method.</value>
		string AgentBillingMethod {get;}
		/// <summary>
		/// Gets the type of the agent payment.
		/// </summary>
		/// <value>The type of the agent payment.</value>
		string AgentPaymentType {get;}
		}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/IAccountHierarchyStep.cs $
 * 
 * 2     10/28/09 5:21p John.gwynn
 * Removed redundant IAccountHeirarchyStep interface
 * 
 * 1     7/10/07 5:32p John.gwynn
 * Added new Interfaces for OPM, ported 1.1 interfaces and segment
 * updates.  
 * 
 * 1     6/21/07 5:47p John.gwynn
 * Added IEmployee, IAccountHierarchyStep and IPolicy for default segment
 * copy costructors for loads
 */
#endregion
