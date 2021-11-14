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
#elif CPU_FEATURES_DOTNET_OS_FREEBSD
#elif CPU_FEATURES_DOTNET_OS_DARWIN
#include <sys/sysctl.h>
#else
#error "Unsupported OS"
#endif  // CPU_FEATURES_DOTNET_OS

CPU_FEATURES_DOTNET_START_CPP_NAMESPACE

CPU_FEATURES_DOTNET_DLL_EXPORT bool is_os_windows(void);
CPU_FEATURES_DOTNET_DLL_EXPORT bool is_os_linux_android(void);
CPU_FEATURES_DOTNET_DLL_EXPORT bool is_os_android(void);
CPU_FEATURES_DOTNET_DLL_EXPORT bool is_os_darwin(void);
CPU_FEATURES_DOTNET_DLL_EXPORT bool is_os_freebsd(void);
CPU_FEATURES_DOTNET_DLL_EXPORT bool darwin_sysctlbyname(char* name);
CPU_FEATURES_DOTNET_DLL_EXPORT bool windows_is_processor_feature_present(int32_t ProcessorFeature);

CPU_FEATURES_DOTNET_END_CPP_NAMESPACE

#endif //CPU_FEATURES_DOTNET_OS_H
