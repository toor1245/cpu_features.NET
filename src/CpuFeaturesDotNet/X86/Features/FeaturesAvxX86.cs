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
    public partial class FeaturesX86
    {
        public bool IsSupportedAVX { get; internal set; }
        public bool IsSupportedAVX2 { get; internal set; }
        public bool IsSupportedAVX512F { get; internal set; }
        public bool IsSupportedAVX512CD { get; internal set; }
        public bool IsSupportedAVX512ER { get; internal set; }
        public bool IsSupportedAVX512PF { get; internal set; }
        public bool IsSupportedAVX512BW { get; internal set; }
        public bool IsSupportedAVX512DQ { get; internal set; }
        public bool IsSupportedAVX512VL { get; internal set; }
        public bool IsSupportedAVX512IFMA { get; internal set; }
        public bool IsSupportedAVX512VBMI { get; internal set; }
        public bool IsSupportedAVX512VBMI2 { get; internal set; }
        public bool IsSupportedAVX512VNNI { get; internal set; }
        public bool IsSupportedAVX512BITALG { get; internal set; }
        public bool IsSupportedAVX512VPOPCNTDQ { get; internal set; }
        public bool IsSupportedAVX512_4VNNIW { get; internal set; }
        public bool IsSupportedAVX512_4VBMI2 { get; internal set; }
        public bool IsSupportedAVX512SecondFMA { get; internal set; }
        public bool IsSupportedAVX512_4FMAPS { get; internal set; }
        public bool IsSupportedAVX512_BF16 { get; internal set; }
        public bool IsSupportedAVX512_VP2INTERSECT { get; internal set; }
    }
}