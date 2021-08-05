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
using static CpuFeaturesDotNet.Utils.BitUtils;
using static CpuFeaturesDotNet.X86.CpuInfoX86.FeaturesX86;

namespace CpuFeaturesDotNet.X86.Simd
{
    internal abstract class BaseSimdFeaturesX86
    {
        private readonly LeafX86 _leaf1;
        private readonly LeafX86 _leaf7;
        private readonly LeafX86 _leaf7_1;

        protected BaseSimdFeaturesX86(in LeafSimdX86 leafsimd)
        {
            _leaf1 = leafsimd.leaf1;
            _leaf7 = leafsimd.leaf7;
            _leaf7_1 = leafsimd.leaf7_1;
        }

        protected virtual void SetSseRegisters()
        {
            IsSupportedSSE = IsBitSet(_leaf1.edx, 25);
            IsSupportedSSE2 = IsBitSet(_leaf1.edx, 26);
            IsSupportedSSE3 = IsBitSet(_leaf1.ecx, 0);
            IsSupportedSSSE3 = IsBitSet(_leaf1.ecx, 9);
            IsSupportedSSE41 = IsBitSet(_leaf1.ecx, 19);
            IsSupportedSSE42 = IsBitSet(_leaf1.ecx, 20);
        }

        protected virtual void SetAvxRegisters()
        {
            IsSupportedFMA3 = IsBitSet(_leaf1.ecx, 12);
            IsSupportedAVX = IsBitSet(_leaf1.ecx, 28);
            IsSupportedAVX2 = IsBitSet(_leaf7.ebx, 5);
        }

        protected virtual void SetAvx512Registers()
        {
            IsSupportedAVX512F = IsBitSet(_leaf7.ebx, 16);
            IsSupportedAVX512CD = IsBitSet(_leaf7.ebx, 28);
            IsSupportedAVX512ER = IsBitSet(_leaf7.ebx, 27);
            IsSupportedAVX512PF = IsBitSet(_leaf7.ebx, 26);
            IsSupportedAVX512BW = IsBitSet(_leaf7.ebx, 30);
            IsSupportedAVX512DQ = IsBitSet(_leaf7.ebx, 17);
            IsSupportedAVX512VL = IsBitSet(_leaf7.ebx, 31);
            IsSupportedAVX512IFMA = IsBitSet(_leaf7.ebx, 21);
            IsSupportedAVX512VBMI = IsBitSet(_leaf7.ecx, 1);
            IsSupportedAVX512VBMI2 = IsBitSet(_leaf7.ecx, 6);
            IsSupportedAVX512VNNI = IsBitSet(_leaf7.ecx, 11);
            IsSupportedAVX512BITALG = IsBitSet(_leaf7.ecx, 12);
            IsSupportedAVX512VPOPCNTDQ = IsBitSet(_leaf7.ecx, 14);
            IsSupportedAVX512_4VNNIW = IsBitSet(_leaf7.edx, 2);
            IsSupportedAVX512_4VBMI2 = IsBitSet(_leaf7.edx, 3);
            IsSupportedAVX512_4FMAPS = IsBitSet(_leaf7.edx, 3);
            IsSupportedAVX512_BF16 = IsBitSet(_leaf7_1.eax, 5);
            IsSupportedAVX512_VP2INTERSECT = IsBitSet(_leaf7.edx, 8);
        }

        protected virtual void SetAmxRegisters()
        {
            IsSupportedAMX_BF16 = IsBitSet(_leaf7.edx, 22);
            IsSupportedAMX_TILE = IsBitSet(_leaf7.edx, 24);
            IsSupportedAMX_INT8 = IsBitSet(_leaf7.edx, 25);
        }

        internal static BaseSimdFeaturesX86 GetSimdResolver(in LeafSimdX86 leafSimd, int model)
        {
            if (VendorX86.IsIntelVendor(leafSimd.leaf))
            {
                return new IntelFeaturesX86(leafSimd, model);
            }

            if (!VendorX86.IsAMDVendor(leafSimd.leaf))
            {
                throw new NotSupportedException();
            }

            var leafMaxExt = LeafX86.CpuId(0x80000000);
            var maxExtendedCpuid = leafMaxExt.eax;
            var leafFeatures = LeafX86.SafeCpuId(maxExtendedCpuid, 0x80000001);
            return new AmdFeaturesX86(leafSimd, leafFeatures);
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