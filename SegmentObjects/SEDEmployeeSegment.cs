#region Header
/**************************************************************************
 * Source File -- SEDEmployeeSegment.cs
 * 
 * NAME: FnsComposite.SegmentObjects.SEDEmployeeSegment.cs
 * AUTHOR: Pintoa

 * Innovation First Notice
 * 140 Kendrick Street 
 * Building A, Suite 300 
 * Needham, MA 02494
 * (617) 886-2600
 *
 * Proprietary Source Code -- Distribution restricted
 *
 * Copyright (c) 2012 by First Notice Systems
 **************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/SEDEmployeeSegment.cs 1     4/26/12 6:49p Pintoa $ */
#endregion

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using FnsComposite.CallObjects;
using FnsComposite.Interfaces;

namespace FnsComposite.SegmentObjects
{
    [ClassInterface(ClassInterfaceType.None), ComVisible(false)]
    // ReSharper disable InconsistentNaming
    public class SEDEmployeeSegment : Segment, ISEDEmployee
    // ReSharper restore InconsistentNaming
    {
        private enum ParmList
        {
            EmployeeId = 0,
            AhsId,
            Ssn,
            FirstName,
            LastName,
            MiddleInitial,
            Title,
            Address1,
            Address2,
            City,
            State,
            Zip,
            Country,
            Phone,
            ClientNumber,
            FilingState,
            TotalDependents,
            Dep18Under,
            DateOfBirth,
            Gender,
            MaritalStatus,
            ReportingUnit,
            Department,
            Status,
            DateOfHire,
            JobCode,
            JobTitle,
            EmployeeCode,
            WageFrequency,
            UnionCode,
            UploadKey,
            TestFlag,
            SupervisorFirstName,
            SupervisorLastName,
            SupervisorPhone,
            NcciJobClass,
            HourlyWage,
            AnnualSalary,
            MonthlyWage,
            DailyWage,
            PaidForOvertime,
            TerminateDate,
            WorkPhone,
            CostCenterId,
            EmploymentStatus,
            SpecialId,
            FileTranLogId,
            TelecommuterFlg,
            SupervisorEmail,
            CloseDate,
            FlsaStatus,
            RecordActive
        };
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeSegment"/> class.
        /// </summary>
        public SEDEmployeeSegment()
            : base("EMPLOYEE")
        {
            ColumnNames = new[]
			              	{
			              		"EMPLOYEE_ID",
			              		"ACCNT_HRCY_STEP_ID",
			              		"SSN",
			              		EntityBase.FirstNameAttribute,
			              		EntityBase.LastNameAttribute,
			              		EntityBase.MiddleNameAttribute,
			              		"TITLE",
			              		"ADDRESS1",
			              		"ADDRESS2",
			              		"CITY",
			              		"STATE",
			              		"ZIP",
			              		"COUNTRY",
			              		"PHONE",
			              		"CLIENT_NUMBER",
			              		"FILING_STATE",
			              		"TOTAL_DEPENDENTS",
			              		"DEPENDENTS_18_UNDER",
			              		"DATE_OF_BIRTH",
			              		"GENDER",
			              		"MARITAL_STATUS",
			              		"REPORTING_UNIT",
			              		"DEPARTMENT",
			              		"STATUS",
			              		"DATE_OF_HIRE",
			              		"JOB_CODE",
			              		"JOB_TITLE",
			              		"EMPLOYEE_CODE",
			              		"WAGE_FREQUENCY",
			              		"UNION_CODE",
			              		"UPLOAD_KEY",
			              		"TEST_FLG",
			              		"SUPERVISOR_NAME_FIRST",
			              		"SUPERVISOR_NAME_LAST",
			              		"SUPERVISOR_PHONE_WORK",
			              		"NCCI_JOBCLASS",
			              		"HOURLY_WAGE",
			              		"ANNUAL_SALARY",
			              		"MONTHLY_WAGE",
			              		"DAILY_WAGE",
			              		"PAID_FOR_OVERTIME_FLG",
			              		"DATE_OF_TERMINATION",
			              		EntityBase.WorkPhoneAttribute,
			              		"COST_CENTER_ID",
			              		"EMPLOYMENT_STATUS",
			              		"SPECIAL_ID",
			              		"FILE_TRANSMISSION_LOG_ID",
			              		"TELECOMMUTER_FLG",
			              		"SUPERVISOR_EMAIL_ADDRESS",
			              		"CLOSE_DATE",
			              		"FLSA_STATUS",
                                "RECORD_ACTIVE"                                
			              	};
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeSegment"/> class.
        /// </summary>
        /// <param name="rec">The rec.</param>
        public SEDEmployeeSegment(ISEDEmployee rec)
            : this()
        {
            Ssn = rec.Ssn;
            AhsId = rec.AhsId;
            FirstName = rec.FirstName;
            LastName = rec.LastName;
            MiddleInitial = rec.MiddleInitial;
            Title = rec.Title;
            Address1 = rec.Address1;
            Address2 = rec.Address2;
            City = rec.City;
            State = rec.State;
            Zip = rec.Zip;
            Country = rec.Country;
            ClientNumber = rec.ClientNumber;
            FilingState = rec.FilingState;
            TotalDependents = rec.TotalDependents;
            Dep18Under = rec.Dep18Under;
            DateOfBirth = rec.DateOfBirth;
            Gender = rec.Gender;
            MaritalStatus = rec.MaritalStatus;
            ReportingUnit = rec.ReportingUnit;
            Department = rec.Department;
            Status = rec.Status;
            DateOfHire = rec.DateOfHire;
            JobCode = rec.JobCode;
            JobTitle = rec.JobTitle;
            EmployeeCode = rec.EmployeeCode;
            WageFrequency = rec.WageFrequency;
            UnionCode = rec.UnionCode;
            UploadKey = rec.UploadKey;
            TestFlag = rec.TestFlag;
            SupervisorFirstName = rec.SupervisorFirstName;
            SupervisorLastName = rec.SupervisorLastName;
            SupervisorPhone = rec.SupervisorPhone;
            NcciJobClass = rec.NcciJobClass;
            HourlyWage = rec.HourlyWage;
            AnnualSalary = rec.AnnualSalary;
            MonthlyWage = rec.MonthlyWage;
            DailyWage = rec.DailyWage;
            PaidForOvertime = rec.PaidForOvertime;
            TerminateDate = rec.TerminateDate;
            WorkPhone = rec.WorkPhone;
            CostCenterId = rec.CostCenterId;
            EmploymentStatus = rec.EmploymentStatus;
            SpecialId = rec.SpecialId;
            FileTranLogId = rec.FileTranLogId;
            TelecommuterFlg = rec.TelecommuterFlg;
            SupervisorEmail = rec.SupervisorEmail;
            CloseDate = rec.CloseDate;
            FlsaStatus = rec.FlsaStatus;
            Phone = rec.Phone;
            RecordActive = rec.RecordActive;
        }
        #endregion
        #region EmployeeId
        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        public string EmployeeId
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.EmployeeId]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.EmployeeId], value);
            }
        }
        #endregion
        #region AhsId
        /// <summary>
        /// Gets or sets the ahs id.
        /// </summary>
        /// <value>The ahs id.</value>
        public string AhsId
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.AhsId]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.AhsId], value);
            }
        }
        #endregion
        #region Ssn
        /// <summary>
        /// Gets or sets the SSN.
        /// </summary>
        /// <value>The SSN.</value>
        public string Ssn
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.Ssn]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.Ssn], value);
            }
        }
        #endregion
        #region FirstName
        /// <summary>
        /// Gets or sets the name of the first.
        /// </summary>
        /// <value>The name of the first.</value>
        public string FirstName
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.FirstName]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.FirstName], value);
            }
        }
        #endregion
        #region LastName
        /// <summary>
        /// Gets or sets the name of the last.
        /// </summary>
        /// <value>The name of the last.</value>
        public string LastName
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.LastName]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.LastName], value);
            }
        }
        #endregion
        #region MiddleInitial
        /// <summary>
        /// Gets or sets the middle initial.
        /// </summary>
        /// <value>The middle initial.</value>
        public string MiddleInitial
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.MiddleInitial]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.MiddleInitial], value);
            }
        }
        #endregion
        #region Title
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.Title]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.Title], value);
            }
        }
        #endregion
        #region Address1
        /// <summary>
        /// Gets or sets the address1.
        /// </summary>
        /// <value>The address1.</value>
        public string Address1
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.Address1]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.Address1], value);
            }
        }
        #endregion
        #region Address2
        /// <summary>
        /// Gets or sets the address2.
        /// </summary>
        /// <value>The address2.</value>
        public string Address2
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.Address2]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.Address2], value);
            }
        }
        #endregion
        #region City
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.City]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.City], value);
            }
        }
        #endregion
        #region State
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public string State
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.State]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.State], value);
            }
        }
        #endregion
        #region Zip
        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        public string Zip
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.Zip]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.Zip], value);
            }
        }
        #endregion
        #region Country
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.Country]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.Country], value);
            }
        }
        #endregion
        #region Phone
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.Phone]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.Phone], value);
            }
        }
        #endregion
        #region ClientNumber
        /// <summary>
        /// Gets or sets the client number.
        /// </summary>
        /// <value>The client number.</value>
        public string ClientNumber
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.ClientNumber]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.ClientNumber], value);
            }
        }
        #endregion
        #region FilingState
        /// <summary>
        /// Gets or sets the state of the filing.
        /// </summary>
        /// <value>The state of the filing.</value>
        public string FilingState
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.FilingState]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.FilingState], value);
            }
        }
        #endregion
        #region LastName
        /// <summary>
        /// Gets or sets the total dependents.
        /// </summary>
        /// <value>The total dependents.</value>
        public string TotalDependents
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.TotalDependents]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.TotalDependents], value);
            }
        }
        #endregion
        #region Dep18Under
        /// <summary>
        /// Gets or sets the dep18 under.
        /// </summary>
        /// <value>The dep18 under.</value>
        public string Dep18Under
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.Dep18Under]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.Dep18Under], value);
            }
        }
        #endregion
        #region DateOfBirth
        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>The date of birth.</value>
        public string DateOfBirth
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.DateOfBirth]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.DateOfBirth], value);
            }
        }
        #endregion
        #region Gender
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public string Gender
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.Gender]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.Gender], value);
            }
        }
        #endregion
        #region MaritalStatus
        /// <summary>
        /// Gets or sets the marital status.
        /// </summary>
        /// <value>The marital status.</value>
        public string MaritalStatus
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.MaritalStatus]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.MaritalStatus], value);
            }
        }
        #endregion
        #region ReportingUnit
        /// <summary>
        /// Gets or sets the reporting unit.
        /// </summary>
        /// <value>The reporting unit.</value>
        public string ReportingUnit
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.ReportingUnit]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.ReportingUnit], value);
            }
        }
        #endregion
        #region Department
        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>The department.</value>
        public string Department
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.Department]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.Department], value);
            }
        }
        #endregion
        #region Status
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.Status]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.Status], value);
            }
        }
        #endregion
        #region DateOfHire
        /// <summary>
        /// Gets or sets the date of hire.
        /// </summary>
        /// <value>The date of hire.</value>
        public string DateOfHire
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.DateOfHire]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.DateOfHire], value);
            }
        }
        #endregion
        #region JobCode
        /// <summary>
        /// Gets or sets the job code.
        /// </summary>
        /// <value>The job code.</value>
        public string JobCode
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.JobCode]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.JobCode], value);
            }
        }
        #endregion
        #region JobTitle
        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        /// <value>The job title.</value>
        public string JobTitle
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.JobTitle]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.JobTitle], value);
            }
        }
        #endregion
        #region EmployeeCode
        /// <summary>
        /// Gets or sets the employee code.
        /// </summary>
        /// <value>The employee code.</value>
        public string EmployeeCode
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.EmployeeCode]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.EmployeeCode], value);
            }
        }
        #endregion
        #region WageFrequency
        /// <summary>
        /// Gets or sets the wage frequency.
        /// </summary>
        /// <value>The wage frequency.</value>
        public string WageFrequency
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.WageFrequency]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.WageFrequency], value);
            }
        }
        #endregion
        #region Status
        /// <summary>
        /// Gets or sets the upload key.
        /// </summary>
        /// <value>The upload key.</value>
        public string UploadKey
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.UploadKey]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.UploadKey], value);
            }
        }
        #endregion
        #region TestFlag
        /// <summary>
        /// Gets or sets the test flag.
        /// </summary>
        /// <value>The test flag.</value>
        public string TestFlag
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.TestFlag]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.TestFlag], value);
            }
        }
        #endregion
        #region SupervisorFirstName
        /// <summary>
        /// Gets or sets the name of the supervisor first.
        /// </summary>
        /// <value>The name of the supervisor first.</value>
        public string SupervisorFirstName
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.SupervisorFirstName]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.SupervisorFirstName], value);
            }
        }
        #endregion
        #region SupervisorLastName
        /// <summary>
        /// Gets or sets the name of the supervisor last.
        /// </summary>
        /// <value>The name of the supervisor last.</value>
        public string SupervisorLastName
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.SupervisorLastName]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.SupervisorLastName], value);
            }
        }
        #endregion
        #region SupervisorPhone
        /// <summary>
        /// Gets or sets the supervisor phone.
        /// </summary>
        /// <value>The supervisor phone.</value>
        public string SupervisorPhone
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.SupervisorPhone]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.SupervisorPhone], value);
            }
        }
        #endregion
        #region NcciJobClass
        /// <summary>
        /// Gets or sets the ncci job class.
        /// </summary>
        /// <value>The ncci job class.</value>
        public string NcciJobClass
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.NcciJobClass]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.NcciJobClass], value);
            }
        }
        #endregion
        #region HourlyWage
        /// <summary>
        /// Gets or sets the hourly wage.
        /// </summary>
        /// <value>The hourly wage.</value>
        public string HourlyWage
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.HourlyWage]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.HourlyWage], value);
            }
        }
        #endregion
        #region AnnualSalary
        /// <summary>
        /// Gets or sets the annual salary.
        /// </summary>
        /// <value>The annual salary.</value>
        public string AnnualSalary
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.AnnualSalary]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.AnnualSalary], value);
            }
        }
        #endregion
        #region MonthlyWage
        /// <summary>
        /// Gets or sets the monthly wage.
        /// </summary>
        /// <value>The monthly wage.</value>
        public string MonthlyWage
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.MonthlyWage]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.MonthlyWage], value);
            }
        }
        #endregion
        #region DailyWage
        /// <summary>
        /// Gets or sets the daily wage.
        /// </summary>
        /// <value>The daily wage.</value>
        public string DailyWage
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.DailyWage]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.DailyWage], value);
            }
        }
        #endregion
        #region PaidForOvertime
        /// <summary>
        /// Gets or sets the paid for overtime.
        /// </summary>
        /// <value>The paid for overtime.</value>
        public string PaidForOvertime
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.PaidForOvertime]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.PaidForOvertime], value);
            }
        }
        #endregion
        #region WorkPhone
        /// <summary>
        /// Gets or sets the work phone.
        /// </summary>
        /// <value>The work phone.</value>
        public string WorkPhone
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.WorkPhone]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.WorkPhone], value);
            }
        }
        #endregion
        #region TerminateDate
        /// <summary>
        /// Gets or sets the terminate date.
        /// </summary>
        /// <value>The terminate date.</value>
        public string TerminateDate
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.TerminateDate]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.TerminateDate], value);
            }
        }
        #endregion
        #region CostCenterId
        /// <summary>
        /// Gets or sets the cost center id.
        /// </summary>
        /// <value>The cost center id.</value>
        public string CostCenterId
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.CostCenterId]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.CostCenterId], value);
            }
        }
        #endregion
        #region EmploymentStatus
        /// <summary>
        /// Gets or sets the employment status.
        /// </summary>
        /// <value>The employment status.</value>
        public string EmploymentStatus
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.EmploymentStatus]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.EmploymentStatus], value);
            }
        }
        #endregion
        #region SpecialId
        /// <summary>
        /// Gets or sets the special id.
        /// </summary>
        /// <value>The special id.</value>
        public string SpecialId
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.SpecialId]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.SpecialId], value);
            }
        }
        #endregion
        #region UnionCode
        /// <summary>
        /// Gets or sets the union code.
        /// </summary>
        /// <value>The union code.</value>
        public string UnionCode
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.UnionCode]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.UnionCode], value);
            }
        }
        #endregion
        #region FileTranLogId
        /// <summary>
        /// Gets or sets the file tran log id.
        /// </summary>
        /// <value>The file tran log id.</value>
        public string FileTranLogId
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.FileTranLogId]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.FileTranLogId], value);
            }
        }
        #endregion
        #region TelecommuterFlg
        /// <summary>
        /// Gets or sets the telecommuter FLG.
        /// </summary>
        /// <value>The telecommuter FLG.</value>
        public string TelecommuterFlg
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.TelecommuterFlg]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.TelecommuterFlg], value);
            }
        }
        #endregion
        #region SupervisorEmail
        /// <summary>
        /// Gets or sets the supervisor email.
        /// </summary>
        /// <value>The supervisor email.</value>
        public string SupervisorEmail
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.SupervisorEmail]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.SupervisorEmail], value);
            }
        }
        #endregion
        #region CloseDate
        /// <summary>
        /// Gets or sets the close date.
        /// </summary>
        /// <value>The close date.</value>
        public string CloseDate
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.CloseDate]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.CloseDate], value);
            }
        }
        #endregion
        #region FlsaStatus
        /// <summary>
        /// Gets or sets the flsa status.
        /// </summary>
        /// <value>The flsa status.</value>
        public string FlsaStatus
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.FlsaStatus]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.FlsaStatus], value);
            }
        }
        #endregion
        #region RecordActive
        /// <summary>
        /// Gets or sets the employee status.
        /// </summary>
        /// <value>The employee status.</value>
        public string RecordActive
        {
            get
            {
                return GetValue(ColumnNames[(int)ParmList.RecordActive]);
            }
            set
            {
                SetValue(ColumnNames[(int)ParmList.RecordActive], value);
            }
        }
        #endregion

        /// <summary>
        /// Sets the parent key.
        /// </summary>
        public override void SetParentKey(string key)
        {
            if (EmployeeId.Length <= 0) return;

            foreach (Segment segment in SegmentList)
                segment.SetParentKey(EmployeeId);
        }

        /// <summary>
        /// Provide validation for the segment by overriding this method.
        /// </summary>
        protected override void ValidationMethod(object sender, EventArgs e)
        {
            Trace.WriteLine("ValidationMethod entered.", Name);

            if (FirstName.Length > 40)
                FirstName = FirstName.Substring(0, 40);

            if (LastName.Length > 80)
                LastName = LastName.Substring(0, 80);

            if (MiddleInitial.Length > 1)
                MiddleInitial = MiddleInitial.Substring(0, 1);

        }
    }
}