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
using static CpuFeaturesDotNet.Native.Library;

namespace CpuFeaturesDotNet.X86
{
    internal static class VendorX86
    {
        [DllImport(NATIVE_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_amd")]
        public static extern bool IsAmd(LeafX86 leaf);
        
        [DllImport(NATIVE_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_intel")]
        public static extern bool IsIntel(LeafX86 leaf);
        
        [DllImport(NATIVE_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "is_hygon")]
        public static extern bool IsHygon(LeafX86 leaf);

    }
}