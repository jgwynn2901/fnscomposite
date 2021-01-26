using System.Xml;

namespace FnsComposite.CallObjects
{
	public class EntityBase : CallObjectBase, IPerson
	{
		public const string FirstNameAttribute = "NAME_FIRST";
		public const string LastNameAttribute = "NAME_LAST";
		public const string MiddleNameAttribute = "NAME_MID";
		public const string HomePhoneAttribute = "PHONE_HOME";
		public const string WorkPhoneAttribute = "PHONE_WORK";

		public EntityBase(string nodeName)
			: base(nodeName)
		{}

		public EntityBase(XmlNode node)
			: base(node)
		{}

		public EntityBase(XmlNode node, string indexedName) 
			: base(node, indexedName)
		{}

		public string NameFirst
		{
			get { return GetValue(FirstNameAttribute); }
			set { SetValue(FirstNameAttribute, value); }
		}

		public string NameLast
		{
			get { return GetValue(LastNameAttribute); }
			set { SetValue(LastNameAttribute, value); }
		}

		public string NameMid
		{
			get { return GetValue(MiddleNameAttribute); }
			set { SetValue(MiddleNameAttribute, value); }
		}

		public string PhoneHome
		{
			get { return GetValue(HomePhoneAttribute); }
			set { SetValue(HomePhoneAttribute, value); }
		}

		public string PhoneWork
		{
			get { return GetValue(WorkPhoneAttribute); }
			set { SetValue(WorkPhoneAttribute, value); }
		}
	}
}
