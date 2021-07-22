using System;
using System.Runtime.CompilerServices;
using CpuFeaturesDotNet.Utils;
using static CpuFeaturesDotNet.Utils.BitUtils;
using static CpuFeaturesDotNet.Utils.UtilsX86;
using static CpuFeaturesDotNet.Utils.FeaturesUtilsX86;

namespace CpuFeaturesDotNet.X86
{
    public static partial class CpuInfoX86
    {
        public static class FeaturesX86
        {
            public static bool IsSupportedFPU { get; private set; }
            public static bool IsSupportedTSC { get; private set; }
            public static bool IsSupportedCX8 { get; private set; }
            public static bool IsSupportedCLFSH { get; private set; }
            public static bool IsSupportedMMX { get; private set; }
            public static bool IsSupportedAES { get; private set; }
            public static bool IsSupportedERMS { get; private set; }
            public static bool IsSupportedF16C { get; private set; }
            public static bool IsSupportedFMA4 { get; private set; }
            public static bool IsSupportedFMA3 { get; private set; }
            public static bool IsSupportedVAES { get; private set; }
            public static bool IsSupportedVPCLMULQDQ { get; private set; }
            public static bool IsSupportedBMI1 { get; private set; }
            public static bool IsSupportedHLE { get; private set; }
            public static bool IsSupportedBMI2 { get; private set; }
            public static bool IsSupportedRTM { get; private set; }
            public static bool IsSupportedRDSEED { get; private set; }
            public static bool IsSupportedCLFLUSHOPT { get; private set; }
            public static bool IsSupportedCLWB { get; private set; }

            public static bool IsSupportedSSE { get; private set; }
            public static bool IsSupportedSSE2 { get; private set; }
            public static bool IsSupportedSSE3 { get; private set; }
            public static bool IsSupportedSSSE3 { get; private set; }
            public static bool IsSupportedSSE41 { get; private set; }
            public static bool IsSupportedSSE42 { get; private set; }
            public static bool IsSupportedSSE4A { get; private set; }

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
            public static bool IsSupportedAMX_BF16 { get; private set; }
            public static bool IsSupportedAMX_TILE { get; private set; }
            public static bool IsSupportedAMX_INT8 { get; private set; }

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

            internal static void GetFeaturesX86Info(in Leaf leaf1, uint maxCpuidLeaf, ref OsPreservesX86 osPreserves,
                int model)
            {
                var leaf_7 = Leaf.SafeCpuId(maxCpuidLeaf, 7);
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
                IsSupportedSGX = IsBitSet(leaf_7.ebx, 2);
                IsSupportedBMI1 = IsBitSet(leaf_7.ebx, 3);
                IsSupportedHLE = IsBitSet(leaf_7.ebx, 4);
                IsSupportedBMI2 = IsBitSet(leaf_7.ebx, 8);
                IsSupportedERMS = IsBitSet(leaf_7.ebx, 9);
                IsSupportedRTM = IsBitSet(leaf_7.ebx, 11);
                IsSupportedRDSEED = IsBitSet(leaf_7.ebx, 18);
                IsSupportedCLFLUSHOPT = IsBitSet(leaf_7.ebx, 23);
                IsSupportedCLWB = IsBitSet(leaf_7.ebx, 24);
                IsSupportedSHA = IsBitSet(leaf_7.ebx, 29);
                IsSupportedVAES = IsBitSet(leaf_7.ecx, 9);
                IsSupportedVPCLMULQDQ = IsBitSet(leaf_7.ecx, 10);
                IsSupportedADX = IsBitSet(leaf_7.ebx, 19);

                var haveXsave = IsBitSet(leaf1.ecx, 26);
                var haveOsxsave = IsBitSet(leaf1.ecx, 27);
                var haveXcr0 = haveXsave && haveOsxsave;

                if (haveXcr0)
                {
                    SetRegisters(leaf1, leaf_7, leaf7_1, model, ref osPreserves);
                }
                else
                {
                    SetRegistersXcr0NotAvailable();
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void SetRegisters(in Leaf leaf1, in Leaf leaf_7,
                in Leaf leaf7_1, int model, ref OsPreservesX86 osPreserves)
            {
                // Here we rely exclusively on cpuid for both CPU and OS support of vector
                // extensions.
                var xcr0Eax = GetXCR0Eax();
                osPreserves.SseRegisters = HasXmmOsXSave(xcr0Eax);
                osPreserves.AvxRegisters = HasYmmOsXSave(xcr0Eax);
                osPreserves.SetAvx512FRegister(xcr0Eax);
                osPreserves.AmxRegisters = HasTmmOsXSave(xcr0Eax);
                SetSimdRegisters(in leaf1, in leaf_7, in leaf7_1, model, ref osPreserves);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void SetSimdRegisters(in Leaf leaf1, in Leaf leaf_7, in Leaf leaf7_1, int model,
                ref OsPreservesX86 osPreserves)
            {
                if (osPreserves.SseRegisters)
                {
                    SetSeeRegisters(in leaf1);
                }
                if (osPreserves.AvxRegisters)
                {
                    SetAvxRegisters(in leaf1, in leaf7_1);
                }
                if (osPreserves.Avx512Registers)
                {
                    SetAvx512Registers(in leaf_7, in leaf7_1, model);
                }
                if (osPreserves.AmxRegisters)
                {
                    SetAmxRegisters(in leaf_7);
                }
            }

            private static void SetSeeRegisters(in Leaf leaf1)
            {
                IsSupportedSSE = IsBitSet(leaf1.edx, 25);
                IsSupportedSSE2 = IsBitSet(leaf1.edx, 26);
                IsSupportedSSE3 = IsBitSet(leaf1.ecx, 0);
                IsSupportedSSSE3 = IsBitSet(leaf1.ecx, 9);
                IsSupportedSSE41 = IsBitSet(leaf1.ecx, 19);
                IsSupportedSSE42 = IsBitSet(leaf1.ecx, 20);
            }

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

            private static void SetAmxRegisters(in Leaf leaf_7)
            {
                IsSupportedAMX_BF16 = IsBitSet(leaf_7.edx, 22);
                IsSupportedAMX_TILE = IsBitSet(leaf_7.edx, 24);
                IsSupportedAMX_INT8 = IsBitSet(leaf_7.edx, 25);
            }

            private static void SetRegistersXcr0NotAvailable()
            {
                if (OSNative.IsWindows())
                {
                    SetRegistersXcr0NotAvailableWindows();
                }
                else if (OSNative.IsDarwin())
                {
                    SetRegistersXcr0NotAvailableDarwin();
                }
            }

            private static void SetRegistersXcr0NotAvailableWindows()
            {
                IsSupportedSSE = OSNative.GetWindowsIsProcessorFeaturePresent(OSNative.WINDOWS_PF_XMMI_INSTRUCTIONS_AVAILABLE);
                IsSupportedSSE2 = OSNative.GetWindowsIsProcessorFeaturePresent(OSNative.WINDOWS_PF_XMMI64_INSTRUCTIONS_AVAILABLE);
                IsSupportedSSE3 = OSNative.GetWindowsIsProcessorFeaturePresent(OSNative.WINDOWS_PF_SSE3_INSTRUCTIONS_AVAILABLE);
            }

            private static void SetRegistersXcr0NotAvailableDarwin()
            {
                IsSupportedSSE = OSNative.GetDarwinSysCtlByName("hw.optional.sse");
                IsSupportedSSE2 = OSNative.GetDarwinSysCtlByName("hw.optional.sse2");
                IsSupportedSSE3 = OSNative.GetDarwinSysCtlByName("hw.optional.sse3");
                IsSupportedSSSE3 = OSNative.GetDarwinSysCtlByName("hw.optional.supplementalsse3");
                IsSupportedSSE41 = OSNative.GetDarwinSysCtlByName("hw.optional.sse4_1");
                IsSupportedSSE42 = OSNative.GetDarwinSysCtlByName("hw.optional.sse4_2");
            }
        }
    }
}