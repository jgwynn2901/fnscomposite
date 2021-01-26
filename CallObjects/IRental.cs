using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FnsComposite.Interfaces;

namespace FnsComposite.CallObjects
{
    public interface IRental: IComposite
    {
        string EracBranchName { get; set; }
        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>The address.</value>
        //IAddress EracBranchAddress { get; }
        string EracBranchAddressLine1 { get; set; }
        string EracBranchAddressLine2{ get; set; }
        string EracBranchAddressCity{ get; set; }
        string EracBranchAddressState{ get; set; }
        string EracBranchAddressZip { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        string Phone { get; set; }
        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>The fax.</value>
        /// 
        string Status { get; set; }
       	
    }
}
