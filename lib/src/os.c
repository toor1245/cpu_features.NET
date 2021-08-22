#include "os.h"

bool is_os_windows() {
  return CPU_FEATURES_DOTNET_OS_WINDOWS;
}

bool is_os_linux_android() {
  return CPU_FEATURES_DOTNET_OS_LINUX_OR_ANDROID;
}

bool is_os_android() {
  return CPU_FEATURES_DOTNET_OS_ANDROID;
}

bool is_os_darwin() {
  return CPU_FEATURES_DOTNET_OS_DARWIN;
}

bool is_os_freebsd() {
  return CPU_FEATURES_DOTNET_OS_FREEBSD;
}

bool darwin_sysctlbyname(char* name) {
#if CPU_FEATURES_DOTNET_OS_DARWIN
  int enabled;
  size_t enabled_len = sizeof(enabled);
  const int failure = sysctlbyname(name, &enabled, &enabled_len, NULL, 0);
  return failure ? false : enabled;
#else
  return false;
#endif
}

bool windows_is_processor_feature_present(int32_t ProcessorFeature) {
#if CPU_FEATURES_DOTNET_OS_WINDOWS
  return IsProcessorFeaturePresent(ProcessorFeature);
#else
  return false;
#endif
}
