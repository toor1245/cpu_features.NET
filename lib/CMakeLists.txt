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

if(CMAKE_SYSTEM_PROCESSOR MATCHES "(x86_64)|(AMD64|amd64)|(^i.86$)")
    set(PROCESSOR_IS_X86 TRUE)
endif()

macro(add_cpu_features_headers_and_sources HDRS_LIST_NAME SRCS_LIST_NAME)
    list(APPEND ${HDRS_LIST_NAME} ${PROJECT_SOURCE_DIR}/include/macros_x86.h)
    if(PROCESSOR_IS_X86)
        list(APPEND ${HDRS_LIST_NAME} ${PROJECT_SOURCE_DIR}/include/cpuinfo_x86.h)
        list(APPEND ${HDRS_LIST_NAME} ${PROJECT_SOURCE_DIR}/include/cpuid_x86.h)
        list(APPEND ${HDRS_LIST_NAME} ${PROJECT_SOURCE_DIR}/include/cpu_features_memory.h)
        list(APPEND ${SRCS_LIST_NAME} ${PROJECT_SOURCE_DIR}/src/cpuid_x86.c)
        list(APPEND ${SRCS_LIST_NAME} ${PROJECT_SOURCE_DIR}/src/cpuinfo_x86.c)
        list(APPEND ${SRCS_LIST_NAME} ${PROJECT_SOURCE_DIR}/src/cpu_features_memory.c)
    else()
        message(FATAL_ERROR "Unsupported architectures ${CMAKE_SYSTEM_PROCESSOR}")
    endif()
endmacro()

#
# library : cpu_features_dotnet
#
set (CPU_FEATURES_DOTNET_HDRS)
set (CPU_FEATURES_DOTNET_SRCS src/cpuid_x86.c)
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