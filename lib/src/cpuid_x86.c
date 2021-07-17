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

#else
#error "Unsupported compiler, x86 cpuid requires either GCC, Clang or MSVC."
#endif

static const leaf_t k_empty_leaf;

leaf_t safe_cpu_id_ex(uint32_t max_cpuid_leaf, uint32_t leaf_id, int ecx) {
  return leaf_id <= max_cpuid_leaf ? cpuid(leaf_id, ecx) : k_empty_leaf;
}

leaf_t safe_cpu_id(uint32_t max_cpuid_leaf, uint32_t leaf_id) {
  return safe_cpu_id_ex(max_cpuid_leaf, leaf_id, 0);
}
