using System.Runtime.CompilerServices;

namespace KotlinSharp
{
    public static class NumberExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this int number)
        {
            return number;
        }
    }
}
