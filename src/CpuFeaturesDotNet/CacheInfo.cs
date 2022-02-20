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

namespace CpuFeaturesDotNet
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct CacheInfo
    {
        public readonly int Size;

        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 10)]
        public readonly CacheLevelInfo[] Levels;

        /// <summary>
        /// Returns cache hierarchy informations.
        /// Can call cpuid multiple times.
        /// </summary>
#if (X64 || X86)
        public static CacheInfo GetX86CacheInfo() => CacheInfoNative._GetX86CacheInfoPort();
#else
        public static CacheInfo GetX86CacheInfo() => throw new System.PlatformNotSupportedException();
#endif
    }
}