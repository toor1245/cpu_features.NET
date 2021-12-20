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

namespace CpuFeaturesDotNet.AArch64.CpuInfo
{
    public enum CpuPartNumberAArch64
    {
        UNKNOWN_PART_NUMBER_AARCH64,

        ARM_AEM_V8,
        ARM_FOUNDATION,
        ARM_CORTEX_A57,
        ARM_CORTEX_A72,
        ARM_CORTEX_A53,
        ARM_CORTEX_A73,
        ARM_CORTEX_A75,
        ARM_CORTEX_A35,
        ARM_CORTEX_A55,
        ARM_CORTEX_A76,
        ARM_NEOVERSE_N1,
        ARM_CORTEX_A77,

        APM_POTENZA,

        CAVIUM_THUNDERX,
        CAVIUM_THUNDERX_81XX,
        CAVIUM_THUNDERX_83XX,
        CAVIUM_THUNDERX2,

        BRCM_BRAHMA_B53,
        BRCM_VULKAN,

        QCOM_FALKOR_V1,
        QCOM_FALKOR,
        QCOM_KRYO,
        QCOM_KRYO_2XX_GOLD,
        QCOM_KRYO_2XX_SILVER,
        QCOM_KRYO_3XX_SILVER,
        QCOM_KRYO_4XX_GOLD,
        QCOM_KRYO_4XX_SILVER,

        NVIDIA_DENVER,
        NVIDIA_CARMEL,

        FUJITSU_A64FX,

        HISI_TSV110,

        APPLE_M1_ICESTORM,
        APPLE_M1_FIRESTORM
    }
}