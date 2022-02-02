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
            _featuresX86.IsSupportedSSE = BitUtils.IsBitSet(_leaf1.Edx, 25);
            _featuresX86.IsSupportedSSE2 = BitUtils.IsBitSet(_leaf1.Edx, 26);
            _featuresX86.IsSupportedSSE3 = BitUtils.IsBitSet(_leaf1.Ecx, 0);
            _featuresX86.IsSupportedSSSE3 = BitUtils.IsBitSet(_leaf1.Ecx, 9);
            _featuresX86.IsSupportedSSE41 = BitUtils.IsBitSet(_leaf1.Ecx, 19);
            _featuresX86.IsSupportedSSE42 = BitUtils.IsBitSet(_leaf1.Ecx, 20);
        }

        protected virtual void SetAvxRegisters()
        {
            _featuresX86.IsSupportedFMA3 = BitUtils.IsBitSet(_leaf1.Ecx, 12);
            _featuresX86.IsSupportedAVX = BitUtils.IsBitSet(_leaf1.Ecx, 28);
            _featuresX86.IsSupportedAVX2 = BitUtils.IsBitSet(_leaf7.Ebx, 5);
        }

        protected virtual void SetAvx512Registers()
        {
            _featuresX86.IsSupportedAVX512F = BitUtils.IsBitSet(_leaf7.Ebx, 16);
            _featuresX86.IsSupportedAVX512CD = BitUtils.IsBitSet(_leaf7.Ebx, 28);
            _featuresX86.IsSupportedAVX512ER = BitUtils.IsBitSet(_leaf7.Ebx, 27);
            _featuresX86.IsSupportedAVX512PF = BitUtils.IsBitSet(_leaf7.Ebx, 26);
            _featuresX86.IsSupportedAVX512BW = BitUtils.IsBitSet(_leaf7.Ebx, 30);
            _featuresX86.IsSupportedAVX512DQ = BitUtils.IsBitSet(_leaf7.Ebx, 17);
            _featuresX86.IsSupportedAVX512VL = BitUtils.IsBitSet(_leaf7.Ebx, 31);
            _featuresX86.IsSupportedAVX512IFMA = BitUtils.IsBitSet(_leaf7.Ebx, 21);
            _featuresX86.IsSupportedAVX512VBMI = BitUtils.IsBitSet(_leaf7.Ecx, 1);
            _featuresX86.IsSupportedAVX512VBMI2 = BitUtils.IsBitSet(_leaf7.Ecx, 6);
            _featuresX86.IsSupportedAVX512VNNI = BitUtils.IsBitSet(_leaf7.Ecx, 11);
            _featuresX86.IsSupportedAVX512BITALG = BitUtils.IsBitSet(_leaf7.Ecx, 12);
            _featuresX86.IsSupportedAVX512VPOPCNTDQ = BitUtils.IsBitSet(_leaf7.Ecx, 14);
            _featuresX86.IsSupportedAVX512_4VNNIW = BitUtils.IsBitSet(_leaf7.Edx, 2);
            _featuresX86.IsSupportedAVX512_4VBMI2 = BitUtils.IsBitSet(_leaf7.Edx, 3);
            _featuresX86.IsSupportedAVX512_4FMAPS = BitUtils.IsBitSet(_leaf7.Edx, 3);
            _featuresX86.IsSupportedAVX512_BF16 = BitUtils.IsBitSet(_leaf7_1.Eax, 5);
            _featuresX86.IsSupportedAVX512_VP2INTERSECT = BitUtils.IsBitSet(_leaf7.Edx, 8);
        }

        protected virtual void SetAmxRegisters()
        {
            _featuresX86.IsSupportedAMX_BF16 = BitUtils.IsBitSet(_leaf7.Edx, 22);
            _featuresX86.IsSupportedAMX_TILE = BitUtils.IsBitSet(_leaf7.Edx, 24);
            _featuresX86.IsSupportedAMX_INT8 = BitUtils.IsBitSet(_leaf7.Edx, 25);
        }

        public static BaseSimdFeaturesX86 GetSimdResolver(in LeafSimdX86 leafSimd, FeaturesX86 featuresX86, int model, string brandString)
        {
            if (VendorX86.IsIntel(leafSimd.leaf))
            {
                return new IntelFeaturesX86(leafSimd, model, brandString, featuresX86);
            }
            if (VendorX86.IsAmd(leafSimd.leaf))
            {
                var leafMaxExt = LeafX86.CpuId(0x80000000);
                var maxExtendedCpuid = leafMaxExt.Eax;
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