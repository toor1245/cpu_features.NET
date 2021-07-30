namespace CpuFeaturesDotNet.X86
{
    public static partial class CpuInfoX86
    {
        public static partial class FeaturesX86
        {
            public static bool IsSupportedAVX { get; internal set; }
            public static bool IsSupportedAVX2 { get; internal set; }

            public static bool IsSupportedAVX512F { get; internal set; }
            public static bool IsSupportedAVX512CD { get; internal set; }
            public static bool IsSupportedAVX512ER { get; internal set; }
            public static bool IsSupportedAVX512PF { get; internal set; }
            public static bool IsSupportedAVX512BW { get; internal set; }
            public static bool IsSupportedAVX512DQ { get; internal set; }
            public static bool IsSupportedAVX512VL { get; internal set; }
            public static bool IsSupportedAVX512IFMA { get; internal set; }
            public static bool IsSupportedAVX512VBMI { get; internal set; }
            public static bool IsSupportedAVX512VBMI2 { get; internal set; }
            public static bool IsSupportedAVX512VNNI { get; internal set; }
            public static bool IsSupportedAVX512BITALG { get; internal set; }
            public static bool IsSupportedAVX512VPOPCNTDQ { get; internal set; }
            public static bool IsSupportedAVX512_4VNNIW { get; internal set; }
            public static bool IsSupportedAVX512_4VBMI2 { get; internal set; }
            public static bool IsSupportedAVX512SecondFMA { get; internal set; }
            public static bool IsSupportedAVX512_4FMAPS { get; internal set; }
            public static bool IsSupportedAVX512_BF16 { get; internal set; }
            public static bool IsSupportedAVX512_VP2INTERSECT { get; internal set; }
        }
    }
}