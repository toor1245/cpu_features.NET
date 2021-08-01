using CpuFeaturesDotNet.Native;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.Attributes
{
    public sealed class FactX86Attribute : FactAttribute
    {
        public FactX86Attribute()
        {
            if (!Architecture.IsArchX86())
            {
                Skip = "Ignored on unsupported x86-64 microarchitecture";
            }
        }
    }
}