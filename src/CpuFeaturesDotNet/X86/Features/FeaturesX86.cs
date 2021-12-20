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

        internal FeaturesX86()
        {
        }

        internal FeaturesX86(in LeafX86 leaf, in LeafX86 leaf1, int model, string brandString)
        {
            var maxCpuidLeaf = leaf.Eax;
            var leaf7 = LeafX86.SafeCpuId(maxCpuidLeaf, 7);
            var leaf7_1 = LeafX86.SafeCpuId(maxCpuidLeaf, 7, 1);

            IsSupportedFPU = BitUtils.IsBitSet(leaf1.Edx, 0);
            IsSupportedTSC = BitUtils.IsBitSet(leaf1.Edx, 4);
            IsSupportedCX8 = BitUtils.IsBitSet(leaf1.Edx, 8);
            IsSupportedCLFSH = BitUtils.IsBitSet(leaf1.Edx, 19);
            IsSupportedMMX = BitUtils.IsBitSet(leaf1.Edx, 23);
            IsSupportedSS = BitUtils.IsBitSet(leaf1.Edx, 27);
            IsSupportedPCLMULQDQ = BitUtils.IsBitSet(leaf1.Ecx, 1);
            IsSupportedSMX = BitUtils.IsBitSet(leaf1.Ecx, 6);
            IsSupportedCX16 = BitUtils.IsBitSet(leaf1.Ecx, 13);
            IsSupportedDCA = BitUtils.IsBitSet(leaf1.Ecx, 18);
            IsSupportedMOVBE = BitUtils.IsBitSet(leaf1.Ecx, 22);
            IsSupportedPOPCNT = BitUtils.IsBitSet(leaf1.Ecx, 23);
            IsSupportedAES = BitUtils.IsBitSet(leaf1.Ecx, 25);
            IsSupportedF16C = BitUtils.IsBitSet(leaf1.Ecx, 29);
            IsSupportedRDRND = BitUtils.IsBitSet(leaf1.Ecx, 30);
            IsSupportedSGX = BitUtils.IsBitSet(leaf7.Ebx, 2);
            IsSupportedBMI1 = BitUtils.IsBitSet(leaf7.Ebx, 3);
            IsSupportedHLE = BitUtils.IsBitSet(leaf7.Ebx, 4);
            IsSupportedBMI2 = BitUtils.IsBitSet(leaf7.Ebx, 8);
            IsSupportedERMS = BitUtils.IsBitSet(leaf7.Ebx, 9);
            IsSupportedRTM = BitUtils.IsBitSet(leaf7.Ebx, 11);
            IsSupportedRDSEED = BitUtils.IsBitSet(leaf7.Ebx, 18);
            IsSupportedCLFLUSHOPT = BitUtils.IsBitSet(leaf7.Ebx, 23);
            IsSupportedCLWB = BitUtils.IsBitSet(leaf7.Ebx, 24);
            IsSupportedSHA = BitUtils.IsBitSet(leaf7.Ebx, 29);
            IsSupportedVAES = BitUtils.IsBitSet(leaf7.Ecx, 9);
            IsSupportedVPCLMULQDQ = BitUtils.IsBitSet(leaf7.Ecx, 10);
            IsSupportedADX = BitUtils.IsBitSet(leaf7.Ebx, 19);

            var haveXsave = BitUtils.IsBitSet(leaf1.Ecx, 26);
            var haveOsxsave = BitUtils.IsBitSet(leaf1.Ecx, 27);
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