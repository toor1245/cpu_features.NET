#ifndef CPU_FEATURES_DOTNET_MACROS_H
#define CPU_FEATURES_DOTNET_MACROS_H

////////////////////////////////////////////////////////////////////////////////
// Cpp
////////////////////////////////////////////////////////////////////////////////

#if defined(__cplusplus)
#define CPU_FEATURES_DOTNET_START_CPP_NAMESPACE \
  namespace cpu_features {                      \
  extern "C" {
#define CPU_FEATURES_DOTNET_END_CPP_NAMESPACE \
  }                                           \
  }
#else
#define CPU_FEATURES_DOTNET_START_CPP_NAMESPACE
#define CPU_FEATURES_DOTNET_END_CPP_NAMESPACE
#endif

////////////////////////////////////////////////////////////////////////////////
// Os
////////////////////////////////////////////////////////////////////////////////

#if defined(__linux__)
#define CPU_FEATURES_DOTNET_OS_LINUX_OR_ANDROID 1
#else
#define CPU_FEATURES_DOTNET_OS_LINUX_OR_ANDROID 0
#endif

#if defined(__ANDROID__)
#define CPU_FEATURES_DOTNET_OS_ANDROID 1
#else
#define CPU_FEATURES_DOTNET_OS_ANDROID 0
#endif

#if (defined(_WIN64) || defined(_WIN32))
#define CPU_FEATURES_DOTNET_OS_WINDOWS 1
#else
#define CPU_FEATURES_DOTNET_OS_WINDOWS 0
#endif

#if (defined(__apple__) || defined(__APPLE__) || defined(__MACH__))
#define CPU_FEATURES_DOTNET_OS_DARWIN 1
#else
#define CPU_FEATURES_DOTNET_OS_DARWIN 0
#endif

#if (defined(__freebsd__) || defined(__FreeBSD__))
#define CPU_FEATURES_DOTNET_OS_FREEBSD 1
#else
#define CPU_FEATURES_DOTNET_OS_FREEBSD 0
#endif

////////////////////////////////////////////////////////////////////////////////
// Compilers
////////////////////////////////////////////////////////////////////////////////

#if defined(__clang__)
#define CPU_FEATURES_DOTNET_COMPILER_CLANG
#endif

#if defined(__GNUC__) && !defined(__clang__)
#define CPU_FEATURES_DOTNET_COMPILER_GCC
#endif

#if defined(_MSC_VER)
#define CPU_FEATURES_DOTNET_COMPILER_MSC
#endif

////////////////////////////////////////////////////////////////////////////////
// Cpp
////////////////////////////////////////////////////////////////////////////////

#if defined(__cplusplus)
#define CPU_FEATURES_DOTNET_START_CPP_NAMESPACE \
  namespace cpu_features_dotnet {               \
  extern "C" {
#define CPU_FEATURES_DOTNET_END_CPP_NAMESPACE \
  }                                           \
  }
#else
#define CPU_FEATURES_DOTNET_START_CPP_NAMESPACE
#define CPU_FEATURES_DOTNET_END_CPP_NAMESPACE
#endif

////////////////////////////////////////////////////////////////////////////////
// DLL
////////////////////////////////////////////////////////////////////////////////
#if defined(CPU_FEATURES_DOTNET_OS_WINDOWS)
#ifdef CPU_FEATURES_DOTNET_DLL
#define CPU_FEATURES_DOTNET_DLL_EXPORT __declspec(dllexport)
#else
#define CPU_FEATURES_DOTNET_DLL_EXPORT __declspec(dllimport)
#endif
#else
#define CPU_FEATURES_DOTNET_DLL_EXPORT
#endif

////////////////////////////////////////////////////////////////////////////////
// Architectures
////////////////////////////////////////////////////////////////////////////////

#if defined(__pnacl__) || defined(__CLR_VER)
#define CPU_FEATURES_DOTNET_ARCH_VM 1
#else
#define CPU_FEATURES_DOTNET_ARCH_VM 0
#endif

#if (defined(_M_IX86) || defined(__i386__)) && \
    !CPU_FEATURES_DOTNET_ARCH_VM
#define CPU_FEATURES_DOTNET_ARCH_X86_32 1
#else
#define CPU_FEATURES_DOTNET_ARCH_X86_32 0
#endif

#if (defined(_M_X64) || defined(__x86_64__)) && \
    !CPU_FEATURES_DOTNET_ARCH_VM
#define CPU_FEATURES_DOTNET_ARCH_X86_64 1
#else
#define CPU_FEATURES_DOTNET_ARCH_X86_64 0
#endif

#if defined(CPU_FEATURES_DOTNET_ARCH_X86_32) || \
    defined(CPU_FEATURES_DOTNET_ARCH_X86_64)
#define CPU_FEATURES_DOTNET_ARCH_X86 1
#else
#define CPU_FEATURES_DOTNET_ARCH_X86 0
#endif

////////////////////////////////////////////////////////////////////////////////
// Compiler flags
////////////////////////////////////////////////////////////////////////////////

// Use the following to check if a feature is known to be available at
// compile time. See README.md for an example.
#if defined(CPU_FEATURES_DOTNET_ARCH_X86)

#if defined(__AES__)
#define CPU_FEATURES_DOTNET_COMPILED_X86_AES 1
#else
#define CPU_FEATURES_DOTNET_COMPILED_X86_AES 0
#endif  //  defined(__AES__)

#if defined(__F16C__)
#define CPU_FEATURES_DOTNET_COMPILED_X86_F16C 1
#else
#define CPU_FEATURES_DOTNET_COMPILED_X86_F16C 0
#endif  //  defined(__F16C__)

#if defined(__BMI__)
#define CPU_FEATURES_DOTNET_COMPILED_X86_BMI 1
#else
#define CPU_FEATURES_DOTNET_COMPILED_X86_BMI 0
#endif  //  defined(__BMI__)

#if defined(__BMI2__)
#define CPU_FEATURES_DOTNET_COMPILED_X86_BMI2 1
#else
#define CPU_FEATURES_DOTNET_COMPILED_X86_BMI2 0
#endif  //  defined(__BMI2__)

#if (defined(__SSE__) || (_M_IX86_FP >= 1))
#define CPU_FEATURES_DOTNET_COMPILED_X86_SSE 1
#else
#define CPU_FEATURES_DOTNET_COMPILED_X86_SSE 0
#endif

#if (defined(__SSE2__) || (_M_IX86_FP >= 2))
#define CPU_FEATURES_DOTNET_COMPILED_X86_SSE2 1
#else
#define CPU_FEATURES_DOTNET_COMPILED_X86_SSE2 0
#endif

#if defined(__SSE3__)
#define CPU_FEATURES_DOTNET_COMPILED_X86_SSE3 1
#else
#define CPU_FEATURES_DOTNET_COMPILED_X86_SSE3 0
#endif  //  defined(__SSE3__)

#if defined(__SSSE3__)
#define CPU_FEATURES_DOTNET_COMPILED_X86_SSSE3 1
#else
#define CPU_FEATURES_DOTNET_COMPILED_X86_SSSE3 0
#endif  //  defined(__SSSE3__)

#if defined(__SSE4_1__)
#define CPU_FEATURES_DOTNET_COMPILED_X86_SSE4_1 1
#else
#define CPU_FEATURES_DOTNET_COMPILED_X86_SSE4_1 0
#endif  //  defined(__SSE4_1__)

#if defined(__SSE4_2__)
#define CPU_FEATURES_DOTNET_COMPILED_X86_SSE4_2 1
#else
#define CPU_FEATURES_DOTNET_COMPILED_X86_SSE4_2 0
#endif  //  defined(__SSE4_2__)

#if defined(__AVX__)
#define CPU_FEATURES_DOTNET_COMPILED_X86_AVX 1
#else
#define CPU_FEATURES_DOTNET_COMPILED_X86_AVX 0
#endif  //  defined(__AVX__)

#if defined(__AVX2__)
#define CPU_FEATURES_DOTNET_COMPILED_X86_AVX2 1
#else
#define CPU_FEATURES_DOTNET_COMPILED_X86_AVX2 0
#endif  //  defined(__AVX2__)

#endif  // defined(CPU_FEATURES_DOTNET_ARCH_X86)

////////////////////////////////////////////////////////////////////////////////
// Utils
////////////////////////////////////////////////////////////////////////////////


// Communicates to the compiler that the block is unreachable
#if defined(CPU_FEATURES_DOTNET_COMPILER_CLANG) || \
    defined(CPU_FEATURES_DOTNET_COMPILER_GCC)
#define UNREACHABLE() __builtin_unreachable()
#elif defined(CPU_FEATURES_DOTNET_COMPILER_MSC)
#define UNREACHABLE() __assume(0)
#else
#define UNREACHABLE()
#endif

#endif  // CPU_FEATURES_DOTNET_MACROS_H
