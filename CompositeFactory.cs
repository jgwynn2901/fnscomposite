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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CompositeFactory.cs 7     7/06/09 7:02p John.gwynn $ */
#endregion

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;

namespace FnsComposite
{
	/// <summary>
	/// Summary description for CompositeFactory.
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public class CompositeFactory
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CompositeFactory"/> class.
		/// </summary>
		private CompositeFactory()
		{}
		/// <summary>
		/// Creates the specified node.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <returns></returns>
		static public CompositeBase CreateCopy(CompositeBase node)
		{
			CompositeBase result;
			
			if(node.IsLeaf)
			{
				result = new CompositeLeaf((CompositeLeaf) node);
			}
			else
			{
					result = new Composite((Composite)node); //BUGBUG N.B. Types are not preserved....
			}
			return result;
		}
		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		static public Composite CreateInstance (string name)
		{
			int bracket = name.IndexOf("[", StringComparison.Ordinal);
			if(bracket > -1)
			{
				return (CreateInstance(name.Substring(0, bracket), name.Substring(bracket)));
			}
			Assembly compositeAssembly = Assembly.GetExecutingAssembly();
			if(compositeAssembly != null)
			{
				string className = name;
				// override map CALL to CallObject
				if (name.Equals("Call", StringComparison.InvariantCultureIgnoreCase))
					className = "Call_Object";
				
				Type type = GetTypeFromOjectName(className);

				if (type != null)
					return compositeAssembly.CreateInstance(type.FullName) as Composite;
			}
			return new Composite(name);
		}
		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="node">The node.</param>
		/// <returns></returns>
		static public Composite CreateInstance (string name, XmlNode node )
		{
			Assembly compositeAssembly = Assembly.GetExecutingAssembly();
			if (compositeAssembly != null)
			{
				string className = name;
				// override map CALL to CallObject
				
				Type requestedType = GetTypeFromOjectName(className);
				if (requestedType != null)
				{
					Type[] types = new Type[] { typeof(XmlNode) };
					ConstructorInfo requestedConstructor = requestedType.GetConstructor(types);
					if (requestedConstructor != null)
					{
						object[] requestedParameters = { node };
						object request = requestedConstructor.Invoke(requestedParameters);
						if (request != null)
						{
							return request as Composite;
						}
					}
				}
			}
			return new Composite(node);
		}
		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="indexSuffix">The index suffix.</param>
		/// <returns></returns>
		static public Composite CreateInstance(string name, string indexSuffix)
		{
			Assembly compositeAssembly = Assembly.GetExecutingAssembly();
			if (compositeAssembly != null)
			{
				Type requestedType = GetTypeFromOjectName(name);
				if (requestedType != null)
				{
					Type[] types = new Type[] { typeof(string) };
					ConstructorInfo requestedConstructor = requestedType.GetConstructor(types);
					if (requestedConstructor != null)
					{
						object[] requestedParameters = { indexSuffix };
						object request = requestedConstructor.Invoke(requestedParameters);
						if (request != null)
						{
							return request as Composite;
						}
					}
				}
			}
			return new Composite(name + indexSuffix);
		}
		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="node">The node.</param>
		/// <param name="indexSuffix">The index suffix.</param>
		/// <returns></returns>
		static public Composite CreateInstance(string name, XmlNode node, string indexSuffix)
		{
			Assembly compositeAssembly = Assembly.GetExecutingAssembly();
			if (compositeAssembly != null)
			{
				string className = name;
				// override map CALL to CallObject
				if (name.Equals("EVENT", StringComparison.InvariantCultureIgnoreCase))
					className = "CallFlow_Event";
				Type requestedType = GetTypeFromOjectName(className);
				if (requestedType != null)
				{
					Type[] types = new Type[] { typeof(XmlNode), typeof(string) };
					ConstructorInfo requestedConstructor = requestedType.GetConstructor(types);
					if (requestedConstructor != null)
					{
						object[] requestedParameters = { node, indexSuffix };
						object request = requestedConstructor.Invoke(requestedParameters);
						if (request != null)
						{
							return request as Composite;
						}
					}
				}
			}
			return new Composite(name+indexSuffix);
		}
		/// <summary>
		/// Gets the name of the type from oject.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		static private Type GetTypeFromOjectName(string name)
		{
			string typeName = PascalCase(name);
			int bracket = typeName.IndexOf("[", StringComparison.Ordinal);
			if (bracket > -1)
			{
				typeName = typeName.Substring(0, bracket);
			}
			Assembly compositeAssembly = Assembly.GetExecutingAssembly();
			Type type = compositeAssembly.GetType(string.Format("FnsComposite.CallObjects.{0}", typeName));
			if (type == null)
			{
				type = compositeAssembly.GetType(string.Format("FnsComposite.{0}", typeName));
			}
			if (type == null)
			{
				type = compositeAssembly.GetType(string.Format("FnsComposite.MessageObjects.{0}", typeName));
			}
			if (type == null)
			{
				type = compositeAssembly.GetType(string.Format("FnsComposite.SegmentObjects.{0}", typeName));
			}
			return type;
		}
		/// <summary>
		/// Pascals the case.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <returns></returns>
		public static string PascalCase(string source)
		{
			string results = source.ToLower();
			if (results.Length > 0)
			{
				return string.Format("{0}{1}", results.Substring(0, 1).ToUpper(), RemoveUnderscore(results.Substring(1)));
			}
			return results;
		}
		/// <summary>
		/// Removes the underscore.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <returns></returns>
		private static string RemoveUnderscore(string source)
		{
			int index = source.IndexOf("_", StringComparison.Ordinal);
			if (index > -1)
			{
				return
					string.Format("{0}{1}{2}", source.Substring(0, index), source.Substring(index + 1, 1).ToUpper(),
												RemoveUnderscore(source.Substring(index + 2)));
			}
			return source;
		}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CompositeFactory.cs $
 * 
 * 7     7/06/09 7:02p John.gwynn
 * Fixed strongly typed constructor for CallflowEvent objects (loading
 * from Xml) and added NamedValueCollection for set difference operations
 * 
 * 6     5/19/09 1:57p John.gwynn
 * added JSON serialiation
 * 
 * 5     11/28/07 11:22a John.gwynn
 * Added CallObject.Property and interface
 * 
 * 4     10/22/07 6:08p John.gwynn
 * 
 * 3     10/21/07 3:51p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 * 
 * 2     4/20/07 5:17p John.gwynn
 * 
 * 1     4/17/07 3:40p John.gwynn
 * update to current version from 1.1
 * 
 * 2     3/11/07 6:35p John.gwynn
 * added constructor output TODO: Initialize parameters
 * 
 * 1     2/21/07 11:39a John.gwynn
 * added Operator == and comparison operators as well as Copy
 * constructors...
 */
#endregion
