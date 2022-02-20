#include "cpu_features_macros.h"

#if defined(CPU_FEATURES_ARCH_AARCH64)
#include "cpuinfo_aarch64_port.h"

Aarch64Info GetAarch64InfoPort(void) {
    return GetAarch64Info();
}
#endif  // CPU_FEATURES_ARCH_AARCH64