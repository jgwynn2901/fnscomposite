#region Header
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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/OverFlow.cs 5     1/06/10 6:43p Gwynnj $ */
#endregion

using System;
using System.Collections;
using FnsComposite.CallObjects;

namespace FnsComposite
{
	/// <summary>
	/// set of OVERFLOW records to be consumed by the generators 
	/// </summary>
	public class OverFlow : Composite, IEnumerable
	{

		private Composite _attributeNames;
		/// <summary>
		/// IEnumerable implementation
		/// </summary>
		public struct OverFlowEnumerator : IEnumerator
		{
			//private Composite _root;
			private readonly SortedList	_sortList;
			int _currentIndex;

			/// <summary>
			/// constructor needs root
			/// </summary>
			/// <param name="node">The node.</param>
			public OverFlowEnumerator (IEnumerable node)
			{
				//_root = node;
				_currentIndex = -1;
				_sortList = new SortedList();
				var enumList = node.GetEnumerator();
				while(enumList.MoveNext())
				{
                    // ReSharper disable once PossibleNullReferenceException
                    if (((CompositeBase) enumList.Current).IsLeaf) continue;
                    var currentOver = (OverFlow)enumList.Current;
                    if (null == currentOver) continue;
                    var iStart = currentOver.Name.IndexOf("[", StringComparison.Ordinal);
                    var iEnd = currentOver.Name.IndexOf("]", StringComparison.Ordinal);
                    if (iStart <= -1 || iEnd <= -1) continue;
                    iStart++;
                    var strIndex = currentOver.Name.Substring(iStart,iEnd - iStart);
                    var indexKey = Convert.ToInt32(strIndex);
                    _sortList.Add( indexKey,currentOver );
                }
			}
			/// <summary>
			/// void IEnumerator.Reset()
			/// </summary>
			/// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
			public void Reset()
			{
				_currentIndex = -1;
			}
			/// <summary>
			/// object IEnumerator.Current { get { return Current; } }
			/// </summary>
			/// <value>The current.</value>
			public object Current 
			{ 
				get 
				{ 
					if(_currentIndex < _sortList.Count)
						return _sortList.GetByIndex(_currentIndex); 
					return null;
				} 
			}
			/// <summary>
			/// Advances the enumerator to the next element of the collection.
			/// </summary>
			/// <returns>
			/// 	<see langword="true"/> if the enumerator was successfully advanced to the next element;
			/// <see langword="false"/> if the enumerator has passed the end of the collection.
			/// </returns>
			/// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
			public bool MoveNext() 
			{ 
				if(++_currentIndex >= _sortList.Count)
					return false;
				return true;
			}
		}
		/// <summary>
		/// This enumerator is ordered by sequence
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/>
		/// that can be used to iterate through the collection.
		/// </returns>
		public new IEnumerator GetEnumerator() 
		{ 
			return new OverFlowEnumerator(this);
		}
		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="name"></param>
		public OverFlow(string name):base("OUTPUT_OVERFLOW"+"[" + name + "]")
		{
			AttributeName = string.Empty;
			Caption = string.Empty;
			CaptionLength = 0;
			LOB_CD = string.Empty;
			Mapping = string.Empty;
			Sequence = 0;
			_attributeNames = null;
		}
		/// <summary>
		/// Adds the attribute description.
		/// </summary>
		/// <param name="attributeName">Name of the attribute.</param>
		/// <returns>results</returns>
		public bool AddAttributeDescription(string attributeName)
		{
			var results = false;
			var value = attributeName;

			if (null == _attributeNames)
			{
				_attributeNames = new Composite("ATTRIBUTEm_nameS");
			}
			var  oCurrent = _attributeNames;
			var indexOfOpen = attributeName.IndexOf("[", StringComparison.Ordinal);
			if(indexOfOpen >-1 && attributeName.IndexOf("[&", StringComparison.Ordinal) == -1)
			{
				while(indexOfOpen >-1)
				{
					var name = ExtractFirstIndexedObjectName (value);
					value = value.Substring(value.IndexOf("]:", StringComparison.Ordinal)+2);

					// does this node already exist ?
					var oNode = (Composite)oCurrent[name];
					if(null==oNode)
					{
						oNode = new Composite(name);
						oCurrent.Add(oNode);
					}
					oCurrent = oNode;
					indexOfOpen = value.IndexOf("[", StringComparison.Ordinal);
				}
				var strObjectValue = ExtractObjectValue(attributeName,":");
				if(strObjectValue.Length > 0)
				{
					var oValNode = new Composite(strObjectValue);
					oCurrent.Add(oValNode);
				}
			}
			else
			{
				var strObjectName = ExtractObjectName(attributeName,":");
				var strObjectValue = ExtractObjectValue(attributeName,":");

				if (strObjectName.Length > 0)
				{
					var oObjNode = (Composite)oCurrent[strObjectName];
					if(null==oObjNode)
					{
						oObjNode = new Composite(strObjectName);
						results = oCurrent.Add(oObjNode);
					}
					if(strObjectValue.Length > 0 && strObjectValue != strObjectName)
					{
						var oValNode = new Composite(strObjectValue);
						results = oObjNode.Add(oValNode);
					}
				}
			}
			return results;
		}
		/// <summary>
		/// Gets the attribute descriptions.
		/// </summary>
		/// <returns></returns>
		public string GetAttributeDescriptions()
		{
			if(null == _attributeNames)
			{
				return string.Empty;
			}
			return _attributeNames.ToString();
		}
		/// <summary>
		/// property AHSID
		/// </summary>
		/// <value>The AHSID.</value>
// ReSharper disable InconsistentNaming
		public string AHSID 
// ReSharper restore InconsistentNaming
		{
			get 
			{
				return this["ACCNT_HRCY_STEP_ID"].Value;
			}
			set
			{
				 Add("ACCNT_HRCY_STEP_ID",value);
			}
		}
		/// <summary>
		/// property LOB_CD
		/// </summary>
		/// <value>The LOb_CD.</value>
// ReSharper disable InconsistentNaming
		public string LOB_CD 
// ReSharper restore InconsistentNaming
		{
			get 
			{
                return this[CallObject.LobCdAttributeName].Value;
			}
			set
			{
				Add(CallObject.LobCdAttributeName,value);
			}
		}
		/// <summary>
		/// Name of mapped attribute or group
		/// </summary>
		/// <value>The name of the attribute.</value>
		public string AttributeName 
		{
			get 
			{
				return this["ATTRIBUTEm_name"].Value;
			}
			set
			{
				Add("ATTRIBUTEm_name",value);
			}
		}
		/// <summary>
		/// Sequence is the defalt order
		/// </summary>
		/// <value>The sequence.</value>
		public int Sequence 
		{
			get 
			{
				var results = 0;
				if( this["SEQUENCE"].Value != string.Empty)
				{
					results = Convert.ToInt32(this["SEQUENCE"].Value);
				}
				return results;
			}
			set
			{
				Add("SEQUENCE",Convert.ToString(value));
			}
		}
		/// <summary>
		/// Show data field even when empty values
		/// </summary>
		/// <value><c>true</c> if [show when empty]; otherwise, <c>false</c>.</value>
		public bool ShowWhenEmpty 
		{
			get 
			{
				if(null==this["SHOW_WHEN_EMPTY_FLAG"])
				{
					return false;
				}
				return this["SHOW_WHEN_EMPTY_FLAG"].Value =="Y";
			}
			set { Add("SHOW_WHEN_EMPTY_FLAG", value ? "Y" : "N"); }
		}
		/// <summary>
		/// caption property
		/// </summary>
		/// <value>The caption.</value>
		public string Caption 
		{
			get 
			{
				return this["CAPTION"].Value;
			}
			set
			{
				Add("CAPTION",value);
			}
		}
		/// <summary>
		/// mapping for evaluator
		/// </summary>
		/// <value>The mapping.</value>
		public string Mapping 
		{
			get 
			{
				return this["MAPPING"].Value;
			}
			set
			{
				Add("MAPPING",value);
			}
		}
		/// <summary>
		/// This is actually the lead whitespace for non justified font
		/// </summary>
		/// <value>The length of the caption.</value>
		public int CaptionLength 
		{
			get 
			{
				var results = 0;
				if( this["CAPTION_LENGTH"].Value != string.Empty)
				{
					results = Convert.ToInt32(this["CAPTION_LENGTH"].Value);
				}
				return results;
			}
			set
			{
				Add("CAPTION_LENGTH",Convert.ToString(value));
			}
		}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/OverFlow.cs $
 * 
 * 5     1/06/10 6:43p Gwynnj
 * Added several constants for CallObject namespace
 * 
 * 4     10/01/07 12:06p John.gwynn
 * 
 * 3     4/20/07 5:17p John.gwynn
 * 
 * 2     4/17/07 3:41p John.gwynn
 * update current version synch to 1.1
 * 
 * 7     11/16/06 5:20p John.gwynn
 * Added NDoc comments and formatting
 * 
 * 6     6/03/06 2:37p John.gwynn
 * added header and log/history regions
 * 
 * 5     4/20/06 11:54a John.gwynn
 * CLI Compliance modifications
 * 
 * 4     4/09/06 8:14p John.gwynn
 * FxCop and Resharper reformatting changes
 * 
 * 3     1/15/06 8:09p John.gwynn
 * finalized overflow attribute structure
 * 
 * 2     1/07/06 7:33p John.gwynn
 * added overflow iterator (sorted by default)
 */
#endregion
 
