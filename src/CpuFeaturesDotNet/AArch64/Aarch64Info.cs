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

namespace CpuFeaturesDotNet.AArch64
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Aarch64Info
    {
        public readonly Aarch64Features Features;
        public readonly int Implementer;
        public readonly int Variant;
        public readonly int Part;
        public readonly int Revision;

#if (ARM64 && OS_LINUX)
        /// <summary>
        /// Calls cpuid and returns an initialized AArch64 info.
        /// </summary>
        public static Aarch64Info GetAarch64Info() => Aarch64InfoNative._GetAarch64Info();
#else
        /// <summary>
        /// Calls cpuid and returns an initialized AArch64 info.
        /// </summary>
        public static Aarch64Info GetAarch64Info() => throw new System.PlatformNotSupportedException();
#endif
    }
}