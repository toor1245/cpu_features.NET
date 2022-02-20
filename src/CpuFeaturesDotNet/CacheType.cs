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

namespace CpuFeaturesDotNet
{
    public enum CacheType
    {
        CPU_FEATURE_CACHE_NULL = 0,
        CPU_FEATURE_CACHE_DATA = 1,
        CPU_FEATURE_CACHE_INSTRUCTION = 2,
        CPU_FEATURE_CACHE_UNIFIED = 3,
        CPU_FEATURE_CACHE_TLB = 4,
        CPU_FEATURE_CACHE_DTLB = 5,
        CPU_FEATURE_CACHE_STLB = 6,
        CPU_FEATURE_CACHE_PREFETCH = 7
    }
}