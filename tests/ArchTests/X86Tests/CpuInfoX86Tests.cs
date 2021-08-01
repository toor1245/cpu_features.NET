using CpuFeaturesDotNet.Native;
using CpuFeaturesDotNet.UnitTesting.Attributes;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.ArchTests.X86Tests
{
    public class CpuInfoX86Tests
    {
        [FactX86]
        public void IsArchX86_True()
        {
            Assert.False(Architecture.IsArchX86());
        }
    }
}