namespace FnsComposite
{
  /// <summary>
  /// returns the collection of untouched elements from last serialization 
  /// operation i.e. LoadFromJson or LoadXml
  /// </summary>
  public class UntouchedVisitor : NameValueVistor
  {
    /// <summary>
    /// tests the Element method determines inclusion in the results set.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <returns></returns>
    protected override bool ElementTest(CompositeBase element)
    {
      return !element.Dirty;
    }
  }
}
