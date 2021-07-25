using CpuFeaturesDotNet.X86.OperatingSystem;
using CpuFeaturesDotNet.X86.Simd;
using static CpuFeaturesDotNet.Utils.BitUtils;

namespace CpuFeaturesDotNet.X86
{
    public static partial class CpuInfoX86
    {
        public static partial class FeaturesX86
        {
            public static bool IsSupportedFPU { get; private set; }
            public static bool IsSupportedTSC { get; private set; }
            public static bool IsSupportedCX8 { get; private set; }
            public static bool IsSupportedCLFSH { get; private set; }
            public static bool IsSupportedMMX { get; private set; }
            public static bool IsSupportedAES { get; private set; }
            public static bool IsSupportedERMS { get; private set; }
            public static bool IsSupportedF16C { get; private set; }
            public static bool IsSupportedFMA4 { get; internal set; }
            public static bool IsSupportedFMA3 { get; internal set; }
            public static bool IsSupportedVAES { get; private set; }
            public static bool IsSupportedVPCLMULQDQ { get; private set; }
            public static bool IsSupportedBMI1 { get; private set; }
            public static bool IsSupportedHLE { get; private set; }
            public static bool IsSupportedBMI2 { get; private set; }
            public static bool IsSupportedRTM { get; private set; }
            public static bool IsSupportedRDSEED { get; private set; }
            public static bool IsSupportedCLFLUSHOPT { get; private set; }
            public static bool IsSupportedCLWB { get; private set; }

            public static bool IsSupportedPCLMULQDQ { get; private set; }
            public static bool IsSupportedSMX { get; private set; }
            public static bool IsSupportedSGX { get; private set; }
            public static bool IsSupportedCX16 { get; private set; }
            public static bool IsSupportedSHA { get; private set; }
            public static bool IsSupportedPOPCNT { get; private set; }
            public static bool IsSupportedMOVBE { get; private set; }
            public static bool IsSupportedRDRND { get; private set; }
            public static bool IsSupportedDCA { get; private set; }
            public static bool IsSupportedSS { get; private set; }
            public static bool IsSupportedADX { get; private set; }

            internal static void GetFeaturesX86Info(in Leaf leaf, in Leaf leaf1, ref OsPreservesX86 osPreserves,
                int model)
            {
                var maxCpuidLeaf = leaf.eax;
                var leaf7 = Leaf.SafeCpuId(maxCpuidLeaf, 7);
                var leaf7_1 = Leaf.SafeCpuId(maxCpuidLeaf, 7, 1);

                IsSupportedFPU = IsBitSet(leaf1.edx, 0);
                IsSupportedTSC = IsBitSet(leaf1.edx, 4);
                IsSupportedCX8 = IsBitSet(leaf1.edx, 8);
                IsSupportedCLFSH = IsBitSet(leaf1.edx, 19);
                IsSupportedMMX = IsBitSet(leaf1.edx, 23);
                IsSupportedSS = IsBitSet(leaf1.edx, 27);
                IsSupportedPCLMULQDQ = IsBitSet(leaf1.ecx, 1);
                IsSupportedSMX = IsBitSet(leaf1.ecx, 6);
                IsSupportedCX16 = IsBitSet(leaf1.ecx, 13);
                IsSupportedDCA = IsBitSet(leaf1.ecx, 18);
                IsSupportedMOVBE = IsBitSet(leaf1.ecx, 22);
                IsSupportedPOPCNT = IsBitSet(leaf1.ecx, 23);
                IsSupportedAES = IsBitSet(leaf1.ecx, 25);
                IsSupportedF16C = IsBitSet(leaf1.ecx, 29);
                IsSupportedRDRND = IsBitSet(leaf1.ecx, 30);
                IsSupportedSGX = IsBitSet(leaf7.ebx, 2);
                IsSupportedBMI1 = IsBitSet(leaf7.ebx, 3);
                IsSupportedHLE = IsBitSet(leaf7.ebx, 4);
                IsSupportedBMI2 = IsBitSet(leaf7.ebx, 8);
                IsSupportedERMS = IsBitSet(leaf7.ebx, 9);
                IsSupportedRTM = IsBitSet(leaf7.ebx, 11);
                IsSupportedRDSEED = IsBitSet(leaf7.ebx, 18);
                IsSupportedCLFLUSHOPT = IsBitSet(leaf7.ebx, 23);
                IsSupportedCLWB = IsBitSet(leaf7.ebx, 24);
                IsSupportedSHA = IsBitSet(leaf7.ebx, 29);
                IsSupportedVAES = IsBitSet(leaf7.ecx, 9);
                IsSupportedVPCLMULQDQ = IsBitSet(leaf7.ecx, 10);
                IsSupportedADX = IsBitSet(leaf7.ebx, 19);

                var haveXsave = IsBitSet(leaf1.ecx, 26);
                var haveOsxsave = IsBitSet(leaf1.ecx, 27);
                var haveXcr0 = haveXsave && haveOsxsave;

                var osFeatures = OsBaseFeaturesX86.GetFeaturesX86();
                var leafSimd = new LeafSimd(leaf, leaf1, leaf7, leaf7_1);
                var simdFeatures = BaseSimdFeaturesX86.GetSimdResolver(in leafSimd, model);

                if (haveXcr0)
                {
                    var xcr0Eax = UtilsX86.GetXCR0Eax();
                    osPreserves.SetRegisters(xcr0Eax, osFeatures);
                    simdFeatures.SetSimdRegisters(ref osPreserves);
                }
                else
                {
                    osFeatures.SetRegistersXcr0NotAvailable();
                }
            }
        }
    }
}