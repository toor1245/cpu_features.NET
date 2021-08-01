using CpuFeaturesDotNet.Native;
using CpuFeaturesDotNet.UnitTesting.Attributes;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.Arm
{
    public class CpuInfoArmTests
    {
        [FactArm]
        public void IsArchArmAny_True()
        {
            Assert.False(Architecture.IsArchArmAny());
        }
    }
}