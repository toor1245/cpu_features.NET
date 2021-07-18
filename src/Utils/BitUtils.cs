using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CpuFeaturesDotNet.UnitTesting")]
namespace CpuFeaturesDotNet.Utils
{
    internal static class BitUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsBitSet(uint register, int bit)
        {
            return ((register >> bit) & 0x1) != 0;
        }

        internal static uint ExtractBitRange(uint register, uint msb, uint lsb)
        {
            var bits = msb - lsb + 1UL;
            var mask = (1UL << (int)bits) - 1UL;
            return (uint)((register >> (int)lsb) & mask);
        }
    }
}