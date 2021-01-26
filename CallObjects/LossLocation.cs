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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/LossLocation.cs 3     9/21/10 6:29p Gwynnj $ */
#endregion

using System;
using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// Implements CallObjects LossLocation node
	/// </summary>
	public class LossLocation : CallObjectBase, ILossLocation
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LossLocation"/> class.
		/// </summary>
		public LossLocation(): base("LOSS_LOCATION")
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="LossLocation"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public LossLocation(XmlNode node) : base (node)
		{}

		#region ILossLocation Members

		/// <summary>
		/// Gets or sets the information.
		/// </summary>
		/// <value>The information.</value>
		public string Information
		{
			get { return GetValue("INFORMATION"); }
			set { SetValue("INFORMATION", value); }
		}

		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		public new IAddress Address
		{
			get { return base.Address; }
		}

		/// <summary>
		/// Gets or sets the phone home.
		/// </summary>
		/// <value>The phone home.</value>
		public string PhoneHome
		{
			get { return GetValue(EntityBase.HomePhoneAttribute); }
			set { SetValue(EntityBase.HomePhoneAttribute, value); }
		}

		/// <summary>
		/// Gets or sets the phone work.
		/// </summary>
		/// <value>The phone work.</value>
		public string PhoneWork
		{
			get { return GetValue(EntityBase.WorkPhoneAttribute); }
			set { SetValue(EntityBase.WorkPhoneAttribute, value); }
		}

		#endregion
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/LossLocation.cs $
 * 
 * 3     9/21/10 6:29p Gwynnj
 * Created EntityBase to factor the IPerson interface
 * 
 * 2     1/16/08 6:39p John.gwynn
 * added CallObjectBase to override SetValue
 * 
 * 1     10/22/07 6:08p John.gwynn
 */
#endregion