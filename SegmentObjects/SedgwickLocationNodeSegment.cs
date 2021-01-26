#region Header
// ================================================================================
// Source File -- SedgwickLocationNodeSegment.cs
// 
// NAME: FnsComposite.SegmentObjects.SedgwickLocationNodeSegment.cs
// AUTHOR: Ashley A. Pinto
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// 
// © 2011 Innovation First Notice, http://www.firstnotice.com/
// 
// $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/SedgwickLocationNodeSegment.cs 1     4/24/11 11:21p Pintoa $ 
// 
// COMMENT:
// ================================================================================
#endregion

using System;
using System.Runtime.InteropServices;
using FnsComposite.Interfaces;

namespace FnsComposite.SegmentObjects
{
    /// <summary>
    /// 
    /// </summary>
    [ClassInterface(ClassInterfaceType.None), ComVisible(false)]
    public class SedgwickLocationNodeSegment : Segment, ISedgwickLocationNode
    {
        private enum ParmList
        {
            SedgLocationNodeId = 0,
            ClientId,
            LocationNode,
            Name,
            Address1,
            Address2,
            City,
            State,
            Zip,
            County,
            Country,
            Phone,
            AltPhone,
            CanAddClaims,
            ActiveStartDate,
            ActiveEndDate,
            ActiveStatus,
            UploadKey,
            FileTranLogId,
            IsInsert,
            IsUpdate
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SedgwickLocationNodeSegment"/> class.
        /// </summary>
        public SedgwickLocationNodeSegment()
            : base("SEDG_LOCATION_NODE")
        {
            ColumnNames = new[]
                              {
                                "SEDG_LOCATION_NODE_ID", 
                                "CLIENT_ID", 
                                "LOCATION_NODE", 
                                "NAME", 
                                "ADDRESS_1", 
                                "ADDRESS_2", 
                                "CITY", 
                                "STATE", 
                                "ZIP", 
                                "COUNTY", 
                                "COUNTRY", 
                                "PHONE", 
                                "ALT_PHONE", 
                                "CAN_ADD_CLAIMS", 
                                "ACTIVE_START_DATE", 
                                "ACTIVE_END_DATE", 
                                "ACTIVE_STATUS", 
                                "UPLOAD_KEY", 
                                "FILE_TRAN_LOG_ID", 
                                //"CREATED_DT",
                                //"MODIFIED_DT"
                                "ISINSERT",
                                "ISUPDATE"
                              };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SedgwickLocationNodeSegment"/> class.
        /// </summary>
        /// <param name="locationNode">The location node.</param>
        public SedgwickLocationNodeSegment(ISedgwickLocationNode locationNode)
            : this()
        {
            SedgLocationNodeId = locationNode.SedgLocationNodeId;
            ClientId = locationNode.ClientId;
            LocationNode = locationNode.LocationNode;
            LocationName = locationNode.Name;
            Address1 = locationNode.Address1;
            Address2 = locationNode.Address2;
            City = locationNode.City;
            State = locationNode.State;
            Zip = locationNode.Zip;
            County = locationNode.County;
            Country = locationNode.Country;
            Phone = locationNode.Phone;
            AltPhone = locationNode.AltPhone;
            CanAddClaims = locationNode.CanAddClaims;
            ActiveStartDate = locationNode.ActiveStartDate;
            ActiveEndDate = locationNode.ActiveEndDate;
            ActiveStatus = locationNode.ActiveStatus;
            UploadKey = locationNode.UploadKey;
            FileTranLogId = locationNode.FileTranLogId;
        }

        /// <summary>
        /// Gets or sets the sedg location node id.
        /// </summary>
        /// <value>The sedg location node id.</value>
        public string SedgLocationNodeId
        {
            get { return GetValue(ColumnNames[(int)ParmList.SedgLocationNodeId]); }
            set { SetValue(ColumnNames[(int)ParmList.SedgLocationNodeId], value); }
        }

        /// <summary>
        /// Gets or sets the client id.
        /// </summary>
        /// <value>The client id.</value>
        public string ClientId
        {
            get { return GetValue(ColumnNames[(int)ParmList.ClientId]); }
            set { SetValue(ColumnNames[(int)ParmList.ClientId], value); }
        }

        /// <summary>
        /// Gets or sets the location node.
        /// </summary>
        /// <value>The location node.</value>
        public string LocationNode
        {
            get { return GetValue(ColumnNames[(int)ParmList.LocationNode]); }
            set { SetValue(ColumnNames[(int)ParmList.LocationNode], value); }
        }

        /// <summary>
        /// Gets or sets the name of the location.
        /// </summary>
        /// <value>The name of the location.</value>
        public string LocationName
        {
            get { return GetValue(ColumnNames[(int)ParmList.Name]); }
            set { SetValue(ColumnNames[(int)ParmList.Name], value); }
        }

        /// <summary>
        /// Gets or sets the address1.
        /// </summary>
        /// <value>The address1.</value>
        public string Address1
        {
            get { return GetValue(ColumnNames[(int)ParmList.Address1]); }
            set { SetValue(ColumnNames[(int)ParmList.Address1], value); }
        }

        /// <summary>
        /// Gets or sets the address2.
        /// </summary>
        /// <value>The address2.</value>
        public string Address2
        {
            get { return GetValue(ColumnNames[(int)ParmList.Address2]); }
            set { SetValue(ColumnNames[(int)ParmList.Address2], value); }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City
        {
            get { return GetValue(ColumnNames[(int)ParmList.City]); }
            set { SetValue(ColumnNames[(int)ParmList.City], value); }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public string State
        {
            get { return GetValue(ColumnNames[(int)ParmList.State]); }
            set { SetValue(ColumnNames[(int)ParmList.State], value); }
        }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        public string Zip
        {
            get { return GetValue(ColumnNames[(int)ParmList.Zip]); }
            set { SetValue(ColumnNames[(int)ParmList.Zip], value); }
        }

        /// <summary>
        /// Gets or sets the county.
        /// </summary>
        /// <value>The county.</value>
        public string County
        {
            get { return GetValue(ColumnNames[(int)ParmList.County]); }
            set { SetValue(ColumnNames[(int)ParmList.County], value); }
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country
        {
            get { return GetValue(ColumnNames[(int)ParmList.Country]); }
            set { SetValue(ColumnNames[(int)ParmList.Country], value); }
        }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone
        {
            get { return GetValue(ColumnNames[(int)ParmList.Phone]); }
            set { SetValue(ColumnNames[(int)ParmList.Phone], value); }
        }

        /// <summary>
        /// Gets or sets the alt phone.
        /// </summary>
        /// <value>The alt phone.</value>
        public string AltPhone
        {
            get { return GetValue(ColumnNames[(int)ParmList.AltPhone]); }
            set { SetValue(ColumnNames[(int)ParmList.AltPhone], value); }
        }

        /// <summary>
        /// Gets or sets the can add claims.
        /// </summary>
        /// <value>The can add claims.</value>
        public string CanAddClaims
        {
            get { return GetValue(ColumnNames[(int)ParmList.CanAddClaims]); }
            set { SetValue(ColumnNames[(int)ParmList.CanAddClaims], value); }
        }

        /// <summary>
        /// Gets or sets the active start date.
        /// </summary>
        /// <value>The active start date.</value>
        public string ActiveStartDate
        {
            get { return GetValue(ColumnNames[(int)ParmList.ActiveStartDate]); }
            set { SetValue(ColumnNames[(int)ParmList.ActiveStartDate], value); }
        }

        /// <summary>
        /// Gets or sets the active end date.
        /// </summary>
        /// <value>The active end date.</value>
        public string ActiveEndDate
        {
            get { return GetValue(ColumnNames[(int)ParmList.ActiveEndDate]); }
            set { SetValue(ColumnNames[(int)ParmList.ActiveEndDate], value); }
        }

        /// <summary>
        /// Gets or sets the active status.
        /// </summary>
        /// <value>The active status.</value>
        public string ActiveStatus
        {
            get { return GetValue(ColumnNames[(int)ParmList.ActiveStatus]); }
            set { SetValue(ColumnNames[(int)ParmList.ActiveStatus], value); }
        }

        /// <summary>
        /// Gets or sets the upload key.
        /// </summary>
        /// <value>The upload key.</value>
        public string UploadKey
        {
            get { return GetValue(ColumnNames[(int)ParmList.UploadKey]); }
            set { SetValue(ColumnNames[(int)ParmList.UploadKey], value); }
        }

        /// <summary>
        /// Gets or sets the file tran log id.
        /// </summary>
        /// <value>The file tran log id.</value>
        public string FileTranLogId
        {
            get { return GetValue(ColumnNames[(int)ParmList.FileTranLogId]); }
            set { SetValue(ColumnNames[(int)ParmList.FileTranLogId], value); }
        }

        public string IsInsert
        {
            get { return GetValue(ColumnNames[(int)ParmList.IsInsert]); }
            set { SetValue(ColumnNames[(int)ParmList.IsInsert], value); }
        }

        public string IsUpdate
        {
            get { return GetValue(ColumnNames[(int)ParmList.IsUpdate]); }
            set { SetValue(ColumnNames[(int)ParmList.IsUpdate], value); }
        }
    }
}

#region Log
/*
 *
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/SedgwickLocationNodeSegment.cs $ 
 * 
 * 1     4/24/11 11:21p Pintoa
 * Sedgwick SRS Location Node implementation.
 *
 */
#endregion
