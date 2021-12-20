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

using System;
using System.Collections.Generic;

namespace CpuFeaturesDotNet.X86.Parser
{
    internal abstract class CacheInfoParserX86
    {
        internal const int LEVELS_SIZE = 10;
        protected readonly uint _maxExt;
        public List<CacheLevelInfoX86> Levels { get; internal set; }

        protected CacheInfoParserX86(uint maxExt)
        {
            _maxExt = maxExt;
            Levels = new List<CacheLevelInfoX86>();
        }

        public abstract List<CacheLevelInfoX86> Parse();

        internal static CacheInfoParserX86 GetCacheInfoParserX86()
        {
            var leaf = LeafX86.CpuId(0);
            var maxExt = LeafX86.CpuId(0x80000000).Eax;
            if (VendorX86.IsAmdVendor(leaf))
            {
                var cpuidExt = LeafX86.SafeCpuId(maxExt, 0x80000001).Ecx;

                // If CPUID Fn8000_0001_ECX[TopologyExtensions]==0
                // then CPUID Fn8000_0001_E[D,C,B,A]X is reserved.
                // https://www.amd.com/system/files/TechDocs/25481.pdf
                if (BitUtils.IsBitSet(cpuidExt, 22))
                {
                    return new AmdCacheInfoParserX86(maxExt);
                }
                return new AmdLegacyCacheInfoParserX86(maxExt);
            }

            if (VendorX86.IsIntelVendor(leaf))
            {
                return new IntelCacheInfoParserX86(maxExt);
            }

            throw new NotSupportedException();
        }
    }
}