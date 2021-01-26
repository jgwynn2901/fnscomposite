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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/Call.cs 1     6/27/09 10:39a John.gwynn $ */
#endregion

#if (ClaimCapture)
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using FnsComposite.CallObjects;

namespace FnsComposite
{
	/// <summary>
	/// 
	/// </summary>
	[ComVisible(false)]
	public interface ICall : FnsInterfaces.ICall, ICallObject
	{
		/// <summary>
		/// Gets or sets the last error.
		/// </summary>
		/// <value>The last error.</value>
		string LastError { get; set; }

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		new string GetValue(string name);

		/// <summary>
		/// Sets the value.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="val">The val.</param>
		new void SetValue(string name, string val);

	}

	/// <summary>
	/// Implementation of the ICall interface
	/// </summary>
	[ComVisible(true), Guid("3F7AA6F7-742E-43fc-B9BF-65FF6096ACF0")]
	public class Call : ICall
	{
		static readonly string[,] _replaceKnownNamesWithSpaces = new string[,]
									{
										{ "IMAGE FILE NAME", "IMAGE_FILENAME" },
										{ "PRINT FILENAME", "PRINT_FILENAME" },
										{ "INPUT SYSTEM", "INPUT_SYSTEM" },
										{ "", "" }//Always the last
									};

		private readonly CallObject _callObject;
		/// <summary>
		/// 
		/// </summary>
		public static string AbortStatus = "ABORTED";
		/// <summary>
		/// 
		/// </summary>
		public static string CompleteStatus = "COMPLETED";
		/// <summary>
		/// 
		/// </summary>
		public static string PendStatus = "PENDED";
		/// <summary>
		/// 
		/// </summary>
		public static string HoldStatus = "HOLD";
		/// <summary>
		/// 
		/// </summary>
		public static string InprocStatus = "INPROC";

		/// <summary>
		/// 
		/// </summary>
		public static string FILE_NAME_ATTR = "IMAGE_FILENAME";

		/// <summary>
		/// constructor
		/// </summary>
		public Call()
		{
			_callObject = new CallObject();
		}
		
		/// <summary>
		/// Gets the base.
		/// </summary>
		/// <value>The base (Composite object) CallObject.</value>
		public CallObject BaseCallObject
		{
			get
			{
				return _callObject;
			}
		}
		

		/// <summary>
		/// get data as XML
		/// </summary>
		/// <returns>Call Object as XML</returns>
		public string GetXML()
		{
			return _callObject.ToXml();
		}
		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public string GetValue(string name)
		{
			return GetValueImplementation(name);
		}

		private string GetValueImplementation (string name)
		{
			string value = String.Empty;
			string index = name.Replace(":", "/");
			if (null != _callObject[index])
			{
				value = _callObject[index].Value;
			}
			return value;
		}


		/// <summary>
		/// Set Value of a named attribute. Create or updates node graph
		/// </summary>
		/// <param name="name">Attribute name including structure i.e. CALL:CLAIM:INSURED:NAME</param>
		/// <param name="value">Value to set</param>
		public void SetValue(string name, string value)
		{
			SetValue(name, value, "string");
		}
		/// <summary>
		/// Sets the value.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="value">The value.</param>
		/// <param name="type">The type.</param>
		public void SetValue(string name, string value, string type)
		{
			// first add to ensure it will return
			value = value.TrimEnd();
			if (value.Length > 0)
			{
				_callObject.Add(name, value, type);
			}
			else
			{
				_callObject.Remove(name);
			}
		}

		/// <summary>
		/// Removes the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		public bool Remove(string name)
		{
			return _callObject.Remove(name);
		}
		

		/// <summary>
		/// Loads from XML.
		/// </summary>
		public void LoadFromXML(string xml)
		{
			_callObject.LoadFromXml(xml);
		}

		/// <summary>
		/// Clears this instance.
		/// </summary>
		public void Clear()
		{
			_callObject.ClearAll();
		}
		/// <summary>
		/// Gets the leaf node count.
		/// </summary>
		/// <returns></returns>
		public int GetLeafNodeCount()
		{
			return _callObject.GetLeafNodeCount();
		}
		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
		/// </returns>
		public override string ToString()
		{
			return _callObject.ToString();
		}
		/// <summary>
		/// Accepts the specified visitor.
		/// </summary>
		/// <param name="visitor">The visitor.</param>
		public void Accept(VisitorBase visitor)
		{
			_callObject.Accept(visitor);
		}
		/// <summary>
		/// Commits this instance.
		/// </summary>
		public void Commit()
		{
			_callObject.Commit();
		}
		/// <summary>
		/// Rollbacks this instance.
		/// </summary>
		public void Rollback()
		{
			_callObject.Rollback();
		}
		/// <summary>
		/// Gets a value indicating whether this instance has changed.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has changed; otherwise, <c>false</c>.
		/// </value>
		public bool HasChanged
		{
			get
			{
				return _callObject.HasChanged;
			}
		}
		/// <summary>
		/// Gets the XML tree.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <returns></returns>
		public string GetXmlTree(string node)
		{
			return _callObject.GetXmlTree(node);
		}

		

		/// <summary>
		/// PrepareValidXML_In
		/// </summary>
		/// <param name="callXml"></param>
		/// <returns></returns>
		private static string PrepareValidXML_In(string callXml)
		{
			StringBuilder results = new StringBuilder(callXml);

			for (int i = 0; _replaceKnownNamesWithSpaces[i, 0] != ""; i++)
				results.Replace(_replaceKnownNamesWithSpaces[i, 0], _replaceKnownNamesWithSpaces[i, 1]);

			return results.ToString();
		}

		#region ICallObject Members

		/// <summary>
		/// Adds the event.
		/// </summary>
		/// <param name="callEvent">The call event.</param>
		public void AddEvent(ICallflowEvent callEvent)
		{
			_callObject.AddEvent(callEvent);
		}

		/// <summary>
		/// Loads from XML vb.
		/// </summary>
		/// <param name="xml">The XML.</param>
		public void LoadFromXmlVb(string xml)
		{
			_callObject.LoadFromXml(xml);
		}

		///<summary>
		///
		///            Gets or sets the call id.
		///            
		///</summary>
		///
		///<value>
		///The call id.
		///</value>
		///
		public string CallId
		{
			get { return _callObject.CallId; }
			set { _callObject.CallId = value; }
		}

		///<summary>
		///
		///            Gets or sets the line of business.
		///            
		///</summary>
		///
		///<value>
		///The line of business.
		///</value>
		///
		public string LineOfBusiness
		{
			get { return _callObject.LineOfBusiness; }
			set { _callObject.LineOfBusiness = value; }
		}

		///<summary>
		///
		///            Gets or sets the call start date.
		///            
		///</summary>
		///
		///<value>
		///The call start date.
		///</value>
		///
		public string CallStartDate
		{
			get { return _callObject.CallStartDate; }
			set { _callObject.CallStartDate = value; }
		}

		///<summary>
		///
		///            Gets or sets the call start time.
		///            
		///</summary>
		///
		///<value>
		///The call start time.
		///</value>
		///
		public string CallStartTime
		{
			get { return _callObject.CallStartTime; }
			set { _callObject.CallStartTime = value; }
		}

		///<summary>
		///
		///            Gets or sets the call end date.
		///            
		///</summary>
		///
		///<value>
		///The call end date.
		///</value>
		///
		public string CallEndDate
		{
			get { return _callObject.CallEndDate; }
			set { _callObject.CallEndDate = value; }
		}

		///<summary>
		///
		///            Gets or sets the call edn time.
		///            
		///</summary>
		///
		///<value>
		///The call end time.
		///</value>
		///
		public string CallEndTime
		{
			get { return _callObject.CallEndTime; }
			set { _callObject.CallEndTime = value; }
		}

		///<summary>
		///
		///            Gets or sets the client id.
		///            
		///</summary>
		///
		///<value>
		///The client id.
		///</value>
		///
		public string ClientId
		{
			get { return _callObject.ClientId; }
			set { _callObject.ClientId = value; }
		}

		///<summary>
		///
		///            Gets or sets the carrier code.
		///            
		///</summary>
		///
		///<value>
		///The carrier code.
		///</value>
		///
		public string CarrierCode
		{
			get { return _callObject.CarrierCode; }
			set { _callObject.CarrierCode = value; }
		}

		///<summary>
		///
		///            Gets or sets the instance.
		///            
		///</summary>
		///
		///<value>
		///The instance.
		///</value>
		///
		public string Instance
		{
			get { return _callObject.Instance; }
			set { _callObject.Instance = value; }
		}
		/// <summary>
		/// Gets or sets the last error.
		/// </summary>
		/// <value>The last error.</value>
		public string LastError
		{
			get { return _callObject.LastError; }
			set { _callObject.LastError = value; }
		}

		///<summary>
		///
		///            Gets or sets the call status.
		///            
		///</summary>
		///
		///<value>
		///The call status.
		///</value>
		///
		public string CallStatus
		{
			get { return _callObject.CallStatus; }
			set { _callObject.CallStatus = value; }
		}

		///<summary>
		///
		///            Gets or sets the user id.
		///            
		///</summary>
		///
		///<value>
		///The user id.
		///</value>
		///
		public string UserId
		{
			get { return _callObject.UserId; }
			set { _callObject.UserId = value; }
		}

		///<summary>
		///
		///            Gets or sets the name of the user.
		///            
		///</summary>
		///
		///<value>
		///The name of the user.
		///</value>
		///
		public string UserName
		{
			get { return _callObject.UserName; }
			set { _callObject.UserName = value; }
		}

		///<summary>
		///
		///            Gets or sets the session key.
		///            
		///</summary>
		///
		///<value>
		///The session key.
		///</value>
		///
		public string SessionKey
		{
			get { return _callObject.SessionKey; }
			set { _callObject.SessionKey = value; }
		}

		///<summary>
		///
		///            Gets or sets the name of the server.
		///            
		///</summary>
		///
		///<value>
		///The name of the server.
		///</value>
		///
		public string ServerName
		{
			get { return _callObject.ServerName; }
			set { _callObject.ServerName = value; }
		}

		///<summary>
		///
		///            Gets or sets the internet user.
		///            
		///</summary>
		///
		///<value>
		///The internet user.
		///</value>
		///
		public string InternetUser
		{
			get { return _callObject.InternetUser; }
			set { _callObject.InternetUser = value; }
		}
		/// <summary>
		/// Gets or sets the ACCNT_HRCY_STEP_ID.
		/// </summary>
		/// <value>The ahs id.</value>
		public string AhsId
		{
			get { return _callObject.AhsId; }
			set { _callObject.AhsId = value; }
		}
		/// <summary>
		/// Gets or sets the policy id.
		/// </summary>
		/// <value>The policy id.</value>
		public string PolicyId
		{
			get { return _callObject.GetValue("POLICY_ID"); }
			set { _callObject.SetValue("POLICY_ID", value); }
		}
		///<summary>
		///
		///            Gets the claim.
		///            
		///</summary>
		///
		///<value>
		///The claim.
		///</value>
		///
		public IClaim Claim
		{
			get { return _callObject.Claim; }
		}

		/// <summary>
		/// Gets the contact.
		/// </summary>
		/// <value>The contact.</value>
		public IContact Contact
		{
			get { return _callObject.Contact; }
		}

		///<summary>
		///
		///            Gets the caller.
		///            
		///</summary>
		///
		///<value>
		///The caller.
		///</value>
		///
		public ICaller Caller
		{
			get { return _callObject.Caller; }
		}

		///<summary>
		///
		///            Gets the ASI node.
		///            
		///</summary>
		///
		///<value>
		///The asi.
		///</value>
		///
		public IAsi Asi
		{
			get { return _callObject.Asi; }
		}

		/// <summary>
		/// Gets the events.
		/// </summary>
		/// <value>The events.</value>
		public List<ICallflowEvent> Events
		{
			get { return _callObject.Events; }
		}

		#endregion

		///<summary>
		///
		///            serialize to XML.
		///            
		///</summary>
		///
		///<returns>
		///
		///</returns>
		///
		public string ToXml()
		{
			return _callObject.ToXml();
		}

		///<summary>
		///
		///            Reloads from XML.
		///            
		///</summary>
		///
		///<param name="node">The node.</param>
		public void ReloadFromXML(XmlNode node)
		{
			_callObject.ReloadFromXML(node);
		}

		#region IComposite Members

		///<summary>
		///
		///            serialize to HTML.
		///            
		///</summary>
		///
		///<returns>
		///
		///</returns>
		///
		public string ToHtml()
		{
			return _callObject.ToHtml();
		}

		///<summary>
		///
		///            Clears all children.
		///            
		///</summary>
		///
		public void ClearAll()
		{
			_callObject.ClearAll();
		}

		#endregion

		#region ICall Members

		/// <summary>
		/// Abandons this instance.
		/// </summary>
		/// <returns></returns>
		public bool Abandon()
		{
			throw new NotImplementedException("The method Abandon() is not implemented.");
		}

		
		
		
		
		#endregion

		#region ICall Members


		/// <summary>
		/// Checks the persistence.
		/// </summary>
		public void CheckPersistence()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Evals the action.
		/// </summary>
		/// <param name="ruleId">The rule id.</param>
		/// <returns></returns>
		public bool EvalAction(int ruleId)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Evals the bool.
		/// </summary>
		/// <param name="ruleId">The rule id.</param>
		/// <returns></returns>
		public bool EvalBool(int ruleId)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Evals the string.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public string EvalString(string input)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the object count.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public int GetObjectCount(string name)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the HTML tree.
		/// </summary>
		/// <value>The HTML tree.</value>
		public string HTMLTree
		{
			get { return this.BaseCallObject.ToHtml(); }
		}

		/// <summary>
		/// Initials the save no callflow.
		/// </summary>
		/// <returns></returns>
		public bool InitialSaveNoCallflow()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Loads from DSN.
		/// </summary>
		/// <param name="callId">The call id.</param>
		/// <param name="dsn">The DSN.</param>
		/// <returns></returns>
		public bool LoadFromDSN(string callId, string dsn)
		{
			throw new NotImplementedException();
		}



		/// <summary>
		/// Called when [event].
		/// </summary>
		/// <param name="ruleText">The rule text.</param>
		public void OnEvent(string ruleText)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Sets the typed value.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="value">The value.</param>
		/// <param name="type">The type.</param>
		public void SetTypedValue(string name, string value, string type)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets or sets the BSTR LOB.
		/// </summary>
		/// <value>The BSTR LOB.</value>
		public string bstrLOB
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Gets or sets the l accnt hier ID.
		/// </summary>
		/// <value>The l accnt hier ID.</value>
		public int lAccntHierID
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Gets or sets the l call id.
		/// </summary>
		/// <value>The l call id.</value>
		public int lCallId
		{
			get
			{
				int callId;
				if (int.TryParse(CallId, out callId))
					return callId;
				else
					return 0;
			}
			set
			{
				CallId = value.ToString(); 
			}
		}

		/// <summary>
		/// Gets or sets the M_BSTR user ID.
		/// </summary>
		/// <value>The M_BSTR user ID.</value>
		public string m_bstrUserID
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Gets or sets the M_L carrier ID.
		/// </summary>
		/// <value>The M_L carrier ID.</value>
		public int m_lCarrierID
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Gets or sets the M_L entry id.
		/// </summary>
		/// <value>The M_L entry id.</value>
		public int m_lEntryId
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		#endregion

		#region IComposite Members


		/// <summary>
		/// Froms the json.
		/// </summary>
		/// <param name="json">The json.</param>
		public void FromJson(string json)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// serialize to json.
		/// </summary>
		/// <returns>Json</returns>
		public string ToJson()
		{
			return _callObject.ToJson();
		}

		#endregion

		#region ICall Members



		/// <summary>
		/// Adds the word to dictionary.
		/// </summary>
		/// <returns></returns>
		public int AddWordToDictionary()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets or sets the bad frame id.
		/// </summary>
		/// <value>The bad frame id.</value>
		public string BadFrameId
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Determines whether this instance can close.
		/// </summary>
		/// <returns></returns>
		public int CanClose()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Checks the spelling.
		/// </summary>
		/// <returns></returns>
		public int CheckSpelling()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Cleans the up.
		/// </summary>
		public void CleanUp()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Cleanups the DB conns.
		/// </summary>
		public void CleanupDBConns()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Clears the attributes.
		/// </summary>
		/// <param name="bstrObjectName">Name of the BSTR object.</param>
		public void ClearAttributes(string bstrObjectName)
		{
			_callObject.Remove(bstrObjectName);
		}

		/// <summary>
		/// Closes the dictionaries.
		/// </summary>
		/// <returns></returns>
		public int CloseDictionaries()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Copies the object to.
		/// </summary>
		/// <param name="bstrBranchName">Name of the BSTR branch.</param>
		/// <param name="bstrTargetRoot">The BSTR target root.</param>
		public void CopyObjectTo(string bstrBranchName, string bstrTargetRoot)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Deletes the array.
		/// </summary>
		/// <param name="bstrName">Name of the BSTR.</param>
		public void DeleteArray(string bstrName)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Deletes the object.
		/// </summary>
		/// <param name="Name">The name.</param>
		public void DeleteObject(string Name)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets or sets the error text.
		/// </summary>
		/// <value>The error text.</value>
		public string ErrorText
		{
			get
			{
				return _callObject.GetValue("ERRORTEXT");
			}
			set
			{
				_callObject.SetValue("ERRORTEXT", value);
			}
		}

		/// <summary>
		/// Escalates this instance.
		/// </summary>
		/// <returns></returns>
		public int Escalate()
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.EvalAction(int lRuleId)
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.EvalBool(int lRuleId)
		{
			throw new NotImplementedException();
		}

		public int ExecuteAction(string bstrRuleText)
		{
			throw new NotImplementedException();
		}

		public int ExecuteScript(string scriptType, string scriptCode)
		{
			throw new NotImplementedException();
		}

		public int FinalSaveRoute(int lCallRoutingID, out string pMessage)
		{
			throw new NotImplementedException();
		}

		public int FlatDelete()
		{
			throw new NotImplementedException();
		}

		public int FlatSave()
		{
			throw new NotImplementedException();
		}

		public string GetABEDescriptions()
		{
			throw new NotImplementedException();
		}

		public string GetABEList()
		{
			throw new NotImplementedException();
		}

		public string GetAHSIDByClientCode(string bstrClientCode)
		{
			throw new NotImplementedException();
		}

		public string GetAttributeList()
		{
			throw new NotImplementedException();
		}

		public string GetCachedCallflowList()
		{
			throw new NotImplementedException();
		}

		public object GetCallflowFrameByID(int iFrameID)
		{
			throw new NotImplementedException();
		}

		public object GetCallflowFrameByName(string bstrFrameName, int bSetAsCurrentFrame)
		{
			throw new NotImplementedException();
		}

		public object GetCurrentFrame()
		{
			throw new NotImplementedException();
		}

		public object GetFirstFrame()
		{
			throw new NotImplementedException();
		}

		public object GetFrameByID(int iFrameID)
		{
			throw new NotImplementedException();
		}

		public object GetFrameByName(string bstrName)
		{
			throw new NotImplementedException();
		}

		public string GetFrameListing()
		{
			throw new NotImplementedException();
		}

		public object GetNextFrame()
		{
			throw new NotImplementedException();
		}

		public object GetPreviousFrame()
		{
			throw new NotImplementedException();
		}

		public string GetSerializedCallData()
		{
			throw new NotImplementedException();
		}

		public string GetSpellErrorFieldCaption()
		{
			throw new NotImplementedException();
		}

		public string GetSpellErrorFrameID()
		{
			throw new NotImplementedException();
		}

		public string GetSpellErrorFrameTitle()
		{
			throw new NotImplementedException();
		}

		public string GetSpellErrorHTML()
		{
			throw new NotImplementedException();
		}

		public string GetSpellErrorSuggestions()
		{
			throw new NotImplementedException();
		}

		public string GetSpellErrorWord()
		{
			throw new NotImplementedException();
		}

		public string GetStringData()
		{
			throw new NotImplementedException();
		}

		public string GetTree(string bstrObjectName)
		{
			throw new NotImplementedException();
		}

		public void IgnoreAllMisspelledWords()
		{
			throw new NotImplementedException();
		}

		public int IgnoreMisspelledWord()
		{
			throw new NotImplementedException();
		}

		public int InTree(int lAccountID)
		{
			throw new NotImplementedException();
		}

		public void InitFrameStatuses()
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.InitialSaveNoCallflow()
		{
			if (InitialSaveNoCallflow())
				return 1;
			else
				return 0;
		}

		public string InsertIndexesInAttrib(string bstrAttribName, string bstrPrefix)
		{
			throw new NotImplementedException();
		}

		public string IsBOF()
		{
			throw new NotImplementedException();
		}

		public string IsEOF()
		{
			throw new NotImplementedException();
		}

		public int IsObject(string bstrName)
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.Load(int lCallId)
		{
			throw new NotImplementedException();
		}

		public void LoadCallFlows()
		{
			throw new NotImplementedException();
		}

		public object LoadCallStart()
		{
			throw new NotImplementedException();
		}

		public object LoadCallStartByType(string bstrAHSID, string bstrLOB, string bstrCallflowTypeCode)
		{
			throw new NotImplementedException();
		}

		public object LoadCallflow(string bstrAcctHierID, string bstrLOB)
		{
			throw new NotImplementedException();
		}

		public object LoadCallflowByType(string bstrAHSID, string bstrLOB, string bstrCallflowTypeCode, int bSetAsCurrentFrame)
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.LoadFromDSN(string bstrCallID, string bstrDSN)
		{
			if (LoadFromDSN(bstrCallID, bstrDSN))
				return 1;
			else
				return 0;
		}

		public int LoadFromFile(string bstrFileName)
		{
			throw new NotImplementedException();
		}

		public void MoveObjectTo(string bstrBranchName, string bstrTargetRoot)
		{
			throw new NotImplementedException();
		}

		public void NewCallFromOld()
		{
			throw new NotImplementedException();
		}

		public int NextSpellError()
		{
			throw new NotImplementedException();
		}

		public void OnAsynchEvent(string bstrEvent)
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.Pend()
		{
			throw new NotImplementedException();
		}

		public int PreviousSpellError()
		{
			throw new NotImplementedException();
		}

		public void ReleaseFlowLists()
		{
			throw new NotImplementedException();
		}

		public void ReloadFlowInList(int lCallflowID, string bstrCallStartFlag)
		{
			throw new NotImplementedException();
		}

		public int ReplaceSpellError(string bstrSuggestion)
		{
			throw new NotImplementedException();
		}

		public void ResetCallflow()
		{
			throw new NotImplementedException();
		}

		public void ResetDsn()
		{
			throw new NotImplementedException();
		}

		public int Route()
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.SetValue(string Name, string Value)
		{
			this.SetValue(Name, Value);
		}

		public string bstrCarrierCode
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public string bstrLocation
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public string m_bstrAttribInError
		{
			get { throw new NotImplementedException(); }
		}

		#endregion

		#region ICall Members


		int FnsInterfaces.ICall.AddWordToDictionary()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.BadFrameId
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		int FnsInterfaces.ICall.CanClose()
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.CheckPersistence()
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.CheckSpelling()
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.CleanUp()
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.CleanupDBConns()
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.ClearAttributes(string bstrObjectName)
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.CloseDictionaries()
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.CopyObjectTo(string bstrBranchName, string bstrTargetRoot)
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.DeleteArray(string bstrName)
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.DeleteObject(string Name)
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.ErrorText
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		int FnsInterfaces.ICall.Escalate()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.EvalString(string bstrStatement)
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.ExecuteAction(string bstrRuleText)
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.ExecuteScript(string scriptType, string scriptCode)
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.FinalSaveRoute(int lCallRoutingID, out string pMessage)
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.FlatDelete()
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.FlatSave()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetABEDescriptions()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetABEList()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetAHSIDByClientCode(string bstrClientCode)
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetAttributeList()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetCachedCallflowList()
		{
			throw new NotImplementedException();
		}

		object FnsInterfaces.ICall.GetCallflowFrameByID(int iFrameID)
		{
			throw new NotImplementedException();
		}

		object FnsInterfaces.ICall.GetCallflowFrameByName(string bstrFrameName, int bSetAsCurrentFrame)
		{
			throw new NotImplementedException();
		}

		object FnsInterfaces.ICall.GetCurrentFrame()
		{
			throw new NotImplementedException();
		}

		object FnsInterfaces.ICall.GetFirstFrame()
		{
			throw new NotImplementedException();
		}

		object FnsInterfaces.ICall.GetFrameByID(int iFrameID)
		{
			throw new NotImplementedException();
		}

		object FnsInterfaces.ICall.GetFrameByName(string bstrName)
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetFrameListing()
		{
			throw new NotImplementedException();
		}

		object FnsInterfaces.ICall.GetNextFrame()
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.GetObjectCount(string Name)
		{
			throw new NotImplementedException();
		}

		object FnsInterfaces.ICall.GetPreviousFrame()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetSerializedCallData()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetSpellErrorFieldCaption()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetSpellErrorFrameID()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetSpellErrorFrameTitle()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetSpellErrorHTML()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetSpellErrorSuggestions()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetSpellErrorWord()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetStringData()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetTree(string bstrObjectName)
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.GetValue(string Name)
		{
			return GetValueImplementation(Name);
		}

		string FnsInterfaces.ICall.GetXML()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.HTMLTree
		{
			get { throw new NotImplementedException(); }
		}

		void FnsInterfaces.ICall.IgnoreAllMisspelledWords()
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.IgnoreMisspelledWord()
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.InTree(int lAccountID)
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.InitFrameStatuses()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.InsertIndexesInAttrib(string bstrAttribName, string bstrPrefix)
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.IsBOF()
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.IsEOF()
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.IsObject(string bstrName)
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.LoadCallFlows()
		{
			throw new NotImplementedException();
		}

		object FnsInterfaces.ICall.LoadCallStart()
		{
			throw new NotImplementedException();
		}

		object FnsInterfaces.ICall.LoadCallStartByType(string bstrAHSID, string bstrLOB, string bstrCallflowTypeCode)
		{
			throw new NotImplementedException();
		}

		object FnsInterfaces.ICall.LoadCallflow(string bstrAcctHierID, string bstrLOB)
		{
			throw new NotImplementedException();
		}

		object FnsInterfaces.ICall.LoadCallflowByType(string bstrAHSID, string bstrLOB, string bstrCallflowTypeCode, int bSetAsCurrentFrame)
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.LoadFromFile(string bstrFileName)
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.LoadFromXML(string bstrXML)
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.MoveObjectTo(string bstrBranchName, string bstrTargetRoot)
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.NewCallFromOld()
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.NextSpellError()
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.OnAsynchEvent(string bstrEvent)
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.OnEvent(string bstrEvent)
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.PreviousSpellError()
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.ReleaseFlowLists()
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.ReloadFlowInList(int lCallflowID, string bstrCallStartFlag)
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.ReplaceSpellError(string bstrSuggestion)
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.ResetCallflow()
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.ResetDsn()
		{
			throw new NotImplementedException();
		}

		int FnsInterfaces.ICall.Route()
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.Save()
		{
			throw new NotImplementedException();
		}

		void FnsInterfaces.ICall.SetTypedValue(string bstrName, string bstrValue, string bstrType)
		{
			throw new NotImplementedException();
		}

		string FnsInterfaces.ICall.bstrCarrierCode
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		string FnsInterfaces.ICall.bstrLOB
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		string FnsInterfaces.ICall.bstrLocation
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		int FnsInterfaces.ICall.lAccntHierID
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		int FnsInterfaces.ICall.lCallId
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		string FnsInterfaces.ICall.m_bstrAttribInError
		{
			get { throw new NotImplementedException(); }
		}

		string FnsInterfaces.ICall.m_bstrUserID
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		int FnsInterfaces.ICall.m_lCarrierID
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		int FnsInterfaces.ICall.m_lEntryId
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		#endregion
				
		#region ICall Members


		public int InitialSave()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region ICall Members

		int FnsInterfaces.ICall.Abandon()
		{
			throw new NotImplementedException();
		}

		public int Abort()
		{
			throw new NotImplementedException();
		}

		public int FinalSave()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region ICall Members


		public int IncrementalSave()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IComposite Members


		public void LoadFromJson(string json)
		{
			this._callObject.LoadFromJson(json);
		}

		#endregion
	}
}
#endif
#region Log
/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/Call.cs $
 * 
 * 1     6/27/09 10:39a John.gwynn
 * Conditional Compile operations for Win2K support (ClaimCapture build)
 * 
 * 1     5/06/09 6:01p John.gwynn
 * 
 * 26    5/06/09 10:39a John.gwynn
 * added interface updates for eSurance
 * 
 * 25    5/04/09 6:56p John.gwynn
 * Refactored ICall interface
 * 
 * 24    5/01/09 1:37p John.gwynn
 * update Call Interface
 * 
 * 23    3/23/09 5:46p John.gwynn
 * fixed the build
 * 
 * 22    3/17/09 6:05p John.gwynn
 * new controllers for callflow manipulation
 * 
 * 21    2/10/09 2:37p John.gwynn
 * CallWrapper.ImageFileName
 * 
 * 20    11/17/08 10:36a Deepika.sharma
 * A-JUC2: caller_info information
 * 
 * 19    7/29/08 9:08p John.gwynn
 * fixed a logging bug
 * 
 * 18    6/12/08 8:52p John.gwynn
 * added ClearAll to reset nodes
 * 
 * 17    6/10/08 8:55p John.gwynn
 * fixed ABORT status to ABORTED
 * 
 * 16    5/28/08 9:16p John.gwynn
 * Added Hold
 * 
 * 15    5/23/08 7:53p John.gwynn
 * Added Several Attribute names
 * 
 * 14    5/20/08 8:33p John.gwynn
 * fixed CallStartDate Time format
 * 
 * 13    5/17/08 5:42p John.gwynn
 * Added suport for InsertPolicyHolderEmailXml
 * 
 * 12    5/15/08 9:03p John.gwynn
 * CallStartTime reformatted by request
 * 
 * 11    5/01/08 4:41p John.gwynn
 * support for eSurance
 * 
 * 10    4/25/08 5:56p John.gwynn
 * Added eSuranceSesionManager support 
 * 
 * 9     4/03/08 7:34p John.gwynn
 * Implemented FinalSave, fixed ClaimNumber mapping in AcordResponse for
 * eSurance
 * 
 * 8     3/20/08 6:59p John.gwynn
 * added support for Events and implemented access to Esurance and CC Web
 * Services
 * 
 * 7     3/06/08 6:58p John.gwynn
 * Added CallEndDate and CallEndTime
 * 
 * 6     2/28/08 7:48p John.gwynn
 * Added CallflowAttribute class for shared attribute definitions across
 * different modules/assemblies 
 * 
 * 5     2/07/08 3:14p John.gwynn
 * added GetPolicy and Validate remote calls to PolicyBroker for eSurance
 * phase III
 * 
 * 4     2/04/08 6:47p John.gwynn
 * added AhsId and LastError
 * 
 * 3     1/30/08 6:20p John.gwynn
 * Added support for InitialSave and policy prefill
 * 
 * 2     1/04/08 3:01p John.gwynn
 * added additional LoadFromXmlVb due to case issues
 * 
 * 1     12/04/07 6:50p John.gwynn
 */
#endregion