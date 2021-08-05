using CpuFeaturesDotNet.Utils;
using Xunit;
// Copyright (c) 2021 Nikolay Hohsadze 
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
                0x49,
                0x49,
                0x41,
                0x22,
                0x5F,
                0x1F
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
                0x49,
                0x49,
                0x41,
                0x21
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