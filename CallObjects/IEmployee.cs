namespace FnsComposite.CallObjects
{
  public interface IEmployee : IPerson
  {
    /// <summary>
    /// Gets or sets the SSN.
    /// </summary>
    /// <value>
    /// The SSN.
    /// </value>
    string Ssn { get; set; }

    /// <summary>
    /// Gets or sets the annual salary.
    /// </summary>
    /// <value>
    /// The annual salary.
    /// </value>
    string AnnualSalary { get; set; }

    /// <summary>
    /// Gets or sets the average weekly wage.
    /// </summary>
    /// <value>
    /// The average weekly wage.
    /// </value>
    string AverageWeeklyWage { get; set; }

    /// <summary>
    /// Gets or sets the employee number.
    /// </summary>
    /// <value>
    /// The employee number.
    /// </value>
    string EmployeeNumber { get; set; }

    /// <summary>
    /// Gets or sets the client number.
    /// </summary>
    /// <value>
    /// The client number.
    /// </value>
    string ClientNumber { get; set; }

    /// <summary>
    /// Gets or sets the birth date.
    /// </summary>
    /// <value>
    /// The birth date.
    /// </value>
    string BirthDate { get; set; }

    /// <summary>
    /// Gets or sets the cost center identifier.
    /// </summary>
    /// <value>
    /// The cost center identifier.
    /// </value>
    string CostCenterId { get; set; }

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    /// <value>
    /// The email address.
    /// </value>
    string EmailAddress { get; set; }

    /// <summary>
    /// Gets or sets the state of the filing.
    /// </summary>
    /// <value>
    /// The state of the filing.
    /// </value>
    string FilingState { get; set; }

    /// <summary>
    /// Gets or sets the gender.
    /// </summary>
    /// <value>
    /// The gender.
    /// </value>
    string Gender { get; set; }

    /// <summary>
    /// Gets or sets the marital status.
    /// </summary>
    /// <value>
    /// The marital status.
    /// </value>
    string MaritalStatus { get; set; }

    /// <summary>
    /// Gets or sets the hire date.
    /// </summary>
    /// <value>
    /// The hire date.
    /// </value>
    string HireDate { get; set; }

    /// <summary>
    /// Gets or sets the job title.
    /// </summary>
    /// <value>
    /// The job title.
    /// </value>
    string JobTitle { get; set; }

    /// <summary>
    /// Gets or sets the reporting unit.
    /// </summary>
    /// <value>
    /// The reporting unit.
    /// </value>
    string ReportingUnit { get; set; }

    /// <summary>
    /// Gets or sets the type of the pay.
    /// </summary>
    /// <value>
    /// The type of the pay.
    /// </value>
    string PayType { get; set; }

    /// <summary>
    /// Gets or sets the name title.
    /// </summary>
    /// <value>
    /// The name title.
    /// </value>
    string NameTitle { get; set; }
    

  }
}
