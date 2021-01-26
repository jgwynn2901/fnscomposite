using System;

namespace FnsComposite.Monads
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public struct Monad<T>
	{
		private readonly T _value;

		/// <summary>
		/// Initializes a new instance of the <see cref="Monad&lt;T&gt;"/> struct.
		/// </summary>
		/// <param name="value">The value.</param>
		public Monad(T value)
		{
			_value = value;
		}

		/// <summary>
		/// Gets the Identity.Value.
		/// </summary>
		public T Value { get { return _value; } }

		/// <summary>
		/// Binds the specified func.
		/// </summary>
		/// <typeparam name="TU"></typeparam>
		/// <param name="func">The func.</param>
		/// <returns></returns>
		public Monad<TU> Bind<TU>(Func<T, Monad<TU>> func)
		{
			return func(_value);
		}

		/// <summary>
		/// Selects the specified selector.
		/// </summary>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="selector">The selector.</param>
		/// <returns></returns>
		public Monad<TResult> Select<TResult>(Func<T, TResult> selector)
		{
			return Monad.Create(selector(_value));
		}

		/// <summary>
		/// Selects the many.
		/// </summary>
		/// <typeparam name="TU"></typeparam>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="selector">The selector.</param>
		/// <param name="resultSelector">The result selector.</param>
		/// <returns></returns>
		public Monad<TResult> SelectMany<TU, TResult>(Func<T, Monad<TU>> selector, Func<T, TU, TResult> resultSelector)
		{
			return Monad.Create(resultSelector(_value, selector(_value).Value));
		}

		public override string ToString()
		{
			return _value.ToString();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public static class Monad
	{
		/// <summary>
		/// Creates the specified monad.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value">The value instance.</param>
		/// <returns></returns>
		public static Monad<T> Create<T>(T value)
		{
			return new Monad<T>(value);
		}

		/// <summary>
		/// Maybe monad for processing results from hierarchies 
		/// that are quite possibly null (DataContracts XElements etc.)
		/// </summary>
		/// <typeparam name="TInput">The default type of the input.</typeparam>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="instance">The this</param>
		/// <param name="evaluator">The evaluator.</param>
		public static TResult With<TInput, TResult>(this TInput instance, Func<TInput, TResult> evaluator)
			where TResult : class
			where TInput : class
		{
			return instance == default(TInput)
				? default(TResult)
				: evaluator(instance);
		}

		/// <summary>
		/// Returns the specified object if not null otherwise specified value.
		/// </summary>
		/// <typeparam name="TInput">The type of the input.</typeparam>
		/// <typeparam name="TResult">The type of the result.</typeparam>
		/// <param name="instance">The instance.</param>
		/// <param name="evaluator">The evaluator.</param>
		/// <param name="failureValue">The failure value.</param>
		/// <returns></returns>
        public static TResult Return<TInput, TResult>(this TInput instance, Func<TInput, TResult> evaluator, TResult failureValue) where TInput : class
		{
// ReSharper disable RedundantCast
            return (object)instance == null
// ReSharper restore RedundantCast
				? failureValue
				: evaluator(instance);
		}

        public static string Return<TInput>(this TInput instance, Func<TInput, string> evaluator)  where TInput : class 
        {
            // ReSharper disable RedundantCast
            return instance != null
               ? evaluator(instance) ?? string.Empty
               : string.Empty;
        }

		/// <summary>
		/// returns instance if predicate is true.
		/// </summary>
		public static TInput If<TInput>(this TInput instance, Func<TInput, bool> evaluator)
			where TInput : class
		{
			if (instance == null) return null;
			return evaluator(instance) 
				? instance 
				: null;
		}

		/// <summary>
		/// returns instance if predicate is false.
		/// </summary>
		public static TInput Unless<TInput>(this TInput instance, Func<TInput, bool> evaluator)
		  where TInput : class
		{
			if (instance == null) return null;
			return evaluator(instance) 
				? null 
				: instance;
		}

		/// <summary>
		/// Executes the specified operation if instance not null.
		/// </summary>
		public static TInput Do<TInput>(this TInput instance, Action<TInput> action)
		  where TInput : class
		{
			if (instance == null) return null;
			action(instance);
			return instance;
		}

	}
}
