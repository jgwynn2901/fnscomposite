// ================================================================================
// Source File -- MdClaimArchiveSegment.cs
// 
// NAME: FnsComposite.SegmentObjects.MdClaimArchiveSegment.cs
// AUTHOR: Ashley A. Pinto
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// 
// © 2010 Innovation First Notice, http://www.firstnotice.com/
// 
// DATE: $time$
// VERSION: $clrversion$
// 
// COMMENT:
// ================================================================================

using System.Runtime.InteropServices;
using FnsComposite.Interfaces;

namespace FnsComposite.SegmentObjects
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Md claim archive segment. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    [ClassInterface(ClassInterfaceType.None), ComVisible(false)]
    public class MdClaimArchiveSegment : Segment, IMdClaimArchive
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent ParmList. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private enum ParmList
        {
            MdClaimArchiveId = 0,
            MdClaimNumber,
            ClaimantTaxId,
            ClaimantFullname,
            AccidentDate,
            UploadKey,
            FileTranLogId
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public MdClaimArchiveSegment()
            : base("MIAMIDADE_CLAIM_ARCHIVE")
        {
            ColumnNames = new[]
                              {
                                "MDCLAIM_ARCHIVE_ID",
                                "MD_CLAIM_NUMBER",
                                "CLAIMANT_TAX_ID",
                                "CLAIMANT_FULLNAME",
                                "ACCIDENT_DT",
                                "UPLOAD_KEY",
                                "FILE_TRANSMISSION_LOG_ID"
                                //"CREATED_DT",
                                //"MODIFIED_DT"
                              };
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <param name="claim">    The claim. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public MdClaimArchiveSegment(IMdClaimArchive claim) : this()
        {
            MdClaimArchiveId    = claim.MdClaimArchiveId;
            MdClaimNumber       = claim.MdClaimNumber;
            ClaimantTaxId       = claim.ClaimantTaxId;
            ClaimantFullname    = claim.ClaimantFullname;
            AccidentDate        = claim.AccidentDate;
            UploadKey           = claim.UploadKey;
            FileTranLogId       = claim.FileTranLogId;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the Miami Dade Claim Archive. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string MdClaimArchiveId
        {
            get { return GetValue(ColumnNames[(int)ParmList.MdClaimArchiveId]); }
            set { SetValue(ColumnNames[(int)ParmList.MdClaimArchiveId], value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Miami Dade Claim Number. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string MdClaimNumber
        {
            get { return GetValue(ColumnNames[(int)ParmList.MdClaimNumber]); }
            set { SetValue(ColumnNames[(int)ParmList.MdClaimNumber], value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the Claimant Tax. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string ClaimantTaxId
        {
            get { return GetValue(ColumnNames[(int)ParmList.ClaimantTaxId]); }
            set { SetValue(ColumnNames[(int)ParmList.ClaimantTaxId], value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Claimant Fullname. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string ClaimantFullname
        {
            get { return GetValue(ColumnNames[(int)ParmList.ClaimantFullname]); }
            set { SetValue(ColumnNames[(int)ParmList.ClaimantFullname], value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date of the Accident. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string AccidentDate
        {
            get { return GetValue(ColumnNames[(int)ParmList.AccidentDate]); }
            set { SetValue(ColumnNames[(int)ParmList.AccidentDate], value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the upload key. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string UploadKey
        {
            get { return GetValue(ColumnNames[(int)ParmList.UploadKey]); }
            set { SetValue(ColumnNames[(int)ParmList.UploadKey], value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the File Transaction Log. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string FileTranLogId
        {
            get { return GetValue(ColumnNames[(int)ParmList.FileTranLogId]); }
            set { SetValue(ColumnNames[(int)ParmList.FileTranLogId], value); }
        }
    }
}