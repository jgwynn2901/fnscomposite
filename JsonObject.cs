namespace FnsComposite
{
  /// <summary>
  /// use for serializing namve value pairs sans object / class name
  /// </summary>
  public class JsonObject : Composite
  {
    /// <summary>
    /// Gets a value indicating whether this instance is root.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is root; otherwise, <c>false</c>.
    /// </value>
    protected override bool IsRoot { get { return true; } }
  }
}
