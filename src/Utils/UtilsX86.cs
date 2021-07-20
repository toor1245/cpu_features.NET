using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Libs;
using CpuFeaturesDotNet.X86;

namespace CpuFeaturesDotNet.Utils
{
    internal static class UtilsX86
    {
        [DllImport(DllPath.CPU_FEATURES_DOTNET_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__uarch")]
        public static extern MicroarchitectureX86 GetMicroarchitectureX86(Leaf leaf, int family, int model, int stepping);

        [DllImport(DllPath.CPU_FEATURES_DOTNET_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cpuid")]
        public static extern Leaf CpuId(uint leafId, int ecx = 0);
        
        [DllImport(DllPath.CPU_FEATURES_DOTNET_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__is_vendor")]
        public static extern bool IsVendor(Leaf leaf, string name);

        public static CacheInfoX86.CacheLevelInfoX86 GetCacheLevelInfo(uint reg)
        {
            const int UNDEF = -1;
            const int KiB = 1024;
            const int MiB = 1024 * KiB;
            return reg switch
            {
                0x01 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 32, 0),
                0x02 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * MiB, 0xFF, UNDEF, 2, 0),
                0x03 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 64, 0),
                0x04 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * MiB, 4, UNDEF, 8, 0),
                0x05 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * MiB, 4, UNDEF, 32, 0),
                0x06 => CreateCacheInfo(1, CacheTypeX86.INSTRUCTION, 8 * KiB, 4, 32, UNDEF, 0),
                0x08 => CreateCacheInfo(1, CacheTypeX86.INSTRUCTION, 16 * KiB, 4, 32, UNDEF, 0),
                0x09 => CreateCacheInfo(1, CacheTypeX86.INSTRUCTION, 32 * KiB, 4, 64, UNDEF, 0),
                0x0A => CreateCacheInfo(1, CacheTypeX86.DATA, 8 * KiB, 2, 32, UNDEF, 0),
                0x0B => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * MiB, 4, UNDEF, 4, 0),
                0x0C => CreateCacheInfo(1, CacheTypeX86.INSTRUCTION, 16 * KiB, 4, 32, UNDEF, 0),
                0x0D => CreateCacheInfo(1, CacheTypeX86.DATA, 16 * KiB, 4, 64, UNDEF, 0),
                0x0E => CreateCacheInfo(1, CacheTypeX86.DATA, 24 * KiB, 6, 64, UNDEF, 0),
                0x1D => CreateCacheInfo(2, CacheTypeX86.INSTRUCTION, 128 * KiB, 4, 64, UNDEF, 0),
                0x21 => CreateCacheInfo(2, CacheTypeX86.DATA, 256 * KiB, 8, 64, UNDEF, 0),
                0x22 => CreateCacheInfo(3, CacheTypeX86.DATA, 512 * KiB, 4, 64, UNDEF, 2),
                0x23 => CreateCacheInfo(3, CacheTypeX86.DATA, 1 * KiB, 8, 64, UNDEF, 2),
                0x24 => CreateCacheInfo(2, CacheTypeX86.DATA, 1 * MiB, 16, 64, UNDEF, 0),
                0x25 => CreateCacheInfo(3, CacheTypeX86.DATA, 2 * MiB, 8, 64, UNDEF, 2),
                0x29 => CreateCacheInfo(3, CacheTypeX86.DATA, 4 * MiB, 8, 64, UNDEF, 2),
                0x2C => CreateCacheInfo(1, CacheTypeX86.DATA, 32 * KiB, 8, 64, UNDEF, 0),
                0x30 => CreateCacheInfo(1, CacheTypeX86.INSTRUCTION, 32 * KiB, 8, 64, UNDEF, 0),
                0x40 => CreateCacheInfo(UNDEF, CacheTypeX86.DATA, UNDEF, UNDEF, UNDEF, UNDEF, 0),
                0x41 => CreateCacheInfo(2, CacheTypeX86.DATA, 128 * KiB, 4, 32, UNDEF, 0),
                0x42 => CreateCacheInfo(2, CacheTypeX86.DATA, 256 * KiB, 4, 32, UNDEF, 0),
                0x43 => CreateCacheInfo(2, CacheTypeX86.DATA, 512 * MiB, 4, 32, UNDEF, 0),
                0x44 => CreateCacheInfo(2, CacheTypeX86.DATA, 1 * MiB, 4, 32, UNDEF, 0),
                0x45 => CreateCacheInfo(2, CacheTypeX86.DATA, 2 * MiB, 4, 32, UNDEF, 0),
                0x46 => CreateCacheInfo(3, CacheTypeX86.DATA, 4 * MiB, 4, 64, UNDEF, 0),
                0x47 => CreateCacheInfo(3, CacheTypeX86.INSTRUCTION, 8 * MiB, 8, 64, UNDEF, 0),
                0x48 => CreateCacheInfo(2, CacheTypeX86.DATA, 3 * MiB, 12, 64, UNDEF, 0),
                0x49 => CreateCacheInfo(2, CacheTypeX86.DATA, 4 * MiB, 16, 64, UNDEF, 0),
                0x49 | (1 << 8) => CreateCacheInfo(3, CacheTypeX86.DATA, 4 * MiB, 16, 64, UNDEF, 0),
                0x4A => CreateCacheInfo(3, CacheTypeX86.DATA, 6 * MiB, 12, 64, UNDEF, 0),
                0x4B => CreateCacheInfo(3, CacheTypeX86.DATA, 8 * MiB, 16, 64, UNDEF, 0),
                0x4C => CreateCacheInfo(3, CacheTypeX86.INSTRUCTION, 12 * MiB, 12, 64, UNDEF, 0),
                0x4D => CreateCacheInfo(3, CacheTypeX86.DATA, 16 * MiB, 16, 64, UNDEF, 0),
                0x4E => CreateCacheInfo(2, CacheTypeX86.DATA, 6 * MiB, 24, 64, UNDEF, 0),
                0x4F => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, UNDEF, UNDEF, 32, 0),
                0x50 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, UNDEF, UNDEF, 64, 0),
                0x51 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, UNDEF, UNDEF, 128, 0),
                0x52 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, UNDEF, UNDEF, 256, 0),
                0x55 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 2 * MiB, 0xFF, UNDEF, 7, 0),
                0x56 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * MiB, 4, UNDEF, 16, 0),
                0x57 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 16, 0),
                0x59 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 0xFF, UNDEF, 16, 0),
                0x5A => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 2 * MiB, 4, UNDEF, 32, 0),
                0x5B => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 0xFF, UNDEF, 64, 0),
                0x5C => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 0xFF, UNDEF, 128, 0),
                0x5D => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, UNDEF, 0xFF, UNDEF, 256, 0),
                0x60 => CreateCacheInfo(1, CacheTypeX86.DATA, 16 * KiB, 8, 64, UNDEF, 0),
                0x61 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 0xFF, UNDEF, 48, 0),
                0x63 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 2 * MiB, 4, UNDEF, 4, 0),
                0x66 => CreateCacheInfo(1, CacheTypeX86.DATA, 8 * KiB, 4, 64, UNDEF, 0),
                0x67 => CreateCacheInfo(1, CacheTypeX86.DATA, 16 * MiB, 4, 64, UNDEF, 0),
                0x68 => CreateCacheInfo(1, CacheTypeX86.DATA, 32 * KiB, 4, 64, UNDEF, 0),
                0x70 => CreateCacheInfo(1, CacheTypeX86.DATA, 12 * KiB, 8, UNDEF, UNDEF, 0),
                0x71 => CreateCacheInfo(1, CacheTypeX86.INSTRUCTION, 16 * KiB, 8, UNDEF, UNDEF, 0),
                0x72 => CreateCacheInfo(1, CacheTypeX86.INSTRUCTION, 32 * KiB, 8, UNDEF, UNDEF, 0),
                0x76 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 2 * MiB, 0xFF, UNDEF, 8, 0),
                0x78 => CreateCacheInfo(2, CacheTypeX86.DATA, 1 * MiB, 4, 64, UNDEF, 0),
                0x79 => CreateCacheInfo(2, CacheTypeX86.DATA, 128 * KiB, 8, 64, UNDEF, 2),
                0x7A => CreateCacheInfo(2, CacheTypeX86.DATA, 256 * KiB, 8, 64, UNDEF, 2),
                0x7B => CreateCacheInfo(2, CacheTypeX86.DATA, 512 * KiB, 8, 64, UNDEF, 2),
                0x7C => CreateCacheInfo(2, CacheTypeX86.DATA, 1 * MiB, 8, 64, UNDEF, 2),
                0x7D => CreateCacheInfo(2, CacheTypeX86.DATA, 2 * MiB, 8, 64, UNDEF, 0),
                0x7F => CreateCacheInfo(2, CacheTypeX86.DATA, 512 * KiB, 2, 64, UNDEF, 0),
                0x80 => CreateCacheInfo(2, CacheTypeX86.DATA, 512 * KiB, 8, 64, UNDEF, 0),
                0x82 => CreateCacheInfo(2, CacheTypeX86.DATA, 256 * KiB, 8, 32, UNDEF, 0),
                0x83 => CreateCacheInfo(2, CacheTypeX86.DATA, 512 * KiB, 8, 32, UNDEF, 0),
                0x84 => CreateCacheInfo(2, CacheTypeX86.DATA, 1 * MiB, 8, 32, UNDEF, 0),
                0x85 => CreateCacheInfo(2, CacheTypeX86.DATA, 2 * MiB, 8, 32, UNDEF, 0),
                0x86 => CreateCacheInfo(2, CacheTypeX86.DATA, 512 * KiB, 4, 32, UNDEF, 0),
                0x87 => CreateCacheInfo(2, CacheTypeX86.DATA, 1 * MiB, 8, 64, UNDEF, 0),
                0xA0 => CreateCacheInfo(UNDEF, CacheTypeX86.DATA, 4 * KiB, 0xFF, UNDEF, 32, 0),
                0xB0 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 128, 0),
                0xB1 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 2 * MiB, 4, UNDEF, 8, 0),
                0xB2 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 64, 0),
                0xB3 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 128, 0),
                0xB4 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 246, 0),
                0xB5 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 8, UNDEF, 64, 0),
                0xB6 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 8, UNDEF, 128, 0),
                0xBA => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 64, 0),
                0xC0 => CreateCacheInfo(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 8, 0),
                0xC1 => CreateCacheInfo(UNDEF, CacheTypeX86.STLB, 4 * KiB, 8, UNDEF, 1024, 0),
                0xC2 => CreateCacheInfo(UNDEF, CacheTypeX86.DATA, 16 * KiB, 8, 64, UNDEF, 0),
                0xC3 => CreateCacheInfo(UNDEF, CacheTypeX86.STLB, 4 * KiB, 6, UNDEF, 1536, 0),
                0xCA => CreateCacheInfo(UNDEF, CacheTypeX86.STLB, 4 * KiB, 4, UNDEF, 512, 0),
                0xD0 => CreateCacheInfo(3, CacheTypeX86.DATA, 512 * KiB, 4, 64, UNDEF, 0),
                0xD1 => CreateCacheInfo(3, CacheTypeX86.DATA, 1 * MiB, 4, 64, UNDEF, 0),
                0xD2 => CreateCacheInfo(3, CacheTypeX86.DATA, 2 * MiB, 4, 64, UNDEF, 0),
                0xD6 => CreateCacheInfo(3, CacheTypeX86.DATA, 1 * MiB, 8, 64, UNDEF, 0),
                0xD7 => CreateCacheInfo(3, CacheTypeX86.DATA, 2 * MiB, 8, 64, UNDEF, 0),
                0xD8 => CreateCacheInfo(3, CacheTypeX86.DATA, 4 * MiB, 8, 64, UNDEF, 0),
                0xDC => CreateCacheInfo(3, CacheTypeX86.DATA, 1536 * KiB, 12, 64, UNDEF, 0),
                0xDD => CreateCacheInfo(3, CacheTypeX86.DATA, 3 * MiB, 12, 64, UNDEF, 0),
                0xDE => CreateCacheInfo(3, CacheTypeX86.DATA, 6 * MiB, 12, 64, UNDEF, 0),
                0xE2 => CreateCacheInfo(3, CacheTypeX86.DATA, 2 * MiB, 16, 64, UNDEF, 0),
                0xE3 => CreateCacheInfo(3, CacheTypeX86.DATA, 4 * MiB, 16, 64, UNDEF, 0),
                0xE4 => CreateCacheInfo(3, CacheTypeX86.DATA, 8 * MiB, 16, 64, UNDEF, 0),
                0xEA => CreateCacheInfo(3, CacheTypeX86.DATA, 12 * MiB, 24, 64, UNDEF, 0),
                0xEB => CreateCacheInfo(3, CacheTypeX86.DATA, 18 * MiB, 24, 64, UNDEF, 0),
                0xEC => CreateCacheInfo(3, CacheTypeX86.DATA, 24 * MiB, 24, 64, UNDEF, 0),
                0xF0 => CreateCacheInfo(UNDEF, CacheTypeX86.PREFETCH, 64 * KiB, UNDEF, UNDEF, UNDEF, 0),
                0xF1 => CreateCacheInfo(UNDEF, CacheTypeX86.PREFETCH, 128 * KiB, UNDEF, UNDEF, UNDEF, 0),
                0xFF => CreateCacheInfo(UNDEF, CacheTypeX86.NULL, UNDEF, UNDEF, UNDEF, UNDEF, 0),
                _ => new CacheInfoX86.CacheLevelInfoX86()
            };
        }
        
        public static CacheInfoX86.CacheLevelInfoX86 CreateCacheInfo(int level, CacheTypeX86 type, int size, int ways,
            int lineSize, int tlbEntries, int partitioning)
        {
            return new CacheInfoX86.CacheLevelInfoX86(level, type, size, ways, lineSize, tlbEntries, partitioning);
        }
    }
}