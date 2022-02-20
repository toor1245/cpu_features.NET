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

namespace CpuFeaturesDotNet.AArch64
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Aarch64Features
    {
        private readonly int featuresRaw1;
        private readonly int featuresRaw2;

        public bool IsSupportedFP => BitUtils.IsBitSet((ulong)featuresRaw1, 0);
        public bool IsSupportedASIMD => BitUtils.IsBitSet((ulong)featuresRaw1, 1);
        public bool IsSupportedEVTSTRM => BitUtils.IsBitSet((ulong)featuresRaw1, 2);
        public bool IsSupportedAES => BitUtils.IsBitSet((ulong)featuresRaw1, 3);
        public bool IsSupportedPMULL => BitUtils.IsBitSet((ulong)featuresRaw1, 4);
        public bool IsSupportedSHA1 => BitUtils.IsBitSet((ulong)featuresRaw1, 5);
        public bool IsSupportedSHA2 => BitUtils.IsBitSet((ulong)featuresRaw1, 6);
        public bool IsSupportedCRC32 => BitUtils.IsBitSet((ulong)featuresRaw1, 7);
        public bool IsSupportedATOMICS => BitUtils.IsBitSet((ulong)featuresRaw1, 8);
        public bool IsSupportedFPHP => BitUtils.IsBitSet((ulong)featuresRaw1, 9);
        public bool IsSupportedASIMDHP => BitUtils.IsBitSet((ulong)featuresRaw1, 10);
        public bool IsSupportedCPUID => BitUtils.IsBitSet((ulong)featuresRaw1, 11);
        public bool IsSupportedASIMDRDM => BitUtils.IsBitSet((ulong)featuresRaw1, 12);
        public bool IsSupportedJSCVT => BitUtils.IsBitSet((ulong)featuresRaw1, 13);
        public bool IsSupportedFCMA => BitUtils.IsBitSet((ulong)featuresRaw1, 14);
        public bool IsSupportedLRCPC => BitUtils.IsBitSet((ulong)featuresRaw1, 15);
        public bool IsSupportedDCPOP => BitUtils.IsBitSet((ulong)featuresRaw1, 16);
        public bool IsSupportedSHA3 => BitUtils.IsBitSet((ulong)featuresRaw1, 17);
        public bool IsSupportedSM3 => BitUtils.IsBitSet((ulong)featuresRaw1, 18);
        public bool IsSupportedSM4 => BitUtils.IsBitSet((ulong)featuresRaw1, 19);
        public bool IsSupportedASIMDDP => BitUtils.IsBitSet((ulong)featuresRaw1, 20);
        public bool IsSupportedSHA512 => BitUtils.IsBitSet((ulong)featuresRaw1, 21);
        public bool IsSupportedSVE => BitUtils.IsBitSet((ulong)featuresRaw1, 22);
        public bool IsSupportedASIMDFHM => BitUtils.IsBitSet((ulong)featuresRaw1, 23);
        public bool IsSupportedDIT => BitUtils.IsBitSet((ulong)featuresRaw1, 24);
        public bool IsSupportedUSCAT => BitUtils.IsBitSet((ulong)featuresRaw1, 25);
        public bool IsSupportedILRCPC => BitUtils.IsBitSet((ulong)featuresRaw1, 26);
        public bool IsSupportedFLAGM => BitUtils.IsBitSet((ulong)featuresRaw1, 27);
        public bool IsSupportedSSBS => BitUtils.IsBitSet((ulong)featuresRaw1, 28);
        public bool IsSupportedSB => BitUtils.IsBitSet((ulong)featuresRaw1, 29);
        public bool IsSupportedPACA => BitUtils.IsBitSet((ulong)featuresRaw1, 30);
        public bool IsSupportedPACG => BitUtils.IsBitSet((ulong)featuresRaw1, 31);
        public bool IsSupportedDCPODP => BitUtils.IsBitSet((ulong)featuresRaw2, 0);
        public bool IsSupportedSVE2 => BitUtils.IsBitSet((ulong)featuresRaw2, 1);
        public bool IsSupportedSVEAES => BitUtils.IsBitSet((ulong)featuresRaw2, 2);
        public bool IsSupportedSVEPMULL => BitUtils.IsBitSet((ulong)featuresRaw2, 3);
        public bool IsSupportedSVEBITPERM => BitUtils.IsBitSet((ulong)featuresRaw2, 4);
        public bool IsSupportedSVESHA3 => BitUtils.IsBitSet((ulong)featuresRaw2, 5);
        public bool IsSupportedSVESM4 => BitUtils.IsBitSet((ulong)featuresRaw2, 6);
        public bool IsSupportedFLAGM2 => BitUtils.IsBitSet((ulong)featuresRaw2, 7);
        public bool IsSupportedFRINT => BitUtils.IsBitSet((ulong)featuresRaw2, 8);
        public bool IsSupportedSVEI8MM => BitUtils.IsBitSet((ulong)featuresRaw2, 9);
        public bool IsSupportedSVEF32MM => BitUtils.IsBitSet((ulong)featuresRaw2, 10);
        public bool IsSupportedSVEF64MM => BitUtils.IsBitSet((ulong)featuresRaw2, 11);
        public bool IsSupportedSVEBF16 => BitUtils.IsBitSet((ulong)featuresRaw2, 12);
        public bool IsSupportedI8MM => BitUtils.IsBitSet((ulong)featuresRaw2, 13);
        public bool IsSupportedBF16 => BitUtils.IsBitSet((ulong)featuresRaw2, 14);
        public bool IsSupportedDGH => BitUtils.IsBitSet((ulong)featuresRaw2, 15);
        public bool IsSupportedRNG => BitUtils.IsBitSet((ulong)featuresRaw2, 16);
        public bool IsSupportedBTI => BitUtils.IsBitSet((ulong)featuresRaw2, 17);
        public bool IsSupportedMTE => BitUtils.IsBitSet((ulong)featuresRaw2, 18);

        internal Aarch64Features(int featuresRaw1, int featuresRaw2)
        {
            this.featuresRaw1 = featuresRaw1;
            this.featuresRaw2 = featuresRaw2;
        }
    }
}