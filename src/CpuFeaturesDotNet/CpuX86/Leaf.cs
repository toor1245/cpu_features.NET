using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Utils;

namespace CpuFeaturesDotNet.X86
{
    [StructLayout(LayoutKind.Sequential)]
    internal ref struct Leaf
    {
        public uint eax, ebx, ecx, edx;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Leaf CpuId(uint leafId, int ecx = 0)
        {
            return UtilsX86.cpuid(leafId, ecx);
        }

        internal static Leaf SafeCpuId(uint maxExtensionCpuId, uint leafId, int ecx = 0)
        {
            return leafId <= maxExtensionCpuId ? CpuId(leafId, ecx) : new Leaf();
        }
    }
}