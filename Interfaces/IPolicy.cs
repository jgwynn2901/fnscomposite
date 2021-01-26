#region Header
/**************************************************************************
 * First Notice Systems
 * 529 Main Street
 * Boston, MA 02129
 * (617) 886 2600
 *
 * Proprietary Source Code -- Distribution restricted
 *
 * Copyright (c) 2007 by First Notice Systems
 **************************************************************************/
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/IPolicy.cs 1     7/10/07 5:32p John.gwynn $ */
#endregion

namespace FnsComposite.Interfaces
{
	/// <summary>
	/// Summary description for IPolicy.
	/// </summary>
	public interface IPolicy
	{
		/// <summary>
		/// Gets the ahs id.
		/// </summary>
		/// <value>The ahs id.</value>
		string AhsId { get; }
		/// <summary>
		/// Gets the line of business.
		/// </summary>
		/// <value>The line of business.</value>
		string LineOfBusiness { get; }
		/// <summary>
		/// Gets the carrier id.
		/// </summary>
		/// <value>The carrier id.</value>
		string CarrierId { get; }
		/// <summary>
		/// Gets the agent id.
		/// </summary>
		/// <value>The agent id.</value>
		string AgentId { get; }
		/// <summary>
		/// Gets the company code.
		/// </summary>
		/// <value>The company code.</value>
		string CompanyCode { get; }
		/// <summary>
		/// Gets the policy number.
		/// </summary>
		/// <value>The policy number.</value>
		string PolicyNumber { get; }
		/// <summary>
		/// Gets the effective date.
		/// </summary>
		/// <value>The effective date.</value>
		string EffectiveDate { get; }
		/// <summary>
		/// Gets the expiration date.
		/// </summary>
		/// <value>The expiration date.</value>
		string ExpirationDate { get; }
		/// <summary>
		/// Gets the description.
		/// </summary>
		/// <value>The description.</value>
		string Description { get; }
		/// <summary>
		/// Gets the coverage codes.
		/// </summary>
		/// <value>The coverage codes.</value>
		string CoverageCodes { get; }
		/// <summary>
		/// Gets the type of the policy.
		/// </summary>
		/// <value>The type of the policy.</value>
		string PolicyType { get; }
		/// <summary>
		/// Gets the division code.
		/// </summary>
		/// <value>The division code.</value>
		string DivisionCode { get; }
		/// <summary>
		/// Gets the file tran log id.
		/// </summary>
		/// <value>The file tran log id.</value>
		string FileTranLogId { get; }
		/// <summary>
		/// Gets the upload key.
		/// </summary>
		/// <value>The upload key.</value>
		string UploadKey { get; }

        //string OriginalEffectiveDate { get; }

        //string CancellationDate { get; }
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/IPolicy.cs $
 * 
 * 1     7/10/07 5:32p John.gwynn
 * Added new Interfaces for OPM, ported 1.1 interfaces and segment
 * updates.  
 * 
 * 1     6/21/07 5:47p John.gwynn
 * Added IEmployee, IAccountHierarchyStep and IPolicy for default segment
 * copy costructors for loads
 */
#endregion