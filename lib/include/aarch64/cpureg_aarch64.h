#ifndef CPU_FEATURES_DOTNET_CPUREG_AARCH64_H
#define CPU_FEATURES_DOTNET_CPUREG_AARCH64_H

#include "macros.h"
#include "cpu_utils.h"

#define read_mrs(reg) ({                                        \
    uint64_t __val;							                                \
    asm volatile("mrs %0, "__stringify(reg) : "=r" (__val));	  \
    __val;                                                      \
})

#endif // CPU_FEATURES_DOTNET_CPUREG_AARCH64_H
