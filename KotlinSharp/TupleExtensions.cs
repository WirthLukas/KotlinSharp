using System.Collections.Generic;

namespace KotlinSharp
{
    public static class TupleExtensions
    {
        public static List<T> ToList<T>(this (T, T) tuple)
            => new List<T> {tuple.Item1, tuple.Item2};
        
        public static List<T> ToList<T>(this (T, T, T) tuple)
            => new List<T> { tuple.Item1, tuple.Item2, tuple.Item3 };
    }
}