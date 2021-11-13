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

namespace CpuFeaturesDotNet.X86
{
    public class CacheLevelInfoX86
    {
        /// <summary>
        /// Cache level
        /// </summary>
        public int Level { get; }

        /// <summary>
        /// Cache type
        /// </summary>
        public CacheTypeX86 Type { get; }

        /// <summary>
        /// Cache size in bytes
        /// </summary>
        public int CacheSize { get; }

        /// <summary>
        /// Associativity, 0 undefined, 0xFF fully associative
        /// </summary>
        public int Ways { get; }

        /// <summary>
        /// Cache line size in bytes
        /// </summary>
        public int LineSize { get; }

        /// <summary>
        /// Number of entries for TLB
        /// </summary>
        public int TlbEntries { get; }

        /// <summary>
        /// Number of lines per sector
        /// </summary>
        public int Partitioning { get; }

        internal CacheLevelInfoX86()
        {
        }

        internal CacheLevelInfoX86(int level, CacheTypeX86 type, int size, int ways, int lineSize,
            int tlbEntries,
            int partitioning)
        {
            Level = level;
            Ways = ways;
            CacheSize = size;
            LineSize = lineSize;
            TlbEntries = tlbEntries;
            Partitioning = partitioning;
            Type = type;
        }
    }
}