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
    [ClassInterface(ClassInterfaceType.None), ComVisible(false)]
    public class DriverSegment : Segment, IDriver
    {
        private enum eParmList
        {
            DriverId = 0,
            PolicyId,
            Ssn,
            UploadKey,
            NameFirst,
            NameLast,
            Address1,
            Address2,
            City,
            State,
            Zip,
            Phone,
            RelationToInsured,
            LicenseNumber,
            ActiveStartDate,
            ActiveEndDate,
            FileTransmissionLogId,
            DriverNumber,
            BirthDate,
            Gender
        }

        public DriverSegment() : base("DRIVER")
        {
            ColumnNames = new string[]
                              {
                                  "DRIVER_ID",
                                  "POLICY_ID",
                                  "SSN",
                                  "UPLOAD_KEY",
                                  "NAME_FIRST",
                                  "NAME_LAST",
                                  "ADDRESS1",
                                  "ADDRESS2",
                                  "CITY",
                                  "STATE",
                                  "ZIP",
                                  "PHONE",
                                  "RELATION_TO_INSURED",
                                  "LICENSE_NUMBER",
                                  "ACTIVE_START_DT",
                                  "ACTIVE_END_DT",
                                  "FILE_TRANSMISSION_LOG_ID",
                                  "DRIVER_NUMBER",
                                  "BIRTH_DT",
                                  "GENDER"
                              };
        }

        public DriverSegment(IDriver rec) : this()
        {
            PolicyId = rec.PolicyId;
            Ssn = rec.Ssn;
            UploadKey = rec.UploadKey;
            NameFirst = rec.NameFirst;
            NameLast = rec.NameLast;
            Address1 = rec.Address1;
            Address2 = rec.Address2;
            City = rec.City;
            State = rec.State;
            Zip = rec.Zip;
            Phone = rec.Phone;
            RelationToInsured = rec.RelationToInsured;
            LicenseNumber = rec.LicenseNumber;
            ActiveStartDate = rec.ActiveStartDate;
            ActiveEndDate = rec.ActiveEndDate;
            FileTransmissionLogId = rec.FileTransmissionLogId;
            DriverNumber = rec.DriverNumber;
            BirthDate = rec.BirthDate;
            Gender = rec.Gender;
        }

        public string DriverId
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.DriverId]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.DriverId], value);
            }
        }

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

        public string Ssn
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Ssn]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Ssn], value);
            }
        }

        public string UploadKey
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.UploadKey]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.UploadKey], value);
            }
        }

        public string NameFirst
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.NameFirst]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.NameFirst], value);
            }
        }

        public string NameLast
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.NameLast]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.NameLast], value);
            }
        }

        public string Address1
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Address1]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Address1], value);
            }
        }

        public string Address2
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Address2]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Address2], value);
            }
        }

        public string City
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.City]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.City], value);
            }
        }

        public string State
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.State]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.State], value);
            }
        }

        public string Zip
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Zip]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Zip], value);
            }
        }

        public string Phone
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Phone]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Phone], value);
            }
        }

        public string RelationToInsured
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.RelationToInsured]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.RelationToInsured], value);
            }
        }

        public string LicenseNumber
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.LicenseNumber]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.LicenseNumber], value);
            }
        }

        public string ActiveStartDate
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.ActiveStartDate]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.ActiveStartDate], value);
            }
        }

        public string ActiveEndDate
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.ActiveEndDate]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.ActiveEndDate], value);
            }
        }

        public string FileTransmissionLogId
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.FileTransmissionLogId]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.FileTransmissionLogId], value);
            }
        }

        public string DriverNumber
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.DriverNumber]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.DriverNumber], value);
            }
        }

        public string BirthDate
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.BirthDate]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.BirthDate], value);
            }
        }

        public string Gender
        {
            get
            {
                return GetValue(ColumnNames[(int)eParmList.Gender]);
            }
            set
            {
                SetValue(ColumnNames[(int)eParmList.Gender], value);
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

            if (DriverId.Length > 0)
            {
                // now propagate to children our key
                foreach (Segment segment in SegmentList)
                {
                    segment.SetParentKey(DriverId);
                }
            }
        }
    }
}
