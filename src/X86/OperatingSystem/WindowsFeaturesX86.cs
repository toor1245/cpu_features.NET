using CpuFeaturesDotNet.Native.OperatingSystem;
using static CpuFeaturesDotNet.X86.CpuInfoX86.FeaturesX86;

namespace CpuFeaturesDotNet.X86.OperatingSystem
{
    internal sealed class WindowsFeaturesX86 : OsBaseFeaturesX86
    {
        public override void SetRegistersXcr0NotAvailable()
        {
            IsSupportedSSE = WindowsNative.GetWindowsIsProcessorFeaturePresent(WindowsNative.PF_XMMI_INSTRUCTIONS_AVAILABLE);
            IsSupportedSSE2 = WindowsNative.GetWindowsIsProcessorFeaturePresent(WindowsNative.PF_XMMI64_INSTRUCTIONS_AVAILABLE);
            IsSupportedSSE3 = WindowsNative.GetWindowsIsProcessorFeaturePresent(WindowsNative.PF_SSE3_INSTRUCTIONS_AVAILABLE);
        }
    }
}