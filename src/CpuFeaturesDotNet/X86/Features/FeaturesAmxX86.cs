
namespace CpuFeaturesDotNet.X86
{
    public static partial class CpuInfoX86
    {
        public static partial class FeaturesX86
        {
            public static bool IsSupportedAMX_BF16 { get; internal set; }
            public static bool IsSupportedAMX_TILE { get; internal set; }
            public static bool IsSupportedAMX_INT8 { get; internal set; }
        }
    }
}