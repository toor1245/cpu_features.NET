// Copyright (c) 2021 Nikolay Hohsadze 
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using CpuFeaturesDotNet.X86.OperatingSystem;
using CpuFeaturesDotNet.X86.Simd;
using static CpuFeaturesDotNet.Utils.BitUtils;

namespace CpuFeaturesDotNet.X86
{
    public partial class FeaturesX86
    {
        public bool IsSupportedFPU { get; }
        public bool IsSupportedTSC { get; }
        public bool IsSupportedCX8 { get; }
        public bool IsSupportedCLFSH { get; }
        public bool IsSupportedMMX { get; }
        public bool IsSupportedAES { get; }
        public bool IsSupportedERMS { get; }
        public bool IsSupportedF16C { get; }
        public bool IsSupportedFMA4 { get; internal set; }
        public bool IsSupportedFMA3 { get; internal set; }
        public bool IsSupportedVAES { get; }
        public bool IsSupportedVPCLMULQDQ { get; }
        public bool IsSupportedBMI1 { get; }
        public bool IsSupportedHLE { get; }
        public bool IsSupportedBMI2 { get; }
        public bool IsSupportedRTM { get; }
        public bool IsSupportedRDSEED { get; }
        public bool IsSupportedCLFLUSHOPT { get; }
        public bool IsSupportedCLWB { get; }

        public bool IsSupportedPCLMULQDQ { get; }
        public bool IsSupportedSMX { get; }
        public bool IsSupportedSGX { get; }
        public bool IsSupportedCX16 { get; }
        public bool IsSupportedSHA { get; }
        public bool IsSupportedPOPCNT { get; }
        public bool IsSupportedMOVBE { get; }
        public bool IsSupportedRDRND { get; }
        public bool IsSupportedDCA { get; }
        public bool IsSupportedSS { get; }
        public bool IsSupportedADX { get; }

        internal FeaturesX86(in LeafX86 leaf, in LeafX86 leaf1, int model, string brandString)
        {
            var maxCpuidLeaf = leaf.eax;
            var leaf7 = LeafX86.SafeCpuId(maxCpuidLeaf, 7);
            var leaf7_1 = LeafX86.SafeCpuId(maxCpuidLeaf, 7, 1);

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

            var osFeatures = OsBaseFeaturesX86.GetFeaturesX86(this);
            var leafSimd = new LeafSimdX86(leaf, leaf1, leaf7, leaf7_1);
            var simdFeatures = BaseSimdFeaturesX86.GetSimdResolver(in leafSimd, this, model, brandString);

            if (haveXcr0)
            {
                var xcr0Eax = NativeX86.GetXCR0Eax();
                var osPreserves = new OsPreservesX86(xcr0Eax, osFeatures);
                simdFeatures.SetSimdRegisters(ref osPreserves);
            }
            else
            {
                osFeatures.SetRegistersXcr0NotAvailable();
            }
        }
    }
}