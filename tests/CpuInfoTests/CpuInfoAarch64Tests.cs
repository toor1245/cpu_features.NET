using CpuFeaturesDotNet.Aarch64.CpuInfo;
using CpuFeaturesDotNet.UnitTesting.Attributes;
using Xunit;
using Xunit.Abstractions;

namespace CpuFeaturesDotNet.UnitTesting.CpuInfoTests
{
    public class CpuInfoAarch64Tests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CpuInfoAarch64Tests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [FactArm64]
        public void Implementor()
        {
            _testOutputHelper.WriteLine(CpuInfoAarch64.Implementer.ToString());
            Assert.True(CpuInfoAarch64.Implementer == CpuImplementorAarch64.ARM);
        }
    }
}