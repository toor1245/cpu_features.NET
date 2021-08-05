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
    public static partial class CpuInfoX86
    {
        public static partial class FeaturesX86
        {
            public static bool IsSupportedSSE { get; internal set; }
            public static bool IsSupportedSSE2 { get; internal set; }
            public static bool IsSupportedSSE3 { get; internal set; }
            public static bool IsSupportedSSSE3 { get; internal set; }
            public static bool IsSupportedSSE41 { get; internal set; }
            public static bool IsSupportedSSE42 { get; internal set; }
            public static bool IsSupportedSSE4A { get; internal set; }
        }
    }
}