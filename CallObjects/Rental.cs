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
/* $Header: /SourceCode/Components/Fns2005/FNSComposite/CallObjects/Rental.cs 2     3/01/11 4:03p Deepika.sharma $ */
#endregion

using System.Runtime.InteropServices;
using System.Xml;
using FnsComposite.CallObjects;

namespace FnsComposite
{
    /// <summary>
    /// CallObject eSurance STAFF implementation
    /// </summary>
    [ComVisible(false)]
    public class Rental : CallObjectBase, IRental
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Estar"/> class.
        /// </summary>
        public Rental()
            : base("RENTAL")
        { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Estar"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public Rental(XmlNode node)
            : base(node)
        { }

        #region IRental Members

        /// <summary>
        /// Gets or sets the name of the shop.
        /// </summary>
        /// <value>The name of the shop.</value>
        public string EracBranchName
        {
            get { return GetValue("ERAC_BRANCH_NAME"); }
            set { SetValue("ERAC_BRANCH_NAME", value); }
        }
        public string EracBranchAddressLine1
        {
            get { return GetValue("ERAC_BRANCH_ADDRESS_LINE1"); }
            set { SetValue("ERAC_BRANCH_ADDRESS_LINE1", value); }
        }
        public string EracBranchAddressLine2
        {
            get { return GetValue("ERAC_BRANCH_ADDRESS_LINE2"); }
            set { SetValue("ERAC_BRANCH_ADDRESS_LINE2", value); }
        }
        public string EracBranchAddressCity
        {
            get { return GetValue("ERAC_BRANCH_ADDRESS_CITY"); }
            set { SetValue("ERAC_BRANCH_ADDRESS_CITY", value); }
        }
        public string EracBranchAddressState
        {
            get { return GetValue("ERAC_BRANCH_ADDRESS_STATE"); }
            set { SetValue("ERAC_BRANCH_ADDRESS_STATE", value); }
        }
        public string EracBranchAddressZip
        {
            get { return GetValue("ERAC_BRANCH_ADDRESS_ZIP"); }
            set { SetValue("ERAC_BRANCH_ADDRESS_ZIP", value); }
        }
        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>The address.</value>
        //public new IAddress EracBranchAddress
        //{
        //    get { return base.Address; }
        //}

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone
        {
            get { return GetValue("ERAC_BRANCH_PHONE"); }
            set { SetValue("ERAC_BRANCH_PHONE", value); }
        }
        public string Status
        {
            get { return GetValue("STATUS"); }
            set { SetValue("STATUS", value); }
        }

        

        
        #endregion
    }
}
#region Log
/*
 * 
 */
#endregion