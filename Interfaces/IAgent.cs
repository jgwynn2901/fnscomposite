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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/IAgent.cs 1     7/10/07 5:32p John.gwynn $ */
#endregion
namespace FnsComposite.Interfaces
{
	/// <summary>
	/// Summary description for IAgent.
	/// </summary>
	public interface IAgent
	{
		/// <summary>
		/// Gets the agent id.
		/// </summary>
		/// <value>The agent id.</value>
		string AgentId { get; }
		/// <summary>
		/// Gets the file tran log id.
		/// </summary>
		/// <value>The file tran log id.</value>
		string FileTranLogId { get; }
		/// <summary>
		/// Gets the branch id.
		/// </summary>
		/// <value>The branch id.</value>
		string BranchId { get; }
		/// <summary>
		/// Gets the agent branch num.
		/// </summary>
		/// <value>The agent branch num.</value>
		string AgentBranchNum { get; }
		/// <summary>
		/// Gets the agent number.
		/// </summary>
		/// <value>The agent number.</value>
		string AgentNumber { get; }
		/// <summary>
		/// Gets the status.
		/// </summary>
		/// <value>The status.</value>
		string Status { get; }
		/// <summary>
		/// Gets the type cd.
		/// </summary>
		/// <value>The type cd.</value>
		string TypeCd { get; }
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		string AgentName { get; }
		/// <summary>
		/// Gets the address.
		/// </summary>
		/// <value>The address.</value>
		string Address { get; }
		/// <summary>
		/// Gets the city.
		/// </summary>
		/// <value>The city.</value>
		string City { get; }
		/// <summary>
		/// Gets the state.
		/// </summary>
		/// <value>The state.</value>
		string State { get; }
		/// <summary>
		/// Gets the zip.
		/// </summary>
		/// <value>The zip.</value>
		string Zip { get; }
		/// <summary>
		/// Gets the phone.
		/// </summary>
		/// <value>The phone.</value>
		string Phone { get; }
		/// <summary>
		/// Gets the fax.
		/// </summary>
		/// <value>The fax.</value>
		string Fax { get; }
		/// <summary>
		/// Gets the fax cd.
		/// </summary>
		/// <value>The fax cd.</value>
		string FaxCd { get; }
		/// <summary>
		/// Gets the lat.
		/// </summary>
		/// <value>The lat.</value>
		string Lat { get; }
		/// <summary>
		/// Gets the lon.
		/// </summary>
		/// <value>The lon.</value>
		string Lon { get; }
		/// <summary>
		/// Gets the email address.
		/// </summary>
		/// <value>The email address.</value>
		string EmailAddress { get; }
		/// <summary>
		/// Gets the type of the contact.
		/// </summary>
		/// <value>The type of the contact.</value>
		string ContactType { get; }
		/// <summary>
		/// Gets the name first.
		/// </summary>
		/// <value>The name first.</value>
		string NameFirst { get; }
		/// <summary>
		/// Gets the name mid.
		/// </summary>
		/// <value>The name mid.</value>
		string NameMid { get; }
		/// <summary>
		/// Gets the name last.
		/// </summary>
		/// <value>The name last.</value>
		string NameLast { get; }
		/// <summary>
		/// Gets the phone ext.
		/// </summary>
		/// <value>The phone ext.</value>
		string PhoneExt { get; }
		/// <summary>
		/// Gets the pref ind.
		/// </summary>
		/// <value>The pref ind.</value>
		string PrefInd { get; }
		/// <summary>
		/// Gets the gat code.
		/// </summary>
		/// <value>The gat code.</value>
		string GatCode { get; }
		/// <summary>
		/// Gets the upload key.
		/// </summary>
		/// <value>The upload key.</value>
		string UploadKey { get; }
	}
}
#region History
/*
 * $History: IAgent.cs $
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 7/10/07    Time: 5:32p
 * Created in $/SourceCode/Components/FNS2005/FnsComposite/Interfaces
 * Added new Interfaces for OPM, ported 1.1 interfaces and segment
 * updates.  
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 7/05/07    Time: 10:33a
 * Created in $/SourceCode/Components/VS.NET/FNSComposite/Interfaces
 * Support for Agent policy loads IAgent 
 */
#endregion