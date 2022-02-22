// Copyright (c) 2022 Mykola Hohsadze 
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

using System;
using CpuFeaturesDotNet.AArch64;
using CpuFeaturesDotNet.Testing.Attributes;
using CpuFeaturesDotNet.X86;
using Xunit;

namespace CpuFeaturesDotNet.Testing
{
    public class DllImportX86Tests
    {
        [FactX64]
        public void DllImportX86_GetX86Info_Success()
        {
            X86Info.GetX86Info();
        }

        [FactX64]
        public void DllImportX86_GetX86Microarchitecture_Success()
        {
            var x86Info = X86Info.GetX86Info();
            X86Info.GetX86Microarchitecture(x86Info);
        }

        [FactX64]
        public void DllImportX86_GetX86BrandString_Success()
        {
            X86Info.GetX86BrandString();
        }

        [FactX64]
        public void DllImportX86_GetAarch64Info_Throws()
        {
            Assert.Throws<PlatformNotSupportedException>(() => Aarch64Info.GetAarch64Info());
        }
    }
}