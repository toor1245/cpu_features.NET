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

using static CpuFeaturesDotNet.X86.CpuInfoX86.FeaturesX86;

namespace CpuFeaturesDotNet.X86.Simd
{
    internal sealed class IntelFeaturesX86 : BaseSimdFeaturesX86
    {
        private readonly int _model;

        public IntelFeaturesX86(in LeafSimdX86 leafSimd, int model)
            : base(leafSimd)
        {
            _model = model;
        }

        protected override void SetAvx512Registers()
        {
            base.SetAvx512Registers();
            IsSupportedAVX512SecondFMA = FeaturesUtilsX86.HasSecondFMA(_model);
        }
    }
}