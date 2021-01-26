using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace FnsComposite
{
  public interface INameValueVistor : IVisitor
  {
    /// <summary>
    /// Gets the collection.
    /// </summary>
    NameValueCollection Items { get; }
  }

  /// <summary>
	/// Extracts a NameValueCollection from the composite
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public class NameValueVistor : VisitorBase, INameValueVistor
  {
		private readonly NameValueCollection _collection = new NameValueCollection();

		/// <summary>
		/// Gets the collection.
		/// </summary>
		public NameValueCollection Items 
		{
			get { return _collection; }
		}

	  protected NameValueCollection Collection
	  {
	    get { return _collection; }
	  }
		/// <summary>
		/// Visits the specified element.
		/// </summary>
		/// <param name="element">The element.</param>
		public override void Visit(CompositeBase element)
		{
			if (element.IsLeaf)
			{
				// process this 
				var name = element.ParentPath();
				// we want the root node to be implicit
				// this is for CALL roots only should be 
				// subclassed to the FnsDomain?
				if (name.StartsWith("CALL:"))
					name = name.Remove(0, 5);

				_collection.Add(name, element.Value);
			}
			else
			{
				foreach (CompositeBase c in (Composite)element)
				{
					c.Accept(this);
				}
			}
		}
    /// <summary>
    /// tests the Element method determines inclusion in the results set.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <returns></returns>
    protected virtual bool ElementTest(CompositeBase element)
    {
      return true;
    }
	}
}
