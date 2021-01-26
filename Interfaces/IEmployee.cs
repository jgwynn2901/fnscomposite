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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/IEmployee.cs 1     7/10/07 5:32p John.gwynn $ */
#endregion

namespace FnsComposite.Interfaces
{
	/// <summary>
	/// IEmployee inteface to be used to manage the Employee object
	/// </summary>
	public interface IEmployee
	{
		/// <summary>
		/// Social Security Number
		/// </summary>
		string Ssn { get; }
		/// <summary>
		/// Client AccountHierarchyStepId
		/// </summary>
		/// <value>The ahs id.</value>
		string AhsId {get;}
		/// <summary>
		/// First Name
		/// </summary>
		/// <value>The name of the first.</value>
		string FirstName {get;}
		/// <summary>
		/// Last Name
		/// </summary>
		string LastName {get;}
		/// <summary>
		/// Mid Init
		/// </summary>
		/// <value>The middle initial.</value>
		string MiddleInitial {get;}
		/// <summary>
		/// Title
		/// </summary>
		/// <value>The title.</value>
		string Title {get;}
		/// <summary>
		/// Address1
		/// </summary>
		/// <value>The address1.</value>
		string Address1 {get;}
		/// <summary>
		/// Gets the address2.
		/// </summary>
		/// <value>The address2.</value>
		string Address2 {get;}
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
		/// Gets the country.
		/// </summary>
		/// <value>The country.</value>
		string Country {get;}
		/// <summary>
		/// Gets the phone.
		/// </summary>
		/// <value>The phone.</value>
		string Phone {get;}
		/// <summary>
		/// Gets the client number.
		/// </summary>
		/// <value>The client number.</value>
		string ClientNumber {get;}
		/// <summary>
		/// Gets the state of the filing.
		/// </summary>
		/// <value>The state of the filing.</value>
		string FilingState {get;}
		/// <summary>
		/// Gets the total dependents.
		/// </summary>
		/// <value>The total dependents.</value>
		string TotalDependents {get;}
		/// <summary>
		/// Gets the dep18 under.
		/// </summary>
		/// <value>The dep18 under.</value>
		string Dep18Under {get;}
		/// <summary>
		/// Gets the date of birth.
		/// </summary>
		/// <value>The date of birth.</value>
		string DateOfBirth {get;}
		/// <summary>
		/// Gets the gender.
		/// </summary>
		/// <value>The gender.</value>
		string Gender {get;}
		/// <summary>
		/// Gets the marital status.
		/// </summary>
		/// <value>The marital status.</value>
		string MaritalStatus {get;}
		/// <summary>
		/// Gets the reporting unit.
		/// </summary>
		/// <value>The reporting unit.</value>
		string ReportingUnit {get;}
		/// <summary>
		/// Gets the department.
		/// </summary>
		/// <value>The department.</value>
		string Department {get;}
		/// <summary>
		/// Gets the status.
		/// </summary>
		/// <value>The status.</value>
		string Status {get;}
		/// <summary>
		/// Gets the date of hire.
		/// </summary>
		/// <value>The date of hire.</value>
		string DateOfHire {get;}
		/// <summary>
		/// Gets the job code.
		/// </summary>
		/// <value>The job code.</value>
		string JobCode {get;}
		/// <summary>
		/// Gets the job title.
		/// </summary>
		/// <value>The job title.</value>
		string JobTitle {get;}
		/// <summary>
		/// Gets the employee code.
		/// </summary>
		/// <value>The employee code.</value>
		string EmployeeCode {get;}
		/// <summary>
		/// Gets the wage frequency.
		/// </summary>
		/// <value>The wage frequency.</value>
		string WageFrequency {get;}
		/// <summary>
		/// Gets the union code.
		/// </summary>
		/// <value>The union code.</value>
		string UnionCode {get;}
		/// <summary>
		/// Gets the upload key.
		/// </summary>
		/// <value>The upload key.</value>
		string UploadKey {get;}
		/// <summary>
		/// Gets the test flag.
		/// </summary>
		/// <value>The test flag.</value>
		string TestFlag {get;}
		/// <summary>
		/// Gets the name of the supervisor first.
		/// </summary>
		/// <value>The name of the supervisor first.</value>
		string SupervisorFirstName {get;}
		/// <summary>
		/// Gets the name of the supervisor last.
		/// </summary>
		/// <value>The name of the supervisor last.</value>
		string SupervisorLastName {get;}
		/// <summary>
		/// Gets the supervisor phone.
		/// </summary>
		/// <value>The supervisor phone.</value>
		string SupervisorPhone {get;}
		/// <summary>
		/// Gets the ncci job class.
		/// </summary>
		/// <value>The ncci job class.</value>
		string NcciJobClass {get;}
		/// <summary>
		/// Gets the hourly wage.
		/// </summary>
		/// <value>The hourly wage.</value>
		string HourlyWage {get;}
		/// <summary>
		/// Gets the annual salary.
		/// </summary>
		/// <value>The annual salary.</value>
		string AnnualSalary {get;}
		/// <summary>
		/// Gets the monthly wage.
		/// </summary>
		/// <value>The monthly wage.</value>
		string MonthlyWage {get;}
		/// <summary>
		/// Gets the daily wage.
		/// </summary>
		/// <value>The daily wage.</value>
		string DailyWage {get;}
		/// <summary>
		/// Gets the paid for overtime.
		/// </summary>
		/// <value>The paid for overtime.</value>
		string PaidForOvertime {get;}
		/// <summary>
		/// Gets the terminate date.
		/// </summary>
		/// <value>The terminate date.</value>
		string TerminateDate {get;}
		/// <summary>
		/// Gets the work phone.
		/// </summary>
		/// <value>The work phone.</value>
		string WorkPhone {get;}
		/// <summary>
		/// Gets the cost center id.
		/// </summary>
		/// <value>The cost center id.</value>
		string CostCenterId {get;}
		/// <summary>
		/// Gets the employment status.
		/// </summary>
		/// <value>The employment status.</value>
		string EmploymentStatus {get;}
		/// <summary>
		/// Gets the special id.
		/// </summary>
		/// <value>The special id.</value>
		string SpecialId {get;}
		/// <summary>
		/// Gets the file tran log id.
		/// </summary>
		/// <value>The file tran log id.</value>
		string FileTranLogId {get;}
		/// <summary>
		/// Gets the telecommuter FLG.
		/// </summary>
		/// <value>The telecommuter FLG.</value>
		string TelecommuterFlg {get;}
		/// <summary>
		/// Gets the supervisor email.
		/// </summary>
		/// <value>The supervisor email.</value>
		string SupervisorEmail {get;}
		/// <summary>
		/// Gets the close date.
		/// </summary>
		/// <value>The close date.</value>
		string CloseDate {get;}
		/// <summary>
		/// Gets the flsa status.
		/// </summary>
		/// <value>The flsa status.</value>
		string FlsaStatus {get;}
 
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/IEmployee.cs $
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
