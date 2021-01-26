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

namespace FnsComposite.Interfaces
{
    /// <summary>
    /// This interface is between the object and the database table.
    /// All attributes have to be directly mapped to a column in the Vehicle table.
    /// </summary>
    public interface ISEDVehicle
    {
        /// <summary>
        /// Gets the upload key.
        /// </summary>
        /// <value>The upload key.</value>
        string UploadKey { get; }

        /// <summary>
        /// Gets the policy id.
        /// </summary>
        /// <value>The policy id.</value>
        string PolicyId { get; }

        /// <summary>
        /// Gets the vin.
        /// </summary>
        /// <value>The vin.</value>
        string Vin { get; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year.</value>
        string Year { get; }

        /// <summary>
        /// Gets the make.
        /// </summary>
        /// <value>The make.</value>
        string Make { get; }

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>The model.</value>
        string Model { get; }

        /// <summary>
        /// Gets the license plate.
        /// </summary>
        /// <value>The license plate.</value>
        string LicensePlate { get; }

        /// <summary>
        /// Gets the state of the license plate.
        /// </summary>
        /// <value>The state of the license plate.</value>
        string LicensePlateState { get; }

        /// <summary>
        /// Gets the state of the registration.
        /// </summary>
        /// <value>The state of the registration.</value>
        string RegistrationState { get; }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <value>The color.</value>
        string Color { get; }

        /// <summary>
        /// Gets the active start date.
        /// </summary>
        /// <value>The active start dt.</value>
        string ActiveStartDt { get; }

        /// <summary>
        /// Gets the active end date.
        /// </summary>
        /// <value>The active end dt.</value>
        string ActiveEndDt { get; }

        /// <summary>
        /// Gets the file transmission log id.
        /// </summary>
        /// <value>The file transmission log id.</value>
        string FileTransmissionLogId { get; }

        /// <summary>
        /// Gets the driver1 number.
        /// </summary>
        /// <value>The driver1 number.</value>
        string Driver1Number { get; }

        /// <summary>
        /// Gets the driver1 percent.
        /// </summary>
        /// <value>The driver1 percent.</value>
        string Driver1Percent { get; }

        /// <summary>
        /// Gets the driver2 number.
        /// </summary>
        /// <value>The driver2 number.</value>
        string Driver2Number { get; }

        /// <summary>
        /// Gets the driver2 percent.
        /// </summary>
        /// <value>The driver2 percent.</value>
        string Driver2Percent { get; }

        /// <summary>
        /// Gets the misc.
        /// </summary>
        /// <value>The misc.</value>
        string Misc { get; }

        /// <summary>
        /// Gets the vehicle number.
        /// </summary>
        /// <value>The vehicle number.</value>
        string VehicleNumber { get; }

        /// <summary>
        /// Gets the type of the body.
        /// </summary>
        /// <value>The type of the body.</value>
        string BodyType { get; }

        /// <summary>
        /// Gets the location Id.
        /// </summary>
        /// <value>The location id.</value>
        string LocationId { get; }

        /// <summary>
        /// Gets the license weight.
        /// </summary>
        /// <value>The license weight.</value>
        string LicenseWeight { get; }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>The name of the entity.</value>
        string EntityName { get; }

        /// <summary>
        /// Gets the apportioned flag.
        /// </summary>
        /// <value>The apportioned flag.</value>
        string ApportionedFlag { get; }

        /// <summary>
        /// Gets the dot number.
        /// </summary>
        /// <value>The dot number.</value>
        string DotNumber { get; }

        /// <summary>
        /// Gets the mileage.
        /// </summary>
        /// <value>The mileage.</value>
        string Mileage { get; }

        /// <summary>
        /// Gets the title number.
        /// </summary>
        /// <value>The title number.</value>
        string TitleNumber { get; }

        /// <summary>
        /// Gets the type of the vehicle.
        /// NOTE : This is a CCE specific column - CCE Vehicle Type.
        /// </summary>
        /// <value>The type of the vehicle.</value>
        string VehicleTypeCCE { get; }

        /// <summary>
        /// Gets the vehicle desc.
        /// NOTE : This is a CCE specific column - CCE Vehicle Description.
        /// </summary>
        /// <value>The vehicle desc.</value>
        string VehicleDescCCE { get; }

        /// <summary>
        /// Gets the client num.
        /// </summary>
        /// <value>The client num.</value>
        string ClientNum { get; }

        /// <summary>
        /// Gets the archived flag.
        /// </summary>
        /// <value>The archived flag.</value>
        string ArchivedFlag { get; }
    }
}
