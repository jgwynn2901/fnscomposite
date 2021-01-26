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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/SpecificDestinationSegment.cs 13    9/21/10 6:30p Gwynnj $ */
#endregion

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using FnsComposite.CallObjects;

namespace FnsComposite.SegmentObjects
{
	/// <summary>
	/// Summary description for SpecificDestinationSegment.
	/// </summary>
	[ComVisible(false)]
	public class SpecificDestinationSegment : Segment
	{
		private const string ParentName = "ACCOUNT_HIERARCHY_STEP";
		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificDestinationSegment"/> class.
		/// </summary>
		public SpecificDestinationSegment() :base ("SPECIFIC_DESTINATION")
		{}

		#region SpecificDestinationId
		/// <summary>
		/// Gets or sets the specific destination id.
		/// </summary>
		/// <value>The specific destination id.</value>
		public string SpecificDestinationId

		{
			get
			{
				return GetValue("SPECIFIC_DESTINATION_ID");
			}
			set
			{
				SetValue("SPECIFIC_DESTINATION_ID",value);
			}
		}
		#endregion

		#region AccntHrcyStepId
		/// <summary>
		/// Gets or sets the accnt hrcy step id.
		/// </summary>
		/// <value>The accnt hrcy step id.</value>
		public string AccntHrcyStepId

		{
			get
			{
				return GetValue("ACCNT_HRCY_STEP_ID");
			}
			set
			{
				SetValue("ACCNT_HRCY_STEP_ID",value);
			}
		}
		#endregion
		#region NameFirst
		/// <summary>
		/// Gets or sets the name first.
		/// </summary>
		/// <value>The name first.</value>
		public string NameFirst

		{
			get
			{
				return GetValue(EntityBase.FirstNameAttribute);
			}
			set
			{
				SetValue(EntityBase.FirstNameAttribute,value);
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
				return GetValue("ADDRESS1");
			}
			set
			{
				SetValue("ADDRESS1",value);
			}
		}
		#endregion
		#region NameLast
		/// <summary>
		/// Gets or sets the name last.
		/// </summary>
		/// <value>The name last.</value>
		public string NameLast

		{
			get
			{
				return GetValue(EntityBase.LastNameAttribute);
			}
			set
			{
				SetValue(EntityBase.LastNameAttribute,value);
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
				return GetValue("ADDRESS2");
			}
			set
			{
				SetValue("ADDRESS2",value);
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
				return GetValue("TITLE");
			}
			set
			{
				SetValue("TITLE",value);
			}
		}
		#endregion
		#region NameMid
		/// <summary>
		/// Gets or sets the name mid.
		/// </summary>
		/// <value>The name mid.</value>
		public string NameMid

		{
			get
			{
				return GetValue("NAME_MI");
			}
			set
			{
				SetValue("NAME_MI",value);
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
				return GetValue("CITY");
			}
			set
			{
				SetValue("CITY",value);
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
				return GetValue("STATE");
			}
			set
			{
				SetValue("STATE",value);
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
				return GetValue("ZIP");
			}
			set
			{
				SetValue("ZIP",value);
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
				return GetValue("PHONE");
			}
			set
			{
				SetValue("PHONE",value);
			}
		}
		#endregion
		#region AlternateFormFlg
		/// <summary>
		/// Gets or sets the alternate form FLG.
		/// </summary>
		/// <value>The alternate form FLG.</value>
		public string AlternateFormFlg

		{
			get
			{
				return GetValue("ALTERNATE_FORM_FLG");
			}
			set
			{
				SetValue("ALTERNATE_FORM_FLG",value);
			}
		}
		#endregion
		#region Lob
		/// <summary>
		/// Gets or sets the lob.
		/// </summary>
		/// <value>The lob.</value>
		public string Lob

		{
			get
			{
				return GetValue("LOB");
			}
			set
			{
				SetValue("LOB",value);
			}
		}
		#endregion
		#region UPLOAD_KEY

		/// <summary>
		/// Gets or sets up load key.
		/// </summary>
		/// <value>Up load key.</value>
		public string UpLoadKey
		{
			get
			{
				return GetValue("UPLOAD_KEY");
			}
			set
			{
				SetValue("UPLOAD_KEY", value);
			}
		}
		#endregion
		#region FILE_TRANSMISSION_LOG_ID

		/// <summary>
		/// Gets or sets the FIL e_ TRANSMISSIO n_ LO g_ ID.
		/// </summary>
		/// <value>The FIL e_ TRANSMISSIO n_ LO g_ ID.</value>
		public string FileTransmissionLogId
		{
			get
			{
				return GetValue("FILE_TRANSMISSION_LOG_ID");
			}
			set
			{
				SetValue("FILE_TRANSMISSION_LOG_ID", value);
			}
		}
		#endregion
		#region SetParentKey
		/// <summary>
		/// Sets the parent key.
		/// </summary>
		/// <param name="key"></param>
		public override void SetParentKey(string key)
		{
			// either we are being called by our parent
			if (key.Length > 0 && AccntHrcyStepId.Length == 0)
			{
				var location = Parent as AhsSegment;
				if(location != null)
				{
					AccntHrcyStepId = location.ClientNodeId;
				}
				else
				{
					throw new ApplicationException(string.Format("SpecificDestinationSegment SetParentKey unsupported parent segment {0}",
					                                             Parent.Name));
				}
			}
			// or are propagating to our children
			if (SpecificDestinationId.Length <= 0) return;

			foreach(Segment segment in SegmentList)
				segment.SetParentKey(SpecificDestinationId);
		}
		#endregion

		/// <summary>
		/// Provide validation for the segment by overriding this method.
		/// </summary>
		protected override void ValidationMethod(object sender, EventArgs e)
		{
			Trace.WriteLine("ValidationMethod entered.", Name);

			if (Parent == null)
				throw new ApplicationException("Parent required!");
            
			if (Parent.Name != ParentName)
				throw new ApplicationException(string.Format("Parent must be of type: {0} not {1}", ParentName, Parent.Name));
			
			if (!string.IsNullOrEmpty(SpecificDestinationId))
				throw new ApplicationException("SpecificDestinationId must be empty.");
		}
	}
}

#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/SpecificDestinationSegment.cs $
 * 
 * 13    9/21/10 6:30p Gwynnj
 * Created EntityBase to factor the IPerson interface
 * 
 * 12    10/29/09 1:11p John.gwynn
 * Moved ValidationMethod to base class as an override for adding
 * validation at the (sub)class definition.
 * 
 * 11    10/01/09 4:17p John.gwynn
 * 
 * 10    9/30/09 6:36p John.gwynn
 * Implemented IComparable for composites adding a virtual Compare method
 * for specialized equality and sorting .e.g. see the AhsSegment where two
 * segments are deemed equal if their upload keys are equal.
 * 
 * 9     9/26/09 12:46p John.gwynn
 * Added IAccountHierarchyStep interface
 * 
 * 8     8/12/08 1:38p Jenny.cheung
 * for sedgwick only
 * 
 * 7     8/04/08 9:13a Jenny.cheung
 * 
 * 6     7/28/08 4:41p Jenny.cheung
 * Added file_transmission_log_id and upload_key due to Sedgwick SOW
 * 
 * 5     11/07/07 9:13a Jenny.cheung
 * 
 * 4     10/21/07 8:17a John.gwynn
 * Modified segment namespace started work on CallObject types
 * 
 * 3     9/24/07 5:35p John.gwynn
 * merged with 2003 changes
 * 
 * 2     4/20/07 5:17p John.gwynn
 * 
 * 1     4/17/07 3:40p John.gwynn
 * update to current version from 1.1
 * 
 * 2     3/27/07 2:42p John.gwynn
 * modified SetParentKey to retrieve clientNodeId
 * 
 * 1     3/14/07 5:15p John.gwynn
 * support for SpecificDestination and SpecificDestSeqStep
 */
#endregion

