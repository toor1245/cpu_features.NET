using System;
using CpuFeaturesDotNet.Native.OperatingSystem;

namespace CpuFeaturesDotNet.X86.OperatingSystem
{
    internal abstract class OsBaseFeaturesX86
    {
        public abstract void SetRegistersXcr0NotAvailable();

        public virtual bool HasAvx512Registers(uint xcr0Eax)
        {
            return FeaturesUtilsX86.HasZmmOsXSave(xcr0Eax);
        }

        internal static OsBaseFeaturesX86 GetFeaturesX86()
        {
            if (OSNative.IsWindows())
            {
                return new WindowsFeaturesX86();
            }

            if (OSNative.IsDarwin())
            {
                return new DarwinFeaturesX86();
            }

            throw new NotSupportedException("Not supported Operating System");
        }
    }
}