using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
  public interface IAccount : IComposite, ICompany
  {
    /// <summary>
    /// Gets or sets the name of the account.
    /// </summary>
    /// <value>
    /// The name of the account.
    /// </value>
    string AccountName { get; set; }
  }
}
