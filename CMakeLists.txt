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

if(UNIX)
    set(CMAKE_C_FLAGS "-fPIC")
    set(CMAKE_CXX_FLAGS "-fPIC")
endif()

set(IS_VISUAL_STUDIO_GENERATOR FALSE)
set(CONFIGURATION_BINARY_DIR "")
if (CMAKE_GENERATOR MATCHES "Visual Studio 16 2019")
    set(IS_VISUAL_STUDIO_GENERATOR TRUE)
    set(CONFIGURATION_BINARY_DIR "${CMAKE_CONFIGURATION_TYPES}/")
    message("-- set CONFIGURATION_BINARY_DIR: ${CMAKE_CONFIGURATION_TYPES}")
endif()

set(CPU_FEATURES_DOTNET cpu_features_dotnet)
set(CPU_FEATURES_DOTNET_SHARED cpu_features_dotnet_shared)

set(PROCESSOR_IS_MIPS FALSE)
set(PROCESSOR_IS_ARM FALSE)
set(PROCESSOR_IS_AARCH64 FALSE)
set(PROCESSOR_IS_X86 FALSE)
set(PROCESSOR_IS_POWER FALSE)
set(PROCESSOR_OUTPUT_NAME)

message("SYSTEM_PROCESSOR: ${CMAKE_SYSTEM_PROCESSOR}")

if(CMAKE_SYSTEM_PROCESSOR MATCHES "(x86_64)|(AMD64|amd64)|(^i.86$)")
    set(PROCESSOR_IS_X86 TRUE)
    set(PROCESSOR_OUTPUT_NAME "x64")
elseif(CMAKE_SYSTEM_PROCESSOR MATCHES "^arm")
    set(PROCESSOR_IS_ARM TRUE)
    set(PROCESSOR_OUTPUT_NAME "aarch32")
elseif(CMAKE_SYSTEM_PROCESSOR MATCHES "^aarch64")
    set(PROCESSOR_IS_AARCH64 TRUE)
    set(PROCESSOR_OUTPUT_NAME "aarch64")
elseif(CMAKE_SYSTEM_PROCESSOR MATCHES "^(powerpc|ppc)")
    set(PROCESSOR_IS_POWER TRUE)
    set(PROCESSOR_OUTPUT_NAME "ppc")
elseif(CMAKE_SYSTEM_PROCESSOR MATCHES "^mips")
    set(PROCESSOR_IS_MIPS TRUE)
    set(PROCESSOR_OUTPUT_NAME "mips")
else()
    message(FATAL_ERROR "Unsupported system !")
endif()

set(CPU_FEATURES_DOTNET_NATIVE ${PROJECT_SOURCE_DIR}/src/CpuFeaturesDotNet/Native)
set(CPU_FEATURES_DOTNET_PLATFORMS ${CPU_FEATURES_DOTNET_NATIVE}/Platforms)
file(MAKE_DIRECTORY ${CPU_FEATURES_DOTNET_PLATFORMS})

set(LIBRARY_EXTENSION)
set(LIBRARY_PATH)
set(LIBRARY_ARCHITECTURE)
set(LIBRARY_ARCHITECTURE_PATH)
set(LIBRARY_OS)

macro(add_architecture_path LIBRARY_NAME ARCH)
    message("-- add_architecture_path params: ARCH=${ARCH}, LIBRARY_NAME=${LIBRARY_NAME}")
    set(LIBRARY_ARCHITECTURE ${ARCH})
    set(LIBRARY_ARCHITECTURE_PATH ${LIBRARY_NAME}/${LIBRARY_ARCHITECTURE})
    file(MAKE_DIRECTORY ${LIBRARY_ARCHITECTURE_PATH})
endmacro()

macro(add_cpu_path LIBRARY_NAME)
    message("-- add_cpu_path params: LIBRARY_NAME=${LIBRARY_NAME}")
    if(PROCESSOR_IS_X86)
        add_architecture_path(${LIBRARY_NAME} x86-64)
    elseif(PROCESSOR_IS_ARM)
        add_architecture_path(${LIBRARY_NAME} aarch32)
    elseif(PROCESSOR_IS_AARCH64)
        add_architecture_path(${LIBRARY_NAME} aarch64)
    else()
        message(FATAL_ERROR "Unsupported CPU Architecture !")
    endif()
endmacro()

macro(add_shared_lib_extension_to_os LIB_EXTENSION OS_DIR)
    message("-- add_shared_lib_extension_to_os params: LIB_EXTENSION=${LIB_EXTENSION}, OS_DIR=${OS_DIR}")
    set(LIBRARY_OS ${OS_DIR})
    set(LIBRARY_EXTENSION ${LIB_EXTENSION})
    set(LIBRARY_PATH ${CPU_FEATURES_DOTNET_PLATFORMS}/${OS_DIR})
    add_cpu_path(${LIBRARY_PATH})
endmacro()

if (CMAKE_SYSTEM_NAME MATCHES "(Windows)")
    add_shared_lib_extension_to_os(.dll win)
elseif(CMAKE_SYSTEM_NAME MATCHES "(Linux)")
    add_shared_lib_extension_to_os(.so linux)
elseif(CMAKE_SYSTEM_NAME MATCHES "(Darwin)")
    add_shared_lib_extension_to_os(.dylib darwin)
elseif(CMAKE_SYSTEM_NAME MATCHES "(FreeBSD)")
    add_shared_lib_extension_to_os(.so freebsd)
else()
    message(FATAL_ERROR "Unsupported Operating System !")
endif()

include(CheckIncludeFile)
include(CheckSymbolExists)
include(GNUInstallDirs)

add_subdirectory(lib)
add_subdirectory(src)