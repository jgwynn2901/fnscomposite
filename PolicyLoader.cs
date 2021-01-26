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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/PolicyLoader.cs 6     5/04/09 3:55p John.gwynn $ */
#endregion

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;

namespace FnsComposite
{
	/// <summary>
	/// PolicyLoader composite provides corollary to the UIF football.
	/// </summary>
	[ComVisible(false)]
	public class PolicyLoader : Composite
	{
		/// <summary>
		/// offsets for each attribute
		/// </summary>
		private enum eParmList 
		{
			CreateTime = 0,
			Action,
			ClientCode,
			Mode,
			Status,
			Sequence,
			FileName,
			FileTranLogId
		};
		/// <summary>
		/// holds the proper attribute names
		/// </summary>
		private static string[] _parameterNames = new string[] 
						{
						"CREATE_TIME",
						"ACTION",
						"CLIENT_CODE",
						"MODE",
						"STATUS",
						"SEQUENCE",
						"FILENAME",
						"FILE_TRAN_LOG_ID"
						};
		/// <summary>
		/// empty Xml for default constructor
		/// </summary>
		private const string defaultNode = "<POLICY_LOAD type=\"SUBSCRIPTION\"><ACTION>SUBSCRIBE</ACTION><MODE default=\"1\">NEW</MODE><STATUS default=\"1\">UNPROCESSED</STATUS></POLICY_LOAD>";
		/// <summary>
		/// Initializes a new instance of the <see cref="PolicyLoader"/> class.
		/// </summary>
		public PolicyLoader() : this (defaultNode)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="PolicyLoader"/> class.
		/// </summary>
		public PolicyLoader(string xml) : base ("POLICY_LOAD")
		{
			try
			{
				XmlDocument document = new XmlDocument();
				document.LoadXml(xml);

				// BUGBUG: add check for CALL node
				ReloadFromXML(document.DocumentElement);
			}
			catch(Exception ex)
			{
				//m_oErrLog.log("LoadFromXML(): " + ex.Message, 3, m_strServiceName);
				//Re-throw outside
				//throw new Exception(, ex);
				Trace.WriteLine("PolicyLoader() constructor: " + ex.Message);
			}
		}
		#region CreateTime
		/// <summary>
		/// Gets the creat time.
		/// </summary>
		/// <value>The creat time.</value>
		public string CreatTime
		{
			get
			{
				return GetValue(_parameterNames[(int)eParmList.CreateTime]);
			}
		}
		#endregion
		#region Action
		/// <summary>
		/// Gets or sets the action.
		/// </summary>
		/// <value>The action.</value>
		public string Action
		{
			get
			{
				return GetValue(_parameterNames[(int)eParmList.Action]);
			}
			set
			{
				SetValue(_parameterNames[(int)eParmList.Action], value);
			}
		}
		#endregion
		#region ClientCode
		/// <summary>
		/// Gets or sets the client code.
		/// </summary>
		/// <value>The client code.</value>
		public string ClientCode
		{
			get
			{
				return GetValue(_parameterNames[(int)eParmList.ClientCode]);
			}
			set
			{
				SetValue(_parameterNames[(int)eParmList.ClientCode], value);
			}
		}
		#endregion
		#region Mode
		/// <summary>
		/// Gets or sets the mode.
		/// </summary>
		/// <value>The mode.</value>
		public string Mode
		{
			get
			{
				return GetValue(_parameterNames[(int)eParmList.Mode]);
			}
			set
			{
				SetValue(_parameterNames[(int)eParmList.Mode], value);
			}
		}
		#endregion
		#region Status
		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public string Status
		{
			get
			{
				return GetValue(_parameterNames[(int)eParmList.Status]);
			}
			set
			{
				SetValue(_parameterNames[(int)eParmList.Status], value);
			}
		}
		#endregion
		#region Sequence
		/// <summary>
		/// Gets or sets the sequence.
		/// </summary>
		/// <value>The sequence.</value>
		public string Sequence
		{
			get
			{
				return GetValue(_parameterNames[(int)eParmList.Sequence]);
			}
			set
			{
				SetValue(_parameterNames[(int)eParmList.Sequence], value);
			}
		}
		#endregion
		#region FileName
		/// <summary>
		/// Gets or sets the name of the file.
		/// </summary>
		/// <value>The name of the file.</value>
		public string FileName
		{
			get
			{
				return GetValue(_parameterNames[(int)eParmList.FileName]);
			}
			set
			{
				SetValue(_parameterNames[(int)eParmList.FileName], value);
			}
		}
		#endregion
		#region FileTranLogId
		/// <summary>
		/// Gets or sets the file tran log id.
		/// </summary>
		/// <value>The file tran log id.</value>
		public string FileTranLogId
		{
			get
			{
				return GetValue(_parameterNames[(int)eParmList.FileTranLogId]);
			}
			set
			{
				SetValue(_parameterNames[(int)eParmList.FileTranLogId], value);
			}
		}
		#endregion
		/// <summary>
		/// Gets the messages.
		/// </summary>
		/// <returns></returns>
		public IEnumerable GetMessages()
		{
			if(null != this["MESSAGE_LIST"])
			{
				LogMessage log = this["MESSAGE_LIST"] as LogMessage;
				if(log != null)
				{
					return log;
				}
			}
			return null;
		}
		/// <summary>
		/// Adds the message.
		/// </summary>
		/// <param name="component">The component.</param>
		/// <param name="message">The message.</param>
		/// <returns></returns>
		public bool AddMessage (string component, string message)
		{
			LogMessage log = null;

			if(null != this["MESSAGE_LIST"])
			{
				log = this["MESSAGE_LIST"] as LogMessage;
			}
			if(log == null)
			{
				log = new LogMessage();
				Add(log);
			}
			log.AddMessage(component, message);
			return true;
		}

	}
}
#region History
/*
 * $History: PolicyLoader.cs $
 * 
 * *****************  Version 6  *****************
 * User: John.gwynn   Date: 5/04/09    Time: 3:55p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * *****************  Version 5  *****************
 * User: Jenny.cheung Date: 11/12/07   Time: 3:39p
 * Updated in $/SourceCode/Components/FNS2005/FnsComposite
 * updated
 * 
 * *****************  Version 4  *****************
 * User: John.gwynn   Date: 8/08/07    Time: 12:02p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * relocated segment classes
 * 
 * *****************  Version 3  *****************
 * User: John.gwynn   Date: 5/17/07    Time: 4:09p
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * PolicyLoader suport for default constructor
 * 
 * *****************  Version 2  *****************
 * User: John.gwynn   Date: 5/11/07    Time: 10:04a
 * Updated in $/SourceCode/Components/VS.NET/FNSComposite
 * 
 * *****************  Version 1  *****************
 * User: John.gwynn   Date: 12/08/06   Time: 3:24p
 * Created in $/SourceCode/Components/VS.NET/FNSComposite
 * Added PolicyLoader MSMQ "football" class from UIF and Messaging.  This
 * will help intergrate the workflow functionality across different tech
 * platforms.
 */
#endregion
