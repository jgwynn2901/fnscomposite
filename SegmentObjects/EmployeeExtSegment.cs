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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/EmployeeExtSegment.cs 7     9/26/09 12:46p John.gwynn $ */
#endregion

using System;
using System.Runtime.InteropServices;
using FnsComposite.SegmentObjects;

namespace FnsComposite
{
	/// <summary>
	/// Summary description for EmployeeExtSegment.
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public class EmployeeExtSegment : Segment
	{
		private enum eParmList 
		{
			/// <summary>
			/// this primary key
			///  </summary>
			EmployeeExtId = 0,
			/// <summary>
			/// The parent EMPLOYEE record
			/// </summary>
			EmployeeId,
			/// <summary>
			/// Field Name (from Callflow)
			/// </summary>
			FieldName,
			/// <summary>
			/// Field Value
			/// </summary>
			FieldValue,
			/// <summary>
			/// link to load
			/// </summary>
			FileTranLogId
		};
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="EmployeeExtSegment"/> class.
		/// </summary>
		public EmployeeExtSegment() :base("EMPLOYEE_EXT")
		{
			ColumnNames = new string[]
				{
					"EMPLOYEE_EXT_ID",
					"EMPLOYEE_ID",
					"FIELD_NAME",
					"FIELD_VALUE",
					"FILE_TRANSMISSION_LOG_ID" };
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
				return GetValue(ColumnNames[(int)eParmList.EmployeeExtId]);
			}
		}
		#endregion
		#region EmployeeId
		/// <summary>
		/// Gets or sets the employee id.
		/// </summary>
		/// <value>The employee id.</value>
		public string EmployeeId 
		{
			get 
			{
				return GetValue(ColumnNames[(int)eParmList.EmployeeId]);
			}
			set 
			{
				SetValue(ColumnNames[(int)eParmList.EmployeeId],value);
			}
		}
		#endregion
		#region FieldName
		/// <summary>
		/// Gets or sets the name of the field.
		/// </summary>
		/// <value>The name of the field.</value>
		public string FieldName 
		{
			get 
			{
				return GetValue(ColumnNames[(int)eParmList.FieldName]);
			}
			set 
			{
				SetValue(ColumnNames[(int)eParmList.FieldName],value);
			}
		}
		#endregion
		#region FieldValue
		/// <summary>
		/// Gets or sets the field value.
		/// </summary>
		/// <value>The field value.</value>
		public string FieldValue 
		{
			get 
			{
				return GetValue(ColumnNames[(int)eParmList.FieldValue]);
			}
			set 
			{
				SetValue(ColumnNames[(int)eParmList.FieldValue],value);
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
				return GetValue(ColumnNames[(int)eParmList.FileTranLogId]);
			}
			set 
			{
				SetValue(ColumnNames[(int)eParmList.FileTranLogId],value);
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
			if(string.Compare(Parent.Name,"EMPLOYEE",true)==0 && key.Length > 0)
			{
				EmployeeId = key;
			}
			else
			{
				throw new ApplicationException(string.Format("PolicySegment SetParentKey unsupported parent segment {0}",
				                                             Parent.Name));
			}
		}
	}
}

#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/EmployeeExtSegment.cs $
 * 
 * 7     9/26/09 12:46p John.gwynn
 * Added IAccountHierarchyStep interface
 * 
 * 6     11/07/07 9:13a Jenny.cheung
 * 
 * 5     10/21/07 8:17a John.gwynn
 * Modified segment namespace started work on CallObject types
 * 
 * 4     9/24/07 5:35p John.gwynn
 * merged with 2003 changes
 * 
 * 3     4/20/07 5:17p John.gwynn
 * 
 * 2     4/17/07 3:41p John.gwynn
 * update current version synch to 1.1
 * 
 * 1     1/12/07 10:17a John.gwynn
 * functionality to support Employee extensions
 */
#endregion
