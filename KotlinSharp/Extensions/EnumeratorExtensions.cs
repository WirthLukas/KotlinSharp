using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using KotlinSharp.Types;

namespace KotlinSharp
{
    public static class EnumeratorExtensions
    {
        // TODO: Support for Array IEnumerator
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<(int Index, T Value)> WithIndex<T>([NotNull]this IEnumerator<T> enumerator)
        {
            return new IndexedIterator<T>(enumerator);
        }
    }
}
