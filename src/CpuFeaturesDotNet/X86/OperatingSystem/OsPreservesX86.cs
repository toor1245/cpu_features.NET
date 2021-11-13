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

namespace CpuFeaturesDotNet.X86.OperatingSystem
{
    internal readonly ref struct OsPreservesX86
    {
        public readonly bool HasSseRegisters;
        public readonly bool HasAvxRegisters;
        public readonly bool HasAvx512Registers;
        public readonly bool HasAmxRegisters;

        public OsPreservesX86(uint xcr0Eax, OsBaseFeaturesX86 osFeaturesX86)
        {
            HasSseRegisters = FeaturesHelperX86.HasXmmOsXSave(xcr0Eax);
            HasAvxRegisters = FeaturesHelperX86.HasYmmOsXSave(xcr0Eax);
            HasAvx512Registers = osFeaturesX86.HasAvx512Registers(xcr0Eax);
            HasAmxRegisters = FeaturesHelperX86.HasTmmOsXSave(xcr0Eax);
        }
    }
}