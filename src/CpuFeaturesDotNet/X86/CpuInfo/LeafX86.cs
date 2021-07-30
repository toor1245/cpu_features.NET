using System.Runtime.InteropServices;
using static CpuFeaturesDotNet.Native.DllPath;

namespace CpuFeaturesDotNet.X86
{
    [StructLayout(LayoutKind.Sequential)]
    internal readonly struct LeafX86
    {
        public readonly uint eax, ebx, ecx, edx;

        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cpuid")]
        internal static extern LeafX86 CpuId(uint leafId, int ecx = 0);

        internal static LeafX86 SafeCpuId(uint maxExtensionCpuId, uint leafId, int ecx = 0)
        {
            return leafId <= maxExtensionCpuId ? CpuId(leafId, ecx) : new LeafX86();
        }
    }
}