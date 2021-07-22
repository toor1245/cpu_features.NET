using CpuFeaturesDotNet.Native.OperatingSystem;
using static CpuFeaturesDotNet.X86.CpuInfoX86.FeaturesX86;

namespace CpuFeaturesDotNet.X86.OperatingSystem
{
    internal sealed class DarwinFeaturesX86 : OsBaseFeaturesX86
    {
        public override void SetRegistersXcr0NotAvailable()
        {
            IsSupportedSSE = DarwinNative.GetDarwinSysCtlByName("hw.optional.sse");
            IsSupportedSSE2 = DarwinNative.GetDarwinSysCtlByName("hw.optional.sse2");
            IsSupportedSSE3 = DarwinNative.GetDarwinSysCtlByName("hw.optional.sse3");
            IsSupportedSSSE3 = DarwinNative.GetDarwinSysCtlByName("hw.optional.supplementalsse3");
            IsSupportedSSE41 = DarwinNative.GetDarwinSysCtlByName("hw.optional.sse4_1");
            IsSupportedSSE42 = DarwinNative.GetDarwinSysCtlByName("hw.optional.sse4_2");
        }
    }
}