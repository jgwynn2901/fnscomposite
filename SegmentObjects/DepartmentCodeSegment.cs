using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FnsComposite.SegmentObjects
{
	/// <summary>
	/// 
	/// </summary>
	[ComVisible(false)]
	public class DepartmentCodeSegment : Segment
	{
		private const string ParentName = "ACCOUNT_HIERARCHY_STEP";

		private enum ParmList
		{
			/// <summary>
			/// the primary key
			/// </summary>
			DepartmentCodeId = 0,

			/// <summary>
			/// The parent AHS record
			/// </summary>
			AhsId,

			/// <summary>
			/// Code
			/// </summary>
			DepartmentCode,

			/// <summary>
			/// Name
			/// </summary>
			DepartmentName,

			/// <summary>
			/// last load
			/// </summary>
			FileTranLogId,

			/// <summary>
			/// 
			/// </summary>
			AccountNumber
		};

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="PolicyExtSegment"/> class.
		/// </summary>
		public DepartmentCodeSegment()
			: base("DEPARTMENT_CODES")
		{
			ColumnNames = new[]
			              	{
			              		"DEPARTMENT_CODES_ID",
			              		"ACCNT_HRCY_STEP_ID",
			              		"DEPARTMENT_CODE",
			              		"DEPARTMENT_NAME",
			              		"FILE_TRANSMISSION_LOG_ID",
			              		"ACCOUNT_NUMBER"
			              	};

		}
		#endregion

		#region Id
		/// <summary>
		/// Gets the id.
		/// </summary>
		/// <value>The id.</value>
		public string Id
		{
			get
			{
				return GetValue(ColumnNames[(int)ParmList.DepartmentCodeId]);
			}
			set
			{
				SetValue(ColumnNames[(int)ParmList.DepartmentCodeId], value);
			}
		}
		#endregion

		#region AhsId
		/// <summary>
		/// Gets or sets the AhsId.
		/// </summary>
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

		#region DepartmentCode
		/// <summary>
		/// Gets or sets the DepartmentCode.
		/// </summary>
		public string DepartmentCode
		{
			get
			{
				return GetValue(ColumnNames[(int)ParmList.DepartmentCode]);
			}
			set
			{
				SetValue(ColumnNames[(int)ParmList.DepartmentCode], value);
			}
		}
		#endregion

		#region DepartmentName
		/// <summary>
		/// Gets or sets the DepartmentName.
		/// </summary>
		public string DepartmentName
		{
			get
			{
				return GetValue(ColumnNames[(int)ParmList.DepartmentName]);
			}
			set
			{
				SetValue(ColumnNames[(int)ParmList.DepartmentName], value);
			}
		}
		#endregion

		#region AccountNumber
		/// <summary>
		/// Gets or sets the file AccountNumber.
		/// </summary>
		public string AccountNumber
		{
			get
			{
				return GetValue(ColumnNames[(int)ParmList.AccountNumber]);
			}
			set
			{
				SetValue(ColumnNames[(int)ParmList.AccountNumber], value);
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

		/// <summary>
		/// Sets the parent key.
		/// </summary>
		/// <param name="key"></param>
		public override void SetParentKey(string key)
		{
			// either we are being called by our parent
			if (string.Compare(Parent.Name, ParentName, true) == 0 && key.Length > 0)
			{
				AhsId = key;
			}
			else
			{
				throw new ApplicationException(string.Format("DepartmentCodeSegment SetParentKey unsupported parent segment {0}",
															 Parent.Name));
			}
		}

		/// <summary>
		/// Validations for the policy record data.
		/// </summary>
		protected override void ValidationMethod(object sender, EventArgs e)
		{
			Trace.WriteLine("ValidationMethod entered.", Name);

			if (Parent == null)
				throw new ApplicationException(string.Format("Parent is missing for type: {0}", Name));

			if (Parent.Name != ParentName)
				throw new ApplicationException(string.Format("Parent must be of type: {0} not {1}", ParentName, Parent.Name));
		}
	}
}
