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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IWebNavigation.cs 2     9/13/11 2:12p Sharmad $ */
#endregion
namespace FnsComposite.CallObjects
{
	/// <summary>
	/// specific interface for Web Navigation record
	/// </summary>
	public interface IWebNavigation
	{
		/// <summary>
		/// Gets or sets the name of the page.
		/// </summary>
		/// <value>The name of the page.</value>
		string PageName { get; set; }
		/// <summary>
		/// Gets or sets the time stamp.
		/// </summary>
		/// <value>The time stamp.</value>
		string TimeStamp { get; set; }

        string TimeStampBegin { get; set; }
		/// <summary>
		/// Gets or sets the call id.
		/// </summary>
		/// <value>The call id.</value>
		string CallId { get; set; }

	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/IWebNavigation.cs $
 * 
 * 2     9/13/11 2:12p Sharmad
 * dsha-0025
 * 
 * 1     2/12/08 4:45p John.gwynn
 * added WebNavigation (support for eSurance) 
 */
#endregion
