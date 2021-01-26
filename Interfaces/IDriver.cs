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

namespace FnsComposite.Interfaces
{
    public interface IDriver
    {
        string PolicyId { get; }
        string Ssn { get; }
        string UploadKey { get; }
        string NameFirst { get; }
        string NameLast { get; }
        string Address1 { get; }
        string Address2 { get; }
        string City { get; }
        string State { get; }
        string Zip { get; }
        string Phone { get; }
        string RelationToInsured { get; }
        string LicenseNumber { get; }
        string ActiveStartDate { get; }
        string ActiveEndDate { get; }
        string FileTransmissionLogId { get; }
        string DriverNumber { get; }
        string BirthDate { get; }
        string Gender { get; }
    }
}
