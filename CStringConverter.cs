using System.IO;
using System.Text;
using System;
using System.Runtime.InteropServices;

namespace FnsComposite
{
	/// <summary>
	/// 
	/// </summary>
	[ComVisible(false)]
	public struct CStringConverter
	{
	  private readonly string _contents;
		private const byte LargeSizeIndicator = 255;


		/// <summary>
		/// Initializes a new instance of the <see cref="CStringConverter"/> struct.
		/// </summary>
		/// <param name="reader">The reader.</param>
		public CStringConverter(BinaryReader reader) : this(reader, false)
		{}

		/// <summary>
		/// Initializes a new instance of the <see cref="CStringConverter"/> struct.
		/// </summary>
		public CStringConverter(BinaryReader reader, bool useWord)
		{
		  int length;
		  var results = new StringBuilder();
			if (useWord)
				length = reader.ReadInt16();
			else
			{
				length = reader.ReadByte();
				if (length == LargeSizeIndicator)
					length = reader.ReadInt16();
			}

			for (var i = 0; i < length; ++i)
				results.Append(reader.ReadChar());

			_contents = results.ToString();
		}

		/// <summary>
		/// Writes string the specified writer.
		/// </summary>
		static public BinaryWriter Write(BinaryWriter writer, string contents)
		{
			return Write(writer, contents, false);
		}

		/// <summary>
		/// Writes string the specified writer.
		/// </summary>
		static public BinaryWriter Write(BinaryWriter writer, string contents, bool useWord)
		{
			if (useWord)
			{
				var len = (short)contents.Length;
				writer.Write(len);
			}
			else if (contents.Length > 254)
			{
				writer.Write(LargeSizeIndicator);
				writer.Write((short)contents.Length);
			}
			else
			{
				var len = (byte)contents.Length;
				writer.Write(len);
			}
			foreach (var t in contents)
			  writer.Write(t);

		  return writer;
		}

		/// <summary>
		/// Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <param name="obj">Another object to compare to.</param>
		/// <returns>
		/// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
		/// </returns>
		public override bool Equals(object obj)
		{
			return _contents.Equals(obj);
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>
		/// A 32-bit signed integer that is the hash code for this instance.
		/// </returns>
		public override int GetHashCode()
		{
			return _contents.GetHashCode();
		}

		/// <summary>
		/// Returns the fully qualified type name of this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> containing a fully qualified type name.
		/// </returns>
		public override string ToString()
		{
			return _contents;
		}
		/// <summary>
		/// Gets the contents.
		/// </summary>
		/// <value>The contents.</value>
		public string Contents
		{
			get { return _contents; }
		}
	}

	/// <summary>
	/// 
	/// </summary>
	[ComVisible(false)]
	public struct CTimeConverter
	{
		private DateTime _dateTime;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTimeConverter"/> struct.
		/// </summary>
		/// <param name="reader">The reader.</param>
		public CTimeConverter(BinaryReader reader)
		{
			var ctime = reader.ReadInt32();
			_dateTime = CTimeToDate(ctime);
		}

		/// <summary>
		/// Returns the fully qualified type name of this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> containing a fully qualified type name.
		/// </returns>
		public override string ToString()
		{
			return _dateTime.ToString("s");
		}

		/// <summary>
		/// Cs the time to date.
		/// </summary>
		/// <param name="cTime">The C time.</param>
		/// <returns></returns>
		static DateTime CTimeToDate(long cTime)
		{
			var span = TimeSpan.FromTicks(cTime * TimeSpan.TicksPerSecond);
			var t = new DateTime(1970, 1, 1).Add(span);
			return TimeZone.CurrentTimeZone.ToLocalTime(t);
		}

		/// <summary>
		/// convert Date to CTime.
		/// </summary>
		public static int DateToCTime(DateTime date)
		{
			var t = new DateTime(1970, 1, 1);
			var span = date - t;
			return (int)span.TotalSeconds;

			
		}
	}

	/// <summary>
	/// encapsulate the MFC serialization trickery
	/// </summary>
	[ComVisible(false)]
	public struct WordReader
	{
		private readonly int _results;
		private const ushort LargeCountIndicator = 65535;

		WordReader(BinaryReader reader)
		{
			_results = reader.ReadInt16();
		}

		int Results
		{
			get { return _results; }
		}

		/// <summary>
		/// Reads the count.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <returns></returns>
		public static long ReadCount(BinaryReader reader)
		{
		  var current = new WordReader(reader);

		  return current.Results == LargeCountIndicator 
        ? reader.ReadInt32() 
        : current._results;
		}

	  /// <summary>
		/// Writes the count.  Encapsulates MFC funny business
		/// </summary>
		public static BinaryWriter WriteCount(BinaryWriter writer, int count)
		{
			if (count >= LargeCountIndicator)
			{
				writer.Write(LargeCountIndicator);
				writer.Write(count);
			}
			else
				writer.Write((short)count);

			return writer;
		}

	}
}
