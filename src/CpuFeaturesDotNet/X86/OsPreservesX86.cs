using CpuFeaturesDotNet.X86.OperatingSystem;

namespace CpuFeaturesDotNet.X86
{
    internal ref struct OsPreservesX86
    {
        public bool HasSseRegisters;
        public bool HasAvxRegisters;
        public bool HasAvx512Registers;
        public bool HasAmxRegisters;

        public void SetRegisters(uint xcr0Eax, OsBaseFeaturesX86 osFeaturesX86)
        {
            HasSseRegisters = FeaturesUtilsX86.HasXmmOsXSave(xcr0Eax);
            HasAvxRegisters = FeaturesUtilsX86.HasYmmOsXSave(xcr0Eax);
            HasAvx512Registers = osFeaturesX86.HasAvx512Registers(xcr0Eax);
            HasAmxRegisters = FeaturesUtilsX86.HasTmmOsXSave(xcr0Eax);
        }
    }
}