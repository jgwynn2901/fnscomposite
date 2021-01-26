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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Staff.cs 3     9/21/10 6:29p Gwynnj $ */
#endregion

using System.Xml;

namespace FnsComposite.CallObjects
{
	/// <summary>
	/// CallObject eSurance STAFF implementation
	/// </summary>
	public class Staff : CallObjectBase, IStaff
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Staff"/> class.
		/// </summary>
		public Staff(): base("STAFF")
		{}
		/// <summary>
		/// Initializes a new instance of the <see cref="Staff"/> class.
		/// </summary>
		/// <param name="node">The node.</param>
		public Staff(XmlNode node): base(node)
		{}

		#region IStaff Members

		/// <summary>
		/// Gets or sets the name first.
		/// </summary>
		/// <value>The name first.</value>
		public string NameFirst
		{
			get { return GetValue(EntityBase.FirstNameAttribute); }
			set { SetValue(EntityBase.FirstNameAttribute, value); }
		}

		/// <summary>
		/// Gets or sets the name last.
		/// </summary>
		/// <value>The name last.</value>
		public string NameLast
		{
			get { return GetValue(EntityBase.LastNameAttribute); }
			set { SetValue(EntityBase.LastNameAttribute, value); }
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
		/// Gets or sets the phone.
		/// </summary>
		/// <value>The phone.</value>
		public string Phone
		{
			get { return GetValue("PHONE"); }
			set { SetValue("PHONE", value); }
		}

		/// <summary>
		/// Gets or sets the fax.
		/// </summary>
		/// <value>The fax.</value>
		public string Fax
		{
			get { return GetValue("FAX"); }
			set { SetValue("FAX", value); }
		}

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		public string Type
		{
			get { return GetValue("TYPE"); }
			set { SetValue("TYPE", value); }
		}

		/// <summary>
		/// Gets or sets the appointment date.
		/// </summary>
		/// <value>The appointment date.</value>
		public string AppointmentDate
		{
			get { return GetValue("APPOINTMENT_DATE"); }
			set { SetValue("APPOINTMENT_DATE", value); }
		}
		/// <summary>
		/// Gets or sets the appraiser code.
		/// </summary>
		/// <value>The appraiser code.</value>
		public string AppraiserCode
		{
			get { return GetValue("ESTAR_APPRAISER_CODE"); }
			set { SetValue("ESTAR_APPRAISER_CODE", value); }
		}
		#endregion
		
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/Staff.cs $
 * 
 * 3     9/21/10 6:29p Gwynnj
 * Created EntityBase to factor the IPerson interface
 * 
 * 2     11/07/08 1:09p Deepika.sharma
 * A-JUC2
 * 
 * 1     5/03/08 7:55p John.gwynn
 * added Estar, IndependentAppraiser and Staf for phase III
 */
#endregion