using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Utils;

namespace CpuFeaturesDotNet.X86
{
    [StructLayout(LayoutKind.Sequential)]
    internal ref struct Leaf
    {
        public uint eax, ebx, ecx, edx;

        internal static Leaf SafeCpuId(uint maxExtensionCpuId, uint leafId, int ecx = 0)
        {
            return leafId <= maxExtensionCpuId ? UtilsX86.CpuId(leafId, ecx) : new Leaf();
        }
    }
}