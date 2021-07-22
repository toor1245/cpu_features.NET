namespace CpuFeaturesDotNet.X86
{
    public static partial class CpuInfoX86
    {
        public static partial class FeaturesX86
        {
            public static bool IsSupportedSSE { get; internal set; }
            public static bool IsSupportedSSE2 { get; internal set; }
            public static bool IsSupportedSSE3 { get; internal set; }
            public static bool IsSupportedSSSE3 { get; internal set; }
            public static bool IsSupportedSSE41 { get; internal set; }
            public static bool IsSupportedSSE42 { get; internal set; }
            public static bool IsSupportedSSE4A { get; internal set; }
        }
    }
}