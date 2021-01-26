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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/DbProperty.cs 4     9/28/09 1:14p John.gwynn $ */
#endregion
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FnsComposite
{
	/// <summary>
	/// Summary description for DbProperty.
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public class DbProperty : Property
	{
		/// <summary>
		/// type descriptor 
		/// </summary>
		private const string _propertyCompositeType = "DbProperty";
		/// <summary>
		/// Initializes a new instance of the <see cref="DbProperty"/> class.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		public DbProperty(string propertyName): this  (propertyName,string.Empty, "string")
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="DbProperty"/> class.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="propertyValue">The property value.</param>
		/// <param name="propertyType">Type of the property.</param>
		public DbProperty(string propertyName, string propertyValue, string propertyType ) : base (propertyName, propertyValue, propertyType)
		{
			NodeType = _propertyCompositeType;
		}
		/// <summary>
		/// toString
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			// supress the definition section
			return string.Empty;
		}
		/// <summary>
		/// Prints the body for this parm
		/// </summary>
		/// <returns></returns>
		public override string Body()
		{
			string publicName = CamelCaseName(m_name);
			StringBuilder results = new StringBuilder();
			results.Append(IndentTabs());
			results.AppendFormat("#region {0}\r\n",publicName);
			results.Append(IndentTabs());
			results.AppendFormat("public {0} {1}\r\n", propertyTypeName, publicName);
			results.Append(IndentTabs());
			results.Append("{\r\n");
			results.Append(IndentTabs());
			results.AppendFormat("\tget{{ return GetValue((int)eParmList.{0}); }}\r\n", m_name);
			if(!isReadOnly)
			{
				results.Append(IndentTabs());
				results.AppendFormat("\tset{{ SetValue((int)eParmList.{0},value); }}\r\n",m_name);			
			}
			results.Append(IndentTabs());
			results.Append("}\r\n");

			results.Append(IndentTabs());
			results.Append("#endregion\r\n");
			return results.ToString();
		}
		/// <summary>
		/// Gets the body.
		/// </summary>
		/// <returns></returns>
		public string GetInit()
		{
			StringBuilder results = new StringBuilder();
			results.Append(IndentTabs());
			results.AppendFormat("AddParm(System.Data.ParameterDirection.{0},", isReadOnly ? "Output" : "Input");
			//results.Append(ClassGen.CrLf);
			//results.Append(IndentTabs());
			results.AppendFormat("_parameterNames[(int)eParmList.{0}],\"\",System.Data.DbType.{1});",m_name,GetDbType());
			results.Append(ClassGen.CrLf);

			return results.ToString();
		}
		/// <summary>
		/// Gets the type of the db.
		/// </summary>
		/// <returns></returns>
		private string GetDbType()
		{
			string results;

			switch (propertyTypeName)
			{
				case "int":
					results = "Int32";
					break;
				case "DateTime":
					results = "Date";
					break;
				default:
					results = "AnsiString";
					break;
			}
			return results;
		}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/DbProperty.cs $
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
 * 3     3/11/07 7:37p John.gwynn
 * First cut for DbClassGenerator
 * 
 * 2     3/09/07 6:21p John.gwynn
 * first cut of the DbClassGen for DbBaseClass generation (Class
 * definition)
 * 
 * 1     3/09/07 3:47p John.gwynn
 * incomplete interim check-in to move to new machine
 */
#endregion
