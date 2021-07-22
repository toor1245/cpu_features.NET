#ifndef CPU_FEATURES_DOTNET_OS_H
#define CPU_FEATURES_DOTNET_OS_H

#include "macros.h"

#include <stdint.h>
#include <stdbool.h>

// The following includes are necessary to provide SSE detections on pre-AVX
// microarchitectures.
#if CPU_FEATURES_DOTNET_OS_WINDOWS
#include <windows.h>  // IsProcessorFeaturePresent
#elif CPU_FEATURES_DOTNET_OS_LINUX_OR_ANDROID
#include "filesystem.h"         // Needed to parse /proc/cpuinfo
#include "stack_line_reader.h"  // Needed to parse /proc/cpuinfo
#include "string_view.h"        // Needed to parse /proc/cpuinfo
#elif defined(CPU_FEATURES_DOTNET_OS_DARWIN)
#if !defined(HAVE_SYSCTLBYNAME)
#error "Darwin needs support for sysctlbyname"
#endif
#include <sys/sysctl.h>
#else
#error "Unsupported OS"
#endif  // CPU_FEATURES_DOTNET_OS

CPU_FEATURES_DOTNET_START_CPP_NAMESPACE

CPU_FEATURES_DOTNET_DLL_EXPORT bool __is_os_windows();
CPU_FEATURES_DOTNET_DLL_EXPORT bool __is_os_linux_android();
CPU_FEATURES_DOTNET_DLL_EXPORT bool __is_os_android();
CPU_FEATURES_DOTNET_DLL_EXPORT bool __is_os_darwin();
CPU_FEATURES_DOTNET_DLL_EXPORT bool __is_os_freebsd();
CPU_FEATURES_DOTNET_DLL_EXPORT bool __darwin_sysctlbyname(char* name);
CPU_FEATURES_DOTNET_DLL_EXPORT bool __windows_is_processor_feature_present(int32_t ProcessorFeature);

CPU_FEATURES_DOTNET_END_CPP_NAMESPACE

#endif //CPU_FEATURES_DOTNET_OS_H
