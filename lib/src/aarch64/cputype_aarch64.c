#include "cputype_aarch64.h"

CPU_FEATURES_DOTNET_DLL_EXPORT uint64_t __read_cpuid_id(void) {
    return read_mrs(MIDR_EL1);
}

CPU_FEATURES_DOTNET_DLL_EXPORT uint64_t __read_revidr_el1(void) {
    return read_mrs(REVIDR_EL1);
}