using System.Runtime.InteropServices;
using static CpuFeaturesDotNet.Native.DllPath;

namespace CpuFeaturesDotNet.Native.OperatingSystem
{
    public static class OSNative
    {
        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_os_windows")]
        public static extern bool IsWindows();

        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_os_linux_android")]
        public static extern bool IsLinuxOrAndroid();

        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_os_android")]
        public static extern bool IsAndroid();

        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_os_darwin")]
        public static extern bool IsDarwin();

        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_os_freebsd")]
        public static extern bool IsFreeBsd();
    }
}