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

using CpuFeaturesDotNet.UnitTesting.Attributes;
using Xunit;
using Architecture = CpuFeaturesDotNet.Native.Architecture;

namespace CpuFeaturesDotNet.UnitTesting.ArchTests.ArmTests
{
    public class CpuInfoArmTests
    {
        [FactArmAny]
        public void IsArchArmAny_True()
        {
            Assert.True(Architecture.IsArchArmAny());
        }

        [FactArm32]
        public void IsArchArm32_True()
        {
            Assert.False(Architecture.IsArchArm32());
        }

        [FactArm64]
        public void IsArchArm64_True()
        {
            Assert.True(Architecture.IsArchArm64());
        }

        [Fact]
        public void TestValue()
        {
            Assert.False(true);
        }
    }
}