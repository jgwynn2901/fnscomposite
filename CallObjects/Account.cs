using System.Xml;

namespace FnsComposite.CallObjects
{
  public class Account : EntityBase, IAccount
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Account"/> class.
    /// </summary>
    public Account(): base("ACCOUNT")
		{}

    /// <summary>
    /// Initializes a new instance of the <see cref="Account"/> class.
    /// </summary>
    /// <param name="node">The node.</param>
    public Account(XmlNode node)
      : base(node)
		{}

    /// <summary>
    /// Gets or sets the name of the account.
    /// </summary>
    /// <value>
    /// The name of the account.
    /// </value>
    public string AccountName
    {
      get { return GetValue("NAME"); }
      set { SetValue("NAME", value); }
    }

    public string CompanyName
    {
      get { return AccountName; }
      set { AccountName = value; }
    }

    public string LocationCode
    {
      get { return GetValue("LOCATION_CODE"); }
      set { SetValue("LOCATION_CODE", value); }
    }
  }
}
