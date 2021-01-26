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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/AddressExtractor.cs 5     9/22/10 12:23p Gwynnj $ */
#endregion

using System;
using System.Linq;
using System.Runtime.InteropServices;
using FnsComposite.CallObjects;

namespace FnsComposite
{
	/// <summary>
	/// Summary description for AddressExtractor.
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]	
	public class AddressExtractor : VisitorBase
	{
		readonly CallObject _call;
		int _curentIndex;
		string _name;

		/// <summary>
		/// Initializes a new instance of the <see cref="AddressExtractor"/> class.
		/// </summary>
		public AddressExtractor()
		{
			_call = new CallObject();
			_curentIndex = 0;
			_name = string.Empty;
		}
		/// <summary>
		/// populate the Document
		/// </summary>
		/// <param name="element">The element.</param>
		public override void Visit (CompositeBase element)
		{
		  if (element.IsLeaf) return;
		  // process this 
		  var name = _name;

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
		/// <summary>
		/// Processes the node.
		/// </summary>
		/// <param name="element">The element.</param>
		private void ProcessNode (Composite element)
		{
		  if (element == null) throw new ArgumentNullException("element");
		  var address = string.Empty;
			var city = string.Empty;
			var state = string.Empty;
			var zipCode = string.Empty;
			
			foreach (var oLeaf in (from CompositeBase c in element where c.IsLeaf select c).Cast<CompositeLeaf>())
			{
			  if(oLeaf.Name.IndexOf(Address.AddressLine1, StringComparison.Ordinal) >-1)
			  {
			    address = oLeaf.Value;
			  }
			  else if(oLeaf.Name.IndexOf(Address.AddressCity, StringComparison.Ordinal) >-1)
			  {
			    city = oLeaf.Value;
			  }
			  else if(oLeaf.Name.IndexOf(Address.AddressState, StringComparison.Ordinal) >-1)
			  {
			    state = oLeaf.Value;
			  }
			  else if(oLeaf.Name.IndexOf(Address.AddressZip, StringComparison.Ordinal) >-1)
			  {
			    zipCode = oLeaf.Value;
			  }
			}
		  if (address == string.Empty || city == string.Empty || state == string.Empty || zipCode == string.Empty) return;
		  _call.SetValue("ADDRESS["+ _curentIndex + "]:NAME",_name);
		  _call.SetValue("ADDRESS["+ _curentIndex + "]:ADDRESS_LINE1",address);
		  _call.SetValue("ADDRESS["+ _curentIndex + "]:ADDRESS_CITY",city);
		  _call.SetValue("ADDRESS["+ _curentIndex + "]:ADDRESS_STATE",state);
		  _call.SetValue("ADDRESS["+ _curentIndex + "]:ADDRESS_ZIP",zipCode);
		  ++_curentIndex;
		}
		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return _call.ToXml();
		}
	}
}
#region History
/*
 * $History: AddressExtractor.cs $
 * 
 * *****************  Version 5  *****************
 * User: Gwynnj       Date: 9/22/10    Time: 12:23p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite
 * Added address constants
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
 * *****************  Version 6  *****************
 * User: John.gwynn   Date: 6/03/06    Time: 4:49p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * added RegexprExtractor and support for counting leaf nodes and strong
 * name file
 */
#endregion
