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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/IEntityObject.cs 1     7/10/07 5:32p John.gwynn $ */
#endregion
namespace DbClassLibrary.Interfaces
{
	/// <summary>
	/// Defines the public contract for Entity Object persistence
	/// N.B. starting very basic adding only what is required.
	/// </summary>
	public interface IEntityObject
	{
		/// <summary>
		/// Gets the last error.
		/// </summary>
		/// <value>The last error.</value>
		string LastError { get;}

		/// <summary>
		/// Commits this instance.
		/// </summary>
		/// <returns></returns>
		bool Commit();
		/// <summary>
		/// Rollbacks this instance.
		/// </summary>
		/// <returns></returns>
		bool Rollback();
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/Interfaces/IEntityObject.cs $
 * 
 * 1     7/10/07 5:32p John.gwynn
 * Added new Interfaces for OPM, ported 1.1 interfaces and segment
 * updates.  
 */
#endregion