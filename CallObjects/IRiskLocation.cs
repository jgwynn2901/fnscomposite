using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
  public interface IRiskLocation : IComposite, ICompany
  {
    /// <summary>
    /// Gets or sets the name of the location.
    /// </summary>
    /// <value>
    /// The name of the location.
    /// </value>
    string LocationName { get; set; }
  }
}
