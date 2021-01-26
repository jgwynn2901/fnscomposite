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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/DbClassGen.cs 3     9/24/07 5:34p John.gwynn $ */
#endregion

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FnsComposite
{
	/// <summary>
	/// Summary description for DbClassGen.
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public class DbClassGen : ClassGen
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DbClassGen"/> class.
		/// </summary>
		/// <param name="nameSpace">The name space.</param>
		/// <param name="className">Name of the class.</param>
		public DbClassGen(string nameSpace, string className) :base(nameSpace, className)
		{
			Baseclass = "DbBaseClass";
		}
		/// <summary>
		/// Adds the property.
		/// </summary>
		/// <param name="propName">Name of the prop.</param>
		/// <param name="propType">Type of the prop.</param>
		public override void AddProperty (string propName, string propType)
		{
			AddProperty(new DbProperty(propName, string.Empty, propType));
		}
		/// <summary>
		/// Adds the property.
		/// </summary>
		/// <param name="propName">Name of the prop.</param>
		/// <param name="propType">Type of the prop.</param>
		/// <param name="parmName">Name of the parm.</param>
		/// <param name="readOnly">if set to <c>true</c> [read only].</param>
		public void AddProperty(string propName, string propType, string parmName, bool readOnly)
		{
			DbProperty prop = new DbProperty(propName, string.Empty, propType);
			prop.AltName = parmName;
			AddProperty(prop);
		}
		/// <summary>
		/// Gets the enumerations.
		/// </summary>
		/// <returns></returns>
		protected override string GetEnumerations ()
		{
			StringBuilder results = new StringBuilder();
			results.Append(IndentTabs(1));
			results.Append("private enum eParmList");
			results.Append(CrLf);
			results.Append(IndentTabs(1));
			results.Append("{");
			results.Append(CrLf);
			results.Append(IndentTabs(1));
			bool isFirst = true;
			foreach (DbProperty prop in propertyList)
			{
				if (!isFirst)
				{
					results.Append(",");
				}
				results.AppendFormat("{0}{1}{2}", CrLf, IndentTabs(2), prop.Name);
				if (isFirst)
				{
					results.Append(" = 0");
					isFirst = false;
				}
			}
			results.Append(CrLf);
			results.Append(IndentTabs(1));
			results.Append("};");
			results.Append(CrLf);

			return results.ToString();
		}
		/// <summary>
		/// Gets the constructor definition(s).
		/// </summary>
		/// <returns></returns>
		protected override string GetConstructor ()
		{
			int indent = 1;
			StringBuilder results = new StringBuilder();
			
			results.Append(IndentTabs(indent));
			results.Append("#region Constructor");
			results.Append(CrLf);
			 
			results.Append(IndentTabs(indent));
			results.AppendFormat("public {0}() : this(String.Empty){1}",m_name, CrLf );
			results.Append(IndentTabs(indent));
			results.Append("{ }");
			results.Append(CrLf);
			results.Append(CrLf);
			results.Append(IndentTabs(indent));
			results.AppendFormat("public {0}(string instance) :base(instance)",m_name );
			results.Append(CrLf);
			results.Append(IndentTabs(indent));
			results.Append("{");
			results.Append(CrLf);
			results.Append(IndentTabs(indent+1));
			results.Append("_name = \"INSERT SPNAME HERE!\";" );
			results.Append(CrLf);
			results.Append(CrLf);
			results.Append(IndentTabs(indent+1));
			results.Append("_parameterNames = new string[] {" );
			results.Append(CrLf);
			results.Append(IndentTabs(indent+1));
			results.Append(GetAltNameArrayDef());
			results.Append("};");
			results.Append(CrLf);
			results.Append(CrLf);
			results.Append(IndentTabs(indent+1));
			results.Append("Initialize();" );
			results.Append(CrLf);
			results.Append(IndentTabs(indent));
			results.Append("}");
			results.Append(CrLf);
			results.Append(IndentTabs(indent));
			results.Append("#endregion");
			results.Append(CrLf);

			return results.ToString();
		}
		/// <summary>
		/// Gets the methods.
		/// </summary>
		/// <returns></returns>
		protected override string GetMethods ()
		{
			int indent = 1;
			StringBuilder results = new StringBuilder();
			
			results.Append(IndentTabs(indent));
			results.Append("#region Initialize");
			results.Append(CrLf);
			results.Append(IndentTabs(indent));
			results.Append("protected override void Initialize()");
			results.Append(CrLf);
			results.Append(IndentTabs(indent));
			results.Append("{");
			results.Append(CrLf);
			foreach (DbProperty prop in propertyList)
			{
				results.Append("\t");
				results.Append(prop.GetInit());
				results.Append(CrLf);
			}
			results.Append(IndentTabs(indent));
			results.Append("}");
			results.Append(CrLf);

			results.Append(IndentTabs(indent));
			results.Append("#endregion");
			results.Append(CrLf);

			return results.ToString();
		}
		/// <summary>
		/// Gets the alt name array def.
		/// </summary>
		/// <returns></returns>
		private string GetAltNameArrayDef ()
		{
			bool isFirst = true;
			StringBuilder results = new StringBuilder();
			foreach (DbProperty prop in propertyList)
			{
				if (isFirst)
				{
					isFirst = false;
				}
				else
				{
					results.Append(",");
				}
				results.AppendFormat("\"{0}\"", prop.AltName);
			}
			return results.ToString();
			
		}
	}

}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/DbClassGen.cs $
 * 
 * 3     9/24/07 5:34p John.gwynn
 * merged with 2003 changes
 * 
 * 2     4/20/07 5:17p John.gwynn
 * 
 * 1     4/17/07 3:40p John.gwynn
 * update to current version from 1.1
 * 
 * 5     3/14/07 5:14p John.gwynn
 * added filter for DbProperty type only on output
 * 
 * 4     3/11/07 7:37p John.gwynn
 * First cut for DbClassGenerator
 * 
 * 3     3/11/07 6:35p John.gwynn
 * added constructor output TODO: Initialize parameters
 * 
 * 2     3/09/07 6:21p John.gwynn
 * first cut of the DbClassGen for DbBaseClass generation (Class
 * definition)
 * 
 * 1     3/09/07 3:47p John.gwynn
 * incomplete interim check-in to move to new machine
 */
#endregion
