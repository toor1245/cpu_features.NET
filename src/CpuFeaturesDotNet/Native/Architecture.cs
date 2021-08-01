using System.Runtime.InteropServices;

namespace CpuFeaturesDotNet.Native
{
    public static class Architecture
    {
        [DllImport(DllPath.X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_arch_X86")]
        public static extern bool IsArchX86();

        [DllImport(DllPath.X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_arch_X86_32")]
        public static extern bool IsArchX86_32();

        [DllImport(DllPath.X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_arch_X86_64")]
        public static extern bool IsArchX86_64();

        [DllImport(DllPath.ARM_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_arch_arm_any")]
        public static extern bool IsArchArmAny();
    }
}