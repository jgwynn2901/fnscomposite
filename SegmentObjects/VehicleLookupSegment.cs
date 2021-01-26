// ================================================================================
// Source File -- VehicleLookupSegment.cs
// 
// NAME: FnsComposite.SegmentObjects.VehicleLookupSegment.cs
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
    /// <summary> AUTO_MAKE_MODEL table segment. 
    /// This is the database table as an object.
    /// All except the Created_Date & Modified_Date columns in the AUTO_MAKE_MODEL table are mapped here.
    /// </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    [ClassInterface(ClassInterfaceType.None), ComVisible(false)]
    public class VehicleLookupSegment : Segment, IVehicleLookup
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent the columns in the table. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private enum ParmList
        {
            AutoMakeModelId = 0,
            Year,
            Make,
            Model,
            ReferenceId,
            UploadKey,
            ArchiveFlg,
            FileTranLogId
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public VehicleLookupSegment()
            : base("AUTO_MAKE_MODEL")
        {
            ColumnNames = new[]
                              {
                                  "AUTO_MAKE_MODEL_ID",
                                  "YEAR",
                                  "MAKE",
                                  "MODEL",
                                  "REFERENCE_ID",
                                  "UPLOAD_KEY",
                                  "ARCHIVED_FLG",
                                  "FILE_TRANSMISSION_LOG_ID"
                                  //"CREATED_DT",
                                  //"MODIFIED_DT"
                              };
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <param name="rec">  The IVehicleLookup record. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public VehicleLookupSegment(IVehicleLookup rec)
            : this()
        {
            AutoMakeModelId = rec.AutoMakeModelId;
            Year = rec.Year;
            Make = rec.Make;
            Model = rec.Model;
            ReferenceId = rec.ReferenceId;
            UploadKey = rec.UploadKey;
            ArchiveFlg = rec.ArchiveFlg;
            FileTranLogId = rec.FileTranLogId;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the AutoMakeModel ID. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string AutoMakeModelId
        {
            get { return GetValue(ColumnNames[(int)ParmList.AutoMakeModelId]); }
            set { SetValue(ColumnNames[(int)ParmList.AutoMakeModelId], value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the year. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Year
        {
            get { return GetValue(ColumnNames[(int)ParmList.Year]); }
            set { SetValue(ColumnNames[(int)ParmList.Year], value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the make. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Make
        {
            get { return GetValue(ColumnNames[(int)ParmList.Make]); }
            set { SetValue(ColumnNames[(int)ParmList.Make], value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the model. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string Model
        {
            get { return GetValue(ColumnNames[(int)ParmList.Model]).Replace("\"", string.Empty); }
            set { SetValue(ColumnNames[(int)ParmList.Model], value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the reference. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string ReferenceId
        {
            get { return GetValue(ColumnNames[(int)ParmList.ReferenceId]); }
            set { SetValue(ColumnNames[(int)ParmList.ReferenceId], value); }
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
        /// <summary>   Gets or sets the archive flg. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string ArchiveFlg
        {
            get { return GetValue(ColumnNames[(int)ParmList.ArchiveFlg]); }
            set { SetValue(ColumnNames[(int)ParmList.ArchiveFlg], value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the File Transmission Log ID. </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string FileTranLogId
        {
            get { return GetValue(ColumnNames[(int)ParmList.FileTranLogId]); }
            set { SetValue(ColumnNames[(int)ParmList.FileTranLogId], value); }
        }
    }
}
