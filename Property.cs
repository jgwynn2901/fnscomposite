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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Property.cs 4     9/28/09 1:14p John.gwynn $ */
#endregion

using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace FnsComposite
{
	/// <summary>
	/// Property class defines class properties used for code generation
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public class Property : CompositeLeaf
	{
		private const string _propertyCompositeType = "Property";
		/// <summary>
		/// defaults to private
		/// </summary>
		private const string _propertyScope = "private";
		/// <summary>
		/// captures the property type
		/// </summary>
		protected string propertyTypeName;
		/// <summary>
		/// used as parm name for e.g.
		/// </summary>
		protected string propertyAltName;

		/// <summary>
		/// is Read Only?
		/// </summary>
		protected bool isReadOnly;
		/// <summary>
		/// Initializes a new instance of the <see cref="Property"/> class.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		public Property(string propertyName): this  (propertyName,string.Empty, "string")
		{
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Property"/> class.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="propertyValue">The property value.</param>
		/// <param name="propertyType">Type of the property.</param>
		public Property(string propertyName, string propertyValue, string propertyType ) : base (propertyName, propertyValue, _propertyCompositeType)
		{
			propertyTypeName = propertyType;
			isReadOnly = false;
			propertyAltName = string.Empty;

			if(propertyValue.Length > 0)
			{
				// the value always stores property state
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(propertyValue);
				Composite _base = new Composite(doc);
				if(_base["propertyTypeName"].Value != null && _base["propertyTypeName"].Value.Length > 0)
				{
					propertyTypeName = _base["propertyTypeName"].Value;
				}
				if(_base["isReadOnly"].Value != null && 
				   string.Compare(_base["isReadOnly"].Value,"True",true)==0)
				{
					isReadOnly = true;
				}
				if(_base["propertyAltName"].Value != null && _base["propertyAltName"].Value.Length > 0)
				{
					propertyAltName = _base["propertyAltName"].Value;
				}
			}
		}
		/// <summary>
		/// Gets or sets a value indicating whether [read only].
		/// </summary>
		/// <value><c>true</c> if [read only]; otherwise, <c>false</c>.</value>
		public bool ReadOnly
		{
			get{ return isReadOnly;}
			set{ isReadOnly = value;}
		}
		/// <summary>
		/// Gets or sets the name of the altName.
		/// </summary>
		/// <value>The alternate name</value>
		public string AltName
		{
			get{ return propertyAltName; }
			set{ propertyAltName = value; }
		}
		/// <summary>
		/// Gets or sets the name of the property type.
		/// </summary>
		/// <value>The name of the property type.</value>
		public string TypeName
		{
			get{ return propertyTypeName; }
			set{ propertyTypeName = value; }
		}
		/// <summary>
		/// toString
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			StringBuilder results = new StringBuilder();
			results.Append(IndentTabs());
			//results.AppendFormat("#region {0} {1} {2}", _propertyScope, propertyTypeName, m_name);
			results.AppendFormat("{0} {1} {2};",  _propertyScope, propertyTypeName, m_name);
			//results.Append("#endregion");

			return results.ToString();
		}
		/// <summary>
		/// convert to string with xml tags
		/// </summary>
		/// <returns></returns>
		public override string ToXml()
		{
			Composite _base = new Composite("PropertyAttributes");
			_base.Add("propertyTypeName", propertyTypeName);
			_base.Add("isReadOnly", isReadOnly.ToString());
			_base.Add("propertyAltName", propertyAltName);
			NodeValue = _base.ToXml();
			return base.ToXml();
		}
		/// <summary>
		/// Bodies this instance.
		/// </summary>
		/// <returns></returns>
		public virtual string Body()
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
			results.AppendFormat("\tget{{ return {0}; }}\r\n",m_name);
			if(!isReadOnly)
			{
				results.Append(IndentTabs());
				results.AppendFormat("\tset{{ {0} = value; }}\r\n",m_name);			
			}
			results.Append(IndentTabs());
			results.Append("}\r\n");

			results.Append(IndentTabs());
			results.Append("#endregion\r\n");
			return results.ToString();
		}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/Property.cs $
 * 
 * 4     9/28/09 1:14p John.gwynn
 * Added support for ICloneable
 * 
 * 3     10/01/07 11:23a John.gwynn
 * added symmetric encode decode and fix to Property
 * 
 * 2     4/20/07 5:17p John.gwynn
 * 
 * 1     4/17/07 3:40p John.gwynn
 * update to current version from 1.1
 * 
 * 4     3/11/07 7:37p John.gwynn
 * First cut for DbClassGenerator
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
