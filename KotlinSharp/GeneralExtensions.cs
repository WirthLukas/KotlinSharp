﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

#nullable enable

namespace KotlinSharp
{
    public static class GeneralExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Also<T>(this T obj, Action<T> block)
        {
            block(obj);
            return obj;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static R Let<T, R>(this T obj, Func<T, R> block) => block(obj);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Let<T>(this T obj, Action<T> block) => block(obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Apply<T>(this T obj, Action<T> block)
        {
            block(obj);
            return obj;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static R Run<T, R>(this T obj, Func<T, R> block) => block(obj);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Run<T>(this T obj, Action<T> block) => block(obj);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? TakeIf<T>(this T obj, Predicate<T> predicate) where T : class
            => predicate(obj) ? obj : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T TakeUnless<T>(this T obj, Predicate<T> predicate) where T : class
            => predicate(obj) ? null : obj;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (TA, TB) To<TA, TB>(this TA obj, TB that)
            => (obj, that);
        
        public static string ToStringK<T>(this T? obj) where T : class
        {
            return obj is null ? "null" : obj.ToString();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static R Use<T, R>(this T obj, Func<T, R> block) where T : IDisposable
        {
            using (obj)
            { 
                return block(obj);
            }
        }
    }
}