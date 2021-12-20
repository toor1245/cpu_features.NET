#include <cpuid_x86.h>

#if defined(CPU_FEATURES_MOCK_CPUID_X86)
#elif defined(CPU_FEATURES_DOTNET_COMPILER_CLANG) || \
    defined(CPU_FEATURES_DOTNET_COMPILER_GCC)

#include <cpuid.h>

leaf_t cpuid(uint32_t leaf_id, int ecx) {
  leaf_t leaf;
  __cpuid_count(leaf_id, ecx, leaf.eax, leaf.ebx, leaf.ecx, leaf.edx);
  return leaf;
}

uint32_t xcr0_eax(void) {
  uint32_t eax, edx;
  /* named form of xgetbv not supported on OSX, so must use byte form, see:
     https://github.com/asmjit/asmjit/issues/78
   */
  __asm(".byte 0x0F, 0x01, 0xd0" : "=a"(eax), "=d"(edx) : "c"(0));
  return eax;
}

#elif defined(CPU_FEATURES_DOTNET_COMPILER_MSC)

#include <immintrin.h>

leaf_t cpuid(uint32_t leaf_id, int ecx) {
  leaf_t leaf;
  int data[4];
  __cpuidex(data, leaf_id, ecx);
  leaf.eax = data[0];
  leaf.ebx = data[1];
  leaf.ecx = data[2];
  leaf.edx = data[3];
  return leaf;
}

uint32_t xcr0_eax(void) { return (uint32_t)_xgetbv(0); }

#else
#error "Unsupported compiler, x86 cpuid requires either GCC, Clang or MSVC."
#endif