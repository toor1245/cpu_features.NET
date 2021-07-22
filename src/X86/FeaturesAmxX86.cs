using static CpuFeaturesDotNet.Utils.BitUtils;

namespace CpuFeaturesDotNet.X86
{
    public static partial class CpuInfoX86
    {
        public static partial class FeaturesX86
        {
            public static bool IsSupportedAMX_BF16 { get; private set; }
            public static bool IsSupportedAMX_TILE { get; private set; }
            public static bool IsSupportedAMX_INT8 { get; private set; }

            private static void SetAmxRegisters(in Leaf leaf_7)
            {
                IsSupportedAMX_BF16 = IsBitSet(leaf_7.edx, 22);
                IsSupportedAMX_TILE = IsBitSet(leaf_7.edx, 24);
                IsSupportedAMX_INT8 = IsBitSet(leaf_7.edx, 25);
            }
        }
    }
}