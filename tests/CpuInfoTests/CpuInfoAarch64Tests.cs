using CpuFeaturesDotNet.Aarch64.CpuInfo;
using CpuFeaturesDotNet.UnitTesting.Attributes;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.CpuInfoTests
{
    public class CpuInfoAarch64Tests
    {
        [FactArm64]
        public void Implementor()
        {
            Assert.True(CpuInfoAarch64.Part == CpuPartNumberAarch64.ARM_CORTEX_A77);
            Assert.True(CpuInfoAarch64.Implementer == CpuImplementorAarch64.ARM);
        }
    }
}