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

using System.Runtime.CompilerServices;
using System.Text;
using static CpuFeaturesDotNet.Utils.BitUtils;

namespace CpuFeaturesDotNet.X86
{
    public class CpuInfoX86 : ICpuInfoX86
    {
        public int Family { get; }
        public int Model { get; }
        public int Stepping { get; }
        public string BrandString { get; }
        public MicroarchitectureX86 Microarchitecture { get; }
        public FeaturesX86 Features { get; }

        public CpuInfoX86()
        {
            var leaf = LeafX86.CpuId(0);
            var maxCpuidLeaf = leaf.eax;
            var leaf1 = LeafX86.SafeCpuId(maxCpuidLeaf, 1);

            var family = ExtractBitRange(leaf1.eax, 11, 8);
            var extendedFamily = ExtractBitRange(leaf1.eax, 27, 20);
            var model = ExtractBitRange(leaf1.eax, 7, 4);
            var extendedModel = ExtractBitRange(leaf1.eax, 19, 16);

            Family = (int)(extendedFamily + family);
            Model = (int)((extendedModel << 4) + model);
            Stepping = (int)ExtractBitRange(leaf1.eax, 3, 0);
            BrandString = GetBrandString();
            Microarchitecture = NativeX86.GetMicroarchitectureX86(leaf, Family, Model, Stepping);
            Features = new FeaturesX86(in leaf, in leaf1, Model, BrandString);
        }
        
        private static unsafe string GetBrandString()
        {
            var brandString = stackalloc byte[49];
            var leafExt = LeafX86.CpuId(0x80000000);
            var maxCpuidLeafExt = leafExt.eax;

            SetString(maxCpuidLeafExt, 0x80000002, brandString);
            SetString(maxCpuidLeafExt, 0x80000003, brandString + 16);
            SetString(maxCpuidLeafExt, 0x80000004, brandString + 32);
            brandString[48] = (byte)'\0';
            return Encoding.ASCII.GetString(brandString, 49);
        }
        
        private static unsafe void SetString(uint max_cpuid_ext_leaf, uint leaf_id, byte* buffer)
        {
            var leaf = LeafX86.SafeCpuId(max_cpuid_ext_leaf, leaf_id);
            Unsafe.CopyBlockUnaligned(buffer, &leaf, (uint)sizeof(LeafX86));
        }
    }
}
