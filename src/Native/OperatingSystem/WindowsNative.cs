using System.Runtime.InteropServices;
using static CpuFeaturesDotNet.Native.DllPath;

namespace CpuFeaturesDotNet.Native.OperatingSystem
{
    internal static class WindowsNative
    {
        internal const int PF_XMMI_INSTRUCTIONS_AVAILABLE = 6;
        internal const int PF_XMMI64_INSTRUCTIONS_AVAILABLE = 10;
        internal const int PF_SSE3_INSTRUCTIONS_AVAILABLE = 13;

        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__windows_is_processor_feature_present")]
        internal static extern bool GetWindowsIsProcessorFeaturePresent(int processorFeature);
    }
}