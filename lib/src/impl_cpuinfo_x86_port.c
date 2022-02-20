#include "cpu_features_macros.h"

#if defined(CPU_FEATURES_ARCH_X86)
#include "cpuinfo_x86_port.h"

X86Microarchitecture GetX86MicroarchitecturePort(const X86Info *info) {
    return GetX86Microarchitecture(info);
}

void FillX86BrandStringPort(char *brand_string) {
    FillX86BrandString(brand_string);
}

X86Info GetX86InfoPort(void) {
    return GetX86Info();
}

CacheInfo GetX86CacheInfoPort(void) {
    return GetX86CacheInfo();
}
#endif  // CPU_FEATURES_ARCH_X86
