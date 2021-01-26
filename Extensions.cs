using System;
using System.Collections.Generic;

namespace FnsComposite
{
    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Convert a single instance to an IEnumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="individual">The individual.</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this T individual)
        {
           return new List<T> {individual};
        }

        /// <summary>
		/// creates a set from original sequence to eliminate duplicates
		/// T must be IComparable
		/// </summary>
		public static HashSet<T> ToSet<T>(this IEnumerable <T> source) where T: IComparable<T>
		{
			var results = new HashSet<T>();
			foreach (var record in source)
				if(!results.Contains(record))
					results.Add(record);
			return results;
		}
    }
}
