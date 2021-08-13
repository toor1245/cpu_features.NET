#ifndef CPU_FEATURES_DOTNET_CPUID_X86_H
#define CPU_FEATURES_DOTNET_CPUID_X86_H

#include <stdint.h>

#include "shared/macros.h"

CPU_FEATURES_DOTNET_START_CPP_NAMESPACE

// A struct to hold the result of a call to cpuid.
typedef struct {
  uint32_t eax, ebx, ecx, edx;
} leaf_t;

// Returns the result of a call to the cpuid instruction.
CPU_FEATURES_DOTNET_DLL_EXPORT leaf_t cpuid(uint32_t leaf_id, int ecx);
CPU_FEATURES_DOTNET_DLL_EXPORT uint32_t xcr0_eax(void);

CPU_FEATURES_DOTNET_END_CPP_NAMESPACE

#endif  // CPU_FEATURES_DOTNET_CPUID_X86_H