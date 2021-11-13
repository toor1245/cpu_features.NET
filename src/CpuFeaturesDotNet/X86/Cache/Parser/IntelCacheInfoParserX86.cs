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

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CpuFeaturesDotNet.X86.Helpers;

namespace CpuFeaturesDotNet.X86.Parser
{
    internal sealed class IntelCacheInfoParserX86 : CacheInfoParserX86
    {
        public IntelCacheInfoParserX86(uint maxExt)
            : base(maxExt)
        {
        }

        public override unsafe List<CacheLevelInfoX86> Parse()
        {
            var leaf = LeafX86.SafeCpuId(_maxExt, 2);
            // The least-significant byte in register EAX (register AL) will always return
            // 01H. Software should ignore this value and not interpret it as an
            // informational descriptor.
            leaf.eax &= 0xFFFFFF00; // Zeroing out AL. 0 is the empty descriptor.
            // The most significant bit (bit 31) of each register indicates whether the
            // register contains valid information (set to 0) or is reserved (set to 1).
            if (BitUtils.IsBitSet(leaf.eax, 31)) leaf.eax = 0;
            if (BitUtils.IsBitSet(leaf.ebx, 31)) leaf.ebx = 0;
            if (BitUtils.IsBitSet(leaf.ecx, 31)) leaf.ecx = 0;
            if (BitUtils.IsBitSet(leaf.edx, 31)) leaf.edx = 0;

            var data = stackalloc byte[16];
            Unsafe.CopyBlock(data, (byte*)Unsafe.AsPointer(ref leaf), 16);
            for (var i = 0; i < 16; i++)
            {
                var descriptor = data[i];
                if (descriptor == 0) continue;
                Levels.Add(CacheInfoHelperX86.GetCacheLevelInfo(descriptor));
            }

            var newCacheLevelInfo = CacheInfoHelperX86.ParseCacheInfo(_maxExt, 4);
            // Override CacheInfo if we successfully extracted Deterministic Cache
            // Parameters.
            var oldLevelInfo = Levels;
            Levels = newCacheLevelInfo.Count > 0 ? newCacheLevelInfo : oldLevelInfo;
            return Levels;
        }
    }
}