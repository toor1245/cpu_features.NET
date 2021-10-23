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

using System;
using CpuFeaturesDotNet.Native;

namespace CpuFeaturesDotNet.Aarch64.CpuInfo
{
    public static unsafe class CpuInfoAarch64
    {
        public static CpuImplementorAarch64 Implementer { get; }
        public static int Variant { get; }
        public static CpuPartNumberAarch64 Part { get; }
        public static int Revision { get; }

        static CpuInfoAarch64()
        {
            if (!Architecture.IsArchAarch64())
            {
                throw new NotSupportedException();
            }

            Implementer = CpuInfoUtilsAarch64.GetImplementerAarch64();
            Part = CpuInfoUtilsAarch64.GetPartNumberAarch64();
        }
    }
}