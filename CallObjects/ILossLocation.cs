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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ILossLocation.cs 1     10/21/07 3:42p John.gwynn $ */
#endregion

using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject Loss Location entity
	/// </summary>
	public interface ILossLocation : IComposite
	{
		/// <summary>
		/// Gets or sets the information.
		/// </summary>
		/// <value>The information.</value>
		string Information { get; set; }
		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		IAddress Address { get; }
		/// <summary>
		/// Gets or sets the phone home.
		/// </summary>
		/// <value>The phone home.</value>
		string PhoneHome { get; set; }
		/// <summary>
		/// Gets or sets the phone work.
		/// </summary>
		/// <value>The phone work.</value>
		string PhoneWork { get; set; }
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/ILossLocation.cs $
 * 
 * 1     10/21/07 3:42p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 */
#endregion