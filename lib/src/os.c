#include "os.h"

bool __is_os_windows() {
  return CPU_FEATURES_DOTNET_OS_WINDOWS;
}

bool __is_os_linux_android() {
  return CPU_FEATURES_DOTNET_OS_LINUX_OR_ANDROID;
}

bool __is_os_android() {
  return CPU_FEATURES_DOTNET_OS_ANDROID;
}

bool __is_os_darwin() {
  return CPU_FEATURES_DOTNET_OS_DARWIN;
}

bool __is_os_freebsd() {
  return CPU_FEATURES_DOTNET_OS_FREEBSD;
}

bool __darwin_sysctlbyname(char* name) {
#if CPU_FEATURES_DOTNET_OS_DARWIN
  int enabled;
  size_t enabled_len = sizeof(enabled);
  const int failure = sysctlbyname(name, &enabled, &enabled_len, NULL, 0);
  return failure ? false : enabled;
#else
  return false;
#endif
}

bool __windows_is_processor_feature_present(int32_t ProcessorFeature) {
#if CPU_FEATURES_DOTNET_OS_WINDOWS
  return IsProcessorFeaturePresent(ProcessorFeature);
#else
  return false;
#endif
}
