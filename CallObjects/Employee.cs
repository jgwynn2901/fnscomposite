using System.Xml;

namespace FnsComposite.CallObjects
{
  public class Employee : EntityBase, IEmployee
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Employee" /> class.
    /// </summary>
    public Employee() : base("EMPLOYEE")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Employee"/> class.
    /// </summary>
    /// <param name="node">The node.</param>
    public Employee(XmlNode node) : base(node)
    {
    }

    /// <summary>
    /// Gets or sets the SSN.
    /// </summary>
    /// <value>
    /// The SSN.
    /// </value>
    public string Ssn
    {
      get { return GetValue("SSN"); }
      set { SetValue("SSN", value); }
    }
    /// <summary>
    /// Gets or sets the annual salary.
    /// </summary>
    /// <value>
    /// The annual salary.
    /// </value>
    public string AnnualSalary
    {
      get { return GetValue("ANNUAL_SALARY"); }
      set { SetValue("ANNUAL_SALARY", value); }
    }
    /// <summary>
    /// Gets or sets the average weekly wage.
    /// </summary>
    /// <value>
    /// The average weekly wage.
    /// </value>
    public string AverageWeeklyWage
    {
      get { return GetValue("AVERAGE_WEEKLY_WAGE"); }
      set { SetValue("AVERAGE_WEEKLY_WAGE", value); }
    }
    /// <summary>
    /// Gets or sets the client number.
    /// </summary>
    /// <value>
    /// The client number.
    /// </value>
    public string ClientNumber
    {
      get { return GetValue("CLIENT_NUMBER"); }
      set { SetValue("CLIENT_NUMBER", value); }
    }
    /// <summary>
    /// Gets or sets the birth date.
    /// </summary>
    /// <value>
    /// The birth date.
    /// </value>
    public string BirthDate
    {
      get { return GetValue("BIRTH_DT"); }
      set { SetValue("BIRTH_DT", value); }
    }
    /// <summary>
    /// Gets or sets the cost center identifier.
    /// </summary>
    /// <value>
    /// The cost center identifier.
    /// </value>
    public string CostCenterId
    {
      get { return GetValue("COST_CENTER_ID"); }
      set { SetValue("COST_CENTER_ID", value); }
    }
    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    /// <value>
    /// The email address.
    /// </value>
    public string EmailAddress
    {
      get { return GetValue("EMAIL_ADDRESS"); }
      set { SetValue("EMAIL_ADDRESS", value); }
    }
    /// <summary>
    /// Gets or sets the employee number.
    /// </summary>
    /// <value>
    /// The employee number.
    /// </value>
    public string EmployeeNumber
    {
      get { return GetValue("EMPLOYEE_CODE"); }
      set { SetValue("EMPLOYEE_CODE", value); }
    }
    /// <summary>
    /// Gets or sets the state of the filing.
    /// </summary>
    /// <value>
    /// The state of the filing.
    /// </value>
    public string FilingState
    {
      get { return GetValue("FILING_STATE"); }
      set { SetValue("FILING_STATE", value); }
    }
    /// <summary>
    /// Gets or sets the gender.
    /// </summary>
    /// <value>
    /// The gender.
    /// </value>
    public string Gender
    {
      get { return GetValue("GENDER"); }
      set { SetValue("GENDER", value); }
    }
    /// <summary>
    /// Gets or sets the marital status.
    /// </summary>
    /// <value>
    /// The marital status.
    /// </value>
    public string MaritalStatus
    {
      get { return GetValue("MARITAL_STATUS"); }
      set { SetValue("MARITAL_STATUS", value); }
    }
    /// <summary>
    /// Gets or sets the hire date.
    /// </summary>
    /// <value>
    /// The hire date.
    /// </value>
    public string HireDate
    {
      get { return GetValue("HIRE_DATE"); }
      set { SetValue("HIRE_DATE", value); }
    }
    /// <summary>
    /// Gets or sets the job title.
    /// </summary>
    /// <value>
    /// The job title.
    /// </value>
    public string JobTitle
    {
      get { return GetValue("JOB_TITLE"); }
      set { SetValue("JOB_TITLE", value); }
    }
    /// <summary>
    /// Gets or sets the reporting unit.
    /// </summary>
    /// <value>
    /// The reporting unit.
    /// </value>
    public string ReportingUnit
    {
      get { return GetValue("REPORTING_UNIT"); }
      set { SetValue("REPORTING_UNIT", value); }
    }
    /// <summary>
    /// Gets or sets the type of the pay.
    /// </summary>
    /// <value>
    /// The type of the pay.
    /// </value>
    public string PayType
    {
      get { return GetValue("PAY_TYPE"); }
      set { SetValue("PAY_TYPE", value); }
    }
    /// <summary>
    /// Gets or sets the name title.
    /// </summary>
    /// <value>
    /// The name title.
    /// </value>
    public string NameTitle
    {
      get { return GetValue("NAME_TITLE"); }
      set { SetValue("NAME_TITLE", value); }
    }
  }
}
