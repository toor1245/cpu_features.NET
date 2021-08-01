using CpuFeaturesDotNet.Native;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.ArchTests.ArmTests
{
    public class CpuInfoArmTests
    {
        [Fact(Skip = "Need to setup CI/CD")]
        public void IsArchArmAny_True()
        {
            Assert.True(Architecture.IsArchArmAny());
        }
    }
}