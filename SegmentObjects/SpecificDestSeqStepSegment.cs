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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/SpecificDestSeqStepSegment.cs 8     9/30/09 6:36p John.gwynn $ */
#endregion

using System;
using System.Runtime.InteropServices;

namespace FnsComposite.SegmentObjects
{
	/// <summary>
	/// Summary description for SpecificDestSeqStepSegment.
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public class SpecificDestSeqStepSegment : Segment
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SpecificDestSeqStepSegment"/> class.
		/// </summary>
		public SpecificDestSeqStepSegment() :base("SPECIFIC_DESTN_SEQ_STEP")
		{}
		#region SpecificDestnSeqStepId
		/// <summary>
		/// Gets or sets the specific destn seq step id.
		/// </summary>
		/// <value>The specific destn seq step id.</value>
		public string SpecificDestnSeqStepId

		{
			get
			{
				return GetValue("SPECIFIC_DESTN_SEQ_STEP_ID");
			}
			set
			{
				SetValue("SPECIFIC_DESTN_SEQ_STEP_ID",value);
			}
		}
		#endregion
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
		#region Sequence
		/// <summary>
		/// Gets or sets the sequence.
		/// </summary>
		/// <value>The sequence.</value>
		public string Sequence

		{
			get
			{
				return GetValue("SEQUENCE");
			}
			set
			{
				SetValue("SEQUENCE",value);
			}
		}
		#endregion
		#region RetryCount
		/// <summary>
		/// Gets or sets the retry count.
		/// </summary>
		/// <value>The retry count.</value>
		public string RetryCount

		{
			get
			{
				return GetValue("RETRY_COUNT");
			}
			set
			{
				SetValue("RETRY_COUNT",value);
			}
		}
		#endregion
		#region RetryWaitTime
		/// <summary>
		/// Gets or sets the retry wait time.
		/// </summary>
		/// <value>The retry wait time.</value>
		public string RetryWaitTime

		{
			get
			{
				return GetValue("RETRY_WAIT_TIME");
			}
			set
			{
				SetValue("RETRY_WAIT_TIME",value);
			}
		}
		#endregion
		#region DestinationString
		/// <summary>
		/// Gets or sets the destination string.
		/// </summary>
		/// <value>The destination string.</value>
		public string DestinationString

		{
			get
			{
				return GetValue("DESTINATION_STRING");
			}
			set
			{
				SetValue("DESTINATION_STRING",value);
			}
		}
		#endregion
		#region TransmissionTypeId
		/// <summary>
		/// Gets or sets the transmission type id.
		/// </summary>
		/// <value>The transmission type id.</value>
		public string TransmissionTypeId

		{
			get
			{
				return GetValue("TRANSMISSION_TYPE_ID");
			}
			set
			{
				SetValue("TRANSMISSION_TYPE_ID",value);
			}
		}
		#endregion
		#region AltDestinationString
		/// <summary>
		/// Gets or sets the alt destination string.
		/// </summary>
		/// <value>The alt destination string.</value>
		public string AltDestinationString

		{
			get
			{
				return GetValue("ALT_DESTINATION_STRING");
			}
			set
			{
				SetValue("ALT_DESTINATION_STRING",value);
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
			if (key.Length > 0 && SpecificDestinationId.Length == 0)
			{
				if(Parent.Name.Equals("SPECIFIC_DESTINATION"))
				{
					SpecificDestinationId = key;
				}
				else
				{
					throw new ApplicationException(string.Format("SpecificDestSeqStepSegment SetParentKey unsupported parent segment {0}",
					                                             Parent.Name));
				}
			}
		}
		#endregion
	}
}

#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/SpecificDestSeqStepSegment.cs $
 * 
 * 8     9/30/09 6:36p John.gwynn
 * Implemented IComparable for composites adding a virtual Compare method
 * for specialized equality and sorting .e.g. see the AhsSegment where two
 * segments are deemed equal if their upload keys are equal.
 * 
 * 7     8/04/08 9:14a Jenny.cheung
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
 * 1     3/14/07 5:15p John.gwynn
 * support for SpecificDestination and SpecificDestSeqStep
 */
#endregion
