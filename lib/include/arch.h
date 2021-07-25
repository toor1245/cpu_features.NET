#ifndef CPU_FEATURES_DOTNET_ARCH_H
#define CPU_FEATURES_DOTNET_ARCH_H

#include "macros.h"

#include <stdbool.h>

CPU_FEATURES_DOTNET_START_CPP_NAMESPACE

CPU_FEATURES_DOTNET_DLL_EXPORT bool is_arch_X86();
CPU_FEATURES_DOTNET_DLL_EXPORT bool is_arch_X86_32();
CPU_FEATURES_DOTNET_DLL_EXPORT bool is_arch_X86_64();

CPU_FEATURES_DOTNET_END_CPP_NAMESPACE
#endif //CPU_FEATURES_DOTNET_ARCH_H
