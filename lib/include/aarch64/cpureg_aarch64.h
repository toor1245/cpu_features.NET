#ifndef CPU_FEATURES_DOTNET_CPUREG_AARCH64_H
#define CPU_FEATURES_DOTNET_CPUREG_AARCH64_H

#include "macros.h"
#include "cpu_utils.h"

#define MIDR_EL1            "MIDR_EL1"
#define REVIDR_EL1          "REVIDR_EL1"

#define MVFR0_EL1           "MVFR0_EL1"
#define MVFR1_EL1           "MVFR1_EL1"
#define MVFR2_EL1           "MVFR2_EL1"
#define ID_AA64PFR0_EL1     "ID_AA64PFR0_EL1"
#define ID_AA64ZFR0_EL1     "ID_AA64ZFR0_EL1"
#define ID_AA64MMFR2_EL1    "ID_AA64MMFR2_EL1"
#define IID_AA64_ISAR0_EL1  "IID_AA64_ISAR0_EL1"
#define IID_AA64_ISAR1_EL1  "IID_AA64_ISAR1_EL1"

#define read_mrs(reg) ({                                        \
    uint64_t __val;							                    \
    asm volatile("mrs %0, " __stringify(reg) : "=r" (__val));	\
    __val;                                                      \
})

#endif // CPU_FEATURES_DOTNET_CPUREG_AARCH64_H
