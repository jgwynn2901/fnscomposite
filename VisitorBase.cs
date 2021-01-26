/**************************************************************************
* First Notice Systems
* 529 Main Street
* Boston, MA 02129
* (617) 886 2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 1993-2006 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/VisitorBase.cs 4     2/03/10 6:12p Gwynnj $ */

using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace FnsComposite
{
  public interface IVisitor
  {
    /// <summary>
    /// Visits the specified element.  
    /// </summary>
    void Visit(CompositeBase element);
  }

  /// <summary>
	/// Summary description for Vsitor.
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public abstract class VisitorBase : IVisitor
  {
	    /// <summary>
		/// Visits the specified element.  
		/// </summary>
		public virtual void Visit(CompositeBase element)
	    {
            // Call this to propagate the tree
            if (!(element is Composite)) return;
            foreach (CompositeBase c in (Composite)element)
                c.Accept(this);
	    }

        /// <summary>
        /// Normalizes the name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static string NormalizeName(string name)
        {
            var results = name;
            if (results.StartsWith("CALL:"))
                results = results.Remove(0, 5);
            var subscript = results.IndexOf("[", StringComparison.Ordinal);
            while (subscript > 0)
            {
                var end = results.IndexOf("]", StringComparison.Ordinal);
                var sub = results.Substring(subscript, (end - subscript) + 1);
                results = results.Replace(sub, "");
                subscript = results.IndexOf("[", StringComparison.Ordinal);
            }
            return results;
        }

	}
	/// <summary>
	/// XmlDocumentVisitor populates XmlDocument with Composite contents
	/// </summary>
	public class XmlDocumentVisitor : VisitorBase
	{
	    readonly XmlDocument _document;
		XmlNode _currentNode;

		/// <summary>
		/// Initializes a new instance of the <see cref="XmlDocumentVisitor"/> class.
		/// </summary>
		/// <param name="document">The o doc.</param>
		public XmlDocumentVisitor(XmlDocument document)
		{
			_document = document;
			_currentNode = _document.DocumentElement;
		}
		/// <summary>
		/// populate the Document
		/// </summary>
		/// <param name="element">The element.</param>
		public override void Visit (CompositeBase element)
		{
			bool isRoot = false;
			if(null==_currentNode)
			{
				var rootDescription = new StringBuilder();

				rootDescription.Append("<?xml version='1.0'?>");
				rootDescription.Append( "<");
				rootDescription.Append(element.Name);
				rootDescription.Append("/>");

				_document.LoadXml(rootDescription.ToString());
				_currentNode = _document.DocumentElement;
				isRoot = true;
			}
			if(element.IsLeaf)
			{
			    if (_currentNode != null)
			        _currentNode.AppendChild(_document.CreateNode(XmlNodeType.Element, element.Name, element.Value));
			}
			else
			{
				XmlNode oNode;

				if(!isRoot)
				{
					oNode = _document.CreateNode(XmlNodeType.Element, element.Name, element.Value);
					_currentNode.AppendChild(oNode);
				}
				else
				{
					oNode = _currentNode;
				}
				foreach (CompositeBase c in (Composite)element) 
				{
					_currentNode = oNode;
					c.Accept(this);
				}
			}
		}
	}
}
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/VisitorBase.cs $
 * 
 * 4     2/03/10 6:12p Gwynnj
 * Added ConditionalVisitor for extraction of existing call attributes
 * based on a given pattern using regex (non-xml)
 * 
 * 3     4/20/07 5:17p John.gwynn
 * 
 * 2     4/17/07 3:41p John.gwynn
 * update current version synch to 1.1
 * 
 * 3     4/09/06 8:15p John.gwynn
 * FxCop and Resharper reformatting changes
 */