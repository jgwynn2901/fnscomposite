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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/PolicyExtSegment.cs 7     10/29/09 1:11p John.gwynn $ */
#endregion

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FnsComposite.SegmentObjects
{
	/// <summary>
	/// Summary description for PolicyExtSegment.
	/// </summary>
	[ComVisible(false)]
	public class PolicyExtSegment : Segment
	{
		private const string ParentName = "POLICY";
		/// <summary>
		/// enumerated parameter list
		/// </summary>
		private enum ParmList 
		{
			/// <summary>
			/// the primary key
			/// </summary>
			PolicyExtId = 0,
			/// <summary>
			/// The parent Policy record
			/// </summary>
			PolicyId,
			/// <summary>
			/// Field Name (from Callflow)
			/// </summary>
			FieldName,
			/// <summary>
			/// Field Value
			/// </summary>
			FieldValue,
			/// <summary>
			/// uses UploadKey logic
			/// </summary>
			UploadKey,
			/// <summary>
			/// link to (last) load
			/// </summary>
			FileTranLogId
		};
		
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="PolicyExtSegment"/> class.
		/// </summary>
		public PolicyExtSegment() :base("POLICY_EXTENSION")
		{
			ColumnNames = new[]
			              	{
			              		"POLICY_EXTENSION_ID",
			              		"POLICY_ID",
			              		"NAME",
			              		"VALUE",
			              		"UPLOAD_KEY",
			              		"FILE_TRANSMISSION_LOG_ID" 
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
				return GetValue(ColumnNames[(int)ParmList.PolicyExtId]);
			}
		}
		#endregion
		#region PolicyId
		/// <summary>
		/// Gets or sets the Policy id.
		/// </summary>
		/// <value>The Policy id.</value>
		public string PolicyId 
		{
			get 
			{
				return GetValue(ColumnNames[(int)ParmList.PolicyId]);
			}
			set 
			{
				SetValue(ColumnNames[(int)ParmList.PolicyId],value);
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
				return GetValue(ColumnNames[(int)ParmList.FieldName]);
			}
			set 
			{
				SetValue(ColumnNames[(int)ParmList.FieldName],value);
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
				return GetValue(ColumnNames[(int)ParmList.FieldValue]);
			}
			set 
			{
				SetValue(ColumnNames[(int)ParmList.FieldValue],value);
			}
		}
		#endregion
		#region UploadKey
		/// <summary>
		/// Gets or sets the file tran log id.
		/// </summary>
		/// <value>The file tran log id.</value>
		public string UploadKey 
		{
			get 
			{
				return GetValue(ColumnNames[(int)ParmList.UploadKey]);
			}
			set 
			{
				SetValue(ColumnNames[(int)ParmList.UploadKey],value);
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
				SetValue(ColumnNames[(int)ParmList.FileTranLogId],value);
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
			if(string.Compare(Parent.Name,"POLICY",true)==0 && key.Length > 0)
			{
				PolicyId = key;
			}
			else
			{
				throw new ApplicationException(string.Format("PolicyExtSegment SetParentKey unsupported parent segment {0}",
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

			if (string.IsNullOrEmpty(FieldName))
				throw new ApplicationException("FieldName is a required field.");
		}
	}
}

#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/PolicyExtSegment.cs $
 * 
 * 7     10/29/09 1:11p John.gwynn
 * Moved ValidationMethod to base class as an override for adding
 * validation at the (sub)class definition.
 * 
 * 6     9/29/09 6:18p John.gwynn
 * epartmentCodeSegment added
 * 
 * 5     9/29/09 5:12p John.gwynn
 * Added Validation Event support for Composite in general and Segment
 * classes.
 * 
 * 4     9/26/09 12:46p John.gwynn
 * Added IAccountHierarchyStep interface
 * 
 * 3     9/24/07 5:35p John.gwynn
 * merged with 2003 changes
 * 
 * 2     4/20/07 5:17p John.gwynn
 * 
 * 1     4/17/07 3:40p John.gwynn
 * update to current version from 1.1
 * 
 * 1     3/01/07 3:51p John.gwynn
 * Esis Policy load
 */
#endregion