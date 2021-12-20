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
#if CPU_FEATURES_DOTNET_OS_WINDOWS
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

#if CPU_FEATURES_DOTNET_ARCH_X86_32 || \
    CPU_FEATURES_DOTNET_ARCH_X86_64
#define CPU_FEATURES_DOTNET_ARCH_X86 1
#else
#define CPU_FEATURES_DOTNET_ARCH_X86 0
#endif

#if (defined(__arm__) || defined(_M_ARM))
#define CPU_FEATURES_DOTNET_ARCH_ARM 1
#else
#define CPU_FEATURES_DOTNET_ARCH_ARM 0
#endif

#if defined(__aarch64__)
#define CPU_FEATURES_DOTNET_ARCH_AARCH64 1
#else
#define CPU_FEATURES_DOTNET_ARCH_AARCH64 0
#endif

#if CPU_FEATURES_DOTNET_ARCH_AARCH64 || CPU_FEATURES_DOTNET_ARCH_ARM
#define CPU_FEATURES_DOTNET_ARCH_ANY_ARM 1
#else
#define CPU_FEATURES_DOTNET_ARCH_ANY_ARM 0
#endif

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
