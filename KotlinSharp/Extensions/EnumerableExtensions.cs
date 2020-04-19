using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using KotlinSharp.Types;

namespace KotlinSharp
{
    public static class EnumerableExtensions
    {
        public static string JoinToString<T>([NotNull]this IEnumerable<T> enumerable, string separator = ", ")
        {
            if (separator == null) throw new ArgumentNullException(nameof(separator));

            var builder = new StringBuilder();
            bool firstElement = true;

            foreach (var item in enumerable)
            {
                if (firstElement)
                {
                    builder.Append(item);
                    firstElement = false;
                }
                else
                {
                    builder.Append(separator + item);
                }
            }

            return builder.ToString();
        }

        public static void ForEach<T>([NotNull]this IEnumerable<T> enumerable, [NotNull]Action<T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var items = enumerable.ToArray();

            foreach (var item in items)
                action(item);
        }

        public static void ForEachIndexed<T>([NotNull]this IEnumerable<T> enumerable, [NotNull]Action<int, T> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            var items = enumerable.ToList();

            foreach (var (index, value) in items.GetEnumerator().WithIndex())
                action(index, value);
        }

        /// <summary>
        /// If you use this Method in a Linq query, you should use it only after ToList or ToArray
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<(int Index, T Value)> WithIndex<T>([NotNull]this IEnumerable<T> enumerable)
        {
            return enumerable.GetEnumerator().WithIndex();
        }
    }
}
