#ifndef CPU_FEATURES_DOTNET_MEMORY_UTILS_H
#define CPU_FEATURES_DOTNET_MEMORY_UTILS_H

#include <stddef.h>
#include <string.h>
#include "cpu_features_macros.h"

CPU_FEATURES_DOTNET_START_CPP_NAMESPACE

CPU_FEATURES_DOTNET_DLL_EXPORT void *_memchr(const void *buffer, int value, size_t max_count);
CPU_FEATURES_DOTNET_DLL_EXPORT int _memcmp(const void *buffer1, const void *buffer2, size_t size);

CPU_FEATURES_DOTNET_END_CPP_NAMESPACE

#endif // CPU_FEATURES_DOTNET_MEMORY_UTILS_H
