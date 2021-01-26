#region Header
/**************************************************************************
* First Notice Systems
* 529 Main Street
* Boston, MA 02129
* (617) 886 2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 2007 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/ListBoxRecord.cs 2     5/04/09 3:55p John.gwynn $ */
#endregion

using System.Runtime.InteropServices;
using System.Xml;
using FnsComposite.Interfaces;

namespace FnsComposite
{
	/// <summary>
	/// 
	/// </summary>
	[ComVisible(false)]
	public class ListBoxRecord : Composite, IListBoxRecord
	{
		private const string _nodeTypeName = "ListBoxRecord";

		/// <summary>
		/// Initializes a new instance of the <see cref="ListBoxRecord"/> class.
		/// </summary>
		public ListBoxRecord(): base(_nodeTypeName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="ListBoxRecord"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="value">The value.</param>
		public ListBoxRecord(string name, string value) : base(_nodeTypeName)
		{
			TextField = name;
			ValueField = value;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="ListBoxRecord"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public ListBoxRecord(XmlNode node) : base (node)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="ListBoxRecord"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="indexedName">Name of the indexed.</param>
		public ListBoxRecord(XmlNode node, string indexedName) : base (node, indexedName)
		{}

		#region IListBoxRecord Members

		/// <summary>
		/// Gets or sets the text field.
		/// </summary>
		/// <value>The text field.</value>
		public string TextField
		{
			get { return GetValue("TextField"); }
			set { SetValue("TextField", value); }
		}

		/// <summary>
		/// Gets or sets the value field.
		/// </summary>
		/// <value>The value field.</value>
		public string ValueField
		{
			get { return GetValue("ValueField"); }
			set { SetValue("ValueField", value); }
		}

		#endregion
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/ListBoxRecord.cs $
 * 
 * 2     5/04/09 3:55p John.gwynn
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * 1     10/30/07 7:12p John.gwynn
 * Support for new Business Rule evaluator
 */
#endregion