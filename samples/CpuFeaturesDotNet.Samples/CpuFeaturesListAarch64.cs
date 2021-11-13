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

using CpuFeaturesDotNet.Aarch64.CpuInfo;
using CpuFeaturesDotNet.Samples.Extensions;
using Xunit.Abstractions;

namespace CpuFeaturesDotNet.Samples
{
    public class CpuFeaturesListAarch64 : Runner
    {
        private readonly ITestOutputHelper _output;

        public CpuFeaturesListAarch64(ITestOutputHelper output)
        {
            _output = output;
        }

        protected override void Run()
        {
            var cpuInfoAarch64 = new CpuInfoAarch64();
            _output.WriteLine(cpuInfoAarch64.ToJsonPretty());
        }
    }
}