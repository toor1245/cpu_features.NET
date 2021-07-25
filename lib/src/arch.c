#include <arch.h>

bool is_arch_X86() {
  return CPU_FEATURES_DOTNET_ARCH_X86;
}

bool is_arch_X86_32() {
  return CPU_FEATURES_DOTNET_ARCH_X86_32;
}

bool is_arch_X86_64() {
  return CPU_FEATURES_DOTNET_ARCH_X86_64;
}
