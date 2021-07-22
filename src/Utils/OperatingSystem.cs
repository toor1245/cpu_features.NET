using System.Runtime.InteropServices;
using static CpuFeaturesDotNet.Native.DllPath;

namespace CpuFeaturesDotNet.Utils
{
    public static class OSNative
    {
        internal const int WINDOWS_PF_XMMI_INSTRUCTIONS_AVAILABLE = 6;
        internal const int WINDOWS_PF_XMMI64_INSTRUCTIONS_AVAILABLE = 10;
        internal const int WINDOWS_PF_SSE3_INSTRUCTIONS_AVAILABLE = 13;
        
        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__is_os_windows")]
        public static extern bool IsWindows();
        
        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__is_os_linux_android")]
        public static extern bool IsLinuxOrAndroid();
        
        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__is_os_android")]
        public static extern bool IsAndroid();
        
        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__is_os_darwin")]
        public static extern bool IsDarwin();

        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__is_os_freebsd")]
        public static extern bool IsFreeBsd();

        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__darwin_sysctlbyname")]
        internal static extern bool GetDarwinSysCtlByName(string name);
        
        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__windows_is_processor_feature_present")]
        internal static extern bool GetWindowsIsProcessorFeaturePresent(int processorFeature);
    }
}