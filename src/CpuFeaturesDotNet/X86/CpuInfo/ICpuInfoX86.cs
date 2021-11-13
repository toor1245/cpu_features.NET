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
    public interface ICpuInfoX86
    {
        public int Family { get; }
        public int Model { get; }
        public int Stepping { get; }
        public string BrandString { get; }
        public MicroarchitectureX86 Microarchitecture { get; }
        public FeaturesX86 Features { get; }
    }
}