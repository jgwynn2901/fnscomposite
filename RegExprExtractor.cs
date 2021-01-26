#region Header
/**************************************************************************
* First Notice Systems
* 529 Main Street
* Boston, MA 02129
* (617) 886 2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 2006 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/RegExprExtractor.cs 5     10/12/11 3:07p Gwynnj $ */
#endregion

using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using FnsComposite.CallObjects;


namespace FnsComposite
{
	/// <summary>
	/// Summary description for RegExprExtractor.
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public class RegExprExtractor : VisitorBase
	{
		private readonly CallObject _oCall;
		private string _name;

        /// <summary>
		/// Initializes a new instance of the <see cref="RegExprExtractor"/> class.
		/// </summary>
		public RegExprExtractor() : this(string.Empty)
		{}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="RegExprExtractor"/> class.
		/// </summary>
		/// <param name="expression">The expression.</param>
		public RegExprExtractor(string expression)
		{
			_oCall = new CallObject();
			_name = string.Empty;
			Expression = expression;
		}
		/// <summary>
		/// Gets or sets the expression.
		/// </summary>
		/// <value>The expression.</value>
		public string Expression { get; set; }

        /// <summary>
		/// Visits the specified element.
		/// </summary>
		/// <param name="element">The element.</param>
		public override void Visit (CompositeBase element)
		{
			if(!element.IsLeaf)
			{
				// process this 
				string name = _name;

				if (element.Name != Composite.CallRoot ||element.Name != Composite.ObjectRoot )
				{
					if(_name.Length == 0)
					{
						_name = element.Name;
					}
					else 
					{
						_name += ":" + element.Name;
					}
				}
				ProcessNode((Composite)element);
				// and propagate
				foreach (CompositeBase c in (Composite)element) 
				{
					c.Accept(this);
				}
				_name = name;
			}
		}
		/// <summary>
		/// Processes the node.
		/// </summary>
		/// <param name="element">The element.</param>
		private void ProcessNode (Composite element)
		{
			var pattern = new Regex(Expression);
			
			foreach (CompositeBase c in element)
            {
                if (!c.IsLeaf || !pattern.IsMatch(c.Name)) continue;
                _oCall.SetValue(string.IsNullOrEmpty(_name) ? c.Name : $"{_name}:{c.Name}", c.Value);
            }
		}
		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return _oCall.ToXml();
		}
		/// <summary>
		/// Gets the leaf node count.
		/// </summary>
		/// <returns></returns>
		public int GetLeafNodeCount ()
		{
			return _oCall.GetLeafNodeCount();
		}
	}
}
#region History
/*
 * $History: RegExprExtractor.cs $
 * 
 * *****************  Version 5  *****************
 * User: Gwynnj       Date: 10/12/11   Time: 3:07p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite
 * fixed a bug in the regex visitor
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 1/02/08    Time: 4:07p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite
 * refactored the ICall class interface and implementation to the
 * FnsDomain assembly
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 4/20/07    Time: 5:17p
 * Updated in $/SourceCode/Components/VS.NET2005/FnsComposite
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 4/17/07    Time: 3:41p
 * Updated in $/SourceCode/Components/VS.NET2005/FnsComposite
 * update current version synch to 1.1
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 11/16/06   Time: 5:20p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * Added NDoc comments and formatting
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 6/03/06    Time: 4:50p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * added RegexprExtractor and support for counting leaf nodes and strong
 * name file
 */
#endregion
