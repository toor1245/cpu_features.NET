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

namespace CpuFeaturesDotNet.Native
{
    public static class Architecture
    {
        [DllImport(Library.SHARED_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_arch_X86")]
        public static extern bool IsArchX86();

        [DllImport(Library.SHARED_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_arch_i386")]
        public static extern bool IsArchI386();

        [DllImport(Library.SHARED_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_arch_X64")]
        public static extern bool IsArchX64();

        [DllImport(Library.SHARED_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_arch_arm")]
        public static extern bool IsArchArm();

        [DllImport(Library.SHARED_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_arch_aarch32")]
        public static extern bool IsArchAArch32();

        [DllImport(Library.SHARED_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_arch_aarch64")]
        public static extern bool IsArchAArch64();
    }
}