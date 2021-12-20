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

        [Theory]
        [InlineData(0b00001101U, 3, true)]
        [InlineData(0b00000101U, 3, false)]
        [InlineData(0b00001101U, 0, true)]
        [InlineData(0b10001101U, 7, true)]
        public void IsBitSet_CheckMiddleBit_True(uint register, int bit, bool expected)
        {
            // Act
            var actual = BitUtils.IsBitSet(register, bit);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}