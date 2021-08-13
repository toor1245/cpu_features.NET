using CpuFeaturesDotNet.Native;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.Attributes
{
    public sealed class FactArm32Attribute : FactAttribute
    {
        public FactArm32Attribute()
        {
            if (!Architecture.IsArchArm32())
            {
                Skip = "Ignored on unsupported arm microarchitecture";
            }
        }
    }
}