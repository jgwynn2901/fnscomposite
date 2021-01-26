using System.Xml;

namespace FnsComposite.CallObjects
{
  public class Citation : CallObjectBase, ICitation
  {
    public Citation(): base("CITATION")
    {}
    /// <summary>
    /// Initializes a new instance of the <see cref="Citation"/> class.
    /// </summary>
    /// <param name="node">The node.</param>
    public Citation(XmlNode node)
      : base(node)
    {}

    /// <summary>
    /// Gets or sets the ticket number.
    /// </summary>
    /// <value>
    /// The ticket number.
    /// </value>
    public string TicketNumber
    {
      get { return GetValue("TICKET_NUMBER"); }
      set { SetValue("TICKET_NUMBER", value); }
    }

    /// <summary>
    /// Gets or sets the citation issued flag.
    /// </summary>
    /// <value>
    /// The citation issued flag.
    /// </value>
    public string CitationIssuedFlag
    {
      get { return GetValue("CITATION_ISSUED_FLG"); }
      set { SetValue("CITATION_ISSUED_FLG", value); }
    }

    /// <summary>
    /// Gets or sets the code1.
    /// </summary>
    /// <value>
    /// The code1.
    /// </value>
    public string Code1
    {
      get { return GetValue("CODE1"); }
      set { SetValue("CODE1", value); }
    }

    /// <summary>
    /// Gets or sets the code2.
    /// </summary>
    /// <value>
    /// The code2.
    /// </value>
    public string Code2
    {
      get { return GetValue("CODE2"); }
      set { SetValue("CODE2", value); }
    }

    /// <summary>
    /// Gets or sets the code3.
    /// </summary>
    /// <value>
    /// The code3.
    /// </value>
    public string Code3
    {
      get { return GetValue("CODE3"); }
      set { SetValue("CODE3", value); }
    }
  }
}
