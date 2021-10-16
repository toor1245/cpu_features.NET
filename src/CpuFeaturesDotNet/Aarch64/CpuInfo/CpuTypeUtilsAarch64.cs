namespace CpuFeaturesDotNet.Aarch64.CpuInfo
{
    internal static class CpuTypeUtilsAarch64
    {
        public static int MpdirLevelBitsShift = 3;
        public static ulong MpdirUpBitMask = 0x1 << 30;
        public static ulong MpdirMtBitMask = 0x1 << 24;
        public static ulong MpdirHwidBitMask = 0xFF00FFFFFF;
        public static ulong MpdirLevelBits = 1UL << MpdirLevelBitsShift;
        public static ulong MpidrLevelMask = (ulong) ((1 << (int)MpdirLevelBits) - 1);
        public static ulong MpidrLevelShift(int level) => (ulong) (((1 << level) >> 1) << MpdirLevelBitsShift);
        public static ulong 
    }
}