namespace CpuFeaturesDotNet.Utils
{
    internal static unsafe class FeaturesUtilsX86
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
    }
}