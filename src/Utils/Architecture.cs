using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Native;

namespace CpuFeaturesDotNet.Utils
{
    public static class Architecture
    {
        [DllImport(DllPath.X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__is_arch_X86")]
        public static extern bool IsArchX86();

        [DllImport(DllPath.X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__is_arch_X86_32")]
        public static extern bool IsArchX86_32();

        [DllImport(DllPath.X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__is_arch_X86_64")]
        public static extern bool IsArchX86_64();
    }
}