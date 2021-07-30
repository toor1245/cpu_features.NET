using System.Runtime.CompilerServices;
using static CpuFeaturesDotNet.Utils.BitUtils;

namespace CpuFeaturesDotNet.X86
{
    public static unsafe partial class CpuInfoX86
    {
        public static class CacheInfoX86
        {
            private const int LEVELS_SIZE = 10;
            private static uint _size;

            public static readonly CacheLevelInfoX86[] Levels;
            public static uint Size => _size;

            static CacheInfoX86()
            {
                Levels = new CacheLevelInfoX86[LEVELS_SIZE];
                var leaf = LeafX86.CpuId(0);
                if (VendorX86.IsIntelVendor(leaf))
                {
                    ParseLeaf2(leaf.eax);
                    ParseCacheInfo(leaf.eax, 4);
                }
                else if (VendorX86.IsAMDVendor(leaf))
                {
                    ParseCacheAMD();
                }
            }

            private static void ParseLeaf2(uint max_cpuid_leaf)
            {
                var leaf = LeafX86.SafeCpuId(max_cpuid_leaf, 2);
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
                    if (!ContainsValidInfo(registers[i])) continue;
                    GetByteArrayFromRegister(bytes, registers[i]);
                    FetchCacheInfoLeaf2(bytes);
                    _size++;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void FetchCacheInfoLeaf2(uint* bytes)
            {
                // In case when byte not equal 0xFF then leaf 4 should be used to fetch cache information.
                for (var j = 0; j < 4 && bytes[j] != 0xFF; ++j)
                {
                    Levels[_size] = UtilsX86.GetCacheLevelInfo(bytes[j]);
                }
            }

            // Gets cache information newer AMD CPUs by 0x8000001D.
            private static void ParseCacheAMD()
            {
                var maxExt = LeafX86.CpuId(0x80000000).eax;
                if (!UtilsX86.IsReservedAMD(maxExt, 22))
                {
                    ParseCacheInfo(maxExt, 0x8000001D);
                }
            }

            // For newer Intel CPUs uses "CPUID, eax=0x00000004".
            // For newer AMD CPUs uses "CPUID, eax=0x8000001D".
            private static void ParseCacheInfo(uint maxCpuidLeaf, uint leafId)
            {
                _size = 0;
                for (var cacheId = 0; cacheId < LEVELS_SIZE; cacheId++)
                {
                    var leaf = LeafX86.SafeCpuId(maxCpuidLeaf, leafId, cacheId);
                    var cacheType = (CacheTypeX86)ExtractBitRange(leaf.eax, 4, 0);

                    if (cacheType == CacheTypeX86.NULL)
                        break;

                    var level = (int)ExtractBitRange(leaf.eax, 7, 5);
                    var lineSize = (int)ExtractBitRange(leaf.ebx, 11, 0) + 1;
                    var partitioning = (int)ExtractBitRange(leaf.ebx, 21, 12) + 1;
                    var ways = (int)ExtractBitRange(leaf.ebx, 31, 22) + 1;
                    var tlbEntries = (int)(leaf.ecx + 1);
                    var cacheSize = ways * partitioning * lineSize * tlbEntries;
                    Levels[cacheId] = new CacheLevelInfoX86(level, cacheType, cacheSize, ways, lineSize, tlbEntries, partitioning);
                    _size++;
                }
            }
        }
    }
}