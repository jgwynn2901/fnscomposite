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
/* $Header: /SourceCode/Components/FNS2005/FnsComposite/CompositeTests/CompositeTest.cs 5     11/12/10 4:16p Gwynnj $ */
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using FnsComposite;
using FnsComposite.CallObjects;
using FnsComposite.MessageObjects;
using NUnit.Framework;
using FnsComposite.SegmentObjects;
using Property=FnsComposite.Property;

namespace CompositeTests
{
	/// <summary>
	/// Summary description for CompositeTest.
	/// </summary>
	[TestFixture]
	[ClassInterface(ClassInterfaceType.None), ComVisible(false)]
	public class CompositeTest
	{
		private CallObject _base;
		
		/// <summary>
		/// testing the first level of supported construction 
		/// essentially instantiating each Composite (and Leaf) and 
		/// adding them to the appropriate parent to demostrate building 
		/// structures dynamically
		/// </summary>
		[SetUp]
		public void Setup()
		{
			_base = new CallObject();

			var oNode = new Claim();
			var oNode2 = new Insured();
			var oNode3 = new Vehicle();
			var oNode4 = new Driver();

			_base.Add(oNode);
			oNode.Add(oNode2);
			oNode2.Add(oNode3);
			oNode2.Add(oNode4);

			oNode.SetValue(CallObject.LobCdAttributeName, "WOR");
			oNode.ClaimNumber = "00122345";
			oNode.LossDate = "12092005";

			oNode2.InsuredName = "Steven Murphy";

			oNode2.SetValue(Address.AddressLine1, "95 Wells Avenue");
			oNode2.SetValue(Address.AddressCity, "Newton");
			oNode2.SetValue(Address.AddressState, "MA");
			oNode2.SetValue(Address.AddressZip, "02459");

			oNode2.PhoneHome = "6178862064";

			oNode3.Make = "TOYOTA";
			oNode3.Model = "MATRIX";
			oNode3.Vin = "1234567891011121314";
			oNode3.Year = "2004";

			oNode4.NameFirst = "Cookie";
			oNode4.NameLast = " Murphy";

			oNode4.SetValue(Address.AddressLine1, "529 Main Street");
			oNode4.SetValue(Address.AddressCity, "Charlestown");
			oNode4.SetValue(Address.AddressState, "MA");
			oNode4.SetValue(Address.AddressZip, "02129");
			oNode4.SetValue(EntityBase.HomePhoneAttribute, "6178862064");
			
			_base.Commit();

		}

		[Test]
		public void TestCopyNode()
		{
			var call = new CallObject();
			call.LoadFromXml(_base.ToXml());
			var vehicle = call.GetNode("CLAIM:INSURED:VEHICLE");
			Assert.IsNotNull(vehicle);
			Console.WriteLine(vehicle.ToString());
			var items = vehicle.ToNameValueDictionary();

			foreach (var item in items.Keys)
				Console.WriteLine("{0}={1}", item, items[item]);
		}

		/// <summary>
		/// Tests the conditional visitor.
		/// </summary>
		[Test]
		public void TestConditionalVisitor()
		{
			var predicate = new ConditionalVisitor(p => p.IsLeaf && p.Name.IndexOf("NAME") > -1);
			_base.Accept(predicate);

			Assert.IsTrue(predicate.Results.Count > 0);
			foreach (var s in predicate.Results)
				Console.WriteLine("{0}={1}",s, _base.GetValue(s));

			var expressionVisitor = new NameExpressionVisitor("ADDRESS");
			_base.Accept(expressionVisitor);

			Assert.IsTrue(expressionVisitor.Results.Count > 0);
			foreach (var s in expressionVisitor.Results)
				Console.WriteLine("{0}={1}", s, _base.GetValue(s));


		}
		/// <summary>
		/// ClearAll is a deep cleaning of each list
		/// </summary>
		[TearDown]
		public void TearDown()
		{
			_base.ClearAll();
		}
		
		/// <summary>
		/// NUNIT Tests the names.
		/// </summary>
		[Test] public void TestNames() 
		{
			Assert.IsNotNull (_base);
			Assert.AreEqual(_base.Name,"CALL");
		}
		/// <summary>
		/// NUNIT Tests the building of the graph.
		/// </summary>
		[Test] public void TestBuild() 
		{	
			Console.WriteLine("{0}",_base);
			Assert.AreEqual(_base.Value,"");

			var myBase = (Composite)_base["CLAIM"];

			foreach (CompositeBase c in myBase) 
			{
				Console.WriteLine("{0}",c);
			}
		}
		/// <summary>
		/// NUNIT Tests the removal of nodes.
		/// </summary>
		[Test] public void TestRemove() 
		{	
			Assert.IsTrue(_base.Remove("CLAIM/INSURED/VEHICLE"));
			Assert.IsFalse(_base.Remove("CLAIM/INSURED/DRIVER/PHONE"));

			Console.WriteLine("{0}",_base);
			Assert.AreEqual(_base.Value,"");
		}
		/// <summary>
		/// NUNIT Tests the add new prebuilt nodes.
		/// </summary>
		[Test] public void TestAddNew() 
		{	
			Assert.IsTrue(_base.Add("CLAIM/INSURED/VEHICLE/COVERAGE[0]/COVERAGE_TYPE","COLL"));
			Assert.IsTrue(_base.Add("CLAIM/INSURED/VEHICLE/COVERAGE[0]/DEDUCTIBLE","500.00"));
			Assert.IsTrue(_base.Add("CLAIM/INSURED/VEHICLE/COVERAGE[1]/COVERAGE_TYPE","COMP"));
			Assert.IsTrue(_base.Add("CLAIM/INSURED/VEHICLE/COVERAGE[1]/DEDUCTIBLE","500.00"));
			Assert.IsTrue(_base.Add("CLAIM/INSURED/VEHICLE/COVERAGE[2]/COVERAGE_TYPE","RENTAL"));
			Assert.IsTrue(_base.Add("CLAIM/INSURED/VEHICLE/COVERAGE[2]/LIMIT","500.00"));

			Console.WriteLine("{0}",_base);
		}
		/// <summary>
		/// NUNIT Tests the XML output.
		/// </summary>
		[Test] public void TestXml() 
		{
			Assert.IsTrue(_base.Add("CLAIM/VEHICLE[0]/MAKE","DODGE"));
			Assert.IsTrue(_base.Add("CLAIM/VEHICLE[0]/MODEL","DART"));
			Assert.IsTrue(_base.Add("CLAIM/VEHICLE[0]/YEAR","2002"));
			Assert.IsTrue(_base.Add("CLAIM/VEHICLE[0]/VIN","ASD3465HJJK5T"));
			Assert.IsTrue(_base.Add("CLAIM/VEHICLE[0]/LICENSE_PLATE","332DDF"));
			Assert.IsTrue(_base.Add("CLAIM/VEHICLE[1]/MAKE","CHEVR"));
			Assert.IsTrue(_base.Add("CLAIM/VEHICLE[1]/MODEL","BLAZER"));
			Assert.IsTrue(_base.Add("CLAIM/VEHICLE[1]/YEAR","2004"));
			Assert.IsTrue(_base.Add("CLAIM/VEHICLE[1]/VIN","98989898989898"));
			Assert.IsTrue(_base.Add("CLAIM/VEHICLE[1]/LICENSE_PLATE","COMP"));

			Console.WriteLine("{0}",_base.ToXml());
		}
		/// <summary>
		/// NUNIT Tests the index overload.
		/// </summary>
		[Test] public void TestIndexer() 
		{
			Assert.IsTrue(_base["CLAIM/INSURED/VEHICLE/MAKE"].Value == "TOYOTA");
			Assert.IsNull(_base["CLAIM/INSURED/VEHICLE/LICENSE_STATE"]);
		}
		/// <summary>
		/// NUNIT Tests the iterator.
		/// </summary>
		[Test] public void TestIterator ()
		{
			Assert.IsTrue(_base.Remove("CLAIM"));
			Assert.IsTrue(_base.Add(new Composite("TEST")));
			Assert.IsTrue(_base.Add(new Composite("CALLER")));
			Assert.IsTrue(_base.Add(new Composite("ASI")));
			Assert.IsTrue(_base.Add(new Composite("STUFF")));
			Assert.IsTrue(_base.Add("CALLER_START_TIME","07:00AM"));
			foreach (CompositeBase c in _base) 
			{
				Console.WriteLine("{0}",c);
			}
		}
		/// <summary>
		/// NUNIT Tests the visitor.
		/// </summary>
		[Test] public void TestVisitor()
		{
			var myDoc = new XmlDocument();
			var myVisitor = new XmlDocumentVisitor(myDoc);
			_base.Accept(myVisitor);

			var strXml = myDoc.InnerXml;
			Assert.IsTrue(strXml.Length > 0);
			Console.WriteLine("{0}",strXml);

		}
		/// <summary>
		/// NUNIT Construct composites from Call xml 
		/// </summary>
		//[Test, Ignore] public void TestXmlConstructor()
		//{
		//	var myDoc = new XmlDocument();
		//	myDoc.Load("C:\\Documents and Settings\\john.gwynn\\My Documents\\testCallSELClaimSubmit.xml");

		//	var newBase = new Composite(myDoc.DocumentElement);

		//	var strXml = newBase.ToString();
		//	Assert.IsTrue(strXml.Length > 0);
		//	Console.WriteLine("{0}",strXml);
		//	Console.WriteLine("{0}",newBase.ToXml());
		//}
		/// <summary>
		/// NUNIT Tests the commit.
		/// </summary>
		[Test] public void TestCommit()
		{
			Assert.IsNotNull(_base,"_base is null");
			Assert.IsNotNull(_base["CLAIM/INSURED/VEHICLE/MAKE"],"Vehicle.Make is null");
			Assert.IsTrue(_base["CLAIM/INSURED/VEHICLE/MAKE"].Value  == "TOYOTA","Invalid _base configuration");
			Assert.IsFalse(_base.HasChanged, "HasChanged should be false");
			
			_base["CLAIM/INSURED/VEHICLE/MAKE"].Value = "CHEVY!";
			
			Assert.IsTrue( _base.HasChanged, "HasChanged should be true");
			_base.Rollback();
			Assert.IsTrue(_base["CLAIM/INSURED/VEHICLE/MAKE"].Value  == "TOYOTA","rollback failed!");
		}
		/// <summary>
		/// NUNIT Tests the policy loader.
		/// </summary>
		//[Test] [Ignore]public void TestPolicyLoader ()
		//{
		//	var doc = new XmlDocument();
		//	doc.Load("C:\\Documents and Settings\\john.gwynn\\My Documents\\policyLoad.xml");
			
		//	string xml = doc.OuterXml;
			
		//	Assert.IsNotEmpty(xml,"xml is empty!");
			
		//	var loader = new PolicyLoader(xml);
		//	Assert.IsNotEmpty(loader.Action,"Loader failed!");
			
		//	Console.WriteLine(String.Format("PolicyLoader.Action = {0}", loader.Action));
		//	Console.WriteLine(String.Format("PolicyLoader.ClientCode = {0}", loader.ClientCode));
		//	Console.WriteLine(String.Format("PolicyLoader.CreatTime = {0}", loader.CreatTime));
		//	Console.WriteLine(String.Format("PolicyLoader.FileName = {0}", loader.FileName));
		//	Console.WriteLine(String.Format("PolicyLoader.FileTranLogId = {0}", loader.FileTranLogId));
		//	Console.WriteLine(String.Format("PolicyLoader.Sequence = {0}", loader.Sequence));
		//	Console.WriteLine(String.Format("PolicyLoader.Status = {0}", loader.Status));
			
		//	string results = loader.ToXml();
			
		//	Assert.IsNotEmpty(results,"toXml failed!");
			
		//	Console.WriteLine(results);
			
		//}
		/// <summary>
		/// NUNIT Tests the copy constructor.
		/// </summary>
		[Test] public void TestCopyConstructor ()
		{
			var test = new Composite(_base);
			Assert.IsNotNull(test,"test is null!");
			Assert.IsTrue(_base.Equals(test),"copy construct problems");
		}
		/// <summary>
		/// NUNIT Tests the Property object
		/// </summary>
		[Test] public void TestPropertyOutput ()
		{
			var prop = new Property("testMessage");
			
			Assert.IsNotEmpty(prop.ToString());
			
			Console.WriteLine(prop);
			Console.WriteLine(prop.Body());
			Console.WriteLine();
			Console.WriteLine(prop.ToXml());

		}
		/// <summary>
		/// NUNIT Tests the ClassGen.
		/// </summary>
		[Test] public void TestClassGen ()
		{
			var test = new ClassGen("FnsComposite","TestGeneratedClass");
			
			test.AddUsing("System");
			test.AddUsing("System.Xml");
			test.AddUsing("System.Text");
			
			test.AddProperty("foo","int");
			test.AddProperty("bar","int");
			test.AddProperty("lastModified","DateTime");
			test.AddProperty("name","string");
			
			Console.WriteLine(test);
		}
		/// <summary>
		/// NUNIT Tests the db property output.
		/// </summary>
		[Test] public void TestDbPropertyOutput ()
		{
			var prop = new DbProperty("TestProperty",String.Empty,"int") {ReadOnly = true, AltName = "m_pTestProperty"};

			Assert.IsEmpty(prop.ToString());
			
			Console.WriteLine(prop);
			Console.WriteLine(prop.Body());
			Console.WriteLine(prop.GetInit());

		}
		/// <summary>
		/// NUNIT Tests the db class gen.
		/// </summary>
		[Test] public void TestDbClassGen ()
		{
			var test = new DbClassGen("FnsComposite","TestGeneratedClass");
			
			test.AddUsing("System");
			test.AddUsing("System.Xml");
			test.AddUsing("System.Text");
			
			test.AddProperty("Foo","int","m_pFoo",true);
			test.AddProperty("Bar","int","m_pBar",false);
			test.AddProperty("LastModified","DateTime","m_pLastModifiedDate",false);
			test.AddProperty("RecordName","string","m_pRecordName",false);
			
			Console.WriteLine(test);
		}
		/// <summary>
		/// NUNIT Tests the message object.
		/// </summary>
		[Test] public void TestMessageObjectSend()
		{
			IMessageObject message = new MessageObject
			                         	{
			                         		Instance = "FNSBA",
			                         		Source = ToString(),
			                         		Destination = ".\\private$\\test"
			                         	};

			Assert.IsNotEmpty(message.CreateDateTime,"IMessage.CreateDateTime failed.");
			Console.WriteLine("Message Type: {0} Created on {1}", ((Composite)message).Name, message.CreateDateTime);
			Assert.IsTrue(message.Send());

			Console.WriteLine(((Composite)message).ToXml());
		}
		
		/// <summary>
		/// Tests the get path.
		/// </summary>
		[Test]
		public void TestGetPath()
		{
			Console.WriteLine("{0}", _base);
			Assert.AreEqual(_base.Value, "");

			var myBase = _base["CLAIM"] as Composite;
			Assert.IsNotNull(myBase, "NULL returned!");
			Console.WriteLine(myBase.GetPath());

			myBase = _base["CLAIM:INSURED"] as Composite;
			Assert.IsNotNull(myBase, "NULL returned!");
			Console.WriteLine(myBase.GetPath());

			myBase = _base["CLAIM:INSURED:VEHICLE"] as Composite;
			Assert.IsNotNull(myBase, "NULL returned!");
			Console.WriteLine(myBase.GetPath());

			var myNode = _base["CLAIM:INSURED:VEHICLE:VIN"];
			Assert.IsNotNull(myNode, "NULL returned!");

			Console.WriteLine(myNode.GetPath());
		}
		/// <summary>
		/// Tests the get XML with parent elements.
		/// </summary>
		[Test]
		public void TestGetXmlWithParentElements()
		{
			Console.WriteLine("{0}", _base);
			Assert.AreEqual(_base.Value, "");

			var myBase = _base["CLAIM"] as Composite;
			Assert.IsNotNull(myBase, "NULL returned!");
			Console.WriteLine(myBase.GetXmlWithParentElements());

			myBase = _base["CLAIM:INSURED"] as Composite;
			Assert.IsNotNull(myBase, "NULL returned!");
			Console.WriteLine(myBase.GetXmlWithParentElements());

			myBase = _base["CLAIM:INSURED:VEHICLE"] as Composite;
			Assert.IsNotNull(myBase, "NULL returned!");
			Console.WriteLine(myBase.GetXmlWithParentElements());

			CompositeBase myNode = _base["CLAIM:INSURED:VEHICLE:VIN"];
			Assert.IsNotNull(myNode, "NULL returned!");

			Console.WriteLine(myNode.GetXmlWithParentElements());
		}
		/// <summary>
		/// Tests the get XML tree.
		/// </summary>
		[Test]
		public void TestGetXmlTree()
		{
			string results = _base.GetXmlTree("CLAIM");
			Assert.IsNotEmpty(results, "Nothing returned!");
			Console.WriteLine(results);

			results = _base.GetXmlTree("CLAIM:INSURED");
			Assert.IsNotEmpty(results, "Nothing returned!");
			Console.WriteLine(results);

			results = _base.GetXmlTree("CLAIM:INSURED:VEHICLE");
			Assert.IsNotEmpty(results, "Nothing returned!");
			Console.WriteLine(results);

			results = _base.GetXmlTree("CLAIM:INSURED:VEHICLE:VIN");
			Assert.IsNotEmpty(results, "Nothing returned!");
			Console.WriteLine(results);
		}
		/// <summary>
		/// Tests the copy.
		/// </summary>
		[Test]
		public void TestCopy()
		{
			const string vehicle = "CLAIM:INSURED:VEHICLE";
			const string vin = "CLAIM:INSURED:VEHICLE:VIN";
			var call = new CallObject();
			call.LoadFromXml(_base.GetXmlTree(vin));
			Assert.IsNotEmpty(call.GetValue(vin), "Nothing returned!");
			Console.WriteLine(call.GetValue(vin));

			call.LoadFromXml(_base.GetXmlTree(vehicle));
			var results = call.ToXml();
			Assert.IsNotEmpty(results, "Nothing returned!");
			Console.WriteLine(results);
		}
		/// <summary>
		/// Tests the factory.
		/// </summary>
		[Test]
		public void TestFactory()
		{
			CompositeBase comp = CompositeFactory.CreateInstance("Policy");
			Assert.IsNotNull(comp, "Expected Policy received null!");
			var policy = comp as Policy;
			Assert.IsNotNull(policy, "Could not cast instance to Policy!");

		}
		/// <summary>
		/// Tests the claim.
		/// </summary>
		[Test] public void TestClaimInterface()
		{
			//=====================================================
			// we can now directly reference common types as 
			// properties of the parent that return the strongly typed
			// node.  I use the CompositeFactory class to create
			// each node from its given type if it exists in this
			// assembly using reflection.
			//=====================================================
			var claim = _base.Claim;
			Assert.IsNotEmpty(claim.ClaimNumber,"Nothing returned from Claim!");
			var insured = claim.Insured;
			Assert.IsNotEmpty(insured.Address.City, "Nothing returned from Address!");
			Assert.IsNotEmpty(insured.Vehicle.Vin, "Nothing returned from Vehicle!");
			//=====================================================
			// create Other vehicle collection
			//=====================================================
			claim.SetValue("VEHICLE[0]:VIN", "123456789");
			claim.SetValue("VEHICLE[0]:MAKE", "AMC");
			claim.SetValue("VEHICLE[0]:MODEL", "Gremlin");
			claim.SetValue("VEHICLE[0]:YEAR", "1999");
			claim.SetValue("VEHICLE[0]:VEHICLE_NUMBER", "1");

			claim.SetValue("VEHICLE[1]:VIN", "A234A234ZZ");
			claim.SetValue("VEHICLE[1]:MAKE", "TOYOTA");
			claim.SetValue("VEHICLE[1]:MODEL", "RAV4");
			claim.SetValue("VEHICLE[1]:YEAR", "2004");
			claim.SetValue("VEHICLE[1]:VEHICLE_NUMBER", "2");

			claim.SetValue("VEHICLE[2]:VIN", "99999999999");
			claim.SetValue("VEHICLE[2]:MAKE", "ACURA");
			claim.SetValue("VEHICLE[2]:MODEL", "LEGEND AE");
			claim.SetValue("VEHICLE[2]:YEAR", "2001");
			claim.SetValue("VEHICLE[2]:VEHICLE_NUMBER", "3");
			claim.SetValue("VEHICLE[2]:TEST", "IT WORKS!");
			//=====================================================
			// we can iterate over each vehicle 
			// using the custom iterators defined in composite
			//=====================================================
			foreach (var v in claim.OtherVehicles)
			{
				Console.WriteLine("{0} {1} {2} {3} VIN: {4} {5}", v.VehicleNumber, v.Year, v.Make, v.Model, v.Vin, v.GetValue("TEST"));
			}
			Console.WriteLine("******************************");
			Console.WriteLine(claim.ToXml());
			Console.WriteLine("******************************");
			//=====================================================
			// Test the Xml constructor
			//=====================================================
			var doc = new XmlDocument();
			doc.LoadXml(claim.ToXml());
			var copy = new Claim(doc.DocumentElement);
			copy.SetValue("VEHICLE[2]:TEST", "COPY WORKS TOO!");

			foreach (var v in copy.OtherVehicles)
			{
				Console.WriteLine("{0} {1} {2} {3} VIN: {4} {5}", v.VehicleNumber, v.Year, v.Make, v.Model, v.Vin, v.GetValue("TEST"));
			}
			//=====================================================
			// Test the partial LoadFromXml 
			//=====================================================
			var call = new CallObject();
			call.Claim.ReloadFromXML(doc.DocumentElement);
			Console.WriteLine("******************************");
			Console.WriteLine(call.ToXml());
			Console.WriteLine("******************************");
		}
		/// <summary>
		/// Tests to HTML.
		/// </summary>
		[Test] public void TestToHtml()
		{
			Console.WriteLine(_base.ToHtml());
		}
		/// <summary>
		/// Tests the create instance.
		/// </summary>
		[Test] public void TestCreateInstance()
		{
			_base.Claim.SetValue("PROPERTY[0]:OWNER:NAME_LAST", "OWNER LAST NAME");
			_base.Claim.SetValue("PROPERTY[0]:OWNER:NAME_FIRST", "OWNER FIRST NAME");
			_base.Claim.SetValue("PROPERTY[0]:OWNER:PHONE_WORK", "5556667777");
		}
		/// <summary>
		/// Tests the I serialize.
		/// </summary>
		[Test] public void TestISerialize()
		{
			// serialize -pick a formatter
			var binaryFmt = new BinaryFormatter(); 
			var fs = new FileStream
				("Composite.xml", FileMode.OpenOrCreate);
			binaryFmt.Serialize(fs, _base);
			fs.Close();
			// Deserialize.
			fs = new FileStream
				("Composite.xml", FileMode.OpenOrCreate);
			var p2 = binaryFmt.Deserialize(fs) as CallObject;
			Assert.IsNotNull(p2,"Null returned!");
			Assert.IsNotEmpty(p2.Claim.ClaimNumber, "Something is wrong!");
			Console.WriteLine(p2.Claim.ClaimNumber);
			fs.Close();
		}

		/// <summary> 
		/// Tests the json.
		/// </summary>
		[Test]
		public void TestJson()
		{
			_base.SetValue("CLAIM:VEHICLE[0]:MAKE", "PLYMOUTH");
			_base.SetValue("CLAIM:VEHICLE[0]:MODEL", "VALIANT");
			_base.SetValue("CLAIM:VEHICLE[1]:MAKE", "DODGE");
			_base.SetValue("CLAIM:VEHICLE[1]:MODEL", "RAM");
			_base.SetValue("CLAIM:VEHICLE[2]:MAKE", "TOYOTA");
			_base.SetValue("CLAIM:VEHICLE[2]:MODEL", "CAMRY");
			_base.Instance = "TEST";
			_base.CallStartTime = "12:00 PM";
			_base.CallStartDate = "12/12/2008";
			string script = _base.ToJson();
			Console.WriteLine(script);

			var test = new CallObject();
			
			test.LoadFromJson(script);
			Assert.IsTrue(test.Name == "CALL", "Not working: " + test.Name);

			Assert.IsTrue(test.Instance == "TEST", "Unexpected result INSTANCE!");
			Assert.IsTrue(test.CallStartTime == "12:00 PM", "Unexpected result CALL_START_TIME!");
			Assert.IsTrue(test.CallStartDate == "12/12/2008", "Unexpected result CALL_START_DATE!");
			Assert.IsTrue(test.GetValue("CLAIM:VEHICLE[0]:MODEL") == "VALIANT", "Unexpected result CLAIM:VEHICLE[0]:MODEL!");
			Assert.IsTrue(test.GetValue("CLAIM:VEHICLE[1]:MAKE") == "DODGE", "Unexpected result CLAIM:VEHICLE[1]:MAKE!");
			Assert.IsTrue(test.GetValue("CLAIM:INSURED:VEHICLE:MODEL") == "MATRIX", "Unexpected result CLAIM:INSURED:VEHICLE:MODEL!");
			Assert.IsTrue(test.GetValue("CLAIM:VEHICLE[2]:MODEL") == "CAMRY", "Unexpected result CLAIM:VEHICLE[2]:MODEL!");

			Console.WriteLine(test.ToXml());

            var callObject = new CallObject();
            callObject.LoadFromJson(script);
			Assert.IsNotNull(callObject, "callObject was null!");
			Assert.IsTrue(callObject.GetType() == typeof(CallObject), "type mismatch");

			Console.WriteLine(callObject.Claim.GetType().ToString());
		}

        [Test]
        public void TestObjectJsonRootNotExplicit()
        {
			var testObject = new Composite("Object");
            testObject.SetValue("FirstName", "John");
            testObject.SetValue("LastName", "Gwynn");
            testObject.SetValue("Address:Street", "8 Country Club Drive #1");
            testObject.SetValue("Address:City", "Manchester");
            testObject.SetValue("Address:State", "NH");
            testObject.SetValue("Address:PostalCode", "03102");
			Console.WriteLine(testObject.ToJson());



        }
		/// <summary>
		/// Tests the name values.
		/// </summary>
		[Test]
		public void TestNameValues()
		{
			const string accountId = "ACCOUNT_ID";
			const string policyId = "POLICY_ID";
			_base.SetValue(accountId, "12345");
			_base.SetValue(policyId, "678910");

			var copyCall = new CallObject();
			copyCall.LoadFromXml(_base.ToXml());
			Assert.IsNotEmpty(copyCall.GetValue(accountId));
			Assert.IsNotEmpty(copyCall.GetValue(policyId));
			copyCall.Remove(policyId);
			Assert.IsEmpty(copyCall.GetValue(policyId));

			// subtract method
			var items = _base.ToNameValueCollection();
			foreach (var key in items.AllKeys)
			{
				if (string.IsNullOrEmpty(copyCall.GetValue(key)))
					_base.Remove(key);
			}
			Assert.IsEmpty(_base.GetValue(policyId));
			Console.WriteLine(_base);

		}

		/// <summary>
		/// Tests the compare to.
		/// </summary>
		[Test] public void TestCompareTo()
		{
			var original = new AhsSegment
			               	{
			               		AhsId = "12345",
			               		UploadKey = "TEST",
			               		FullName = "TEST ACCOUNT",
			               		AhsType = "ACCOUNT",
			               		ClientNodeId = "202"
			               	};
			var clone = (AhsSegment)original.Clone();
			Assert.IsTrue(original.CompareTo(clone) == 0, "Something failed!");
			clone.UploadKey = "TEST2";
			Assert.IsTrue(original.CompareTo(clone) < 0, "Something failed!");
			clone.UploadKey = "ABC";
			Assert.IsTrue(original.CompareTo(clone) > 0, "Something failed!");

			var clone2 = (AhsSegment)original.Clone();

			Assert.IsTrue(original == clone2, "Something failed!");
			clone2.UploadKey = "TEST2";
			Assert.IsTrue(original != clone2, "Something failed!");
		}

		/// <summary>
		/// Tests the copy and preserve segment functionality.
		/// </summary>
		[Test]
		public void TestCopyAndPreserve()
		{
			var ahs = new AhsSegment
			          	{
			          		AhsId = "12",
			          		AhsType = "RISK LOCATION",
			          		ActiveStatus = "DEACTIVATED",
			          		FullName = "D. B. SWEENY"
			          	};

			var source = new AhsSegment
			             	{
			             		Address1 = "529 Main Street",
			             		Address2 = "Suite 6000",
			             		City = "Charlestown",
			             		State = "MA",
			             		ActiveStatus = "ACTIVE",
			             		FullName = "D B SWEENEY"
			             	};

			ahs.CopyAndPreserve(source);

			Assert.IsTrue(ahs.AhsId == "12");
			Assert.IsTrue(ahs.Address1 == "529 Main Street");
			Assert.IsTrue(ahs.Address2 == "Suite 6000");
			Assert.IsTrue(ahs.City == "Charlestown");
			Assert.IsTrue(ahs.State == "MA");
			Assert.IsTrue(ahs.ActiveStatus == "ACTIVE");
			Console.WriteLine(ahs.FullName);
		}

		/// <summary>
		/// Tests the tran outcome support.
		/// </summary>
		[Test]
		public void TestTranOutcomeSupport()
		{
			var message = new TranOutcomeSupport
			              	{
			              		TranDone = "12",
			              		TranFailed = "0",
			              		MainThreadId = "12345",
			              		Module = "NUnit",
			              		IdleSpeed = "999",
			              		ProcessId = "8",
			              		LastIdle = DateTime.Now.ToString()

			              	};

			Console.WriteLine(message.ToXml());
		}

		/// <summary>
		/// Tests the tran outcome support.
		/// </summary>
		[Test]
		public void TestTranOutcome()
		{
			var message = new TranOutcome
			              	{
			              		CallId = "1200000",
			              		Status = "INPROC",
			              		TranOutcomeId = "3333",
			              		Type = "CALL_ROUTING",
			              		LastModTime = DateTime.Now.ToString()
			              	};
			Console.WriteLine(message.ToXml());
		}

		[Test]
		public void TestToList()
		{
			const int testInteger = 12;
			var list = testInteger.ToList();
			Assert.IsTrue(list.Count == 1);
			PrintList(list);
			PrintList("Hello World".ToList());
		}

		private static void PrintList<T>(IEnumerable<T> list)
		{
			foreach (var result in list)
				Console.WriteLine(result);
		}
	}
}

/*
 * $Log: /SourceCode/Components/FNS2005/FnsComposite/CompositeTests/CompositeTest.cs $
 * 
 * 5     11/12/10 4:16p Gwynnj
 * NodeNameValueVisitor is only for chidren no depth > 1
 * 
 * 4     10/20/10 10:27p Gwynnj
 * Added suport for ToNameValueDictionary for use in node copy i.e.
 * Affirmative Entities
 * 
 * 3     9/22/10 12:23p Gwynnj
 * Added address constants
 * 
 * 2     9/21/10 6:30p Gwynnj
 * Created EntityBase to factor the IPerson interface
 * 
 * 1     7/13/10 2:08p Gwynnj
 * 
 * 23    4/15/10 7:07a Gwynnj
 * Minor edits
 * 
 * 22    2/24/10 6:46p Gwynnj
 * Added TranOutcome and TranOutcomeSupport message objects for
 * communication with legacy message objects used by OutcomeViewer
 * 
 * 21    2/03/10 6:12p Gwynnj
 * Added ConditionalVisitor for extraction of existing call attributes
 * based on a given pattern using regex (non-xml)
 * 
 * 20    1/06/10 6:43p Gwynnj
 * Added several constants for CallObject namespace
 * 
 * 19    10/13/09 4:32p John.gwynn
 * Added Segment.CopyAndPreserve to do a non-destructive clone of values
 * from a source segment. (does not affect prior values when source column
 * is empty)
 * 
 * 18    9/30/09 6:36p John.gwynn
 * Implemented IComparable for composites adding a virtual Compare method
 * for specialized equality and sorting .e.g. see the AhsSegment where two
 * segments are deemed equal if their upload keys are equal.
 * 
 * 17    7/06/09 7:03p John.gwynn
 * Fixed strongly typed constructor for CallflowEvent objects (loading
 * from Xml) and added NamedValueCollection for set difference operations
 * 
 * 16    5/19/09 1:57p John.gwynn
 * added JSON serialiation
 * 
 * 15    3/20/09 5:50p John.gwynn
 * added JSON serialize OUT - in not quite ready
 * 
 * 14    5/02/08 3:18p John.gwynn
 * 
 * 13    3/16/08 3:33p John.gwynn
 * Implemented ISerializable
 * 
 * 12    1/02/08 4:07p John.gwynn
 * refactored the ICall class interface and implementation to the
 * FnsDomain assembly
 * 
 * 11    11/28/07 11:22a John.gwynn
 * Added CallObject.Property and interface
 * 
 * 10    11/07/07 12:13p John.gwynn
 * Added ToHtml (with raw styles for now)
 * 
 * 9     10/23/07 11:36a John.gwynn
 * Implemented Claim.OtherVehicles
 * 
 * 8     10/22/07 6:08p John.gwynn
 * 
 * 7     10/21/07 3:51p John.gwynn
 * Added CreateInstance mthods to CompositeFactory.  Added CallObjects
 * classes and interface definitions
 * 
 * 6     8/28/07 11:22a John.gwynn
 * modified the LoadFromXml to Copy [retain] elements that alread exist
 * (rather than overwriting them)
 * 
 * 5     8/26/07 10:06a John.gwynn
 * added support for GetXmlTree method to extract subtrees in xml
 * 
 * 4     5/29/07 7:05p John.gwynn
 * new MessageObject set of classes for OPM with some refactoring and
 * gebneral enhancements
 * 
 * 3     4/20/07 5:17p John.gwynn
 * 
 * 2     4/17/07 3:41p John.gwynn
 * update current version synch to 1.1
 * 
 * 19    3/11/07 7:37p John.gwynn
 * First cut for DbClassGenerator
 * 
 * 18    3/09/07 6:21p John.gwynn
 * first cut of the DbClassGen for DbBaseClass generation (Class
 * definition)
 * 
 * 17    3/06/07 6:35p John.gwynn
 * composite based Code generation support added 
 * 
 * 16    2/21/07 2:45p John.gwynn
 * test copy constructor, set equivalence and Equals
 * 
 * 15    2/21/07 11:39a John.gwynn
 * added Operator == and comparison operators as well as Copy
 * constructors...
 * 
 * 14    12/08/06 3:24p John.gwynn
 * Added PolicyLoader MSMQ "football" class from UIF and Messaging.  This
 * will help intergrate the workflow functionality across different tech
 * platforms.
 * 
 * 13    11/16/06 5:20p John.gwynn
 * Added NDoc comments and formatting
 * 
 * 12    11/14/06 10:35a John.gwynn
 * Added Commit to setup.
 * 
 * 11    9/19/06 6:42p John.gwynn
 * Added HasChanged, Commit and Rollback for edits.
 * 
 * 10    9/08/06 2:04p John.gwynn
 * Build modifications [Unit tests]
 * 
 * 9     4/09/06 8:14p John.gwynn
 * FxCop and Resharper reformatting changes
 * 
 * 8     1/07/06 7:33p John.gwynn
 * added overflow iterator (sorted by default)
 */