#include "cputype_aarch64.h"

uint64_t __read_cpuid_id(void) {
  return read_mrs(MIDR_EL1);
}

uint64_t __read_cpuid_mpidr(void) {
  return read_mrs(MPIDR_EL1);
}

uint64_t __read_cpuid_implementor(void) {
  return MIDR_IMPLEMENTOR(__read_cpuid_id());
}

uint64_t __read_cpuid_part_number(void) {
  return MIDR_PARTNUM(__read_cpuid_id());
}

uint64_t __read_cpuid_cachetype(void) {
  return read_mrs(CTR_EL0);
}

aarch64_impl get_aarch64_impl(void) {
  const uint64_t impl = __read_cpuid_implementor();
  switch (impl) {
    case ARM_CPU_IMP_ARM:     return ARM;
    case ARM_CPU_IMP_APM:     return APM;
    case ARM_CPU_IMP_APPLE:   return APPLE;
    case ARM_CPU_IMP_BRCM:    return BRCM;
    case ARM_CPU_IMP_CAVIUM:  return CAVIUM;
    case ARM_CPU_IMP_FUJITSU: return FUJITSU;
    case ARM_CPU_IMP_HISI:    return HISI;
    case ARM_CPU_IMP_NVIDIA:  return NVIDIA;
    case ARM_CPU_IMP_QCOM:    return QCOM;
    default:                  return UNKNOWN_IMPL_AARCH64;
  }
}

aarch64_part_num get_aarch64_part_num(void) {
  const uint64_t part_num = __read_cpuid_part_number();
  switch (part_num) {
    case ARM_CPU_PART_AEM_V8:             return AEM_V8;
    case ARM_CPU_PART_FOUNDATION:         return FOUNDATION;
    case ARM_CPU_PART_NEOVERSE_N1:        return NEOVERSE_N1;
    case ARM_CPU_PART_CORTEX_A35:         return CORTEX_A35;
    case ARM_CPU_PART_CORTEX_A53:         return CORTEX_A53;
    case ARM_CPU_PART_CORTEX_A55:         return CORTEX_A55;
    case ARM_CPU_PART_CORTEX_A57:         return CORTEX_A57;
    case ARM_CPU_PART_CORTEX_A72:         return CORTEX_A72;
    case ARM_CPU_PART_CORTEX_A73:         return CORTEX_A73;
    case ARM_CPU_PART_CORTEX_A75:         return CORTEX_A75;
    case ARM_CPU_PART_CORTEX_A76:         return CORTEX_A76;
    case ARM_CPU_PART_CORTEX_A77:         return CORTEX_A77;
    case APM_CPU_PART_POTENZA:            return POTENZA;
    case CAVIUM_CPU_PART_THUNDERX:        return THUNDERX;
    case CAVIUM_CPU_PART_THUNDERX_81XX:   return THUNDERX_81XX;
    case CAVIUM_CPU_PART_THUNDERX_83XX:   return THUNDERX_83XX;
    case CAVIUM_CPU_PART_THUNDERX2:       return THUNDERX2;
    case BRCM_CPU_PART_BRAHMA_B53:        return BRAHMA_B53;
    case BRCM_CPU_PART_VULCAN:            return VULCAN;
    case QCOM_CPU_PART_FALKOR_V1:         return FALKOR_V1;
    case QCOM_CPU_PART_FALKOR:            return FALKOR;
    case QCOM_CPU_PART_KRYO:              return KRYO;
    case QCOM_CPU_PART_KRYO_2XX_SILVER:   return KRYO_2XX_SILVER;
    case QCOM_CPU_PART_KRYO_3XX_SILVER:   return KRYO_3XX_SILVER;
    case QCOM_CPU_PART_KRYO_4XX_GOLD:     return KRYO_4XX_GOLD;
    case QCOM_CPU_PART_KRYO_4XX_SILVER:   return KRYO_4XX_SILVER;
    case NVIDIA_CPU_PART_DENVER:          return DENVER;
    case NVIDIA_CPU_PART_CARMEL:          return CARMEL;
    case FUJITSU_CPU_PART_A64FX:          return A64FX;
    case HISI_CPU_PART_TSV110:            return TSV110;
    case APPLE_CPU_PART_M1_FIRESTORM:     return M1_FIRESTORM;
    case APPLE_CPU_PART_M1_ICESTORM:      return M1_ICESTORM;
    default:                              return UNKNOWN_PART_NUM_AARCH64;
  }
}
