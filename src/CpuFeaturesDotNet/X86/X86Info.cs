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

using System;
using System.Runtime.InteropServices;

namespace CpuFeaturesDotNet.X86
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct X86Info
    {
        public readonly X86Features Features;
        public readonly int Family;
        public readonly int Model;
        public readonly int Stepping;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public readonly string Vendor;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 49)]
        public readonly string BrandString;

#if X64
        /// <summary>
        /// Calls cpuid and returns an initialized X86info.
        /// </summary>
        public static X86Info GetX86Info() => X86InfoNative._GetX86Info();

        /// <summary>
        /// Returns the underlying microarchitecture by looking at X86Info's vendor, family and model.
        /// </summary>
        public static X86Microarchitecture GetX86Microarchitecture(X86Info x86Info)
            => X86InfoNative._GetX86Microarchitecture(in x86Info);

        /// <summary>
        /// Calls cpuid and fills the brand_string.
        /// </summary>
        /// <remarks>This method is deprecated and will be removed when deprecation period is over.</remarks>
        [Obsolete("Remove when deprecation period is over")]
        public static string GetX86BrandString()
        {
            var brandStringBuilder = new System.Text.StringBuilder(48);
            X86InfoNative._FillX86BrandString(brandStringBuilder);
            return brandStringBuilder.ToString();
        }
#else
        /// <summary>
        /// Calls cpuid and returns an initialized X86info.
        /// </summary>
        public static X86Info GetX86Info() => throw new PlatformNotSupportedException();

        /// <summary>
        /// Returns the underlying microarchitecture by looking at X86Info's vendor, family and model.
        /// </summary>
        public static X86Microarchitecture GetX86Microarchitecture(X86Info x86Info) 
            => throw new PlatformNotSupportedException();

        /// <summary>
        /// Calls cpuid and fills the brand_string.
        /// </summary>
        /// <remarks>This method is deprecated and will be removed when deprecation period is over.</remarks>
        [Obsolete("Remove when deprecation period is over")]
        public static string GetX86BrandString() => throw new PlatformNotSupportedException();
#endif
    }
}