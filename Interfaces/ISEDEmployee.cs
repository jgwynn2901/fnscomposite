#region Header
/**************************************************************************
 * Source File -- ISEDEmployee.cs
 * 
 * NAME: FnsComposite.Interfaces.ISEDEmployee.cs
 * AUTHOR: Pintoa

 * Innovation First Notice
 * 140 Kendrick Street 
 * Building A, Suite 300 
 * Needham, MA 02494
 * (617) 886-2600
 *
 * Proprietary Source Code -- Distribution restricted
 *
 * Copyright (c) 2012 by First Notice Systems
 **************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/ISEDEmployee.cs 1     4/26/12 6:48p Pintoa $ */
#endregion

namespace FnsComposite.Interfaces
{
    // ReSharper disable InconsistentNaming
    public interface ISEDEmployee : IEmployee
    // ReSharper restore InconsistentNaming
    {
        /// <summary>
        /// Gets the Employee status.
        /// </summary>
        /// <value>The Employee status.</value>
        string RecordActive { get; }
    }
}

#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/ISEDEmployee.cs $ 
 * 
 * 1     4/26/12 6:48p Pintoa
 * Sedgwick Employee Parser implementation.
 * 
*/
#endregion
