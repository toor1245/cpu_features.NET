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
using CpuFeaturesDotNet.X86.OperatingSystem;
using CpuFeaturesDotNet.X86.Simd;
using static CpuFeaturesDotNet.Utils.BitUtils;

namespace CpuFeaturesDotNet.X86
{
    internal abstract class BaseSimdFeaturesX86
    {
        private readonly LeafX86 _leaf1;
        private readonly LeafX86 _leaf7;
        private readonly LeafX86 _leaf7_1;
        
        protected readonly FeaturesX86 _featuresX86;

        protected BaseSimdFeaturesX86(in LeafSimdX86 leafSimd, FeaturesX86 featuresX86)
        {
            _featuresX86 = featuresX86;
            _leaf1 = leafSimd.leaf1;
            _leaf7 = leafSimd.leaf7;
            _leaf7_1 = leafSimd.leaf7_1;
        }

        protected virtual void SetSseRegisters()
        {
            _featuresX86.IsSupportedSSE = IsBitSet(_leaf1.edx, 25);
            _featuresX86.IsSupportedSSE2 = IsBitSet(_leaf1.edx, 26);
            _featuresX86.IsSupportedSSE3 = IsBitSet(_leaf1.ecx, 0);
            _featuresX86.IsSupportedSSSE3 = IsBitSet(_leaf1.ecx, 9);
            _featuresX86.IsSupportedSSE41 = IsBitSet(_leaf1.ecx, 19);
            _featuresX86.IsSupportedSSE42 = IsBitSet(_leaf1.ecx, 20);
        }

        protected virtual void SetAvxRegisters()
        {
            _featuresX86.IsSupportedFMA3 = IsBitSet(_leaf1.ecx, 12);
            _featuresX86.IsSupportedAVX = IsBitSet(_leaf1.ecx, 28);
            _featuresX86.IsSupportedAVX2 = IsBitSet(_leaf7.ebx, 5);
        }

        protected virtual void SetAvx512Registers()
        {
            _featuresX86.IsSupportedAVX512F = IsBitSet(_leaf7.ebx, 16);
            _featuresX86.IsSupportedAVX512CD = IsBitSet(_leaf7.ebx, 28);
            _featuresX86.IsSupportedAVX512ER = IsBitSet(_leaf7.ebx, 27);
            _featuresX86.IsSupportedAVX512PF = IsBitSet(_leaf7.ebx, 26);
            _featuresX86.IsSupportedAVX512BW = IsBitSet(_leaf7.ebx, 30);
            _featuresX86.IsSupportedAVX512DQ = IsBitSet(_leaf7.ebx, 17);
            _featuresX86.IsSupportedAVX512VL = IsBitSet(_leaf7.ebx, 31);
            _featuresX86.IsSupportedAVX512IFMA = IsBitSet(_leaf7.ebx, 21);
            _featuresX86.IsSupportedAVX512VBMI = IsBitSet(_leaf7.ecx, 1);
            _featuresX86.IsSupportedAVX512VBMI2 = IsBitSet(_leaf7.ecx, 6);
            _featuresX86.IsSupportedAVX512VNNI = IsBitSet(_leaf7.ecx, 11);
            _featuresX86.IsSupportedAVX512BITALG = IsBitSet(_leaf7.ecx, 12);
            _featuresX86.IsSupportedAVX512VPOPCNTDQ = IsBitSet(_leaf7.ecx, 14);
            _featuresX86.IsSupportedAVX512_4VNNIW = IsBitSet(_leaf7.edx, 2);
            _featuresX86.IsSupportedAVX512_4VBMI2 = IsBitSet(_leaf7.edx, 3);
            _featuresX86.IsSupportedAVX512_4FMAPS = IsBitSet(_leaf7.edx, 3);
            _featuresX86.IsSupportedAVX512_BF16 = IsBitSet(_leaf7_1.eax, 5);
            _featuresX86.IsSupportedAVX512_VP2INTERSECT = IsBitSet(_leaf7.edx, 8);
        }

        protected virtual void SetAmxRegisters()
        {
            _featuresX86.IsSupportedAMX_BF16 = IsBitSet(_leaf7.edx, 22);
            _featuresX86.IsSupportedAMX_TILE = IsBitSet(_leaf7.edx, 24);
            _featuresX86.IsSupportedAMX_INT8 = IsBitSet(_leaf7.edx, 25);
        }

        public static BaseSimdFeaturesX86 GetSimdResolver(in LeafSimdX86 leafSimd, FeaturesX86 featuresX86, int model, string brandString)
        {
            if (VendorX86.IsIntelVendor(leafSimd.leaf))
            {
                return new IntelFeaturesX86(leafSimd, model, brandString, featuresX86);
            }
            if (VendorX86.IsAmdVendor(leafSimd.leaf))
            {
                var leafMaxExt = LeafX86.CpuId(0x80000000);
                var maxExtendedCpuid = leafMaxExt.eax;
                var leafFeatures = LeafX86.SafeCpuId(maxExtendedCpuid, 0x80000001);
                return new AmdFeaturesX86(leafSimd, leafFeatures, featuresX86);
            }
            throw new NotSupportedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SetSimdRegisters(ref OsPreservesX86 osPreserves)
        {
            if (osPreserves.HasSseRegisters)
            {
                SetSseRegisters();
            }

            if (osPreserves.HasAvxRegisters)
            {
                SetAvxRegisters();
            }

            if (osPreserves.HasAvx512Registers)
            {
                SetAvx512Registers();
            }

            if (osPreserves.HasAmxRegisters)
            {
                SetAmxRegisters();
            }
        }
    }
}