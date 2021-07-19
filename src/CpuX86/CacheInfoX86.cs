using CpuFeaturesDotNet.Utils;

namespace CpuFeaturesDotNet.X86
{
    public unsafe struct CacheInfoX86
    {
        private int size;
        private const int LEVELS_SIZE = 10;
        private CacheLevelInfoX86[] levels;

        public CacheInfoX86(int size)
        {
            this.size = size;
            levels = new CacheLevelInfoX86[LEVELS_SIZE];
        }

        public CacheInfoX86 GetX86CacheInfo()
        {
            var cacheInfoX86 = new CacheInfoX86(0);
            var leaf_0 = Leaf.CpuId(0);
            if (VendorX86.IsVendor(leaf_0, VendorX86.GENUINE_INTEL))
            {

            }
        }

        private static void ParseLeaf2(int max_cpuid_leaf, ref CacheInfoX86 info)
        {
            var leaf = Leaf.SafeCpuId((uint)max_cpuid_leaf, 2);
            var registers = stackalloc uint[]
            {
                leaf.eax,
                leaf.ebx,
                leaf.ecx,
                leaf.edx
            };
            var bytes = stackalloc uint[4];

            for (var i = 0; i < 4; ++i)
            {
                if ((registers[i] & (1U << 31)) != 0)
                {
                    continue;  // register does not contains valid information
                }

                BitUtils.GetByteArrayFromRegister(bytes, registers[i]);

                for (var j = 0; j < 4; ++j)
                {
                    if (bytes[j] == 0xFF)
                    {
                        break; // leaf 4 should be used to fetch cache information
                    }

                    info.levels[info.size] = GetCacheLevelInfo(bytes[j]);
                }
                info.size++;
            }
        }

        CacheInfo GetX86CacheInfo(void)
        {
            CacheInfo info = kEmptyCacheInfo;
            const Leaf leaf_0 = CpuId(0);
            if (IsVendor(leaf_0, CPU_FEATURES_VENDOR_GENUINE_INTEL))
            {
                ParseLeaf2(leaf_0.eax, &info);
                ParseCacheInfo(leaf_0.eax, 4, &info);
            }
            else if (IsVendor(leaf_0, CPU_FEATURES_VENDOR_AUTHENTIC_AMD) ||
                     IsVendor(leaf_0, CPU_FEATURES_VENDOR_HYGON_GENUINE))
            {
                const uint32_t max_ext = CpuId(0x80000000).eax;
                if (!IsReservedAMD(max_ext, 22))
                {
                    ParseCacheInfo(max_ext, 0x8000001D, &info);
                }
            }
            return info;
        }
    }
}