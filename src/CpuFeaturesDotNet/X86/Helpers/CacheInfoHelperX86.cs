using System.Collections.Generic;
using CpuFeaturesDotNet.X86.Parser;

namespace CpuFeaturesDotNet.X86.Helpers
{
    internal static class CacheInfoHelperX86
    {
        public static CacheLevelInfoX86 GetCacheLevelInfo(uint reg)
        {
            const int UNDEF = -1;
            const int KiB = 1024;
            const int MiB = 1024 * KiB;
            return reg switch
            {
                0x01 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 32, 0),
                0x02 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * MiB, 0xFF, UNDEF, 2, 0),
                0x03 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 64, 0),
                0x04 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * MiB, 4, UNDEF, 8, 0),
                0x05 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * MiB, 4, UNDEF, 32, 0),
                0x06 => new CacheLevelInfoX86(1, CacheTypeX86.INSTRUCTION, 8 * KiB, 4, 32, UNDEF, 0),
                0x08 => new CacheLevelInfoX86(1, CacheTypeX86.INSTRUCTION, 16 * KiB, 4, 32, UNDEF, 0),
                0x09 => new CacheLevelInfoX86(1, CacheTypeX86.INSTRUCTION, 32 * KiB, 4, 64, UNDEF, 0),
                0x0A => new CacheLevelInfoX86(1, CacheTypeX86.DATA, 8 * KiB, 2, 32, UNDEF, 0),
                0x0B => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * MiB, 4, UNDEF, 4, 0),
                0x0C => new CacheLevelInfoX86(1, CacheTypeX86.INSTRUCTION, 16 * KiB, 4, 32, UNDEF, 0),
                0x0D => new CacheLevelInfoX86(1, CacheTypeX86.DATA, 16 * KiB, 4, 64, UNDEF, 0),
                0x0E => new CacheLevelInfoX86(1, CacheTypeX86.DATA, 24 * KiB, 6, 64, UNDEF, 0),
                0x1D => new CacheLevelInfoX86(2, CacheTypeX86.INSTRUCTION, 128 * KiB, 4, 64, UNDEF, 0),
                0x21 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 256 * KiB, 8, 64, UNDEF, 0),
                0x22 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 512 * KiB, 4, 64, UNDEF, 2),
                0x23 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 1 * KiB, 8, 64, UNDEF, 2),
                0x24 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 1 * MiB, 16, 64, UNDEF, 0),
                0x25 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 2 * MiB, 8, 64, UNDEF, 2),
                0x29 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 4 * MiB, 8, 64, UNDEF, 2),
                0x2C => new CacheLevelInfoX86(1, CacheTypeX86.DATA, 32 * KiB, 8, 64, UNDEF, 0),
                0x30 => new CacheLevelInfoX86(1, CacheTypeX86.INSTRUCTION, 32 * KiB, 8, 64, UNDEF, 0),
                0x40 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.DATA, UNDEF, UNDEF, UNDEF, UNDEF, 0),
                0x41 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 128 * KiB, 4, 32, UNDEF, 0),
                0x42 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 256 * KiB, 4, 32, UNDEF, 0),
                0x43 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 512 * MiB, 4, 32, UNDEF, 0),
                0x44 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 1 * MiB, 4, 32, UNDEF, 0),
                0x45 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 2 * MiB, 4, 32, UNDEF, 0),
                0x46 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 4 * MiB, 4, 64, UNDEF, 0),
                0x47 => new CacheLevelInfoX86(3, CacheTypeX86.INSTRUCTION, 8 * MiB, 8, 64, UNDEF, 0),
                0x48 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 3 * MiB, 12, 64, UNDEF, 0),
                0x49 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 4 * MiB, 16, 64, UNDEF, 0),
                0x49 | (1 << 8) => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 4 * MiB, 16, 64, UNDEF, 0),
                0x4A => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 6 * MiB, 12, 64, UNDEF, 0),
                0x4B => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 8 * MiB, 16, 64, UNDEF, 0),
                0x4C => new CacheLevelInfoX86(3, CacheTypeX86.INSTRUCTION, 12 * MiB, 12, 64, UNDEF, 0),
                0x4D => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 16 * MiB, 16, 64, UNDEF, 0),
                0x4E => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 6 * MiB, 24, 64, UNDEF, 0),
                0x4F => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, UNDEF, UNDEF, 32, 0),
                0x50 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, UNDEF, UNDEF, 64, 0),
                0x51 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, UNDEF, UNDEF, 128, 0),
                0x52 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, UNDEF, UNDEF, 256, 0),
                0x55 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 2 * MiB, 0xFF, UNDEF, 7, 0),
                0x56 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * MiB, 4, UNDEF, 16, 0),
                0x57 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 16, 0),
                0x59 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 0xFF, UNDEF, 16, 0),
                0x5A => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 2 * MiB, 4, UNDEF, 32, 0),
                0x5B => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 0xFF, UNDEF, 64, 0),
                0x5C => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 0xFF, UNDEF, 128, 0),
                0x5D => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, UNDEF, 0xFF, UNDEF, 256, 0),
                0x60 => new CacheLevelInfoX86(1, CacheTypeX86.DATA, 16 * KiB, 8, 64, UNDEF, 0),
                0x61 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 0xFF, UNDEF, 48, 0),
                0x63 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 2 * MiB, 4, UNDEF, 4, 0),
                0x66 => new CacheLevelInfoX86(1, CacheTypeX86.DATA, 8 * KiB, 4, 64, UNDEF, 0),
                0x67 => new CacheLevelInfoX86(1, CacheTypeX86.DATA, 16 * MiB, 4, 64, UNDEF, 0),
                0x68 => new CacheLevelInfoX86(1, CacheTypeX86.DATA, 32 * KiB, 4, 64, UNDEF, 0),
                0x70 => new CacheLevelInfoX86(1, CacheTypeX86.DATA, 12 * KiB, 8, UNDEF, UNDEF, 0),
                0x71 => new CacheLevelInfoX86(1, CacheTypeX86.INSTRUCTION, 16 * KiB, 8, UNDEF, UNDEF, 0),
                0x72 => new CacheLevelInfoX86(1, CacheTypeX86.INSTRUCTION, 32 * KiB, 8, UNDEF, UNDEF, 0),
                0x76 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 2 * MiB, 0xFF, UNDEF, 8, 0),
                0x78 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 1 * MiB, 4, 64, UNDEF, 0),
                0x79 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 128 * KiB, 8, 64, UNDEF, 2),
                0x7A => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 256 * KiB, 8, 64, UNDEF, 2),
                0x7B => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 512 * KiB, 8, 64, UNDEF, 2),
                0x7C => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 1 * MiB, 8, 64, UNDEF, 2),
                0x7D => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 2 * MiB, 8, 64, UNDEF, 0),
                0x7F => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 512 * KiB, 2, 64, UNDEF, 0),
                0x80 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 512 * KiB, 8, 64, UNDEF, 0),
                0x82 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 256 * KiB, 8, 32, UNDEF, 0),
                0x83 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 512 * KiB, 8, 32, UNDEF, 0),
                0x84 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 1 * MiB, 8, 32, UNDEF, 0),
                0x85 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 2 * MiB, 8, 32, UNDEF, 0),
                0x86 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 512 * KiB, 4, 32, UNDEF, 0),
                0x87 => new CacheLevelInfoX86(2, CacheTypeX86.DATA, 1 * MiB, 8, 64, UNDEF, 0),
                0xA0 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.DATA, 4 * KiB, 0xFF, UNDEF, 32, 0),
                0xB0 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 128, 0),
                0xB1 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 2 * MiB, 4, UNDEF, 8, 0),
                0xB2 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 64, 0),
                0xB3 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 128, 0),
                0xB4 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 246, 0),
                0xB5 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 8, UNDEF, 64, 0),
                0xB6 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 8, UNDEF, 128, 0),
                0xBA => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 64, 0),
                0xC0 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.TLB, 4 * KiB, 4, UNDEF, 8, 0),
                0xC1 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.STLB, 4 * KiB, 8, UNDEF, 1024, 0),
                0xC2 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.DATA, 16 * KiB, 8, 64, UNDEF, 0),
                0xC3 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.STLB, 4 * KiB, 6, UNDEF, 1536, 0),
                0xCA => new CacheLevelInfoX86(UNDEF, CacheTypeX86.STLB, 4 * KiB, 4, UNDEF, 512, 0),
                0xD0 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 512 * KiB, 4, 64, UNDEF, 0),
                0xD1 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 1 * MiB, 4, 64, UNDEF, 0),
                0xD2 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 2 * MiB, 4, 64, UNDEF, 0),
                0xD6 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 1 * MiB, 8, 64, UNDEF, 0),
                0xD7 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 2 * MiB, 8, 64, UNDEF, 0),
                0xD8 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 4 * MiB, 8, 64, UNDEF, 0),
                0xDC => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 1536 * KiB, 12, 64, UNDEF, 0),
                0xDD => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 3 * MiB, 12, 64, UNDEF, 0),
                0xDE => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 6 * MiB, 12, 64, UNDEF, 0),
                0xE2 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 2 * MiB, 16, 64, UNDEF, 0),
                0xE3 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 4 * MiB, 16, 64, UNDEF, 0),
                0xE4 => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 8 * MiB, 16, 64, UNDEF, 0),
                0xEA => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 12 * MiB, 24, 64, UNDEF, 0),
                0xEB => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 18 * MiB, 24, 64, UNDEF, 0),
                0xEC => new CacheLevelInfoX86(3, CacheTypeX86.DATA, 24 * MiB, 24, 64, UNDEF, 0),
                0xF0 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.PREFETCH, 64 * KiB, UNDEF, UNDEF, UNDEF, 0),
                0xF1 => new CacheLevelInfoX86(UNDEF, CacheTypeX86.PREFETCH, 128 * KiB, UNDEF, UNDEF, UNDEF, 0),
                0xFF => new CacheLevelInfoX86(UNDEF, CacheTypeX86.NULL, UNDEF, UNDEF, UNDEF, UNDEF, 0),
                _ => new CacheLevelInfoX86()
            };
        }

        // For newer Intel CPUs uses "CPUID, eax=0x00000004".
        // https://www.felixcloutier.com/x86/cpuid#input-eax-=-04h--returns-deterministic-cache-parameters-for-each-level
        // For newer AMD CPUs uses "CPUID, eax=0x8000001D"
        public static List<CacheLevelInfoX86> ParseCacheInfo(uint maxCpuidLeaf, uint leafId)
        {
            var levels = new List<CacheLevelInfoX86>();
            for (var cacheId = 0; cacheId < CacheInfoParserX86.LEVELS_SIZE; cacheId++)
            {
                var leaf = LeafX86.SafeCpuId(maxCpuidLeaf, leafId, cacheId);
                var cacheType = (CacheTypeX86)BitUtils.ExtractBitRange(leaf.eax, 4, 0);

                if (cacheType == CacheTypeX86.NULL)
                    break;

                var level = (int)BitUtils.ExtractBitRange(leaf.eax, 7, 5);
                var lineSize = (int)BitUtils.ExtractBitRange(leaf.ebx, 11, 0) + 1;
                var partitioning = (int)BitUtils.ExtractBitRange(leaf.ebx, 21, 12) + 1;
                var ways = (int)BitUtils.ExtractBitRange(leaf.ebx, 31, 22) + 1;
                var tlbEntries = (int)(leaf.ecx + 1);
                var cacheSize = ways * partitioning * lineSize * tlbEntries;
                levels.Add(new CacheLevelInfoX86(level, cacheType, cacheSize, ways, lineSize, tlbEntries, partitioning));
            }
            return levels;
        }
    }
}