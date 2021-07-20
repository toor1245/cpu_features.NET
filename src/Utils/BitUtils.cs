using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CpuFeaturesDotNet.UnitTesting")]
namespace CpuFeaturesDotNet.Utils
{
    internal static unsafe class BitUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBitSet(uint register, int bit)
        {
            return ((register >> bit) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ExtractBitRange(uint register, uint msb, uint lsb)
        {
            var bits = msb - lsb + 1UL;
            var mask = (1UL << (int)bits) - 1UL;
            return (uint)((register >> (int)lsb) & mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetByteArrayFromRegister(uint* byteArray, uint register)
        {
            for (var i = 0; i < 4; ++i)
            {
                byteArray[i] = ExtractBitRange(register, (uint)((i + 1) * 8), (uint)(i * 8));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsValidInfo(uint register)
        {
            return (register & (1U << 31)) == 0;
        }
    }
}