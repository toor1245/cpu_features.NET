using CpuFeaturesDotNet.Utils;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.Utils
{
    public unsafe class StringUtilsTests
    {
        [Fact]
        public void strlen_GetLengthOfString_ReturnsSix()
        {
            // Arrange
            var sse41 = stackalloc byte[]
            {
                0x49, 0x49, 0x41, 0x22, 0x5F, 0x1F
            };
            const ulong expected = 6UL;

            // Act
            var actual = StringUtils.str_len(sse41);

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void strlen_GetLengthOfString_ReturnsLength()
        {
            // Arrange
            var sse3 = stackalloc byte[]
            {
                0x49, 0x49, 0x41, 0x21
            };
            const ulong expected = 4UL;

            // Act
            var actual = StringUtils.str_len(sse3);

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void strlen_Empty_True()
        {
            // Arrange
            var str = stackalloc byte[] { };
            const ulong expected = 0UL;

            // Act
            var actual = StringUtils.str_len(str);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}