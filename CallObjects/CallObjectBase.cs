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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/CallObjectBase.cs 9     9/28/09 1:14p John.gwynn $ */
#endregion

using System;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// base class to override GetValue
	/// </summary>
	[Serializable]
	public class CallObjectBase : Composite
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CallObjectBase"/> class.
		/// </summary>
		public CallObjectBase(): base("UNKNOWN")
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="CallObjectBase"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		public CallObjectBase(string name): base(name)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="CallObjectBase"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public CallObjectBase(XmlNode node): base(node)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="CallObjectBase"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="indexedName">Name of the indexed.</param>
		public CallObjectBase(XmlNode node, string indexedName): base(node, indexedName)
		{}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="CallObjectBase"/> class.
		/// </summary>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		protected CallObjectBase(SerializationInfo info, StreamingContext context)
			: base(info)
		{}
		
		/// <summary>
		/// SetValue
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public override void SetValue(string name, string value)
		{
			if (value.Length > 0)
			{
				base.SetValue(name, value);
			}
			else if(GetValue(name).Length > 0)
			{
				Remove(name);
			}
		}

		/// <summary>
		/// Serializes the BLOB with first node as HEADER.
		/// </summary>
		public override void Serialize(BinaryWriter writer)
		{
			CStringConverter.Write(writer, m_name);
			WordReader.WriteCount(writer, ObjectList.Count);

			bool first = true;
			foreach (CompositeBase node in ObjectList.Values)
			{
				// key
				CStringConverter.Write(writer, node.Name);

				if (first)
				{
					first = false;
					writer.Write(HeaderIndicator);
					writer.Write((ushort)1);	// preface 
					if (node.IsLeaf)
						CStringConverter.Write(writer, "Attribute");
					else
						CStringConverter.Write(writer, "Object");
				}

				// now proceed using the non-header version
				if (node.IsLeaf)
					writer.Write((ushort)AttributeType);
				else
					writer.Write((ushort)ObjectType);

				node.Serialize(writer);
			}
		}
	}
}
