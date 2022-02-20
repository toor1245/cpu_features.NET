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

namespace CpuFeaturesDotNet.AArch32
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ArmFeatures
    {
        private readonly int featuresRaw1;

        public bool IsSupportedSWP => BitUtils.IsBitSet((ulong) featuresRaw1, 0);
        public bool IsSupportedHALF => BitUtils.IsBitSet((ulong) featuresRaw1, 1);
        public bool IsSupportedTHUMB => BitUtils.IsBitSet((ulong) featuresRaw1, 2);
        public bool IsSupported_26BIT => BitUtils.IsBitSet((ulong) featuresRaw1, 3);

        public bool IsSupportedFASTMULT => BitUtils.IsBitSet((ulong) featuresRaw1, 4);
        public bool IsSupportedFPA => BitUtils.IsBitSet((ulong) featuresRaw1, 5);
        public bool IsSupportedVFP => BitUtils.IsBitSet((ulong) featuresRaw1, 6);
        public bool IsSupportedEDSP => BitUtils.IsBitSet((ulong) featuresRaw1, 7);

        public bool IsSupportedJAVA => BitUtils.IsBitSet((ulong) featuresRaw1, 8);
        public bool IsSupportedIWMMXT => BitUtils.IsBitSet((ulong) featuresRaw1, 9);
        public bool IsSupportedCRUNCH => BitUtils.IsBitSet((ulong) featuresRaw1, 10);
        public bool IsSupportedTHUMBEE => BitUtils.IsBitSet((ulong) featuresRaw1, 11);
        public bool IsSupportedNEON => BitUtils.IsBitSet((ulong) featuresRaw1, 12);
        public bool IsSupportedVFPV3 => BitUtils.IsBitSet((ulong) featuresRaw1, 13);
        public bool IsSupportedVFPV3D16 => BitUtils.IsBitSet((ulong) featuresRaw1, 14);
        public bool IsSupportedTLS => BitUtils.IsBitSet((ulong) featuresRaw1, 15);
        public bool IsSupportedVFPV4 => BitUtils.IsBitSet((ulong) featuresRaw1, 16);
        public bool IsSupportedIDIVA => BitUtils.IsBitSet((ulong) featuresRaw1, 17);
        public bool IsSupportedIDIVT => BitUtils.IsBitSet((ulong) featuresRaw1, 18);
        public bool IsSupportedVFPD32 => BitUtils.IsBitSet((ulong) featuresRaw1, 19);
        public bool IsSupportedLPAE => BitUtils.IsBitSet((ulong) featuresRaw1, 20);

        public bool IsSupportedEVTSTRM => BitUtils.IsBitSet((ulong) featuresRaw1, 21);
        public bool IsSupportedAES => BitUtils.IsBitSet((ulong) featuresRaw1, 22);
        public bool IsSupportedPMULL => BitUtils.IsBitSet((ulong) featuresRaw1, 23);
        public bool IsSupportedSHA1 => BitUtils.IsBitSet((ulong) featuresRaw1, 24);
        public bool IsSupportedSHA2 => BitUtils.IsBitSet((ulong) featuresRaw1, 25);
        public bool IsSupportedCRC32 => BitUtils.IsBitSet((ulong) featuresRaw1, 26);

        internal ArmFeatures(int featuresRaw1)
        {
            this.featuresRaw1 = featuresRaw1;
        }
    }
}