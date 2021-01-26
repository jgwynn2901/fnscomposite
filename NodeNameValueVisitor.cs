using System;
using System.Collections.Generic;

namespace FnsComposite
{
	public class NodeNameValueVisitor : VisitorBase
	{
		private readonly Dictionary<string, string> _items = new Dictionary<string, string>();

		public Dictionary<string, string> Items
		{
			get { return _items; }
		}

		public override void Visit(CompositeBase element)
		{
			if (element.IsLeaf)
			{
				if (_items.ContainsKey(element.Name))
					throw new ApplicationException(string.Format("NodeNameValueVisitor duplicate name error adding {0}/{1}", 
						element.ParentPath(), element.Name));
					_items.Add(element.Name, element.Value);					
			}
			else
			{
				foreach (CompositeBase c in (Composite)element)
					if(c.IsLeaf)
						c.Accept(this);
			}
		}
	}
}
