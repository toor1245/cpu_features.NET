using CpuFeaturesDotNet.Utils;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.Utils
{
    public class BitUtilsTest
    {
        [Fact]
        public void ExtractBitRange_ShouldGetLsb3Bits_AssertMustBeEqual4()
        {
            // Arrange
            const uint register = 0b00001100;
            const uint expected = 0b00000100;

            // Act
            var actual = BitUtils.ExtractBitRange(register, 2, 0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}