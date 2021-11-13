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

using CpuFeaturesDotNet.X86.Simd;

namespace CpuFeaturesDotNet.X86
{
    internal sealed class AmdFeaturesX86 : BaseSimdFeaturesX86
    {
        private readonly LeafX86 _leafExtFeatures;

        public AmdFeaturesX86(in LeafSimdX86 leafSimd, in LeafX86 leafExtFeatures, FeaturesX86 featuresX86)
            : base(leafSimd, featuresX86)
        {
            _leafExtFeatures = leafExtFeatures;
        }

        protected override void SetAvxRegisters()
        {
            base.SetAvxRegisters();
            _featuresX86.IsSupportedFMA4 = BitUtils.IsBitSet(_leafExtFeatures.ecx, 16);
            _featuresX86.IsSupportedSSE4A = BitUtils.IsBitSet(_leafExtFeatures.ecx, 6);
        }
    }
}