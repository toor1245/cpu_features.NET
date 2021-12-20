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
    [StructLayout(LayoutKind.Sequential)]
    internal struct LeafX86
    {
        public uint Eax, Ebx, Ecx, Edx;

        private LeafX86(uint eax, uint ebx, uint ecx, uint edx)
        {
            Eax = eax;
            Ebx = ebx;
            Ecx = ecx;
            Edx = edx;
        }

        public static LeafX86 SafeCpuId(uint maxExtensionCpuId, uint leafId, int ecx = 0)
        {
            return leafId <= maxExtensionCpuId ? CpuId(leafId, ecx) : new LeafX86();
        }

        [DllImport(NATIVE_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cpuid")]
        public static extern LeafX86 CpuId(uint leafId, int ecx = 0);
    }
}