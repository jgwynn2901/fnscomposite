#region Header
/**************************************************************************
* First Notice Systems
* (617) 886 2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 2012 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/InvolvedParty.cs 6     6/04/12 4:12p Gwynnj $ */
#endregion

using System.Collections.Generic;
using System.Xml;

namespace FnsComposite.CallObjects
{
    public class InvolvedParty : CallObjectBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvolvedParty"/> class.
        /// </summary>
        public InvolvedParty(int index)
            : base("InvolvedParty["+ index + "]")
		{}

        /// <summary>
        /// Initializes a new instance of the <see cref="InvolvedParty"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public InvolvedParty(XmlNode node)
            : base(node)
		{}

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName
        {
            get { return GetValue("CompanyName"); }
            set { SetValue("CompanyName", value); }
        }

        /// <summary>
        /// Gets or sets the name first.
        /// </summary>
        public string NameFirst
        {
            get { return GetValue("NameFirst"); }
            set { SetValue("NameFirst", value); }
        }

        /// <summary>
        /// Gets or sets the name last.
        /// </summary>
         public string NameLast
        {
            get { return GetValue("NameLast"); }
            set { SetValue("NameLast", value); }
        }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
         public string NameMid
        {
            get { return GetValue("NameMid"); }
            set { SetValue("NameMid", value); }
        }

         /// <summary>
         /// Gets or sets the name suffix.
         /// </summary>
        public string NameSuffix
        {
            get { return GetValue("NameSuffix"); }
            set { SetValue("NameSuffix", value); }
        }

        /// <summary>
        /// Gets or sets the node type.
        /// </summary>
        public string Type
        {
            get { return GetValue("Type"); }
            set { SetValue("Type", value); }
        }

        /// <summary>
        /// Gets or sets the street address line.
        /// </summary>
        /// <value>
        /// The street address line.
        /// </value>
        public string StreetAddressLine
        {
            get { return GetValue("StreetAddressLine"); }
            set { SetValue("StreetAddressLine", value); }
        }

        /// <summary>
        /// Gets or sets the extended street address line.
        /// </summary>
        /// <value>
        /// The extended street address line.
        /// </value>
        public string ExtendedStreetAddressLine
        {
            get { return GetValue("ExtendedStreetAddressLine"); }
            set { SetValue("ExtendedStreetAddressLine", value); }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City
        {
            get { return GetValue("City"); }
            set { SetValue("City", value); }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State
        {
            get { return GetValue("State"); }
            set { SetValue("State", value); }
        }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        public string ZipCode
        {
            get { return GetValue("ZipCode"); }
            set { SetValue("ZipCode", value); }
        }

        /// <summary>
        /// Gets or sets the county.
        /// </summary>
        /// <value>
        /// The county.
        /// </value>
        public string County
        {
            get { return GetValue("County"); }
            set { SetValue("County", value); }
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country
        {
            get { return GetValue("Country"); }
            set { SetValue("Country", value); }
        }

        /// <summary>
        /// Gets or sets the phone home.
        /// </summary>
        /// <value>
        /// The phone home.
        /// </value>
        public string PhoneHome
        {
            get { return GetValue("PhoneHome"); }
            set { SetValue("PhoneHome", value); }
        }

        /// <summary>
        /// Gets or sets the phone work.
        /// </summary>
        /// <value>
        /// The phone work.
        /// </value>
        public string PhoneWork
        {
            get { return GetValue("PhoneWork"); }
            set { SetValue("PhoneWork", value); }
        }

        /// <summary>
        /// Gets or sets the phone cell.
        /// </summary>
        /// <value>
        /// The phone cell.
        /// </value>
        public string PhoneCell
        {
            get { return GetValue("PhoneCell"); }
            set { SetValue("PhoneCell", value); }
        }

        /// <summary>
        /// Gets or sets the preferred phone.
        /// </summary>
        /// <value>
        /// The preferred phone.
        /// </value>
        public string PreferredPhone
        {
            get { return GetValue("PreferredPhone"); }
            set { SetValue("PreferredPhone", value); }
        }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public string EmailAddress
        {
            get { return GetValue("EmailAddress"); }
            set { SetValue("EmailAddress", value); }
        }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public string Source
        {
            get { return GetValue("Source"); }
            set { SetValue("Source", value); }
        }

        public string DateOfBirth
        {
            get { return GetValue("DateOfBirth"); }
            set { SetValue("DateOfBirth", value); }
        }

        public string Age
        {
            get { return GetValue("Age"); }
            set { SetValue("Age", value); }
        }

        public string Ssn
        {
            get { return GetValue("Ssn"); }
            set { SetValue("Ssn", value); }
        }

        public string RelationToInsured
        {
            get { return GetValue("RelationToInsured"); }
            set { SetValue("RelationToInsured", value); }
        }

        public string RelationToDriver
        {
            get { return GetValue("RelationToDriver"); }
            set { SetValue("RelationToDriver", value); }
        }

        public string DrivingLicenseNumber
        {
            get { return GetValue("DrivingLicenseNumber"); }
            set { SetValue("DrivingLicenseNumber", value); }
        }

        public string DrivingLicenseState
        {
            get { return GetValue("DrivingLicenseState"); }
            set { SetValue("DrivingLicenseState", value); }
        }

        public string LicensePlate
        {
            get { return GetValue("LicensePlate"); }
            set { SetValue("LicensePlate", value); }
        }

        public string Occupation
        {
            get { return GetValue("Occupation"); }
            set { SetValue("Occupation", value); }
        }

        public string CitationNumber
        {
            get { return GetValue("CitationNumber"); }
            set { SetValue("CitationNumber", value); }
        }

        public string CitationCode1
        {
            get { return GetValue("CitationCode1"); }
            set { SetValue("CitationCode1", value); }
        }

        public string CitationCode2
        {
            get { return GetValue("CitationCode2"); }
            set { SetValue("CitationCode2", value); }
        }

        public string CitationCode3
        {
            get { return GetValue("CitationCode3"); }
            set { SetValue("CitationCode3", value); }
        }

        public string CitationCode4
        {
            get { return GetValue("CitationCode4"); }
            set { SetValue("CitationCode4", value); }
        }

        public string CitationType1
        {
            get { return GetValue("CitationType1"); }
            set { SetValue("CitationType1", value); }
        }

        public string CitationType2
        {
            get { return GetValue("CitationType2"); }
            set { SetValue("CitationType2", value); }
        }

        public string CitationType3
        {
            get { return GetValue("CitationType3"); }
            set { SetValue("CitationType3", value); }
        }

        public string CitationType4
        {
            get { return GetValue("CitationType4"); }
            set { SetValue("CitationType4", value); }
        }

        public string WitnessRelation
        {
            get { return GetValue("WitnessRelation"); }
            set { SetValue("WitnessRelation", value); }
        }

        public string AuthoritiesName
        {
            get { return GetValue("AuthoritiesName"); }
            set { SetValue("AuthoritiesName", value); }
        }

        public string Injured
        {
            get { return GetValue("Injured"); }
            set { SetValue("Injured", value); }
        }

        public string InjuryDescription
        {
            get { return GetValue("InjuryDescription"); }
            set { SetValue("InjuryDescription", value); }
        }

        public string InjuryType
        {
            get { return GetValue("InjuryType"); }
            set { SetValue("InjuryType", value); }
        }

        public string TreatmentReceived
        {
            get { return GetValue("TreatmentReceived"); }
            set { SetValue("TreatmentReceived", value); }
        }

        public string Severity
        {
            get { return GetValue("Severity"); }
            set { SetValue("Severity", value); }
        }

        public string HospitalName
        {
            get { return GetValue("HospitalName"); }
            set { SetValue("HospitalName", value); }
        }

        public string AmbulanceUsed
        {
            get { return GetValue("AmbulanceUsed"); }
            set { SetValue("AmbulanceUsed", value); }
        }

        public string Fatality
        {
            get { return GetValue("Fatality"); }
            set { SetValue("Fatality", value); }
        }

        public string FatalityDate
        {
            get { return GetValue("FatalityDate"); }
            set { SetValue("FatalityDate", value); }
        }

        public string Cuts
        {
            get { return GetValue("Cuts"); }
            set { SetValue("Cuts", value); }
        }

        public string BrokenBones
        {
            get { return GetValue("BrokenBones"); }
            set { SetValue("BrokenBones", value); }
        }

        public string SoreNeckOrBack
        {
            get { return GetValue("SoreNeckOrBack"); }
            set { SetValue("SoreNeckOrBack", value); }
        }
        
        public string SrCode
        {
            get { return GetValue("SrCode"); }
            set { SetValue("SrCode", value); }
        }

        public string KindOfLoss
        {
            get { return GetValue("KindOfLoss"); }
            set { SetValue("KindOfLoss", value); }
        }

        public string CallerComments
        {
            get { return GetValue("CallerComments"); }
            set { SetValue("CallerComments", value); }
        }

        public string ManualEscalationReason
        {
            get { return GetValue("ManualEscalationReason"); }
            set { SetValue("ManualEscalationReason", value); }
        }
        public string ManualEscalationFlag
        {
            get { return GetValue("ManualEscalationFlag"); }
            set { SetValue("ManualEscalationFlag", value); }
        }

        public string OtherInsurance
        {
            get { return GetValue("OtherInsurance"); }
            set { SetValue("OtherInsurance", value); }
        }

        public string OtherInsuranceCarrierName
        {
            get { return GetValue("OtherInsuranceCarrierName"); }
            set { SetValue("OtherInsuranceCarrierName", value); }
        }

        public string OtherInsuranceCarrierAddress
        {
            get { return GetValue("OtherInsuranceCarrierAddress"); }
            set { SetValue("OtherInsuranceCarrierAddress", value); }
        }

        public string OtherInsuranceCarrierCity
        {
            get { return GetValue("OtherInsuranceCarrierCity"); }
            set { SetValue("OtherInsuranceCarrierCity", value); }
        }

        public string OtherInsuranceCarrierState
        {
            get { return GetValue("OtherInsuranceCarrierState"); }
            set { SetValue("OtherInsuranceCarrierState", value); }
        }

        public string OtherInsurancePolicyNumber
        {
            get { return GetValue("OtherInsurancePolicyNumber"); }
            set { SetValue("OtherInsurancePolicyNumber", value); }
        }

        public string OwnerIsCompanyFlag
        {
            get { return GetValue("OwnerIsCompanyFlag"); }
            set { SetValue("OwnerIsCompanyFlag", value); }
        }

        public string BestTimeToContact
        {
            get { return GetValue("BestTimeToContact"); }
            set { SetValue("BestTimeToContact", value); }
        }

        public string DamageRelatedToEngine
        {
            get { return GetValue("DamageRelatedToEngine"); }
            set { SetValue("DamageRelatedToEngine", value); }
        }
        
        public string DamageRelatedToDifferential
        {
            get { return GetValue("DamageRelatedToDifferential"); }
            set { SetValue("DamageRelatedToDifferential", value); }
        }
        
        public string DamageRelatedToTransmission
        {
            get { return GetValue("DamageRelatedToTransmission"); }
            set { SetValue("DamageRelatedToTransmission", value); }
        }
        
        public string DamageRelatedToMechanical
        {
            get { return GetValue("DamageRelatedToMechanical"); }
            set { SetValue("DamageRelatedToMechanical", value); }
        }

        public string VehicleRepairedFlag
        {
            get { return GetValue("VehicleRepairedFlag"); }
            set { SetValue("VehicleRepairedFlag", value); }
        }
        
        public string RepairAmount
        {
            get { return GetValue("RepairAmount"); }
            set { SetValue("RepairAmount", value); }
        }

        public string RepairInvoiceFlag
        {
            get { return GetValue("RepairInvoiceFlag"); }
            set { SetValue("RepairInvoiceFlag", value); }
        }

        public string RepairInvoiceNumber
        {
            get { return GetValue("RepairInvoiceNumber"); }
            set { SetValue("RepairInvoiceNumber", value); }
        }
        
        public string RepairShop
        {
            get { return GetValue("RepairShop"); }
            set { SetValue("RepairShop", value); }
        }
        
        public string DriverSameAsOwner
        {
            get { return GetValue("DriverSameAsOwner"); }
            set { SetValue("DriverSameAsOwner", value); }
        }
        
        public string CitationsIssuedFlag
        {
            get { return GetValue("CitationsIssuedFlag"); }
            set { SetValue("CitationsIssuedFlag", value); }
        }

        public string OtherInjuryDescription
        {
            get { return GetValue("OtherInjuryDescription"); }
            set { SetValue("OtherInjuryDescription", value); }
        }

        public string AdmittedToHospital
        {
            get { return GetValue("AdmittedToHospital"); }
            set { SetValue("AdmittedToHospital", value); }
        }

        public string PersonIdentifier
        {
            get { return GetValue("PersonIdentifier"); }
            set { SetValue("PersonIdentifier", value); }
        }

        public string Headache
        {
            get { return GetValue("Headache"); }
            set { SetValue("Headache", value); }
        }

        public string OtherVehicleCarrierPhone
        {
            get { return GetValue("OtherVehicleCarrierPhone"); }
            set { SetValue("OtherVehicleCarrierPhone", value); }
        }
        
        public string EmployerName
        {
            get { return GetValue("EmployerName"); }
            set { SetValue("EmployerName", value); }
        }
        
        public string EmployerAddress
        {
            get { return GetValue("EmployerAddress"); }
            set { SetValue("EmployerAddress", value); }
        }
        
        public string EmployerCity
        {
            get { return GetValue("EmployerCity"); }
            set { SetValue("EmployerCity", value); }
        }
        
        public string HospitalizedFlag
        {
            get { return GetValue("HospitalizedFlag"); }
            set { SetValue("HospitalizedFlag", value); }
        }
        public List<Role> Roles
        {
            get
            {
                var roles = new List<Role>();
                foreach (Role v in GetEnumerator<Role>())
                {
                    roles.Add(v);
                }
                return roles;
            }
        }
        public void AddRole (string roleCode)
        {
            Add(new Role(GetNodeCount("Role")) {AssignedRole = roleCode});
        }
    }
}
#region Log
/*
* $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/InvolvedParty.cs $
 * 
 * 6     6/04/12 4:12p Gwynnj
 * added Roles property to InvolvedParty node.
 * 
 * 5     5/23/12 12:58p Gwynnj
 * Additional elements defined TODO: finish VENDOR_REFERALL node
 * processing.
 * 
 * 4     5/22/12 3:59p Gwynnj
 * Additional Attributes added.
 * 
 * 3     5/20/12 5:42p Gwynnj
 * support for roles
 * 
 * 2     5/20/12 1:57p Gwynnj
 * extended InvolvedParty node
 * 
 * 1     5/17/12 12:20p Gwynnj
*/
#endregion