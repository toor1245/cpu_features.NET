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

namespace CpuFeaturesDotNet.X86.Simd
{
    internal readonly ref struct LeafSimdX86
    {
        public readonly LeafX86 leaf, leaf1, leaf7, leaf7_1;

        public LeafSimdX86(LeafX86 leaf, LeafX86 leaf1, LeafX86 leaf7, LeafX86 leaf7_1)
        {
            this.leaf = leaf;
            this.leaf1 = leaf1;
            this.leaf7 = leaf7;
            this.leaf7_1 = leaf7_1;
        }
    }
}