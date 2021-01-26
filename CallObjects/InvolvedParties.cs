#region Header
/**************************************************************************
* First Notice Systems
* (617) 886 2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 2012 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/InvolvedParties.cs 1     5/17/12 12:20p Gwynnj $ */
#endregion

using System.Collections.Generic;
using System.Xml;

namespace FnsComposite.CallObjects
{
    /// <summary>
    /// AAA Array transform class generated for Xml output document 
    /// </summary>
    public class InvolvedParties : CallObjectBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvolvedParties"/> class.
        /// </summary>
        public InvolvedParties()
            : base("InvolvedParties")
		{}

        /// <summary>
        /// Initializes a new instance of the <see cref="InvolvedParties"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public InvolvedParties(XmlNode node)
            : base(node)
		{}

        /// <summary>
        /// Gets the items.
        /// </summary>
        public List<InvolvedParty> Items
        {
            get
            {
                var parties = new List<InvolvedParty>();
                foreach (InvolvedParty v in GetEnumerator<InvolvedParty>())
                {
                    parties.Add(v);
                }
                return parties;
            }
        }
    }
}
#region Log
/*
* $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/InvolvedParties.cs $
 * 
 * 1     5/17/12 12:20p Gwynnj
*/
#endregion