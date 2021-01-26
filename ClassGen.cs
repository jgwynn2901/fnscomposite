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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/ClassGen.cs 4     9/28/09 1:14p John.gwynn $ */
#endregion

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace FnsComposite
{
	/// <summary>
	/// Summary description for ClassGen.
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public class ClassGen : Composite
	{
		/// <summary>
		/// BUGBUG: we should use Environment.NewLine
		/// </summary>
		public const string CrLf = "\r\n"; // BUGBUG: move to generic i.e. StringHelper
		private const string namespaceAttribute = "NameSpace";
		private const string baseClassAttribute = "BaseClass";
		private const string usingAttribute = "UsingCollection";
		/// <summary>
		/// Holds the property attribute list for inOrder enumeration
		/// </summary>
		protected ArrayList propertyList;
		/// <summary>
		/// default header region
		/// </summary>
		static protected string[] headerRegion = 
			{
				"#region Header",
				"/**************************************************************************",
				"* First Notice Systems",
				"* 95 Wells Avenue",
				"* Newton, MA 02459",
				"* (617) 886-2600",
				"*",
				"* Proprietary Source Code -- Distribution restricted",
				"*",
				"* Copyright (c) 2007 by First Notice Systems",
				"**************************************************************************/",
				"/* ####Header: #### */",
				"#endregion",
			};
		/// <summary>
		/// default log
		/// </summary>
		static protected string logRegion = "#region Log\r\n/*\r\n * ####Log: ####\r\n */\r\n#endregion\r\n";
		/// <summary>
		/// Gets the header.
		/// </summary>
		/// <returns></returns>
		public string GetHeader()
		{
			StringBuilder results = new StringBuilder();

			foreach (string line in headerRegion)
			{
				results.AppendFormat("{0}\r\n", line.Replace("####", "$"));
			}
			return results.ToString();
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="ClassGen"/> class.
		/// </summary>
		/// <param name="nameSpace">The name space.</param>
		/// <param name="className">Name of the class.</param>
		public ClassGen(string nameSpace, string className)
			: base(className)
		{
			Depth = 1;
			Add(namespaceAttribute, nameSpace);
			propertyList = new ArrayList();
		}
		/// <summary>
		/// Gets or sets the namespace.
		/// </summary>
		/// <value>The namespace.</value>
		public string Namespace
		{
			get
			{
				if (this[namespaceAttribute] != null)
					return this[namespaceAttribute].Value;
				return string.Empty;
			}
			set { Add(namespaceAttribute, value); }
		}
		/// <summary>
		/// Gets or sets the baseclass.
		/// </summary>
		/// <value>The baseclass.</value>
		public string Baseclass
		{
			get
			{
				if (this[baseClassAttribute] != null)
					return this[baseClassAttribute].Value;
				return string.Empty;
			}
			set { Add(baseClassAttribute, value); }
		}
		/// <summary>
		/// Adds the property.
		/// </summary>
		/// <param name="propName">Name of the prop.</param>
		/// <param name="propType">Type of the prop.</param>
		public virtual void AddProperty(string propName, string propType)
		{
			Property prop = new Property(propName, string.Empty, propType);
			prop.Depth = Depth + 1;
			propertyList.Add(prop);
			HasAddedSinceLastCommit = true;
		}
		/// <summary>
		/// Adds the property.
		/// </summary>
		/// <param name="prop">The prop.</param>
		public void AddProperty(Property prop)
		{
			prop.Depth = Depth + 1;
			propertyList.Add(prop);
			HasAddedSinceLastCommit = true;
		}
		/// <summary>
		/// Adds the using.
		/// </summary>
		/// <param name="assembly">The assembly.</param>
		public void AddUsing(string assembly)
		{
			Add(string.Format("{0}/{1}", usingAttribute, assembly), assembly);
		}
		/// <summary>
		/// toString
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder results = new StringBuilder();

			results.Append(GetHeader());
			results.AppendFormat("{0}{1}{0}{0}", CrLf, GetUsings());
			results.AppendFormat("namespace {1}{0}", CrLf, Namespace);
			results.Append("{");
			results.Append(CrLf);
			results.Append(IndentTabs());
			if (Baseclass.Length > 0)
			{
				results.AppendFormat("public class {0} : {1}{2}", m_name, Baseclass, CrLf);
			}
			else
			{
				results.AppendFormat("public class {0}{1}", m_name, CrLf);
			}
			results.Append(IndentTabs());
			results.Append("{");
			results.Append(CrLf);
			// enumerations
			results.Append(GetEnumerations());
			// property definitions
			results.Append(GetPropertyDefinitions());
			// Property body setter/getter
			results.Append(CrLf);
			results.Append(GetConstructor());
			results.Append(CrLf);
			// Property body setter/getter
			results.Append(GetPropertyBodies());
			results.Append(GetMethods());
			results.Append(CrLf);
			results.Append(IndentTabs());
			results.Append("}");
			results.Append(CrLf);

			results.Append("}");
			results.Append(CrLf);
			results.Append(CrLf);
			results.Append(logRegion.Replace("####", "$"));

			return results.ToString();
		}
		/// <summary>
		/// Gets the property definitions.
		/// </summary>
		/// <returns></returns>
		protected virtual string GetPropertyDefinitions()
		{
			StringBuilder results = new StringBuilder();
			foreach (Property prop in propertyList)
			{
				results.AppendFormat("{0}\r\n", prop);
			}
			return results.ToString();
		}
		/// <summary>
		/// Gets the property bodies.
		/// </summary>
		/// <returns></returns>
		protected virtual string GetPropertyBodies()
		{
			StringBuilder results = new StringBuilder();
			foreach (Property prop in propertyList)
			{
				results.AppendFormat("{0}\r\n", prop.Body());
			}
			return results.ToString();
		}
		/// <summary>
		/// Gets the usings.
		/// </summary>
		/// <returns></returns>
		protected string GetUsings()
		{
			StringBuilder results = new StringBuilder();
			foreach (CompositeBase node in this)
			{
				if (node.Name == usingAttribute)
				{
					foreach (CompositeLeaf leaf in (Composite)node)
					{
						results.AppendFormat("using {0};\r\n", leaf.Value);
					}
				}
			}
			return results.ToString();
		}
		/// <summary>
		/// Gets the methods.
		/// </summary>
		/// <returns></returns>
		protected virtual string GetMethods()
		{
			return string.Empty;
		}
		/// <summary>
		/// Gets the enumerations.
		/// </summary>
		/// <returns></returns>
		protected virtual string GetEnumerations()
		{
			return string.Empty;
		}
		/// <summary>
		/// Gets the constructor.
		/// </summary>
		/// <returns></returns>
		protected virtual string GetConstructor()
		{
			StringBuilder results = new StringBuilder();
			int indent = 1;

			results.Append(IndentTabs(indent));
			results.Append("#region Constructor");
			results.Append(CrLf);

			results.AppendFormat("{0}public {1}(){2}", IndentTabs(indent), m_name, CrLf);
			results.Append(IndentTabs(indent));
			results.Append("{ }");
			results.Append(CrLf);
			results.Append(IndentTabs(indent));
			results.Append("#endregion");
			results.Append(CrLf);

			return results.ToString();
		}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/ClassGen.cs $
 * 
 * 4     9/28/09 1:14p John.gwynn
 * Added support for ICloneable
 * 
 * 3     9/24/07 5:34p John.gwynn
 * merged with 2003 changes
 * 
 * 2     4/20/07 5:17p John.gwynn
 * 
 * 1     4/17/07 3:40p John.gwynn
 * update to current version from 1.1
 * 
 * 5     3/11/07 7:37p John.gwynn
 * First cut for DbClassGenerator
 * 
 * 4     3/11/07 6:35p John.gwynn
 * added constructor output TODO: Initialize parameters
 * 
 * 3     3/09/07 6:21p John.gwynn
 * first cut of the DbClassGen for DbBaseClass generation (Class
 * definition)
 * 
 * 2     3/09/07 3:47p John.gwynn
 * incomplete interim check-in to move to new machine
 * 
 * 1     3/06/07 6:35p John.gwynn
 * composite based Code generation support added 
 */
#endregion