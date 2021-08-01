using CpuFeaturesDotNet.Native;
using CpuFeaturesDotNet.Native.OperatingSystem;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.Attributes
{
    public sealed class FactArmAttribute : FactAttribute
    {
        public FactArmAttribute()
        {
            if (!OSNative.IsLinuxOrAndroid())
            {
                Skip = "Not supported OS. At the moment shared library works only on Linux";
                return;
            }
            if (!Architecture.IsArchArmAny())
            {
                Skip = "Ignored on unsupported arm microarchitecture";
            }
        }
        
    }
}