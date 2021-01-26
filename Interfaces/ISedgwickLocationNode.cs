#region Header
// ================================================================================
// Source File -- ISedgwickLocationNode.cs
// 
// NAME: FnsComposite.Interfaces.ISedgwickLocationNode.cs
// AUTHOR: Ashley A. Pinto
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// 
// © 2011 Innovation First Notice, http://www.firstnotice.com/
// 
// $Header: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/ISedgwickLocationNode.cs 1     4/24/11 11:21p Pintoa $ 
// 
// COMMENT:
// ================================================================================
#endregion

namespace FnsComposite.Interfaces
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for Sedgwick Location Node Db record. </summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public interface ISedgwickLocationNode
    {
		string SedgLocationNodeId { get; }
		string ClientId { get; }
		string LocationNode { get; }
		string Name { get; }
		string Address1 { get; }
		string Address2 { get; }
		string City { get; }
		string State { get; }
		string Zip { get; }
		string County { get; }
		string Country { get; }
		string Phone { get; }
		string AltPhone { get; }
		string CanAddClaims { get; }
		string ActiveStartDate { get; }
		string ActiveEndDate { get; }
		string ActiveStatus { get; }
		string UploadKey { get; }
		string FileTranLogId { get; }
        string IsInsert { get; }
        string IsUpdate { get; }
    }
}

#region Log
/*
 *
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/ISedgwickLocationNode.cs $ 
 * 
 * 1     4/24/11 11:21p Pintoa
 * Sedgwick SRS Location Node implementation.
 *
 */
#endregion
