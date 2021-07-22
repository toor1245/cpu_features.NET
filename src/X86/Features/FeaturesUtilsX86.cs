namespace CpuFeaturesDotNet.X86
{
    internal static class FeaturesUtilsX86
    {
        private const int MASK_XMM = 0x2;
        private const int MASK_YMM = 0x4;
        private const int MASK_MASKREG = 0x20;
        private const int MASK_ZMM0_15 = 0x40;
        private const int MASK_ZMM16_31 = 0x80;
        private const int MASK_XTILECFG = 0x20000;
        private const int MASK_XTILEDATA = 0x40000;

        internal static bool HasMask(uint value, uint mask)
        {
            return (value & mask) == mask;
        }

        // Checks that operating system saves and restores xmm registers during context
        // switches.
        internal static bool HasXmmOsXSave(uint xcr0_eax)
        {
            return HasMask(xcr0_eax, MASK_XMM);
        }

        // Checks that operating system saves and restores ymm registers during context
        // switches.
        internal static bool HasYmmOsXSave(uint xcr0_eax)
        {
            return HasMask(xcr0_eax, MASK_XMM | MASK_YMM);
        }

        // Checks that operating system saves and restores zmm registers during context
        // switches.
        internal static bool HasZmmOsXSave(uint xcr0_eax)
        {
            return HasMask(xcr0_eax, MASK_XMM | MASK_YMM | MASK_MASKREG | MASK_ZMM0_15 |
                                     MASK_ZMM16_31);
        }

        // Checks that operating system saves and restores AMX/TMUL state during context
        // switches.
        internal static bool HasTmmOsXSave(uint xcr0_eax)
        {
            return HasMask(xcr0_eax, MASK_XMM | MASK_YMM | MASK_MASKREG | MASK_ZMM0_15 |
                                     MASK_ZMM16_31 | MASK_XTILECFG | MASK_XTILEDATA);
        }

        internal static bool HasSecondFMA(int model)
        {
            switch (model)
            {
                // Skylake server
                case 0x55:
                    {
                        var proc_name = CpuInfoX86.BrandString;
                        // detect Xeon
                        if (proc_name[9] != 'X') return true;
                        switch (proc_name[17])
                        {
                            // detect Silver or Bronze
                            case 'S':
                            case 'B':
                                return false;
                            // detect Gold 5_20 and below, except for Gold 53__
                            case 'G' when proc_name[22] == '5':
                                return proc_name[23] == '3' || proc_name[24] == '2' && proc_name[25] == '2';
                        }

                        // detect Xeon W 210x
                        if (proc_name[17] == 'W' && proc_name[21] == '0') return false;
                        // detect Xeon D 2xxx
                        return proc_name[17] != 'D' || proc_name[19] != '2' || proc_name[20] != '1';
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