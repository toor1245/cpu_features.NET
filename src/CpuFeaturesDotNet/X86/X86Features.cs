// Copyright (c) 2022 Mykola Hohsadze 
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

using System.Runtime.InteropServices;

namespace CpuFeaturesDotNet.X86
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct X86Features
    {
        private readonly int featuresRaw1;
        private readonly int featuresRaw2;

        public bool IsSupportedFPU => BitUtils.IsBitSet((ulong)featuresRaw1, 0);
        public bool IsSupportedTSC => BitUtils.IsBitSet((ulong)featuresRaw1, 1);
        public bool IsSupportedCX8 => BitUtils.IsBitSet((ulong)featuresRaw1, 2);
        public bool IsSupportedCLFSH => BitUtils.IsBitSet((ulong)featuresRaw1, 3);
        public bool IsSupportedMMX => BitUtils.IsBitSet((ulong)featuresRaw1, 4);
        public bool IsSupportedAES => BitUtils.IsBitSet((ulong)featuresRaw1, 5);
        public bool IsSupportedERMS => BitUtils.IsBitSet((ulong)featuresRaw1, 6);
        public bool IsSupportedF16C => BitUtils.IsBitSet((ulong)featuresRaw1, 7);
        public bool IsSupportedFMA4 => BitUtils.IsBitSet((ulong)featuresRaw1, 8);
        public bool IsSupportedFMA3 => BitUtils.IsBitSet((ulong)featuresRaw1, 9);
        public bool IsSupportedVAES => BitUtils.IsBitSet((ulong)featuresRaw1, 10);
        public bool IsSupportedVPCLMULQDQ => BitUtils.IsBitSet((ulong)featuresRaw1, 11);
        public bool IsSupportedBMI1 => BitUtils.IsBitSet((ulong)featuresRaw1, 12);
        public bool IsSupportedHLE => BitUtils.IsBitSet((ulong)featuresRaw1, 13);
        public bool IsSupportedBMI2 => BitUtils.IsBitSet((ulong)featuresRaw1, 14);
        public bool IsSupportedRTM => BitUtils.IsBitSet((ulong)featuresRaw1, 15);
        public bool IsSupportedRDSEED => BitUtils.IsBitSet((ulong)featuresRaw1, 16);
        public bool IsSupportedCLFLUSHOPT => BitUtils.IsBitSet((ulong)featuresRaw1, 17);
        public bool IsSupportedCLWB => BitUtils.IsBitSet((ulong)featuresRaw1, 18);

        public bool IsSupportedSSE => BitUtils.IsBitSet((ulong)featuresRaw1, 19);
        public bool IsSupportedSSE2 => BitUtils.IsBitSet((ulong)featuresRaw1, 20);
        public bool IsSupportedSSE3 => BitUtils.IsBitSet((ulong)featuresRaw1, 21);
        public bool IsSupportedSSSE3 => BitUtils.IsBitSet((ulong)featuresRaw1, 22);
        public bool IsSupportedSSE4_1 => BitUtils.IsBitSet((ulong)featuresRaw1, 23);
        public bool IsSupportedSSE4_2 => BitUtils.IsBitSet((ulong)featuresRaw1, 24);
        public bool IsSupportedSSE4A => BitUtils.IsBitSet((ulong)featuresRaw1, 25);

        public bool IsSupportedAVX => BitUtils.IsBitSet((ulong)featuresRaw1, 26);
        public bool IsSupportedAVX_VNNI => BitUtils.IsBitSet((ulong)featuresRaw1, 27);
        public bool IsSupportedAVX2 => BitUtils.IsBitSet((ulong)featuresRaw1, 28);

        public bool IsSupportedAVX512F => BitUtils.IsBitSet((ulong)featuresRaw1, 29);
        public bool IsSupportedAVX512CD => BitUtils.IsBitSet((ulong)featuresRaw1, 30);
        public bool IsSupportedAVX512ER => BitUtils.IsBitSet((ulong)featuresRaw1, 31);
        public bool IsSupportedAVX512PF => BitUtils.IsBitSet((ulong)featuresRaw1, 0);
        public bool IsSupportedAVX512BW => BitUtils.IsBitSet((ulong)featuresRaw2, 1);
        public bool IsSupportedAVX512DQ => BitUtils.IsBitSet((ulong)featuresRaw2, 2);
        public bool IsSupportedAVX512VL => BitUtils.IsBitSet((ulong)featuresRaw2, 3);
        public bool IsSupportedAVX512IFMA => BitUtils.IsBitSet((ulong)featuresRaw2, 4);
        public bool IsSupportedAVX512VBMI => BitUtils.IsBitSet((ulong)featuresRaw2, 5);
        public bool IsSupportedAVX512VBMI2 => BitUtils.IsBitSet((ulong)featuresRaw2, 6);
        public bool IsSupportedAVX512VNNI => BitUtils.IsBitSet((ulong)featuresRaw2, 7);
        public bool IsSupportedAVX512BITALG => BitUtils.IsBitSet((ulong)featuresRaw2, 8);
        public bool IsSupportedAVX512VPOPCNTDQ => BitUtils.IsBitSet((ulong)featuresRaw2, 9);
        public bool IsSupportedAVX512_4VNNIW => BitUtils.IsBitSet((ulong)featuresRaw2, 10);
        public bool IsSupportedAVX512_4VBMI2 => BitUtils.IsBitSet((ulong)featuresRaw2, 11);
        public bool IsSupportedAVX512_SECOND_FMA => BitUtils.IsBitSet((ulong)featuresRaw2, 12);
        public bool IsSupportedAVX512_4FMAPS => BitUtils.IsBitSet((ulong)featuresRaw2, 13);
        public bool IsSupportedAVX512_BF16 => BitUtils.IsBitSet((ulong)featuresRaw2, 14);
        public bool IsSupportedAVX512_VP2INTERSECT => BitUtils.IsBitSet((ulong)featuresRaw2, 15);

        public bool IsSupportedAMX_BF16 => BitUtils.IsBitSet((ulong)featuresRaw2, 16);
        public bool IsSupportedAMX_TILE => BitUtils.IsBitSet((ulong)featuresRaw2, 17);
        public bool IsSupportedAMX_INT8 => BitUtils.IsBitSet((ulong)featuresRaw2, 18);

        public bool IsSupportedPCLMULQDQ => BitUtils.IsBitSet((ulong)featuresRaw2, 19);
        public bool IsSupportedSMX => BitUtils.IsBitSet((ulong)featuresRaw2, 20);
        public bool IsSupportedSGX => BitUtils.IsBitSet((ulong)featuresRaw2, 21);
        public bool IsSupportedCX16 => BitUtils.IsBitSet((ulong)featuresRaw2, 22);
        public bool IsSupportedSHA => BitUtils.IsBitSet((ulong)featuresRaw2, 23);
        public bool IsSupportedDPOPCNT => BitUtils.IsBitSet((ulong)featuresRaw2, 24);
        public bool IsSupportedDMOVBE => BitUtils.IsBitSet((ulong)featuresRaw2, 25);
        public bool IsSupportedDRDRND => BitUtils.IsBitSet((ulong)featuresRaw2, 26);

        public bool IsSupportedDCA => BitUtils.IsBitSet((ulong)featuresRaw2, 27);
        public bool IsSupportedSS => BitUtils.IsBitSet((ulong)featuresRaw2, 28);
        public bool IsSupportedADX => BitUtils.IsBitSet((ulong)featuresRaw2, 29);

        internal X86Features(int featuresRaw1, int featuresRaw2)
        {
            this.featuresRaw1 = featuresRaw1;
            this.featuresRaw2 = featuresRaw2;
        }
    }
}