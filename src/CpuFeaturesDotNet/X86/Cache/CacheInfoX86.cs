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
using CpuFeaturesDotNet.Native;
using CpuFeaturesDotNet.X86.Parser;

namespace CpuFeaturesDotNet.X86
{
    public class CacheInfoX86 : ICacheInfoX86
    {
        public List<CacheLevelInfoX86> CacheLevelInfo { get; }

        public CacheInfoX86()
        {
            if (!Architecture.IsArchX86())
            {
                CacheLevelInfo = new List<CacheLevelInfoX86>();
                return;
            }
            CacheLevelInfo = CacheInfoParserX86.GetCacheInfoParserX86().Parse();
        }
    }
}