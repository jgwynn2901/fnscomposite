#region Header
/**************************************************************************
* First Notice Systems
* 529 Main Street
* Boston, MA 02129
* (617) 886 2600
*
* Proprietary Source Code -- Distribution restricted
*
* Copyright (c) 1993-2006 by First Notice Systems
**************************************************************************/
/* $Header: /SourceCode/Components/VS.NET2005/FnsComposite/OverflowSet.cs 2     4/17/07 3:41p John.gwynn $ */
#endregion

using System;
using System.Data;
using System.Data.OracleClient;

namespace FnsComposite
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class OverflowSet
	{
		private OverflowSet()
		{
		}
		/// <summary>
		/// BUGBUG: the data access should be factored to DAL
		/// </summary>
		/// <param name="ahsId"></param>
		/// <param name="lobCd"></param>
		/// <returns></returns>
		static public  OverFlow BuildOverflowSet (string ahsId,string lobCd)
		{
			OverFlow result = null;
			OracleConnection sqlConn = null;
			OracleCommand sqlCommand = null;
			OracleDataReader dr = null;

			string connString = "Data Source=FNSPROD; user id=FNSOWNER; password=ctown_prod; Persist Security info=False;";
			string strSQL = "DBCLASSLIBRARY.GetOverflowSet";
			
			try
			{
				// create connection
				sqlConn = new OracleConnection(connString);
				
				sqlCommand = new OracleCommand(strSQL,sqlConn);
				sqlCommand.CommandType = CommandType.StoredProcedure;
					
				sqlCommand.Parameters.Add("p_accntHrcyStepId", OracleType.Int32);
				sqlCommand.Parameters.Add("p_LineOfBusiness", OracleType.Char);
				sqlCommand.Parameters.Add("results", OracleType.Cursor);

				sqlCommand.Parameters[0].Value = ahsId;
				sqlCommand.Parameters[1].Value = lobCd;
				sqlCommand.Parameters[2].Direction = ParameterDirection.Output;


				// open connection to the database
				sqlConn.Open();

				// execute SQL statement
				dr = sqlCommand.ExecuteReader();
				int iSequence = 0;
				// Always call Read before accessing data.
				while (dr.Read()) 
				{
					if (null == result) // do we have a root node?
					{
						result = new OverFlow("0");
						result.AHSID = ahsId;
						result.LOB_CD = lobCd;
					}
					++iSequence;
					OverFlow currentOverflow = new OverFlow(iSequence.ToString());

					currentOverflow.AHSID = ahsId;
					currentOverflow.LOB_CD = lobCd;

					currentOverflow.Sequence = dr.GetInt32(0);
					currentOverflow.AttributeName = dr.GetString(1);
					result.AddAttributeDescription(dr.GetString(1));


					if(!dr.IsDBNull(2))
					{
						currentOverflow.Caption = dr.GetString(2);
					}
					else
					{
						currentOverflow.Caption = String.Empty;
					}
					if(!dr.IsDBNull(3))
					{
						currentOverflow.Mapping = dr.GetString(3);
					}
					else
					{
						currentOverflow.Mapping = String.Empty;
					}
					if(!dr.IsDBNull(4))
					{
						currentOverflow.CaptionLength = dr.GetInt32(4);
					}
					else
					{
						currentOverflow.CaptionLength = 0;
					}
					currentOverflow.ShowWhenEmpty = (dr.GetString(5) == "Y");

					result.Add(currentOverflow);
				}
			}
			catch (Exception E)
			{
				Console.WriteLine("ERROR: RunSQLReturnDataReader {0}",
					E.ToString());
				// rethow error
				//throw E;
			}
			finally
			{
				// clean up
				sqlCommand.Dispose();
				dr.Close();
				sqlConn.Close();
			}
			result.ResetDepth();

			return result;
		}
	}
}
#region Log
/*
 * $Log: /SourceCode/Components/VS.NET2005/FnsComposite/OverflowSet.cs $
 * 
 * 2     4/17/07 3:41p John.gwynn
 * update current version synch to 1.1
 * 
 * 7     6/04/06 6:43p John.gwynn
 * use stored proc for overflow set
 * 
 * 6     6/03/06 2:37p John.gwynn
 * added header and log/history regions
 * 
 * 5     4/20/06 11:54a John.gwynn
 * CLI Compliance modifications
 * 
 * 4     4/09/06 8:14p John.gwynn
 * FxCop and Resharper reformatting changes
 * 
 * 3     1/15/06 8:09p John.gwynn
 * finalized overflow attribute structure
 * 
 * 2     1/07/06 7:33p John.gwynn
 * added overflow iterator (sorted by default)
 */
#endregion
