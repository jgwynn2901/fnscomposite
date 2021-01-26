namespace FnsComposite.CallObjects
{
  public interface ICitation
  {
    /// <summary>
    /// Gets or sets the ticket number.
    /// </summary>
    /// <value>
    /// The ticket number.
    /// </value>
    string TicketNumber { get; set; }

    /// <summary>
    /// Gets or sets the citation issued flag.
    /// </summary>
    /// <value>
    /// The citation issued flag.
    /// </value>
    string CitationIssuedFlag { get; set; }

    /// <summary>
    /// Gets or sets the code1.
    /// </summary>
    /// <value>
    /// The code1.
    /// </value>
    string Code1 { get; set; }

    /// <summary>
    /// Gets or sets the code2.
    /// </summary>
    /// <value>
    /// The code2.
    /// </value>
    string Code2 { get; set; }

    /// <summary>
    /// Gets or sets the code3.
    /// </summary>
    /// <value>
    /// The code3.
    /// </value>
    string Code3 { get; set; }
  }
}