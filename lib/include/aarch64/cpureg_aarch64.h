#ifndef CPU_FEATURES_DOTNET_CPUREG_AARCH64_H
#define CPU_FEATURES_DOTNET_CPUREG_AARCH64_H

#include "cpu_features_macros.h"

#define read_mrs(reg) ({                                        \
    uint64_t __val;							                                \
    asm volatile("mrs %0, "#reg : "=r" (__val));	              \
    __val;                                                      \
})

#endif // CPU_FEATURES_DOTNET_CPUREG_AARCH64_H
