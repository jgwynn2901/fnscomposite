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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/CallObject.cs 24    4/26/11 8:06a Gwynnj $ */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

namespace FnsComposite.CallObjects
{
  /// <summary>
  /// Summary description for CallObject.
  /// </summary>
  [Serializable]
  public class CallObject : CallObjectBase, ICallObject
  {
    public const string InstanceAttributeName = "INSTANCE";
    public const string CallIdAttributeName = "CALL_ID";
    public const string AhsIdAttributeName = "AHS_ID";
    public const string ClientIdAttributeName = "CLIENT_ID";
    public const string CallStatusAttribute = "CALL_STATUS";
    public const string CompletedStatusAttribute = "COMPLETED";
    public const string AbortedStatusAttribute = "ABORTED";
    public const string AbandonedStatusAttribute = "ABANDONED";

    /// <summary>
    /// Line of Business constants
    /// </summary>
    public const string LobCdAttributeName = "LOB_CD";
    public const string LobCdPersonalAuto = "PAU";
    public const string LobCdPersonalProperty = "PPR";
    public const string LobCdPersonalLiability = "PLI";
    public const string LobCdCommercialAuto = "CAU";
    public const string LobCdCommercialProperty = "CPR";
    public const string LobCdCommercialLiability = "CLI";
    public const string LobCdWorkersCompensation = "WOR";

    /// <summary>
    /// Initializes a new instance of the <see cref="CallObject"/> class.
    /// </summary>
    public CallObject()
      : base(CallRoot)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CallObject"/> class.
    /// </summary>
    /// <param name="node">The node.</param>
    public CallObject(XmlNode node)
      : base(node)
    { }
    /// <summary>
    /// Initializes a new instance of the <see cref="CallObject"/> class.
    /// </summary>
    /// <param name="info">The info.</param>
    /// <param name="context">The context.</param>
    protected CallObject(SerializationInfo info, StreamingContext context)
      : base(info, context)
    { }

    #region ICallObject Members

    /// <summary>
    /// Gets or sets the ACCNT_HRCY_STEP_ID.
    /// </summary>
    /// <value>The ahs id.</value>
    public string AhsId
    {
      get { return GetValue(AhsIdAttributeName); }
      set { SetValue(AhsIdAttributeName, value); }
    }

    /// <summary>
    /// Gets or sets the call id.
    /// </summary>
    /// <value>The call id.</value>
    public string CallId
    {
      get { return GetValue(CallIdAttributeName); }
      set { SetValue(CallIdAttributeName, value.ToString(CultureInfo.InvariantCulture)); }
    }

    /// <summary>
    /// Gets or sets the line of business.
    /// </summary>
    /// <value>The line of business.</value>
    public string LineOfBusiness
    {
      get { return GetValue(LobCdAttributeName); }
      set { SetValue(LobCdAttributeName, value); }
    }

    /// <summary>
    /// Gets or sets the call start date.
    /// </summary>
    /// <value>The call start date.</value>
    public string CallStartDate
    {
      get { return GetValue("CALL_START_DATE"); }
      set { SetValue("CALL_START_DATE", value); }
    }

    /// <summary>
    /// Gets or sets the call start time.
    /// </summary>
    /// <value>The call start time.</value>
    public string CallStartTime
    {
      get { return GetValue("CALL_START_TIME"); }
      set { SetValue("CALL_START_TIME", value); }
    }

    /// <summary>
    /// Gets or sets the call end date.
    /// </summary>
    /// <value>The call end date.</value>
    public string CallEndDate
    {
      get { return GetValue("CALL_END_DATE"); }
      set { SetValue("CALL_END_DATE", value); }
    }

    /// <summary>
    /// Gets or sets the call end time.
    /// </summary>
    /// <value>The call end time.</value>
    public string CallEndTime
    {
      get { return GetValue("CALL_END_TIME"); }
      set { SetValue("CALL_END_TIME", value); }
    }

    /// <summary>
    /// Gets or sets the client id.
    /// </summary>
    /// <value>The client id.</value>
    public string ClientId
    {
      get { return GetValue(ClientIdAttributeName); }
      set { SetValue(ClientIdAttributeName, value); }
    }

    /// <summary>
    /// Gets or sets the carrier code.
    /// </summary>
    /// <value>The carrier code.</value>
    public string CarrierCode
    {
      get { return GetValue("CARRIER_CODE"); }
      set { SetValue("CARRIER_CODE", value); }
    }

    /// <summary>
    /// Gets or sets the instance.
    /// </summary>
    /// <value>The instance.</value>
    public string Instance
    {
      get { return GetValue(InstanceAttributeName); }
      set { SetValue(InstanceAttributeName, value); }
    }

    /// <summary>
    /// Gets or sets the call status.
    /// </summary>
    /// <value>The call status.</value>
    public string CallStatus
    {
      get { return GetValue("CALL_STATUS"); }
      set { SetValue("CALL_STATUS", value); }
    }

    /// <summary>
    /// Gets or sets the user id.
    /// </summary>
    /// <value>The user id.</value>
    public string UserId
    {
      get { return GetValue("USER_ID"); }
      set { SetValue("USER_ID", value); }
    }

    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    /// <value>The name of the user.</value>
    public string UserName
    {
      get { return GetValue("USER_NAME"); }
      set { SetValue("USER_NAME", value); }
    }

    /// <summary>
    /// Gets or sets the session key.
    /// </summary>
    /// <value>The session key.</value>
    public string SessionKey
    {
      get { return GetValue("SESSIONKEY"); }
      set { SetValue("SESSIONKEY", value); }
    }

    /// <summary>
    /// Gets or sets the name of the server.
    /// </summary>
    /// <value>The name of the server.</value>
    public string ServerName
    {
      get { return GetValue("SERVER_NAME"); }
      set { SetValue("SERVER_NAME", value); }
    }

    /// <summary>
    /// Gets or sets the internet user.
    /// </summary>
    /// <value>The internet user.</value>
    public string InternetUser
    {
      get { return GetValue("INTERNETUSER"); }
      set { SetValue("INTERNETUSER", value); }
    }

    public string EmployeeId
    {
      get { return GetValue("EMPLOYEE_ID"); }
      set { SetValue("EMPLOYEE_ID", value); }
    }
    /// <summary>
    /// Adds the event.
    /// </summary>
    /// <param name="callEvent"></param>
    public void AddEvent(ICallflowEvent callEvent)
    {
      var newEvent = new CallflowEvent(string.Format("[{0}]", Events.Count));
      newEvent.CopyFrom(callEvent);
      Add(newEvent);
    }

    /// <summary>
    /// Gets or sets the last error.
    /// </summary>
    /// <value>The last error.</value>
    public new string LastError
    {
      get { return GetValue("LASTERROR"); }
      set { SetValue("LASTERROR", value); }
    }
    /// <summary>
    /// Gets the claim.
    /// </summary>
    /// <value>The claim.</value>
    public IClaim Claim
    {
      get
      {
        var node = GetObject<Claim>("CLAIM") as Claim;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: Claim");
        }
        return node;
      }
    }

    /// <summary>
    /// Gets the contact.
    /// </summary>
    /// <value>The contact.</value>
    public IContact Contact
    {
      get
      {
        var node = GetObject<Contact>("CONTACT") as Contact;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: Contact");
        }
        return node;
      }
    }

    /// <summary>
    /// Gets the caller.
    /// </summary>
    /// <value>The caller.</value>
    public ICaller Caller
    {
      get
      {
        var node = GetObject<Caller>("CALLER") as Caller;
        if (node == null)
        {
          throw new ApplicationException("CallObject error retrieving type: Caller");
        }
        return node;
      }
    }

    /// <summary>
    /// Gets the ASI node.
    /// </summary>
    /// <value>The asi.</value>
    public IAsi Asi
    {
      get
      {
        var node = GetObject<Asi>("ASI") as Asi;
        if (node == null)
          throw new ApplicationException("CallObject error retrieving type: Asi");

        return node;
      }
    }
    /// <summary>
    /// Gets the events.
    /// </summary>
    /// <value>The events.</value>
    [ComVisible(false)]
    public List<ICallflowEvent> Events
    {
      get
      {
        var events = new List<ICallflowEvent>();
        foreach (CallflowEvent v in GetEnumerator<CallflowEvent>())
          events.Add(v);

        return events;
      }
    }

    /// <summary>
    /// Clears this instance contents.
    /// </summary>
    public void Clear()
    {
      ClearAll();
    }

    public string GetTree(string node)
    {
      var current = GetNode(node);
      return current != null ? current.ToString() : string.Empty;
    }

    /// <summary>
    /// Gets the node.
    /// </summary>
    public new Composite GetNode(string name)
    {
      var names = name.Split(new[] { ':', '/' });
      Composite current = this;
      for (var i = 0; i < names.Length; ++i)
      {
        if (current == null) break;
        current = current[names[i]] as Composite;
      }
      return current;
    }

    #endregion
  }
}

/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CallObjects/CallObject.cs $
 * 
 * 24    4/26/11 8:06a Gwynnj
 * added GetValueAsInt
 * 
 * 23    4/11/11 12:54p Gwynnj
 * Added LineOfBusiness Constants
 * 
 * 22    10/20/10 10:27p Gwynnj
 * Added suport for ToNameValueDictionary for use in node copy i.e.
 * Affirmative Entities
 * 
 * 21    1/12/10 5:13p Gwynnj
 * Added GetNodeCount for indexed elements
 * 
 * 20    1/06/10 6:43p Gwynnj
 * Added several constants for CallObject namespace
 * 
 * 19    1/04/10 3:14p John.gwynn
 * Added CallObject.InstanceAttributeName = "INSTANCE" as a pre-defined
 * constant
 * 
 * 18    9/29/09 5:12p John.gwynn
 * Added Validation Event support for Composite in general and Segment
 * classes.
 * 
 * 17    7/07/09 3:34p John.gwynn
 * added logging for Events count!
 * 
 * 16    5/04/09 3:55p John.gwynn
 * removed FnsComposite.ICall (replaced with the Interop version in
 * FnsInterfaces)
 * 
 * 15    5/04/08 7:59p John.gwynn
 * fixed a bug in the CopyFrom method
 * 
 * 14    5/01/08 4:13p John.gwynn
 * refactored IPerson interface and added support for Contact
 * 
 * 13    4/08/08 3:33p John.gwynn
 * Fix for bug in encode/decode (added encode to the constructor) now all
 * values are encoded and decoded except when ToXml is called...
 * 
 * 12    3/20/08 6:58p John.gwynn
 * Added support for CallflowEvents for explicating specific defined
 * events during the course of a given call
 * 
 * 11    3/16/08 3:33p John.gwynn
 * Implemented ISerializable
 * 
 * 10    3/06/08 6:59p John.gwynn
 * Added CallEndDate and CallEndTime
 * 
 * 9     3/02/08 2:50p John.gwynn
 * refactored LoadFromXml to eliminate code duplicaton
 * 
 * 8     2/28/08 7:47p John.gwynn
 * Added ASI and Carrier support
 * 
 * 7     2/04/08 6:46p John.gwynn
 * Added AhsId and LastError 
 * 
 * 6     1/16/08 6:39p John.gwynn
 * added CallObjectBase to override SetValue
 * 
 * 5     10/30/07 7:12p John.gwynn
 * Support for new Business Rule evaluator
 * 
 * 4     10/22/07 6:08p John.gwynn
 * 
 * 3     4/20/07 5:17p John.gwynn
 * 
 * 2     4/17/07 3:41p John.gwynn
 * update current version synch to 1.1
 * 
 * 2     4/09/06 8:14p John.gwynn
 * FxCop and Resharper reformatting changes
 * 
 * 1     1/09/06 8:14a John.gwynn
 */
