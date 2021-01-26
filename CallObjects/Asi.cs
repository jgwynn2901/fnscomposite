#region Header
/**************************************************************************
* First Notice Systems
* 95 Wells Avenue
* Newton, MA 02459
* (617) 886-2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 2008 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Asi.cs 1     2/28/08 7:47p John.gwynn $ */
#endregion

using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Implements ASI node for CallObject	
	/// </summary>
	public class Asi : CallObjectBase, IAsi
	{
		private const string _nodeTypeName = "ASI";
		/// <summary>
		/// Initializes a new instance of the <see cref="Asi"/> class.
		/// </summary>
		public Asi() : base(_nodeTypeName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Asi"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Asi(XmlNode node): base(node)
		{}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Asi.cs $
 * 
 * 1     2/28/08 7:47p John.gwynn
 * Added ASI and Carrier support
 */
#endregion