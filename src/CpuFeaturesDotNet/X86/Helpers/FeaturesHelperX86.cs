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

namespace CpuFeaturesDotNet.X86
{
    internal static class FeaturesHelperX86
    {
        private const int MASK_XMM = 0x2;
        private const int MASK_YMM = 0x4;
        private const int MASK_MASKREG = 0x20;
        private const int MASK_ZMM0_15 = 0x40;
        private const int MASK_ZMM16_31 = 0x80;
        private const int MASK_XTILECFG = 0x20000;
        private const int MASK_XTILEDATA = 0x40000;

        private static bool HasMask(uint value, uint mask)
        {
            return (value & mask) == mask;
        }

        // Checks that operating system saves and restores xmm registers during context
        // switches.
        public static bool HasXmmOsXSave(uint xcr0_eax)
        {
            return HasMask(xcr0_eax, MASK_XMM);
        }

        // Checks that operating system saves and restores ymm registers during context
        // switches.
        public static bool HasYmmOsXSave(uint xcr0_eax)
        {
            return HasMask(xcr0_eax, MASK_XMM | MASK_YMM);
        }

        // Checks that operating system saves and restores zmm registers during context
        // switches.
        public static bool HasZmmOsXSave(uint xcr0_eax)
        {
            return HasMask(xcr0_eax, MASK_XMM | MASK_YMM | MASK_MASKREG | MASK_ZMM0_15 |
                                     MASK_ZMM16_31);
        }

        // Checks that operating system saves and restores AMX/TMUL state during context
        // switches.
        public static bool HasTmmOsXSave(uint xcr0_eax)
        {
            return HasMask(xcr0_eax, MASK_XMM | MASK_YMM | MASK_MASKREG | MASK_ZMM0_15 |
                                     MASK_ZMM16_31 | MASK_XTILECFG | MASK_XTILEDATA);
        }

        public static bool HasSecondFMA(int model, string brandString)
        {
            switch (model)
            {
                // Skylake server
                case 0x55:
                    {
                        // detect Xeon
                        if (brandString[9] != 'X') return true;
                        switch (brandString[17])
                        {
                            // detect Silver or Bronze
                            case 'S':
                            case 'B':
                                return false;
                            // detect Gold 5_20 and below, except for Gold 53__
                            case 'G' when brandString[22] == '5':
                                return brandString[23] == '3' || brandString[24] == '2' && brandString[25] == '2';
                        }

                        // detect Xeon W 210x
                        if (brandString[17] == 'W' && brandString[21] == '0') return false;
                        // detect Xeon D 2xxx
                        return brandString[17] != 'D' || brandString[19] != '2' || brandString[20] != '1';
                    }
                // Cannon Lake client
                case 0x66:
                    return false;
                default:
                    // Ice Lake client
                    return model != 0x7d && model != 0x7e;
            }
        }
    }
}