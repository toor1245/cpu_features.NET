cmake_minimum_required(VERSION 3.8)

project(CpuFeaturesDotNet VERSION 0.0.1 LANGUAGES C)

# option() honors normal variables.
# see: https://cmake.org/cmake/help/git-stage/policy/CMP0077.html
if(POLICY CMP0077)
    cmake_policy(SET CMP0077 NEW)
endif()

set(CMAKE_C_STANDARD 99)

# Default Build Type to be Release
if(NOT CMAKE_BUILD_TYPE)
    set(CMAKE_BUILD_TYPE "Release" CACHE STRING
            "Choose the type of build, options are: Debug Release RelWithDebInfo MinSizeRel."
            FORCE)
endif(NOT CMAKE_BUILD_TYPE)

set(CPU_FEATURES_DOTNET cpu_features_dotnet)
set(CPU_FEATURES_DOTNET_NAME CpuFeaturesDotNet)
set(CPU_FEATURES_DOTNET_VERSION 1.0.1)
set(CPU_FEATURES_DOTNET_PROCESSOR_IS_ARM FALSE)
set(CPU_FEATURES_DOTNET_PROCESSOR_IS_AARCH64 FALSE)
set(CPU_FEATURES_DOTNET_PROCESSOR_IS_X86 FALSE)
set(CPU_FEATURES_DOTNET_DEFAULT_TOOLCHAIN cmake/toolchains/default.cmake)

include(${CMAKE_CURRENT_SOURCE_DIR}/${CPU_FEATURES_DOTNET_DEFAULT_TOOLCHAIN})

if (CMAKE_SYSTEM_NAME MATCHES "(Windows)")
    set(CPU_FEATURES_DOTNET_RID win-${CPU_FEATURES_DOTNET_ARCH})
elseif(CMAKE_SYSTEM_NAME MATCHES "(Linux)")
    set(CPU_FEATURES_DOTNET_RID linux-${CPU_FEATURES_DOTNET_ARCH})
elseif(CMAKE_SYSTEM_NAME MATCHES "(Darwin)")
    set(CPU_FEATURES_DOTNET_RID osx-${CPU_FEATURES_DOTNET_ARCH})
else()
    message(FATAL_ERROR "Unsupported Operating System. CMAKE_SYSTEM_NAME=${CMAKE_SYSTEM_NAME}")
endif()

include(CheckIncludeFile)
include(CheckSymbolExists)
include(GNUInstallDirs)

add_subdirectory(lib)
add_subdirectory(src)

message(STATUS "CPU_FEATURES_DOTNET_RID=${CPU_FEATURES_DOTNET_RID}")
message(STATUS "CPU_FEATURES_DOTNET_ARCH=${CPU_FEATURES_DOTNET_ARCH}")
