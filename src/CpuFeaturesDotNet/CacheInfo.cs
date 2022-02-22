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
        public readonly CacheLevelInfo[] Levels;

        private CacheInfo(int size, CacheLevelInfo[] levels)
        {
            Size = size;
            Levels = levels;
        }

#if (X64 || X86)
        /// <summary>
        /// Returns cache hierarchy informations.
        /// Can call cpuid multiple times.
        /// </summary>
        public static CacheInfo GetX86CacheInfo() => _GetX86CacheInfo();

        private static unsafe CacheInfo _GetX86CacheInfo()
        {
            int size;
            var ptrSize = &size;
            var cacheLevelInfo = new CacheLevelInfo[10];
            fixed (CacheLevelInfo* ptrLevels = cacheLevelInfo)
            {
                CacheInfoNative.__GetX86CacheInfo(ptrSize, ptrLevels);
            }

            return new CacheInfo(*ptrSize, cacheLevelInfo);
        }
#else
        /// <summary>
        /// Returns cache hierarchy informations.
        /// Can call cpuid multiple times.
        /// </summary>
        public static CacheInfo GetX86CacheInfo() => throw new System.PlatformNotSupportedException();
#endif
    }
}