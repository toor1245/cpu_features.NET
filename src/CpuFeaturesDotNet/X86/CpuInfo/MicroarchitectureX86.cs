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
    public enum MicroarchitectureX86
    {
        X86_UNKNOWN,            // X86 UNKNOWN
        INTEL_CORE,             // CORE
        INTEL_PENRYN,           // PENRYN
        INTEL_NEHALEM,          // NEHALEM
        INTEL_ATOM_BONNELL,     // BONNELL
        INTEL_WESTMERE,         // WESTMERE
        INTEL_SANDYBRIDGE,      // SANDYBRIDGE
        INTEL_IVYBRIDGE,        // IVYBRIDGE
        INTEL_ATOM_SILVERMONT,  // SILVERMONT
        INTEL_HASWELL,          // HASWELL
        INTEL_BROADWELL,        // BROADWELL
        INTEL_SKYLAKE,          // SKYLAKE
        INTEL_ATOM_GOLDMONT,    // GOLDMONT
        INTEL_KABY_LAKE,        // KABY LAKE
        INTEL_COFFEE_LAKE,      // COFFEE LAKE
        INTEL_WHISKEY_LAKE,     // WHISKEY LAKE
        INTEL_CANNON_LAKE,      // CANNON LAKE
        INTEL_ICE_LAKE,         // ICE LAKE
        INTEL_TIGER_LAKE,       // TIGER LAKE
        INTEL_SAPPHIRE_RAPIDS,  // SAPPHIRE RAPIDS
        AMD_HAMMER,             // K8 HAMMER
        AMD_K10,                // K10
        AMD_K11,                // K11
        AMD_K12,                // K12
        AMD_BOBCAT,             // K14 BOBCAT
        AMD_PILEDRIVER,         // K15 PILEDRIVER
        AMD_STREAMROLLER,       // K15 STREAMROLLER
        AMD_EXCAVATOR,          // K15 EXCAVATOR
        AMD_BULLDOZER,          // K15 BULLDOZER
        AMD_JAGUAR,             // K16 JAGUAR
        AMD_PUMA,               // K16 PUMA
        AMD_ZEN,                // K17 ZEN
        AMD_ZEN_PLUS,           // K17 ZEN+
        AMD_ZEN2,               // K17 ZEN 2
        AMD_ZEN3,               // K19 ZEN 3
    }
}