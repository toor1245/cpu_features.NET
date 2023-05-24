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

using CpuFeaturesDotNet.Samples.Settings;
using CpuFeaturesDotNet.X86;
using Newtonsoft.Json;

namespace CpuFeaturesDotNet.Samples.Extensions;

public static class X86InfoExtensions
{
    public static string ToJsonPretty(this X86Info cpuInfoX86)
    {
        return JsonConvert.SerializeObject(cpuInfoX86, JsonSerializerCpuInfoSettings.Settings);
    }
}