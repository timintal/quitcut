using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Common
{
    public static class MathExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 xy0(this float2 v)
        {
            return new float3(v.x, v.y, 0);
        }
    }
}