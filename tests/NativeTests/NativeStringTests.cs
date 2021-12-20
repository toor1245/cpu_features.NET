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

using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.Utils
{
    public unsafe class StringUtilsTests
    {
        [Fact]
        public void Strlen_GetLengthOfString_ReturnsSix()
        {
            // Arrange
            var sse41 = stackalloc sbyte[]
            {
                0x49,
                0x49,
                0x41,
                0x22,
                0x5F,
                0x1F
            };
            const int expected = 6;

            // Act
            var actual = NativeString.Strlen(sse41);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Strlen_GetLengthOfString_ReturnsLength()
        {
            // Arrange
            const int expected = 4;
            var sse3 = new sbyte[]
            {
                0x49,
                0x49,
                0x41,
                0x21
            };

            // Act
            var actual = NativeString.Strlen(ref sse3[0]);

            // Assert
            Assert.Equal(expected, actual);

        }
    }
}