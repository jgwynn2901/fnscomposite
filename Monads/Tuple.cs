using System.Collections.Generic;

namespace FnsComposite.Monads
{
	/// <summary>
	/// Represents a container with two objects
	/// Note: This is for C# 3.5 and will be replaced by c# 4.0 Tuple
	/// </summary>
	/// <typeparam name="T1"></typeparam>
	/// <typeparam name="T2"></typeparam>
	public class Tuple<T1, T2> : IEqualityComparer<Tuple<T1, T2>>
	{
		/// <summary>
		/// First item
		/// </summary>
		public T1 First { get; private set; }

		/// <summary>
		/// Second item
		/// </summary>
		public T2 Second { get; private set; }

		/// <summary>
		/// Constructor
		/// </summary>
		public Tuple(T1 first, T2 second)
		{
			First = first;
			Second = second;
		}

		/// <summary>
		/// Creates the specified first.
		/// </summary>
		public static Tuple<T1, T2> Create(T1 first, T2 second)
		{
			return new Tuple<T1, T2>(first, second);
		}

		/// <summary>
		/// Checks for equality
		/// </summary>
		public bool Equals(Tuple<T1, T2> x, Tuple<T1, T2> y)
		{
			return EqualityComparer<T1>.Default.Equals(x.First, y.First)
		  && EqualityComparer<T2>.Default.Equals(x.Second, y.Second);
		}

		/// <summary>
		/// Checks for equality
		/// </summary>
		public override bool Equals(object obj)
		{
			return obj is Tuple<T1, T2> && Equals(this, (Tuple<T1, T2>)obj);
		}

		/// <summary>
		/// Returns the hash code of a object
		/// </summary>
		public int GetHashCode(Tuple<T1, T2> obj)
		{
			return EqualityComparer<T1>.Default.GetHashCode(First) ^
		  EqualityComparer<T2>.Default.GetHashCode(Second);
		}

		/// <summary>
		/// Overrides the == operator
		/// </summary>
		public static bool operator ==(Tuple<T1, T2> left, Tuple<T1, T2> right)
		{
			if (((object)left) == null && ((object)right) == null)
				return true;

			return (left != null)
							? !left.Equals(right)
							: false;
		}

		/// <summary>
		/// Overrides the != operator
		/// </summary>
		public static bool operator !=(Tuple<T1, T2> left, Tuple<T1, T2> right)
		{
			if (((object)left) == null && ((object)right) == null)
				return true;

			return (left != null)
				? !left.Equals(right)
				: false;
		}

		/// <summary>
		/// Equalses the specified other.
		/// </summary>
		public bool Equals(Tuple<T1, T2> other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.First, First) && Equals(other.Second, Second);
		}

		/// <summary>
		/// Serves as a hash function for a particular type.
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"/>.
		/// </returns>
		public override int GetHashCode()
		{
			unchecked
			{
				return (First.GetHashCode() * 397) ^ Second.GetHashCode();
			}
		}
	}

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1">The type of the 1.</typeparam>
    public class Tuple<T1> : Tuple<T1, T1>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tuple&lt;T1&gt;"/> class.
        /// </summary>
        /// <param name="first">The first.</param>
        public Tuple(T1 first) : base(first, default(T1))
        {}
    }


	/// <summary>
	/// Represents a container which contains three object
	/// </summary>
	public class Tuple<T1, T2, T3>
		: Tuple<T1, T2>, IEqualityComparer<Tuple<T1, T2, T3>>
	{
		/// <summary>
		/// Third item
		/// </summary>
		public T3 Third { get; private set; }

		/// <summary>
		/// Constructor
		/// </summary>
		public Tuple(T1 first, T2 second, T3 third)
			: base(first, second)
		{
			Third = third;
		}

		/// <summary>
		/// Checks for equality
		/// </summary>
		public bool Equals(Tuple<T1, T2, T3> x, Tuple<T1, T2, T3> y)
		{
			return EqualityComparer<T1>.Default.Equals(x.First, y.First) &&
		  EqualityComparer<T2>.Default.Equals(x.Second, y.Second) &&
		  EqualityComparer<T3>.Default.Equals(x.Third, y.Third);
		}

		/// <summary>
		/// Checks for equality of a specific object
		/// </summary>
		public override bool Equals(object obj)
		{
			return obj is Tuple<T1, T2, T3> && Equals(this, (Tuple<T1, T2, T3>)obj);
		}

		/// <summary>
		/// Returns the hash code of a specific object
		/// </summary>
		/// <returns></returns>
		public int GetHashCode(Tuple<T1, T2, T3> obj)
		{
			return EqualityComparer<T1>.Default.GetHashCode(First) ^
		  EqualityComparer<T2>.Default.GetHashCode(Second) ^
		  EqualityComparer<T3>.Default.GetHashCode(Third);
		}

		/// <summary>
		/// Overrides the == operator
		/// </summary>
		public static bool operator ==(Tuple<T1, T2, T3> left,
									   Tuple<T1, T2, T3> right)
		{
			if (((object)left) == null && ((object)right) == null)
				return true;

			return (left != null)
					? left.Equals(right)
					: false;
		}

		/// <summary>
		/// Overrides the != operator
		/// </summary>
		public static bool operator !=(Tuple<T1, T2, T3> left,
									   Tuple<T1, T2, T3> right)
		{
			if (((object)left) == null && ((object)right) == null)
				return true;

			if (left != null) return !left.Equals(right);
			return false;
		}

		/// <summary>
		/// Equalses the specified other.
		/// </summary>
		public bool Equals(Tuple<T1, T2, T3> other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return base.Equals(other) && Equals(other.Third, Third);
		}

		/// <summary>
		/// Serves as a hash function for a particular type.
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"/>.
		/// </returns>
		public override int GetHashCode()
		{
			unchecked
			{
				{
					return (base.GetHashCode() * 397) ^ Third.GetHashCode();
				}
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public static class TupleExtensions
	{
		/// <summary>
		/// Withes the second.
		/// </summary>
		public static Tuple<T1, T2> WithSecond<T1, T2>(this Tuple<T1, T2> tuple, T2 second)
		{
			return new Tuple<T1, T2>(tuple.First, second);
		}

        /// <summary>
        /// Tries the get tuple.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static Tuple<bool, T2> TryGetTuple<T1, T2>(this IDictionary<T1, T2> dictionary, T1 key)
        {
            T2 results;
            return dictionary.TryGetValue(key, out results)
                ? Tuple<bool, T2>.Create(true, results)
                : Tuple<bool, T2>.Create(false, default(T2));
        }
	}
}
