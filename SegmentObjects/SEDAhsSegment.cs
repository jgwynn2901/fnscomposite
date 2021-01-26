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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/SegmentObjects/SEDAhsSegment.cs 3     10/31/09 10:11a Ashley.pinto $ */
#endregion

using System;
using System.Collections;
using System.Runtime.InteropServices;
using FnsComposite.SegmentObjects;

namespace FnsComposite
{
	/// <summary>
	/// AhsSegment encapsulated data assigned to ACCOUNT_HIERARCHY_STEP table 
	/// for InputProcessManager segment loader processing.  AhsSegment
	/// will usually be associated to (child of)a AhsSegment in cases where
	/// we are building a tree hence the use of Composite design pattern
	/// </summary>
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
    public class SEDAhsSegment : AhsSegment
	{
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="AhsSegment"/> class.
		/// </summary>
		public SEDAhsSegment()
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="AhsSegment"/> class.
		/// </summary>
		/// <param name="source">The source.</param>
		public SEDAhsSegment(SEDAhsSegment source) :base(source)
		{
		}
		#endregion


        #region public string DisseminationFlag
        /// <summary>
        /// Gets the dissemination flag.
        /// </summary>
        /// <value>The dissemination flag.</value>
        public string DisseminationFlag
		{
			get
			{
				return GetValue("DISSEMINATIONFLAG");				
			}

            set
            {
                SetValue("DISSEMINATIONFLAG", value);
            }
			
		}
		#endregion

	    #region Overrides of Composite

	    /// <summary>
	    /// Validates this instance.
	    /// </summary>
	    public override bool Validate()
	    {
	        return true;
	    }

	    #endregion
	}
}

#region History
/*
 * $History: SEDAhsSegment.cs $
 * 
 * *****************  Version 3  *****************
 * User: Ashley.pinto Date: 10/31/09   Time: 10:11a
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Sedgwick CCE Implementation Updates.
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 9/26/09    Time: 12:46p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added IAccountHierarchyStep interface
 * 
 * *****************  Version 1  *****************
 * User: Jenny.cheung Date: 8/12/08    Time: 1:38p
 * Created in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * 
 * *****************  Version 7  *****************
 * User: Jenny.cheung Date: 8/11/08    Time: 12:59p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Added Dissemination Flag due to Sedgwick' s Dissemination SOW
 * 
 * *****************  Version 6  *****************
 * User: Jenny.cheung Date: 11/06/07   Time: 5:19p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * 
 * *****************  Version 5  *****************
 * User: John.gwynn   Date: 10/21/07   Time: 8:17a
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * Modified segment namespace started work on CallObject types
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 9/24/07    Time: 5:34p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite/SegmentObjects
 * merged with 2003 changes
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
 * User: John.gwynn   Date: 3/14/07    Time: 5:13p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * added SpecificDestinationFlag
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 2/27/07    Time: 3:24p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * Extended the AhsSegment class
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 2/21/07    Time: 4:16p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * added checks for null in operator ==
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 11/14/06   Time: 10:28a
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * Address3 had a typo that was fixed
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 10/27/06   Time: 5:06p
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * Segment class for the AHS table (InputProcessManager)
 */
#endregion
