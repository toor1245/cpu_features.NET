cmake_minimum_required(VERSION 3.0)

# option() honors normal variables.
# see: https://cmake.org/cmake/help/git-stage/policy/CMP0077.html
if(POLICY CMP0077)
    cmake_policy(SET CMP0077 NEW)
endif()

project(CpuFeaturesDotNet VERSION 0.1.0 LANGUAGES C)

set(CMAKE_C_STANDARD 99)

# Default Build Type to be Release
if(NOT CMAKE_BUILD_TYPE)
    set(CMAKE_BUILD_TYPE "Release" CACHE STRING
            "Choose the type of build, options are: Debug Release RelWithDebInfo MinSizeRel."
            FORCE)
endif(NOT CMAKE_BUILD_TYPE)

option(BUILD_SHARED_LIBS "Build library as shared." OFF)
# PIC
option(BUILD_PIC "Build with Position Independant Code." OFF) # Default is off at least for GCC

# Force PIC on unix when building shared libs
# see: https://en.wikipedia.org/wiki/Position-independent_code
if(BUILD_SHARED_LIBS AND UNIX)
    set(BUILD_PIC ON)
endif()

set(CMAKE_C_FLAGS "-fPIC")

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

include(CheckIncludeFile)
include(CheckSymbolExists)
include(GNUInstallDirs)

macro(setup_include_and_definitions TARGET_NAME)
    target_include_directories(${TARGET_NAME}
            PUBLIC  $<BUILD_INTERFACE:${PROJECT_SOURCE_DIR}/include>
            )
    target_compile_definitions(${TARGET_NAME}
            PUBLIC STACK_LINE_READER_BUFFER_SIZE=1024
            )
endmacro()

set(PROCESSOR_IS_X86 FALSE)
set(PROCESSOR_IS_ARM FALSE)

if(CMAKE_SYSTEM_PROCESSOR MATCHES "(x86_64)|(AMD64|amd64)|(^i.86$)")
    set(PROCESSOR_IS_X86 TRUE)
elseif(CMAKE_SYSTEM_PROCESSOR MATCHES "^arm")
    set(PROCESSOR_IS_ARM TRUE)
endif()

macro(add_cpu_features_headers_and_sources HDRS_LIST_NAME SRCS_LIST_NAME)
    list(APPEND ${HDRS_LIST_NAME} include/shared/macros.h)
    list(APPEND ${HDRS_LIST_NAME} include/shared/arch.h)
    list(APPEND ${HDRS_LIST_NAME} include/shared/os.h)
    list(APPEND ${HDRS_LIST_NAME} include/shared/filesystem.h)
    list(APPEND ${SRCS_LIST_NAME} ${PROJECT_SOURCE_DIR}/src/os.c)
    list(APPEND ${SRCS_LIST_NAME} ${PROJECT_SOURCE_DIR}/src/filesystem.c)
    list(APPEND ${SRCS_LIST_NAME} ${PROJECT_SOURCE_DIR}/src/arch.c)
    if(PROCESSOR_IS_X86)
        list(APPEND ${HDRS_LIST_NAME} include/x86-64/cpuinfo_x86.h)
        list(APPEND ${HDRS_LIST_NAME} include/x86-64/cpuid_x86.h)
        list(APPEND ${SRCS_LIST_NAME} ${PROJECT_SOURCE_DIR}/src/cpuid_x86.c)
        list(APPEND ${SRCS_LIST_NAME} ${PROJECT_SOURCE_DIR}/src/cpuinfo_x86.c)
    elseif(PROCESSOR_IS_ARM)
        list(APPEND ${HDRS_LIST_NAME} include/aarch32/cpuinfo_arm.h)
        list(APPEND ${SRCS_LIST_NAME} ${PROJECT_SOURCE_DIR}/src/cpuinfo_arm.c)
    else()
        message(FATAL_ERROR "Unsupported architectures ${CMAKE_SYSTEM_PROCESSOR}")
    endif()
endmacro()

#
# library : shared
#

add_library(cpu_features_dotnet_shared SHARED
        include/shared/arch.h
        include/shared/filesystem.h
        include/shared/macros.h
        include/shared/os.h
        ${PROJECT_SOURCE_DIR}/src/arch.c
        ${PROJECT_SOURCE_DIR}/src/filesystem.c
        ${PROJECT_SOURCE_DIR}/src/os.c
        )
target_link_libraries(cpu_features_dotnet_shared PUBLIC ${CMAKE_DL_LIBS})
set_property(TARGET cpu_features_dotnet_shared PROPERTY POSITION_INDEPENDENT_CODE ${BUILD_PIC})
setup_include_and_definitions(cpu_features_dotnet_shared)

#
# library : cpu_features_dotnet
#
add_cpu_features_headers_and_sources(CPU_FEATURES_DOTNET_HDRS CPU_FEATURES_DOTNET_SRCS)
add_library(cpu_features_dotnet SHARED ${CPU_FEATURES_DOTNET_HDRS} ${CPU_FEATURES_DOTNET_SRCS})
set_target_properties(cpu_features_dotnet PROPERTIES PUBLIC_HEADER "${CPU_FEATURES_DOTNET_HDRS}")
setup_include_and_definitions(cpu_features_dotnet)
target_link_libraries(cpu_features_dotnet PUBLIC ${CMAKE_DL_LIBS})
set_property(TARGET cpu_features_dotnet PROPERTY POSITION_INDEPENDENT_CODE ${BUILD_PIC})
target_include_directories(cpu_features_dotnet
        PUBLIC $<INSTALL_INTERFACE:${CMAKE_INSTALL_INCLUDEDIR}/cpu_features_dotnet>
        )
if(PROCESSOR_IS_X86)
    if(APPLE)
        target_compile_definitions(cpu_features_dotnet PRIVATE HAVE_SYSCTLBYNAME)
    endif()
endif()
add_library(CpuFeature::cpu_features_dotnet ALIAS cpu_features_dotnet)

#
# program : cpu_features_entry
#

add_executable(list_cpu_features ${PROJECT_SOURCE_DIR}/src/utils/cpu_features_entry.c)
target_link_libraries(list_cpu_features PRIVATE cpu_features_dotnet)
add_executable(CpuFeature::list_cpu_features ALIAS list_cpu_features)