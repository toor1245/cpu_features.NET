#ifndef CPU_FEATURES_DOTNET_CPUINFO_ARM_PORT_H
#define CPU_FEATURES_DOTNET_CPUINFO_ARM_PORT_H

#include "cpu_features_port_macros.h"
#include "cpuinfo_arm.h"
#include <stdint.h>

CPU_FEATURES_DOTNET_DLL_EXPORT ArmInfo GetArmInfoPort(void);

CPU_FEATURES_DOTNET_DLL_EXPORT uint32_t GetArmCpuIdPort(const ArmInfo *info);

#endif // CPU_FEATURES_DOTNET_CPUINFO_ARM_PORT_H
