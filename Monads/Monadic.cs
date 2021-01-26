using System;
using System.Collections.Generic;

namespace FnsComposite.Monads
{
    /// <summary>
    /// 
    /// </summary>
    public static class Monadic
    {
        /// <summary>
        /// Anies the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static bool Any<TSource>(this TSource source)
        {
            return !Equals(source, default(TSource));
        }

        /// <summary>
        /// Anies the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static bool Any<TSource>(this TSource source, Func<TSource, bool> predicate)
        {
            return predicate(source);
        }

        /// <summary>
        /// Concats the specified first.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Concat<TSource>(this TSource first, TSource second)
        {
            yield return first;
            yield return second;
        }

        /// <summary>
        /// Orders the by.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <returns></returns>
        public static TSource OrderBy<TSource, TKey>(this TSource source, Func<TSource, TKey> keySelector)
        {
            return source;
        }

        /// <summary>
        /// Orders the by.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns></returns>
        public static TSource OrderBy<TSource, TKey>(this TSource source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return source;
        }

        /// <summary>
        /// Orders the by descending.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <returns></returns>
        public static TSource OrderByDescending<TSource, TKey>(this TSource source, Func<TSource, TKey> keySelector)
        {
            return source;
        }

        /// <summary>
        /// Orders the by descending.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns></returns>
        public static TSource OrderByDescending<TSource, TKey>(this TSource source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return source;
        }

        /// <summary>
        /// Selects the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        //public static TResult Select<TSource, TResult>(this TSource source, Func<TSource, TResult> selector)
        //{
        //    return selector(source);
        //}

        /// <summary>
        /// Selects the many.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TCollection">The type of the collection.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="collectionSelector">The collection selector.</param>
        /// <param name="resultSelector">The result selector.</param>
        /// <returns></returns>
        //public static TResult SelectMany<TSource, TCollection, TResult>(this TSource source, Func<TSource, TCollection> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        //{
        //    return resultSelector(source, collectionSelector(source));
        //}

        /// <summary>
        /// Toes the enumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> ToEnumerable<TSource>(this TSource source)
        {
            return new[] { source };
        }

        /// <summary>
        /// Toes the func.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static Func<TSource> ToFunc<TSource>(this TSource source)
        {
            return () => source;
        }

        /// <summary>
        /// Y combinator circuit for single value functional composition 
        /// </summary>
// ReSharper disable InconsistentNaming
         public static Func<T, V> Compose<T, U, V>(this Func<U, V> f, Func<T, U> g)
// ReSharper restore InconsistentNaming
        {
            return x => f(g(x));
        }

         /// <summary>
         /// Monadic Identity 
         /// </summary>
         public static T Identity<T>(this T value)
         {
             return value;
         }
    }
}
