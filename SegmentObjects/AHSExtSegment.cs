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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/AHSExtSegment.cs 2     9/26/09 12:46p John.gwynn $ */
#endregion

using System;
using System.Runtime.InteropServices;
using FnsComposite.SegmentObjects;
using FnsComposite.Interfaces;

namespace FnsComposite
{
	/// <summary>
	/// Summary description for AHSExtSegment.
	/// </summary>
    [ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public class AHSExtSegment : Segment
	{
		/// <summary>
		/// enumerated parameter list
		/// </summary>
		private enum eParmList 
		{
			/// <summary>
			/// the primary key
			/// </summary>
			AHSExtId = 0,
			/// <summary>
			/// The parent Policy record
			/// </summary>
			AHSId,
			/// <summary>
			/// Field Name (from Callflow)
			/// </summary>
			FieldName,
			/// <summary>
			/// Field Value
			/// </summary>
			FieldValue,
			/// <summary>
			/// link to (last) load
			/// </summary>
			FileTranLogId
		};
		
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="AHSExtSegment"/> class.
		/// </summary>
		public AHSExtSegment() :base("AHS_EXTENSION")
		{
			ColumnNames = new string[]
										{
											"AHS_EXTENSION_ID",
											"ACCNT_HRCY_STEP_ID",
											"NAME",
											"VALUE",
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
				return GetValue(ColumnNames[(int)eParmList.AHSExtId]);
			}
		}
		#endregion
		#region AHSId
		/// <summary>
		/// Gets or sets the AHS id.
		/// </summary>
		/// <value>The AHS id.</value>
		public string AHSId 
		{
			get 
			{
				return GetValue(ColumnNames[(int)eParmList.AHSId]);
			}
			set 
			{
				SetValue(ColumnNames[(int)eParmList.AHSId],value);
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
			if(string.Compare(Parent.Name,"ACCOUNT_HIERARCHY_STEP",true)==0 && key.Length > 0)
			{
				AHSId = key;
			}
			else
			{
				throw new ApplicationException(string.Format("AHSExtSegment SetParentKey unsupported parent segment {0}",
					Parent.Name));
			}
		}
		/// <summary>
		/// Clears the parent key.
		/// </summary>
		public override void ClearParentKey ()
		{
			AHSId = string.Empty;
		}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/AHSExtSegment.cs $
 * 
 * 2     9/26/09 12:46p John.gwynn
 * Added IAccountHierarchyStep interface
 * 
 * 1     11/06/07 5:19p Jenny.cheung
 * 
 * 2     7/05/07 1:45p John.gwynn
 * support for segment ClearKeys() method added
 * 
 * 1     5/09/07 2:42p Jenny.cheung
 * Added AHSExtension Segment for ESIS ACTEC Load
 * 
 * 1     3/01/07 3:51p John.gwynn
 * Esis Policy load
 */
#endregion