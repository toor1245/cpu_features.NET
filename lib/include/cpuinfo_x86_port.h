#ifndef CPU_FEATURES_DOTNET_CPUINFO_X86_PORT_H
#define CPU_FEATURES_DOTNET_CPUINFO_X86_PORT_H

#include "cpu_features_port_macros.h"
#include "cpuinfo_x86.h"

CPU_FEATURES_DOTNET_DLL_EXPORT X86Info GetX86InfoPort(void);

CPU_FEATURES_DOTNET_DLL_EXPORT CacheInfo GetX86CacheInfoPort(void);

CPU_FEATURES_DOTNET_DLL_EXPORT X86Microarchitecture GetX86MicroarchitecturePort(const X86Info *info);

CPU_FEATURES_DOTNET_DLL_EXPORT void FillX86BrandStringPort(char brand_string[49]);

#endif // CPU_FEATURES_DOTNET_CPUINFO_X86_PORT_H
