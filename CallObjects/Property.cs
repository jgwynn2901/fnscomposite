#region Header
/**************************************************************************
* First Notice Systems
* 95 Wells Avenue
* Newton, MA 02459
* (617) 886-2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 2007 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Property.cs 3     5/22/12 6:09p Gwynnj $ */
#endregion

using System;
using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Implements propery for CallObjects	
	/// </summary>
	public class Property : CallObjectBase, IProperty
	{
		private const string NodeTypeName = "PROPERTY";

		/// <summary>
		/// Initializes a new instance of the <see cref="Property"/> class.
		/// </summary>
		public Property(): base(NodeTypeName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Property"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Property(XmlNode node) : base (node)
		{}

        public Property(XmlNode node, string indexedName)
            : base(node, indexedName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Property"/> class.
		/// </summary>
		/// <param name="indexName">Name of the index.</param>
		public Property(string indexName): base(NodeTypeName+indexName)
		{}

		#region IProperty Members

		/// <summary>
		/// Gets the owner.
		/// </summary>
		/// <value>The owner.</value>
		public IOwner Owner
		{
			get
			{
				Owner node = GetObject<Owner>("OWNER") as Owner;
				if (node == null)
				{
					throw new ApplicationException("CallObject error retrieving type: Claim");
				}
				return node;
			}
		}
		#endregion
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Property.cs $
 * 
 * 3     5/22/12 6:09p Gwynnj
 * additional updates required for AAA
 * 
 * 2     1/16/08 6:39p John.gwynn
 * added CallObjectBase to override SetValue
 * 
 * 1     11/28/07 11:22a John.gwynn
 * Added CallObject.Property and interface
 */
#endregion