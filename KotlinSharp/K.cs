using System;
using System.Runtime.CompilerServices;

#nullable enable

namespace KotlinSharp
{
    public static class K
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Repeat(int times, Action<int> action)
        {
            for (int i = 0; i < times; i++)
                action(i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T RequireNotNull<T>(T? value) where T : class
        {
            return value ?? throw new ArgumentNullException(nameof(value));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Run<T>(Func<T> block) => block();

        // Should return Result
        /*public static T RunCatching<T>(Func<T> block)
        {
            try
            {
                return block();
            }
            catch (Exception ex)
            {
                throw;
            }
        }*/

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Synchronized<TResult>(object locker, Func<TResult> block)
        {
            lock (locker)
            {
                return block();
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult With<T, TResult>(T receiver, Func<T, TResult> block) => block(receiver);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void With<T>(T receiver, Action<T> block) => block(receiver);
    }
}