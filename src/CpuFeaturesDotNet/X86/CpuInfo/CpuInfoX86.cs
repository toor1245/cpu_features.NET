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

using System;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using CpuFeaturesDotNet.Native;
using CpuFeaturesDotNet.X86.OperatingSystem;
using static CpuFeaturesDotNet.Utils.BitUtils;

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
            Microarchitecture = UtilsX86.GetMicroarchitectureX86(leaf, Family, Model, Stepping);
            BrandString = GetBrandString();
            var osPreserves = new OsPreservesX86();
            FeaturesX86.GetFeaturesX86Info(in leaf, in leaf1, ref osPreserves, Model);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetBrandString()
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetString(uint max_cpuid_ext_leaf, uint leaf_id, byte* buffer)
        {
            var leaf = LeafX86.SafeCpuId(max_cpuid_ext_leaf, leaf_id);
            Unsafe.CopyBlockUnaligned(buffer, &leaf, (uint)sizeof(LeafX86));
        }
    }
}
