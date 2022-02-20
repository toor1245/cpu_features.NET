#include "cpu_features_macros.h"

#if defined(CPU_FEATURES_ARCH_ARM)
#include "cpuinfo_arm_port.h"

ArmInfo GetArmInfoPort(void) {
    return GetArmInfo();
}

uint32_t GetArmCpuIdPort(const ArmInfo *info) {
    return GetArmCpuId(info);
}
#endif  // CPU_FEATURES_ARCH_ARM
