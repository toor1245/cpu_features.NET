using static CpuFeaturesDotNet.Utils.BitUtils;
using static CpuFeaturesDotNet.Utils.FeaturesUtilsX86;

namespace CpuFeaturesDotNet.X86
{
    public static partial class CpuInfoX86
    {
        public static partial class FeaturesX86
        {
            public static bool IsSupportedAVX { get; private set; }
            public static bool IsSupportedAVX2 { get; private set; }

            public static bool IsSupportedAVX512F { get; private set; }
            public static bool IsSupportedAVX512CD { get; private set; }
            public static bool IsSupportedAVX512ER { get; private set; }
            public static bool IsSupportedAVX512PF { get; private set; }
            public static bool IsSupportedAVX512BW { get; private set; }
            public static bool IsSupportedAVX512DQ { get; private set; }
            public static bool IsSupportedAVX512VL { get; private set; }
            public static bool IsSupportedAVX512IFMA { get; private set; }
            public static bool IsSupportedAVX512VBMI { get; private set; }
            public static bool IsSupportedAVX512VBMI2 { get; private set; }
            public static bool IsSupportedAVX512VNNI { get; private set; }
            public static bool IsSupportedAVX512BITALG { get; private set; }
            public static bool IsSupportedAVX512VPOPCNTDQ { get; private set; }
            public static bool IsSupportedAVX512_4VNNIW { get; private set; }
            public static bool IsSupportedAVX512_4VBMI2 { get; private set; }
            public static bool IsSupportedAVX512SecondFMA { get; private set; }
            public static bool IsSupportedAVX512_4FMAPS { get; private set; }
            public static bool IsSupportedAVX512_BF16 { get; private set; }
            public static bool IsSupportedAVX512_VP2INTERSECT { get; private set; }

            private static void SetAvxRegisters(in Leaf leaf1, in Leaf leaf_7)
            {
                IsSupportedFMA3 = IsBitSet(leaf1.ecx, 12);
                IsSupportedAVX = IsBitSet(leaf1.ecx, 28);
                IsSupportedAVX2 = IsBitSet(leaf_7.ebx, 5);
            }

            private static void SetAvx512Registers(in Leaf leaf_7, in Leaf leaf7_1, int model)
            {
                IsSupportedAVX512F = IsBitSet(leaf_7.ebx, 16);
                IsSupportedAVX512CD = IsBitSet(leaf_7.ebx, 28);
                IsSupportedAVX512ER = IsBitSet(leaf_7.ebx, 27);
                IsSupportedAVX512PF = IsBitSet(leaf_7.ebx, 26);
                IsSupportedAVX512BW = IsBitSet(leaf_7.ebx, 30);
                IsSupportedAVX512DQ = IsBitSet(leaf_7.ebx, 17);
                IsSupportedAVX512VL = IsBitSet(leaf_7.ebx, 31);
                IsSupportedAVX512IFMA = IsBitSet(leaf_7.ebx, 21);
                IsSupportedAVX512VBMI = IsBitSet(leaf_7.ecx, 1);
                IsSupportedAVX512VBMI2 = IsBitSet(leaf_7.ecx, 6);
                IsSupportedAVX512VNNI = IsBitSet(leaf_7.ecx, 11);
                IsSupportedAVX512BITALG = IsBitSet(leaf_7.ecx, 12);
                IsSupportedAVX512VPOPCNTDQ = IsBitSet(leaf_7.ecx, 14);
                IsSupportedAVX512_4VNNIW = IsBitSet(leaf_7.edx, 2);
                IsSupportedAVX512_4VBMI2 = IsBitSet(leaf_7.edx, 3);
                IsSupportedAVX512SecondFMA = HasSecondFMA(model);
                IsSupportedAVX512_4FMAPS = IsBitSet(leaf_7.edx, 3);
                IsSupportedAVX512_BF16 = IsBitSet(leaf7_1.eax, 5);
                IsSupportedAVX512_VP2INTERSECT = IsBitSet(leaf_7.edx, 8);
            }
        }
    }
}