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

using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Native;

namespace CpuFeaturesDotNet.Aarch64.CpuInfo
{
    internal static class CpuInfoUtilsAarch64
    {
        [DllImport(Library.NATIVE_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "get_aarch64_impl")]
        public static extern CpuImplementorAarch64 GetImplementorAarch64();

        [DllImport(Library.NATIVE_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "get_aarch64_part_num")]
        public static extern CpuPartNumberAarch64 GetPartNumberAarch64();
    }
}