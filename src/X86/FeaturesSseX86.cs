using CpuFeaturesDotNet.Native.OperatingSystem;
using static CpuFeaturesDotNet.Utils.BitUtils;

namespace CpuFeaturesDotNet.X86
{
    public static partial class CpuInfoX86
    {
        public static partial class FeaturesX86
        {
            public static bool IsSupportedSSE { get; private set; }
            public static bool IsSupportedSSE2 { get; private set; }
            public static bool IsSupportedSSE3 { get; private set; }
            public static bool IsSupportedSSSE3 { get; private set; }
            public static bool IsSupportedSSE41 { get; private set; }
            public static bool IsSupportedSSE42 { get; private set; }
            public static bool IsSupportedSSE4A { get; private set; }

            private static void SetSeeRegisters(in Leaf leaf1)
            {
                IsSupportedSSE = IsBitSet(leaf1.edx, 25);
                IsSupportedSSE2 = IsBitSet(leaf1.edx, 26);
                IsSupportedSSE3 = IsBitSet(leaf1.ecx, 0);
                IsSupportedSSSE3 = IsBitSet(leaf1.ecx, 9);
                IsSupportedSSE41 = IsBitSet(leaf1.ecx, 19);
                IsSupportedSSE42 = IsBitSet(leaf1.ecx, 20);
            }

            private static void SetRegistersXcr0NotAvailable()
            {
                if (OSNative.IsWindows())
                {
                    SetRegistersXcr0NotAvailableWindows();
                }
                else if (OSNative.IsDarwin())
                {
                    SetRegistersXcr0NotAvailableDarwin();
                }
            }

            private static void SetRegistersXcr0NotAvailableWindows()
            {
                IsSupportedSSE = WindowsNative.GetWindowsIsProcessorFeaturePresent(WindowsNative.PF_XMMI_INSTRUCTIONS_AVAILABLE);
                IsSupportedSSE2 = WindowsNative.GetWindowsIsProcessorFeaturePresent(WindowsNative.PF_XMMI64_INSTRUCTIONS_AVAILABLE);
                IsSupportedSSE3 = WindowsNative.GetWindowsIsProcessorFeaturePresent(WindowsNative.PF_SSE3_INSTRUCTIONS_AVAILABLE);
            }

            private static void SetRegistersXcr0NotAvailableDarwin()
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
}