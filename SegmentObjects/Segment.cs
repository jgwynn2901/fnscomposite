#region Header
/**************************************************************************
* First Notice Systems
* 529 Main Street
* Boston, MA 02129
* (617) 886 2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 2006 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/Segment.cs 17    3/02/10 5:28p Gwynnj $ */
#endregion

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace FnsComposite.SegmentObjects
{
	/// <summary>
	/// Summary description for Segment.  Base class for the InputProcessManager segments
	/// designed to support object graphs with multiples where the Composite only allows 
	/// one named instance at the child level, Segment will keep a seperate array of
	/// children nodes and use the composite leaf for attributes only
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public class Segment : Composite
	{
		/// <summary>
		/// Segment specific aggregation (N.B. to be replaced with generics)
		/// TODO:  protected field violates encapsulation JJG is a shoemaker!!!  -JJG ;)
		/// </summary>
		protected ArrayList SegmentList;
		/// <summary>
		/// Segment Child node name list
		/// </summary>
		protected string[] ColumnNames;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Segment"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		public Segment(string name) :base(name)
		{
			SegmentList = new ArrayList();
			ColumnNames = null;
			Validation += ValidationMethod;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Segment"/> class.
		/// </summary>
		/// <param name="source">The source.</param>
		public Segment(Segment source) :base (source)
		{
			SegmentList = new ArrayList();
			ColumnNames = null;

			foreach(Segment node in source)
				SegmentList.Add(node.Clone());

			Validation += ValidationMethod;
		}

		/// <summary>
		/// Copies the and presesrve.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <returns></returns>
		public Segment CopyAndPreserve(Segment source)
		{
			LoadFromXml(source.ToXml());
			return this;
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or
		/// resetting unmanaged resources.
		/// </summary>
		public override void Dispose()
		{
			if (SegmentList == null) return;
			SegmentList.Clear();
			SegmentList = null;
			base.Dispose();
		}
		/// <summary>
		/// Adds the specified child.
		/// </summary>
		/// <param name="child">The child.</param>
		/// <returns></returns>
		public bool Add(Segment child)
		{
			child.Parent = this;
			return SegmentList.Add(child) > 0;
		}

		/// <summary>
		/// Determines whether this instance has children.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if this instance has children; otherwise, <c>false</c>.
		/// </returns>
		public bool HasChildren ()
		{
			return SegmentList.Count > 0;
		}

		/// <summary>
		/// Raises the validate event.
		/// Override when you need to include args
		/// </summary>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected override void OnValidate(EventArgs e)
		{
			base.OnValidate(e);

			// propagate 
			foreach (Segment child in SegmentList)
				child.OnValidate(e);
		}
		/// <summary>
		/// Returns an enumerator that can iterate through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/>
		/// that can be used to iterate through the collection.
		/// </returns>
		public new IEnumerator GetEnumerator() 
		{ 
			return SegmentList.GetEnumerator();
		}
		/// <summary>
		/// SetValue
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public override void SetValue(string name, string value)
		{
			Add(name, value);
		}
		/// <summary>
		/// Sets the parent key.
		/// </summary>
		virtual public void SetParentKey (string key)
		{
			throw new NotImplementedException ("SetParentKey from base class is not supported");
		}
		/// <summary>
		/// Clears the parent key.
		/// </summary>
		virtual public void ClearParentKey()
		{
			throw new NotImplementedException("ClearParentKey from base class is not supported");
		}
		/// <summary>
		/// Clears the key.
		/// </summary>
		virtual public void ClearKey()
		{
			throw new NotImplementedException("ClearParentKey from base class is not supported");
		}
		/// <summary>
		/// Clears the keys.
		/// </summary>
		public void ClearKeys()
		{
			ClearParentKey();
			ClearKey();
		}
		/// <summary>
		/// Clears the children.
		/// </summary>
		public void ClearChildren()
		{
			foreach(Segment node in SegmentList)
			{
				node.ClearChildren();
			}
			SegmentList.Clear();
		}

		#region Validation

		/// <summary>
		/// Provide validation for the segment by overriding this method.
		/// </summary>
		protected virtual void ValidationMethod(object sender, EventArgs e)
		{ }

		/// <summary>
		/// Formats the phone field.
		/// </summary>
		/// <param name="phone">The phone.</param>
		/// <returns></returns>
		public static string  FormatPhoneField (string phone)
		{
			return StripNonNumericCharacters(phone);
		}

		/// <summary>
		/// Strips the non numeric characters.
		/// </summary>
		public static string StripNonNumericCharacters(string field)
		{
			var results = new StringBuilder(field.Length);

			foreach (var c in field)
				if (char.IsDigit(c))
					results.Append(c);

			return results.ToString();
		}

		/// <summary>
		/// Determines whether [is null or long] [the specified value].
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		/// 	<c>true</c> if [is null or long] [the specified value]; otherwise, <c>false</c>.
		/// </returns>
		protected bool IsNullOrLong(string value)
		{
			if(!string.IsNullOrEmpty(value))
			{
				long longValue;
				return long.TryParse(value, out longValue);
			}
			return true;
		}

		/// <summary>
		/// Trims and truncates field to specified size.
		/// </summary>
		/// <param name="field">The field.</param>
		/// <param name="size">The size.</param>
		/// <returns></returns>
		public static string TrimTruncate(string field, int size)
		{
			var results = field.Trim();
			return results.Length > size ? results.Substring(0, size) : results;
		}

		/// <summary>
		/// Trims non-printables -preserves tab CrLf only
		/// </summary>
		public static string TrimPlus (string input)
		{
			var results = new StringBuilder();
			var trimmedInput = input.Trim();
			foreach (var c in trimmedInput)
				if ((c >= 32 && c <= 126) || 
					c == '\t' || c == '\n' || c=='\r')
					results.Append(c);

			return results.ToString();


		}
		/// <summary>
		/// Determines whether [is null or date time] [the specified value].
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>
		/// 	<c>true</c> if [is null or date time] [the specified value]; otherwise, <c>false</c>.
		/// </returns>
		protected bool IsNullOrDateTime(string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				DateTime dateTimeValue;
				return DateTime.TryParse(value, out dateTimeValue);
			}
			return true;
		}


		/// <summary>
		/// Copies this instance (override this for ICloneable support of the superclasses.)
		/// </summary>
		/// <returns></returns>
		protected override CompositeBase Copy()
		{
			return new Segment(this);
		}
		#endregion

		#region IComparable<Composite> Members

        /// <summary>
        /// Compares the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
		protected override int Compare(CompositeBase node)
		{
			var source = node as Segment;
			var results = -1;
			if (source != null)
			{
				// if we have the same name
				results = base.Compare(source);
				if (results == 0)
				{
					// and this contents equals source
					foreach (CompositeLeaf n in GetEnumerator<CompositeLeaf>())
					{
						if ((results = n.Value.CompareTo(source.GetValue(n.Name))) != 0)
							return results;
					}
					//// and the source equals contents
					//foreach(CompositeLeaf s in source.GetEnumerator<CompositeLeaf>())
					//{
					//    if ((results = s.Value.CompareTo(GetValue(s.Name))) != 0)
					//        return results;
					//}
				}
			}
			return results;
		}

		#endregion

	}
}

#region History
/*
 * $History: Segment.cs $
 * 
 * *****************  Version 17  *****************
 * User: Gwynnj       Date: 3/02/10    Time: 5:28p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * cleared out build warnings
 * 
 * *****************  Version 16  *****************
 * User: John.gwynn   Date: 11/11/09   Time: 3:43p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * segment compare is deep, composite is just name
 * 
 * *****************  Version 15  *****************
 * User: John.gwynn   Date: 11/09/09   Time: 11:24a
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * missing comments added
 * 
 * *****************  Version 14  *****************
 * User: John.gwynn   Date: 10/29/09   Time: 1:11p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Moved ValidationMethod to base class as an override for adding
 * validation at the (sub)class definition.
 * 
 * *****************  Version 13  *****************
 * User: John.gwynn   Date: 10/27/09   Time: 6:57p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added AhsChildren as IEnumerable for linq support
 * 
 * *****************  Version 12  *****************
 * User: John.gwynn   Date: 10/20/09   Time: 4:34p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * fixed bug in TrimPlus
 * 
 * *****************  Version 11  *****************
 * User: John.gwynn   Date: 10/20/09   Time: 2:28p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added Segment.TrimPlus( string value) to strip non-printable special or
 * control characters from input 
 * 
 * *****************  Version 10  *****************
 * User: John.gwynn   Date: 10/19/09   Time: 7:15p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added HasChildren() for segment processing
 * 
 * *****************  Version 9  *****************
 * User: John.gwynn   Date: 10/13/09   Time: 4:32p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added Segment.CopyAndPreserve to do a non-destructive clone of values
 * from a source segment. (does not affect prior values when source column
 * is empty)
 * 
 * *****************  Version 8  *****************
 * User: John.gwynn   Date: 9/30/09    Time: 6:36p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Implemented IComparable for composites adding a virtual Compare method
 * for specialized equality and sorting .e.g. see the AhsSegment where two
 * segments are deemed equal if their upload keys are equal.
 * 
 * *****************  Version 7  *****************
 * User: John.gwynn   Date: 9/29/09    Time: 5:12p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added Validation Event support for Composite in general and Segment
 * classes.
 * 
 * *****************  Version 6  *****************
 * User: John.gwynn   Date: 9/28/09    Time: 7:30p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * added some rudimentary formatting 
 * 
 * *****************  Version 5  *****************
 * User: John.gwynn   Date: 9/28/09    Time: 1:14p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added support for ICloneable
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 9/26/09    Time: 12:46p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added IAccountHierarchyStep interface
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 5/04/09    Time: 6:56p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Refactored ICall interface
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 9/24/07    Time: 5:35p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * merged with 2003 changes
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 7/11/07    Time: 10:58a
 * Created in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 5/29/07    Time: 7:05p
 * Updated in $/SourceCode/Components/VS.NET2005/FnsComposite
 * new MessageObject set of classes for OPM with some refactoring and
 * gebneral enhancements
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 4/20/07    Time: 5:17p
 * Updated in $/SourceCode/Components/VS.NET2005/FnsComposite
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 4/17/07    Time: 3:41p
 * Updated in $/SourceCode/Components/VS.NET2005/FnsComposite
 * update current version synch to 1.1
 * 
 * *****************  Version 5  *****************
 * User: John.gwynn   Date: 2/21/07    Time: 2:44p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * Copy costructor is type safe
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 2/21/07    Time: 11:39a
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * added Operator == and comparison operators as well as Copy
 * constructors...
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 1/12/07    Time: 10:17a
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * functionality to support Employee extensions
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 11/16/06   Time: 5:20p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * Added NDoc comments and formatting
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 10/27/06   Time: 5:07p
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * segment base class (InputProcessManager)
 */
#endregion
