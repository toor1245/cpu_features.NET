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

namespace CpuFeaturesDotNet.Aarch64.CpuInfo
{
    public sealed class CpuInfoAarch64 : ICpuInfoAarch64
    {
        public CpuImplementorAarch64 Implementer { get; }
        public CpuPartNumberAarch64 Part { get; }
        public int Variant { get; }
        public int Revision { get; }

        public CpuInfoAarch64()
        {
            if (!Architecture.IsArchAarch64())
                return;
            Implementer = CpuInfoUtilsAarch64.GetImplementorAarch64();
            Part = CpuInfoUtilsAarch64.GetPartNumberAarch64();
        }
    }
}