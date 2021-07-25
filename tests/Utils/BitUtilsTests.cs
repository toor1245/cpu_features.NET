using CpuFeaturesDotNet.Utils;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.Utils
{
    public class BitUtilsTests
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
        
        [Fact]
        public void IsBitSet_CheckMiddleBit_True()
        {
            // Arrange
            const uint register = 0b00001101;
            const bool expected = true;

            // Act
            var actual = BitUtils.IsBitSet(register, 3);

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void IsBitSet_CheckMiddleBit_False()
        {
            // Arrange
            const uint register = 0b00000101;
            const bool expected = false;

            // Act
            var actual = BitUtils.IsBitSet(register, 3);

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void IsBitSet_CheckFirstBit_True()
        {
            // Arrange
            const uint register = 0b00001101;
            const bool expected = true;

            // Act
            var actual = BitUtils.IsBitSet(register, 0);

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void IsBitSet_CheckMsb_True()
        {
            // Arrange
            const uint register = 0b10001100;
            const bool expected = true;

            // Act
            var actual = BitUtils.IsBitSet(register, 7);

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void IsBitSet_CheckMsb_False()
        {
            // Arrange
            const uint register = 0b00001100;
            const bool expected = false;

            // Act
            var actual = BitUtils.IsBitSet(register, 7);

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void IsBitSet_CheckFirstBit_False()
        {
            // Arrange
            const uint register = 0b00001100;
            const bool expected = false;

            // Act
            var actual = BitUtils.IsBitSet(register, 0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}