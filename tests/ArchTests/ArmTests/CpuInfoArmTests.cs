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

using CpuFeaturesDotNet.Native;
using CpuFeaturesDotNet.UnitTesting.Attributes;
using Xunit;

namespace CpuFeaturesDotNet.UnitTesting.ArchTests.ArmTests
{
    public class CpuInfoArmTests
    {
        [FactArm]
        public void IsArchArm_True()
        {
            Assert.True(Architecture.IsArchArm());
        }

        [FactAarch32]
        public void IsArchAArch32_True()
        {
            Assert.True(Architecture.IsArchAArch32());
        }

        [FactAarch64]
        public void IsArchAArch64_True()
        {
            Assert.True(Architecture.IsArchAArch64());
        }
    }
}