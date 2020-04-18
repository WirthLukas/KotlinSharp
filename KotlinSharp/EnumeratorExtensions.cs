using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace KotlinSharp
{
    public static class EnumeratorExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<(int Index, T Value)> WithIndex<T>(this IEnumerator<T> enumerator)
        {
            return new IndexedEnumerator<T>(enumerator);
        }

        public struct IndexedEnumerator<T>
            : IEnumerator<(int Index, T Value)>, IEnumerable<(int Index, T Value)>
        {
            private readonly IEnumerator<T> _enumerator;
            private int _index;

            public (int Index, T Value) Current => (_index, _enumerator.Current);
            object? IEnumerator.Current => Current;

            public IndexedEnumerator([NotNull] IEnumerator<T> enumerator)
            {
                _enumerator = enumerator ?? throw new ArgumentNullException(nameof(enumerator));
                _index = 0;
            }

            public bool MoveNext()
            {
                _index++;
                return _enumerator.MoveNext();
            }

            public void Reset()
            {
                _index = 0;
                _enumerator.Reset();
            }

            public void Dispose() => _enumerator.Dispose();

            public IEnumerator<(int Index, T Value)> GetEnumerator() => this;

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
