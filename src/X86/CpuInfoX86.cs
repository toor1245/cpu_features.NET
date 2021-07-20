using System;
using System.Runtime.CompilerServices;
using System.Text;
using static CpuFeaturesDotNet.Utils.BitUtils;
using static CpuFeaturesDotNet.Utils.UtilsX86;
using Architecture = CpuFeaturesDotNet.Utils.Architecture;

namespace CpuFeaturesDotNet.X86
{
    public static unsafe partial class CpuInfoX86
    {
        public static int Family { get; }
        public static int Model { get; }
        public static int Stepping { get; }
        public static string BrandString { get; }
        public static MicroarchitectureX86 Microarchitecture { get; }

        static CpuInfoX86()
        {
            if (!Architecture.IsArchX86())
            {
                throw new NotSupportedException("Your target CPU architecture is not X86");
            }
            var leaf = CpuId(0);
            var max_cpuid_leaf = leaf.eax;
            var leaf1 = Leaf.SafeCpuId(max_cpuid_leaf, 1);

            var family = ExtractBitRange(leaf1.eax, 11, 8);
            var extendedFamily = ExtractBitRange(leaf1.eax, 27, 20);
            var model = ExtractBitRange(leaf1.eax, 7, 4);
            var extendedModel = ExtractBitRange(leaf1.eax, 19, 16);

            Family = (int)(extendedFamily + family);
            Model = (int)((extendedModel << 4) + model);
            Stepping = (int)ExtractBitRange(leaf1.eax, 3, 0);
            Microarchitecture = GetMicroarchitectureX86(leaf, Family, Model, Stepping);
            BrandString = GetBrandString();
        }

        private static string GetBrandString()
        {
            var brand_string = stackalloc byte[49];
            var leaf_ext_0 = CpuId(0x80000000);
            var max_cpuid_leaf_ext = leaf_ext_0.eax;

            SetString(max_cpuid_leaf_ext, 0x80000002, brand_string);
            SetString(max_cpuid_leaf_ext, 0x80000003, brand_string + 16);
            SetString(max_cpuid_leaf_ext, 0x80000004, brand_string + 32);
            brand_string[48] = (byte)'\0';
            return Encoding.ASCII.GetString(brand_string, 49);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetString(uint max_cpuid_ext_leaf, uint leaf_id, byte* buffer)
        {
            var leaf = Leaf.SafeCpuId(max_cpuid_ext_leaf, leaf_id);
            Unsafe.CopyBlockUnaligned(buffer, &leaf, (uint)sizeof(Leaf));
        }
    }
}
