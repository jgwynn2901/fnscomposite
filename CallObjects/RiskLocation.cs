using System.Xml;

namespace FnsComposite.CallObjects
{
  public class RiskLocation : EntityBase, IRiskLocation
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RiskLocation"/> class.
    /// </summary>
    public RiskLocation(): base("RISK_LOCATION")
		{}

    /// <summary>
    /// Initializes a new instance of the <see cref="RiskLocation"/> class.
    /// </summary>
    /// <param name="node">The node.</param>
	  public RiskLocation(XmlNode node)
      : base(node)
		{}

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string LocationName
    {
      get { return GetValue("NAME"); }
      set { SetValue("NAME", value); }
    }

    public string CompanyName
    {
      get { return LocationName; }
      set { LocationName = value; }
    }

    public string LocationCode
    {
      get { return GetValue("LOCATION_CODE"); }
      set { SetValue("LOCATION_CODE", value); }
    }
  }
}
