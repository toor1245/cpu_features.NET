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

using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Samples.Extensions;
using CpuFeaturesDotNet.X86;
using Xunit.Abstractions;

namespace CpuFeaturesDotNet.Samples
{
    public class CpuFeaturesListX64 : Runner
    {
        private readonly ITestOutputHelper _output;

        public CpuFeaturesListX64(ITestOutputHelper output)
        {
            _output = output;
        }

        protected override void Run()
        {
            if (RuntimeInformation.OSArchitecture != Architecture.X64) return;
            var x86Info = X86Info.GetX86Info();
            var cacheInfo = CacheInfo.GetX86CacheInfo();
            _output.WriteLine(x86Info.ToJsonPretty());
            _output.WriteLine(cacheInfo.ToJsonPretty());
        }
    }
}