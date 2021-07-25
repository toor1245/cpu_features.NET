using CpuFeaturesDotNet.Utils;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.Utils
{
    public unsafe class MemoryUtilsTests
    {
        [Fact]
        public void memchr_FindCharacter_True()
        {
            // Arrange
            var sse41 = stackalloc byte[]
            {
                0x49, 0x49, 0x41, 0x22, 0x5F, 0x1F
            };
            const int expected = 0x41;

            // Act
            var length = (uint)StringUtils.str_len(sse41);
            var actual = (byte*)MemoryUtils.memchr(sse41, 0x41, length);

            // Assert
            Assert.Equal(expected, *actual);
        }
        
        [Fact]
        public void memchr_LengthNull_True()
        {
            // Arrange
            var sse41 = stackalloc byte[]
            {
                0x49, 0x49, 0x41, 0x22, 0x5F, 0x1F
            };

            // Act
            var actual = (byte*)MemoryUtils.memchr(sse41, 0x41, 0);

            // Assert
            Assert.True(actual == null);
        }
        
        [Fact]
        public void memcmp_CompareStrings_True()
        {
            // Arrange
            var sse41 = stackalloc byte[]
            {
                0x49, 0x49, 0x41, 0x22, 0x5F, 0x1F
            };
            
            var sse42 = stackalloc byte[]
            {
                0x49, 0x49, 0x41, 0x22, 0x5F, 0x20
            };
            var expected = -1;

            // Act
            var actual = MemoryUtils.memcmp(sse41, sse42, (uint)StringUtils.str_len(sse41));

            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void memcmp_CompareStrings_False()
        {
            // Arrange
            var sse41 = stackalloc byte[]
            {
                0x49, 0x49, 0x41, 0x22, 0x5F, 0x1F
            };
            
            var sse42 = stackalloc byte[]
            {
                0x49, 0x49, 0x41, 0x22, 0x5F, 0x1F
            };
            var expected = 0;

            // Act
            var actual = MemoryUtils.memcmp(sse41, sse42, (uint)StringUtils.str_len(sse41));

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}