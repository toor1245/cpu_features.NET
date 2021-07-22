using CpuFeaturesDotNet.Native.OperatingSystem;
using CpuFeaturesDotNet.Utils;

namespace CpuFeaturesDotNet.X86
{
    internal ref struct OsPreservesX86
    {
        public bool SseRegisters;
        public bool AvxRegisters;
        public bool Avx512Registers;
        public bool AmxRegisters;

        public void SetAvx512FRegister(uint xcr0Eax)
        {
            Avx512Registers = OSNative.IsDarwin()
                ? DarwinNative.GetDarwinSysCtlByName("hw.optional.avx512f")
                : FeaturesUtilsX86.HasZmmOsXSave(xcr0Eax);
        }
    }
}