using CpuFeaturesDotNet.Utils;
using static CpuFeaturesDotNet.Utils.BitUtils;

namespace CpuFeaturesDotNet.X86
{
    public unsafe struct CacheInfoX86
    {
        private const int LEVELS_SIZE = 10;
        public uint Size;
        public readonly CacheLevelInfoX86[] Levels;

        private CacheInfoX86(uint size)
        {
            Size = size;
            Levels = new CacheLevelInfoX86[LEVELS_SIZE];
        }

        public static CacheInfoX86 GetX86CacheInfo()
        {
            var info = new CacheInfoX86(0);
            var leaf = Leaf.CpuId(0);
            if (VendorX86.IsVendor(leaf, VendorX86.GENUINE_INTEL))
            {
                ParseLeaf2(leaf.eax, ref info);
                ParseCacheInfo(leaf.eax, 4, ref info);
            }
            else if (VendorX86.IsAMDMicroarchitecture(leaf))
            {
                var maxExt = Leaf.CpuId(0x80000000).eax;
                if (!IsReservedAMD(maxExt, 22))
                {
                    ParseCacheInfo(maxExt, 0x8000001D, ref info);
                }
            }
            return info;
        }
        
        // If CPUID Fn8000_0001_ECX[bit]==0 then CPUID Fn8000_00XX_E[D,C,B,A]X is
        // reserved. https://www.amd.com/system/files/TechDocs/25481.pdf
        private static bool IsReservedAMD(uint maxExtended, int bit)
        {
            var cpuidExt = Leaf.SafeCpuId(maxExtended, 0x80000001).ecx;
            return !IsBitSet(cpuidExt, bit);
        }

        private static void ParseLeaf2(uint max_cpuid_leaf, ref CacheInfoX86 info)
        {
            var leaf = Leaf.SafeCpuId(max_cpuid_leaf, 2);
            var registers = stackalloc uint[]
            {
                leaf.eax,
                leaf.ebx,
                leaf.ecx,
                leaf.edx
            };
            var bytes = stackalloc uint[4];
            
            for (var i = 0; i < 4; i++)
            {
                if ((registers[i] & (1U << 31)) != 0)
                {
                    continue;  // register does not contains valid information
                }
                
                GetByteArrayFromRegister(bytes, registers[i]);
                
                for (var j = 0; j < 4; ++j)
                {
                    if (bytes[j] == 0xFF)
                    {
                        break; // leaf 4 should be used to fetch cache information
                    }
                    info.Levels[info.Size] = UtilsX86.GetCacheLevelInfo(bytes[j]);
                }
                info.Size++;
            }
        }
        
        // For newer Intel CPUs uses "CPUID, eax=0x00000004".
        // For newer AMD CPUs uses "CPUID, eax=0x8000001D".
        private static void ParseCacheInfo(uint maxCpuidLeaf, uint leafId, ref CacheInfoX86 info)
        {
            info.Size = 0;
            for (var cacheId = 0; cacheId < LEVELS_SIZE; cacheId++) 
            {
                var leaf = Leaf.SafeCpuId(maxCpuidLeaf, leafId, cacheId);
                var cacheType = (CacheTypeX86) ExtractBitRange(leaf.eax, 4, 0);
                if (cacheType == CacheTypeX86.NULL)
                {
                    info.Levels[cacheId] = new CacheLevelInfoX86();
                    continue;
                }
                var level = (int) ExtractBitRange(leaf.eax, 7, 5);
                var lineSize = (int) ExtractBitRange(leaf.ebx, 11, 0) + 1;
                var partitioning = (int) ExtractBitRange(leaf.ebx, 21, 12) + 1;
                var ways = (int) ExtractBitRange(leaf.ebx, 31, 22) + 1;
                var tlbEntries = (int) (leaf.ecx + 1);
                var cacheSize = ways * partitioning * lineSize * tlbEntries;
                info.Levels[cacheId] = UtilsX86.CreateCacheInfo(level, cacheType, cacheSize, ways, lineSize, tlbEntries, partitioning);
                info.Size++;
            }
        }
    }
}