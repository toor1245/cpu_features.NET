using CpuFeaturesDotNet.Native;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.Attributes
{
    public sealed class FactArm64Attribute : FactAttribute
    {
        public FactArm64Attribute()
        {
            if (!Architecture.IsArchArm64())
            {
                Skip = "Ignored on unsupported arm microarchitecture";
            }
        }
    }
}