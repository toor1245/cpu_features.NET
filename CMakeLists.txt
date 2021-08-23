cmake_minimum_required(VERSION 3.8)

project(CpuFeaturesDotNet VERSION 0.0.1 LANGUAGES C)

# option() honors normal variables.
# see: https://cmake.org/cmake/help/git-stage/policy/CMP0077.html
if(POLICY CMP0077)
    cmake_policy(SET CMP0077 NEW)
endif()

set(CMAKE_C_STANDARD 99)

set(IS_GENERATE_FOR_ARM FALSE)
if(IS_GENERATE_FOR_ARM)
    set(CMAKE_SYSTEM_NAME Linux)
    set(CMAKE_SYSTEM_PROCESSOR arm)

    set(triple arm-linux-gnueabihf)

    set(CMAKE_C_COMPILER clang)
    set(CMAKE_C_COMPILER_TARGET ${triple})
    set(CMAKE_CXX_COMPILER clang++)
    set(CMAKE_CXX_COMPILER_TARGET ${triple})
endif()

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

add_subdirectory(lib)