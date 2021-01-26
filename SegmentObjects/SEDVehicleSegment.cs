#region Header
/**************************************************************************
 * Innovation First Notice
 * 199 Wells Ave
 * Newton, MA 02459
* (617) 886-2600
 *
 * Proprietary Source Code -- Distribution restricted
 *
 * © 2013 Innovation First Notice, http://www.innovation-group.com/us
 **************************************************************************/
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
    public class SEDVehicleSegment : Segment, ISEDVehicle
    {
        private enum eParmList
        {
            VehicleId = 0,
            UploadKey,
            PolicyId,
            Vin,
            Year,
            Make,
            Model,
            LicensePlate,
            LicensePlateState,
            RegistrationState,
            Color,
            ActiveStartDt,
            ActiveEndDt,
            FileTransmissionLogId,
            Driver1Number,
            Driver1Percent,
            Driver2Number,
            Driver2Percent,
            Misc,
            VehicleNumber,
            BodyType,
            LocationId,
            LicenseWeight,
            EntityName,
            ApportionedFlag,
            DotNumber,
            Mileage,
            TitleNumber,
            VehicleType,
            VehicleDesc,
            ClientNum,
            ArchivedFlag
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleSegment"/> class.
        /// </summary>
        public SEDVehicleSegment() : base("VEHICLE")
        {
            ColumnNames = new string[]
                              {
                                  "VEHICLE_ID",
                                  "UPLOAD_KEY",
                                  "POLICY_ID",
                                  "VIN",
                                  "YEAR",
                                  "MAKE",
                                  "MODEL",
                                  "LICENSE_PLATE",
                                  "LICENSE_PLATE_STATE",
                                  "REGISTRATION_STATE",
                                  "COLOR",
                                  "ACTIVE_START_DT",
                                  "ACTIVE_END_DT",
                                  "FILE_TRANSMISSION_LOG_ID",
                                  "DRIVER1_NUMBER",
                                  "DRIVER1_PERCENT",
                                  "DRIVER2_NUMBER",
                                  "DRIVER2_PERCENT",
                                  "MISC",
                                  "VEHICLE_NUMBER",
                                  "BODY_TYPE",
                                  "LOCATION_ID",
                                  "LICENSE_WEIGHT",
                                  "ENTITY_NAME",
                                  "APPORTIONED_FLG",
                                  "DOT_NUMBER",
                                  "MILEAGE",
                                  "TITLE_NUMBER",
                                  "VEHICLE_TYPE",
                                  "VEHICLE_DESC",
                                  "CLIENT_NUM",
                                  "ARCHIVED_FLG"
                              };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleSegment"/> class.
        /// </summary>
        /// <param name="rec">The rec.</param>
        public SEDVehicleSegment(ISEDVehicle rec) : this()
        {
            PolicyId = rec.PolicyId;
            UploadKey = rec.UploadKey;
            Vin = rec.Vin;
            Year = rec.Year;
            Make = rec.Make;
            Model = rec.Model;
            LicensePlate = rec.LicensePlate;
            LicensePlateState = rec.LicensePlateState;
            RegistrationState = rec.RegistrationState;
            Color = rec.Color;
            ActiveStartDt = rec.ActiveStartDt;
            ActiveEndDt = rec.ActiveEndDt;
            FileTransmissionLogId = rec.FileTransmissionLogId;
            Driver1Number = rec.Driver1Number;
            Driver1Percent = rec.Driver1Percent;
            Driver2Number = rec.Driver2Number;
            Driver2Percent = rec.Driver2Percent;
            Misc = rec.Misc;
            VehicleNumber = rec.VehicleNumber;
            BodyType = rec.BodyType;
            LocationId = rec.LocationId;
            LicenseWeight = rec.LicenseWeight;
            EntityName = rec.EntityName;
            ApportionedFlag = rec.ApportionedFlag;
            DotNumber = rec.DotNumber;
            Mileage = rec.Mileage;
            TitleNumber = rec.TitleNumber;
            VehicleTypeCCE = rec.VehicleTypeCCE;
            VehicleDescCCE = rec.VehicleDescCCE;
            ClientNum = rec.ClientNum;
            ArchivedFlag = rec.ArchivedFlag;
        }

        /// <summary>
        /// Gets or sets the vehicle id.
        /// </summary>
        /// <value>The vehicle id.</value>
        public string VehicleId
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.VehicleId]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.VehicleId], value);
            }
        }

        /// <summary>
        /// Gets the upload key.
        /// </summary>
        /// <value>The upload key.</value>
        public string UploadKey
        {
            get
            {
                return GetValue(ColumnNames[(int) eParmList.UploadKey]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.UploadKey], value);
            }
        }

        /// <summary>
        /// Gets the policy id.
        /// </summary>
        /// <value>The policy id.</value>
        public string PolicyId
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.PolicyId]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.PolicyId], value);
            }
        }

        /// <summary>
        /// Gets the vin.
        /// </summary>
        /// <value>The vin.</value>
        public string Vin
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Vin]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Vin], value);
            }
        }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year.</value>
        public string Year
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Year]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Year], value);
            }
        }

        /// <summary>
        /// Gets the make.
        /// </summary>
        /// <value>The make.</value>
        public string Make
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Make]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Make], value);
            }
        }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>The model.</value>
        public string Model
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Model]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Model], value);
            }
        }

        /// <summary>
        /// Gets the license plate.
        /// </summary>
        /// <value>The license plate.</value>
        public string LicensePlate
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.LicensePlate]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.LicensePlate], value);
            }
        }

        /// <summary>
        /// Gets the state of the license plate.
        /// </summary>
        /// <value>The state of the license plate.</value>
        public string LicensePlateState
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.LicensePlateState]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.LicensePlateState], value);
            }
        }

        /// <summary>
        /// Gets the state of the registration.
        /// </summary>
        /// <value>The state of the registration.</value>
        public string RegistrationState
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.RegistrationState]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.RegistrationState], value);
            }
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <value>The color.</value>
        public string Color
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Color]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Color], value);
            }
        }

        /// <summary>
        /// Gets the type of the body.
        /// </summary>
        /// <value>The type of the body.</value>
        public string BodyType
        {
            get
            {
                return GetValue(ColumnNames[(int) eParmList.BodyType]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.BodyType], value);
            }
        }

        /// <summary>
        /// Gets the active start date.
        /// </summary>
        /// <value>The active start dt.</value>
        public string ActiveStartDt
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.ActiveStartDt]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.ActiveStartDt], value);
            }
        }

        /// <summary>
        /// Gets the active end date.
        /// </summary>
        /// <value>The active end dt.</value>
        public string ActiveEndDt
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.ActiveEndDt]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.ActiveEndDt], value);
            }
        }

        /// <summary>
        /// Gets the file transmission log id.
        /// </summary>
        /// <value>The file transmission log id.</value>
        public string FileTransmissionLogId
        {
            get
            {
                return GetValue(ColumnNames[(int) eParmList.FileTransmissionLogId]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.FileTransmissionLogId], value);
            }
        }

        /// <summary>
        /// Gets the driver1 number.
        /// </summary>
        /// <value>The driver1 number.</value>
        public string Driver1Number
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Driver1Number]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Driver1Number], value);
            }
        }

        /// <summary>
        /// Gets the driver1 percent.
        /// </summary>
        /// <value>The driver1 percent.</value>
        public string Driver1Percent
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Driver1Percent]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Driver1Percent], value);
            }
        }

        /// <summary>
        /// Gets the driver2 number.
        /// </summary>
        /// <value>The driver2 number.</value>
        public string Driver2Number
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Driver2Number]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Driver2Number], value);
            }
        }

        /// <summary>
        /// Gets the driver2 percent.
        /// </summary>
        /// <value>The driver2 percent.</value>
        public string Driver2Percent
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Driver2Percent]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Driver2Percent], value);
            }
        }

        /// <summary>
        /// Gets the misc.
        /// </summary>
        /// <value>The misc.</value>
        public string Misc
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Misc]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Misc], value);
            }
        }

        /// <summary>
        /// Gets the vehicle number.
        /// </summary>
        /// <value>The vehicle number.</value>
        public string VehicleNumber
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.VehicleNumber]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.VehicleNumber], value);
            }
        }

        /// <summary>
        /// Gets the location Id.
        /// </summary>
        /// <value>The location id.</value>
        public string LocationId
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.LocationId]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.LocationId], value);
            }
        }

        /// <summary>
        /// Gets the license weight.
        /// </summary>
        /// <value>The license weight.</value>
        public string LicenseWeight
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.LicenseWeight]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.LicenseWeight], value);
            }
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>The name of the entity.</value>
        public string EntityName
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.EntityName]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.EntityName], value);
            }
        }

        /// <summary>
        /// Gets the apportioned flag.
        /// </summary>
        /// <value>The apportioned flag.</value>
        public string ApportionedFlag
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.ApportionedFlag]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.ApportionedFlag], value);
            }
        }

        /// <summary>
        /// Gets the dot number.
        /// </summary>
        /// <value>The dot number.</value>
        public string DotNumber
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.DotNumber]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.DotNumber], value);
            }
        }

        /// <summary>
        /// Gets the mileage.
        /// </summary>
        /// <value>The mileage.</value>
        public string Mileage
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Mileage]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Mileage], value);
            }
        }

        /// <summary>
        /// Gets the title number.
        /// </summary>
        /// <value>The title number.</value>
        public string TitleNumber
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.TitleNumber]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.TitleNumber], value);
            }
        }

        /// <summary>
        /// Gets the type of the vehicle.
        /// NOTE : This is a CCE specific column - CCE Vehicle Type.
        /// </summary>
        /// <value>The type of the vehicle.</value>
        public string VehicleTypeCCE
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.VehicleType]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.VehicleType], value);
            }
        }

        /// <summary>
        /// Gets the vehicle desc.
        /// NOTE : This is a CCE specific column - CCE Vehicle Description.
        /// </summary>
        /// <value>The vehicle desc.</value>
        public string VehicleDescCCE
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.VehicleDesc]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.VehicleDesc], value);
            }
        }

        /// <summary>
        /// Gets or sets the client number.
        /// </summary>
        /// <value>The client num.</value>
        public string ClientNum
        {
            get
            {
                return GetValue(ColumnNames[(int) eParmList.ClientNum]);
            }
            set
            {
                SetValue(ColumnNames[(int) eParmList.ClientNum], value);
            }
        }

        /// <summary>
        /// Gets the archived flag.
        /// </summary>
        /// <value>The archived flag.</value>
        public string ArchivedFlag
        {
            get
            {
                return GetValue(ColumnNames[(int) eParmList.ArchivedFlag]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.ArchivedFlag], value);
            }
    
        }

        /// <summary>
        /// Sets the parent key.
        /// </summary>
        /// <param name="key"></param>
        public override void SetParentKey(string key)
        {
            // either we are being called by our parent
            if (!string.IsNullOrEmpty(key) && PolicyId.Length == 0)
            {
                if (Parent.Name.Equals("POLICY"))
                    PolicyId = key;
            }

            if (VehicleId.Length > 0)
            {
                // now propagate to children our key
                foreach (Segment segment in SegmentList)
                {
                    segment.SetParentKey(VehicleId);
                }
            }
        }
    }
}