#ifndef CPU_FEATURES_DOTNET_CPUID_X86_H
#define CPU_FEATURES_DOTNET_CPUID_X86_H

#include <stdint.h>

#include "macros.h"

CPU_FEATURES_DOTNET_START_CPP_NAMESPACE

// A struct to hold the result of a call to cpuid.
typedef struct {
  uint32_t eax, ebx, ecx, edx;
} leaf_t;

// Returns the result of a call to the cpuid instruction.
CPU_FEATURES_DOTNET_DLL_EXPORT leaf_t cpuid(uint32_t leaf_id, int ecx);

leaf_t safe_cpu_id(uint32_t max_cpuid_leaf, uint32_t leaf_id);
leaf_t safe_cpu_id_ex(uint32_t max_cpuid_leaf, uint32_t leaf_id, int ecx);

CPU_FEATURES_DOTNET_END_CPP_NAMESPACE

#endif  // CPU_FEATURES_DOTNET_CPUID_X86_H