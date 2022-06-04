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
using System.Text;

namespace CpuFeaturesDotNet.X86
{
    internal static class X86InfoNative
    {
        [DllImport(Library.NATIVE_LIBRARY, EntryPoint = "GetX86InfoPort")]
        public static extern unsafe void __GetX86Info(StringBuilder brandString, StringBuilder vendor, int* model,
            int* stepping, int* family, X86Features* features);

        [DllImport(Library.NATIVE_LIBRARY, EntryPoint = "GetX86MicroarchitecturePort")]
        public static extern X86Microarchitecture _GetX86Microarchitecture(in X86Info info);

        [DllImport(Library.NATIVE_LIBRARY, EntryPoint = "FillX86BrandStringPort")]
        public static extern X86Microarchitecture _FillX86BrandString(StringBuilder brandString);
    }
}
