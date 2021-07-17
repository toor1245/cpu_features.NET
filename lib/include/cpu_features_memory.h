#ifndef CPU_FEATURES_DOTNET_CPU_FEATURES_MEMORY_H
#define CPU_FEATURES_DOTNET_CPU_FEATURES_MEMORY_H

#include <memory.h>
#include <stdbool.h>
#include <stdint.h>

#include "macros_x86.h"

CPU_FEATURES_DOTNET_START_CPP_NAMESPACE

CPU_FEATURES_DOTNET_DLL_EXPORT void __memcpy(void* dest, void* src,
                                             int byte_count);
CPU_FEATURES_DOTNET_DLL_EXPORT bool __memcmp(void* buf1, void* buf2,
                                             size_t size);

CPU_FEATURES_DOTNET_END_CPP_NAMESPACE

#endif  // CPU_FEATURES_DOTNET_CPU_FEATURES_MEMORY_H
