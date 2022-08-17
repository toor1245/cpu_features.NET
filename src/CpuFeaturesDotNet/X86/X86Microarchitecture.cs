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

namespace CpuFeaturesDotNet.X86
{
    public enum X86Microarchitecture
    {
        /// <summary>
        /// X86 UNKNOWN
        /// </summary>
        X86_UNKNOWN,

        /// <summary>
        /// ZhangJiang
        /// </summary>
        ZHAOXIN_ZHANGJIANG,

        /// <summary>
        /// WuDaoKou
        /// </summary>
        ZHAOXIN_WUDAOKOU,

        /// <summary>
        /// LuJiaZui
        /// </summary>
        ZHAOXIN_LUJIAZUI,

        /// <summary>
        /// YongFeng
        /// </summary>
        ZHAOXIN_YONGFENG,

        /// <summary>
        /// 80486
        /// </summary>
        INTEL_80486,

        /// <summary>
        /// P5
        /// </summary>
        INTEL_P5,

        /// <summary>
        /// LAKEMONT
        /// </summary>
        INTEL_LAKEMONT,

        /// <summary>
        /// CORE
        /// </summary>
        INTEL_CORE,

        /// <summary>
        /// PENRYN
        /// </summary>
        INTEL_PNR,

        /// <summary>
        /// NEHALEM
        /// </summary>
        INTEL_NHM,

        /// <summary>
        /// BONNELL
        /// </summary>
        INTEL_ATOM_BNL,

        /// <summary>
        /// WESTMERE
        /// </summary>
        INTEL_WSM,

        /// <summary>
        /// SANDYBRIDGE
        /// </summary>
        INTEL_SNB,

        /// <summary>
        /// IVYBRIDGE
        /// </summary>
        INTEL_IVB,

        /// <summary>
        /// SILVERMONT
        /// </summary>
        INTEL_ATOM_SMT,

        /// <summary>
        /// HASWELL
        /// </summary>
        INTEL_HSW,

        /// <summary>
        /// BROADWELL
        /// </summary>
        INTEL_BDW,

        /// <summary>
        /// SKYLAKE
        /// </summary>
        INTEL_SKL,

        /// <summary>
        /// GOLDMONT
        /// </summary>
        INTEL_ATOM_GMT,

        /// <summary>
        /// GOLDMONT+
        /// </summary>
        INTEL_ATOM_GMT_PLUS,

        /// <summary>
        /// TREMONT
        /// </summary>
        INTEL_ATOM_TMT,

        /// <summary>
        /// KABY LAKE
        /// </summary>
        INTEL_KBL,

        /// <summary>
        /// COFFEE LAKE
        /// </summary>
        INTEL_CFL,

        /// <summary>
        /// WHISKEY LAKE
        /// </summary>
        INTEL_WHL,

        /// <summary>
        /// COMET LAKE
        /// </summary>
        INTEL_CML,

        /// <summary>
        /// CANNON LAKE
        /// </summary>
        INTEL_CNL,

        /// <summary>
        /// ICE LAKE
        /// </summary>
        INTEL_ICL,

        /// <summary>
        /// TIGER LAKE
        /// </summary>
        INTEL_TGL,

        /// <summary>
        /// SAPPHIRE RAPIDS
        /// </summary>
        INTEL_SPR,

        /// <summary>
        /// ALDER LAKE
        /// </summary>
        INTEL_ADL,

        /// <summary>
        /// ROCKET LAKE
        /// </summary>
        INTEL_RCL,

        /// <summary>
        /// KNIGHTS MILL
        /// </summary>
        INTEL_KNIGHTS_M,

        /// <summary>
        /// KNIGHTS LANDING
        /// </summary>
        INTEL_KNIGHTS_L,

        /// <summary>
        /// KNIGHTS FERRY
        /// </summary>
        INTEL_KNIGHTS_F,

        /// <summary>
        /// KNIGHTS CORNER
        /// </summary>
        INTEL_KNIGHTS_C,

        /// <summary>
        /// NETBURST
        /// </summary>
        INTEL_NETBURST,

        /// <summary>
        /// K8 HAMMER
        /// </summary>
        AMD_HAMMER,

        /// <summary>
        /// K10
        /// </summary>
        AMD_K10,

        /// <summary>
        /// K11
        /// </summary>
        AMD_K11,

        /// <summary>
        /// K12
        /// </summary>
        AMD_K12,

        /// <summary>
        /// K14 BOBCAT
        /// </summary>
        AMD_BOBCAT,

        /// <summary>
        /// K15 PILEDRIVER
        /// </summary>
        AMD_PILEDRIVER,

        /// <summary>
        /// K15 STREAMROLLER
        /// </summary>
        AMD_STREAMROLLER,

        /// <summary>
        /// K15 EXCAVATOR
        /// </summary>
        AMD_EXCAVATOR,

        /// <summary>
        /// K15 BULLDOZER
        /// </summary>
        AMD_BULLDOZER,

        /// <summary>
        /// K16 JAGUAR
        /// </summary>
        AMD_JAGUAR,

        /// <summary>
        /// K16 PUMA
        /// </summary>
        AMD_PUMA,

        /// <summary>
        /// K17 ZEN
        /// </summary>
        AMD_ZEN,

        /// <summary>
        /// K17 ZEN+
        /// </summary>
        AMD_ZEN_PLUS,

        /// <summary>
        /// K17 ZEN 2
        /// </summary>
        AMD_ZEN2,

        /// <summary>
        /// K19 ZEN 3
        /// </summary>
        AMD_ZEN3,

        /// <summary>
        /// K19 ZEN 4
        /// </summary>
        AMD_ZEN4
    }
}