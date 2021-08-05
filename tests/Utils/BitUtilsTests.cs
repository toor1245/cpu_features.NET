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