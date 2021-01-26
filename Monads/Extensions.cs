using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace FnsComposite.Monads
{
    public static class Extensions
    {
        public static IEnumerable<KeyValuePair<string, string>> ToPairs(this NameValueCollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            return collection.Cast<string>().Select(key => new KeyValuePair<string, string>(key, collection[key]));
        }

        public static IDictionary<string, string> ToDictionary(this NameValueCollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            return collection.Cast<string>().Select(s => new { Key = s, Value = collection[s] }).ToDictionary(p => p.Key, p => p.Value);
        }

        public static Func<T2, TResult> Partial<T1, T2, TResult>(this Func<T1, T2, TResult> f, T1 a)
        {
            return b => f(a, b);
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            return new HashSet<T>(source);
        }
    }
}
