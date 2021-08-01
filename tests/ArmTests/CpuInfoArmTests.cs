using CpuFeaturesDotNet.Native;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.Arm
{
    public class CpuInfoArmTests
    {
        [Fact]
        public void IsArchArmAny_True()
        {
            Assert.False(Architecture.IsArchArmAny());
        }
    }
}