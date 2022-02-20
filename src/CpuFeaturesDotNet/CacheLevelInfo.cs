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
    public readonly struct CacheLevelInfo
    {
        /// <summary>
        /// Cache level.
        /// </summary>
        public readonly int Level;

        /// <summary>
        /// Cache type.
        /// </summary>
        public readonly CacheType CacheType;

        /// <summary>
        /// Cache size in bytes.
        /// </summary>
        public readonly int CacheSize;

        /// <summary>
        /// Associativity, 0 undefined, 0xFF fully associative.
        /// </summary>
        public readonly int Ways;

        /// <summary>
        /// Cache line size in bytes.
        /// </summary>
        public readonly int LineSize;

        /// <summary>
        /// Number of entries for TLB.
        /// </summary>
        public readonly int TlbEntries;

        /// <summary>
        /// Number of lines per sector.
        /// </summary>
        public readonly int Partitioning;
    }
}