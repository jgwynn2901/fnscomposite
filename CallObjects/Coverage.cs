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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Coverage.cs 2     3/18/11 11:10a Sharmad $ */
#endregion

using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// encapsulates the standard vehicle coverage attributes
	/// </summary>
	public class Coverage : CallObjectBase, ICoverage
	{
		private const string _nodeTypeName = "COVERAGE";
		/// <summary>
		/// Initializes a new instance of the <see cref="Vehicle"/> class.
		/// </summary>
		public Coverage(): base(_nodeTypeName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vehicle"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Coverage(XmlNode node) : base (node)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vehicle"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="indexedName">Overrides for types with indexes i.e. VEHICLE[0]</param>
		public Coverage(XmlNode node, string indexedName) : base (node, indexedName)
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Vehicle"/> class.
		/// </summary>
		/// <param name="indexName">Name of the index.</param>
		public Coverage(string indexName)
			: base(_nodeTypeName + indexName)
		{}
		/// <summary>
		/// Gets or sets the type of the coverage.
		/// </summary>
		/// <value>The type of the coverage.</value>
		public string CoverageType
		{
			get { return GetValue("COVERAGE_TYPE"); }
			set { SetValue("COVERAGE_TYPE", value); }
		}

		/// <summary>
		/// Gets or sets the deductible1.
		/// </summary>
		/// <value>The deductible1.</value>
		public string Deductible1
		{
			get { return GetValue("DEDUCTIBLE1"); }
			set { SetValue("DEDUCTIBLE1", value); }
		}

		/// <summary>
		/// Gets or sets the deductible2.
		/// </summary>
		/// <value>The deductible2.</value>
		public string Deductible2
		{
			get { return GetValue("DEDUCTIBLE2"); }
			set { SetValue("DEDUCTIBLE2", value); }
		}

		/// <summary>
		/// Gets or sets the limit1.
		/// </summary>
		/// <value>The limit1.</value>
		public string Limit1
		{
			get { return GetValue("LIMIT1"); }
			set { SetValue("LIMIT1", value); }
		}

		/// <summary>
		/// Gets or sets the limit2.
		/// </summary>
		/// <value>The limit2.</value>
		public string Limit2
		{
			get { return GetValue("LIMIT2"); }
			set { SetValue("LIMIT2", value); }
		}

        public string ReceivedStartDt
        {
            get { return GetValue("RECEIVED_START_DT"); }
            set { SetValue("RECEIVED_START_DT", value); }
        }
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Coverage.cs $
 * 
 * 2     3/18/11 11:10a Sharmad
 * EFIG-0131
 * 
 * 1     2/08/08 3:10p John.gwynn
 * Added (CalObject) Coverage and fixed a bug loading Xml array elements
 * from Call Xml
 */
#endregion