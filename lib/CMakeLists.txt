include(CheckIncludeFile)
include(CheckSymbolExists)
include(GNUInstallDirs)

macro(setup_include_and_definitions TARGET_NAME)
    target_include_directories(${TARGET_NAME}
            PUBLIC  $<BUILD_INTERFACE:${CMAKE_CURRENT_SOURCE_DIR}/include/aarch32>
            PUBLIC  $<BUILD_INTERFACE:${CMAKE_CURRENT_SOURCE_DIR}/include/shared>
            PUBLIC  $<BUILD_INTERFACE:${CMAKE_CURRENT_SOURCE_DIR}/include/x86-64>
            )
    target_compile_definitions(${TARGET_NAME}
            PUBLIC STACK_LINE_READER_BUFFER_SIZE=1024
            )
endmacro()

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
endif()

macro(add_cpu_features_headers_and_sources HDRS_LIST_NAME SRCS_LIST_NAME)
    list(APPEND ${HDRS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/include/shared/macros.h)
    list(APPEND ${HDRS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/include/shared/arch.h)
    list(APPEND ${HDRS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/include/shared/os.h)
    list(APPEND ${HDRS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/include/shared/filesystem.h)

    list(APPEND ${SRCS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/src/os.c)
    list(APPEND ${SRCS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/src/filesystem.c)
    list(APPEND ${SRCS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/src/arch.c)
    if(PROCESSOR_IS_X86)
        list(APPEND ${HDRS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/include/x86-64/cpuinfo_x86.h)
        list(APPEND ${HDRS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/include/x86-64/cpuid_x86.h)

        list(APPEND ${SRCS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/src/cpuid_x86.c)
        list(APPEND ${SRCS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/src/cpuinfo_x86.c)
    elseif(PROCESSOR_IS_ARM)
        list(APPEND ${HDRS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/include/aarch32/cpuinfo_arm.h)

        list(APPEND ${SRCS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/src/cpuinfo_arm.c)
    else()
        message(FATAL_ERROR "Unsupported architectures ${CMAKE_SYSTEM_PROCESSOR}")
    endif()
endmacro()

set(CPU_FEATURES_DOTNET_NATIVE ${PROJECT_SOURCE_DIR}/src/CpuFeaturesDotNet/Native)
set(CPU_FEATURES_DOTNET_PLATFORMS ${CPU_FEATURES_DOTNET_NATIVE}/Platforms)
file(MAKE_DIRECTORY ${CPU_FEATURES_DOTNET_PLATFORMS})

set(LIBRARY_EXTENSION)
set(LIBRARY_PATH)
set(LIBRARY_ARCHITECTURE_PATH)

macro(add_cpu_path LIBRARY_NAME)
    if(PROCESSOR_IS_X86)
        set(LIBRARY_ARCHITECTURE_PATH ${LIBRARY_NAME}/x86-64)
        file(MAKE_DIRECTORY ${LIBRARY_ARCHITECTURE_PATH})
    endif()
    if(PROCESSOR_IS_ARM)
        set(LIBRARY_ARCHITECTURE_PATH ${LIBRARY_NAME}/aarch32)
        file(MAKE_DIRECTORY ${LIBRARY_ARCHITECTURE_PATH})
    endif()
    if(PROCESSOR_IS_AARCH64)
        set(LIBRARY_ARCHITECTURE_PATH ${LIBRARY_NAME}/aarch64)
        file(MAKE_DIRECTORY ${LIBRARY_ARCHITECTURE_PATH})
    endif()
endmacro()

if (CMAKE_SYSTEM_NAME MATCHES "(Windows)")
    set(LIBRARY_EXTENSION .dll)
    set(LIBRARY_PATH ${CPU_FEATURES_DOTNET_PLATFORMS}/win)
    message("Library ${LIBRARY_PATH}")
    add_cpu_path(${LIBRARY_PATH})
elseif(CMAKE_SYSTEM_NAME MATCHES "(Linux)")
    set(LIBRARY_PATH ${CPU_FEATURES_DOTNET_PLATFORMS}/linux)
    set(LIBRARY_EXTENSION .so)
    add_cpu_path(${LIBRARY_PATH})
elseif(CMAKE_SYSTEM_NAME MATCHES "(Darwin)")
    set(LIBRARY_PATH ${CPU_FEATURES_DOTNET_PLATFORMS}/darwin)
    set(LIBRARY_EXTENSION .dylib)
    add_cpu_path(${LIBRARY_PATH})
elseif(CMAKE_SYSTEM_NAME MATCHES "(FreeBSD)")
    set(LIBRARY_PATH ${CPU_FEATURES_DOTNET_PLATFORMS}/freebsd)
    set(LIBRARY_EXTENSION .so)
    add_cpu_path(${LIBRARY_PATH})
endif()

macro(copy_to_CpuFeaturesDotNet TARGET_NAME)
    message(${CMAKE_BINARY_DIR}/lib/${CONFIGURATION_BINARY_DIR}${TARGET_NAME}.${PROCESSOR_OUTPUT_NAME}${LIBRARY_EXTENSION})
    message(${LIBRARY_ARCHITECTURE_PATH}/)
    add_custom_command(TARGET ${TARGET_NAME} POST_BUILD
            COMMAND ${CMAKE_COMMAND} -E copy_if_different
            ${CMAKE_BINARY_DIR}/lib/${CONFIGURATION_BINARY_DIR}${TARGET_NAME}.${PROCESSOR_OUTPUT_NAME}${LIBRARY_EXTENSION} ${LIBRARY_ARCHITECTURE_PATH}
            )
endmacro()

#
# library : shared
#

set(CPU_FEATURES_DOTNET_SHARED cpu_features_dotnet_shared)
add_library(${CPU_FEATURES_DOTNET_SHARED} SHARED
        ${CMAKE_CURRENT_SOURCE_DIR}/include/shared/arch.h
        ${CMAKE_CURRENT_SOURCE_DIR}/include/shared/filesystem.h
        ${CMAKE_CURRENT_SOURCE_DIR}/include/shared/macros.h
        ${CMAKE_CURRENT_SOURCE_DIR}/include/shared/os.h

        ${CMAKE_CURRENT_SOURCE_DIR}/src/arch.c
        ${CMAKE_CURRENT_SOURCE_DIR}/src/filesystem.c
        ${CMAKE_CURRENT_SOURCE_DIR}/src/os.c
        )
set_target_properties(${CPU_FEATURES_DOTNET_SHARED} PROPERTIES PREFIX "")
set_target_properties(${CPU_FEATURES_DOTNET_SHARED} PROPERTIES OUTPUT_NAME "${CPU_FEATURES_DOTNET_SHARED}.${PROCESSOR_OUTPUT_NAME}")
target_link_libraries(${CPU_FEATURES_DOTNET_SHARED} PUBLIC ${CMAKE_DL_LIBS})
set_property(TARGET ${CPU_FEATURES_DOTNET_SHARED} PROPERTY POSITION_INDEPENDENT_CODE ${BUILD_PIC})
setup_include_and_definitions(${CPU_FEATURES_DOTNET_SHARED})

#
# library : cpu_features_dotnet
#

set(CPU_FEATURES_DOTNET cpu_features_dotnet)
add_cpu_features_headers_and_sources(CPU_FEATURES_DOTNET_HDRS CPU_FEATURES_DOTNET_SRCS)
add_library(${CPU_FEATURES_DOTNET} SHARED ${CPU_FEATURES_DOTNET_HDRS} ${CPU_FEATURES_DOTNET_SRCS})
set_target_properties(${CPU_FEATURES_DOTNET} PROPERTIES PREFIX "")
set_target_properties(${CPU_FEATURES_DOTNET} PROPERTIES OUTPUT_NAME "${CPU_FEATURES_DOTNET}.${PROCESSOR_OUTPUT_NAME}")
set_target_properties(${CPU_FEATURES_DOTNET} PROPERTIES PUBLIC_HEADER "${CPU_FEATURES_DOTNET_HDRS}")
setup_include_and_definitions(${CPU_FEATURES_DOTNET})
target_link_libraries(${CPU_FEATURES_DOTNET} PUBLIC ${CMAKE_DL_LIBS})
set_property(TARGET ${CPU_FEATURES_DOTNET} PROPERTY POSITION_INDEPENDENT_CODE ${BUILD_PIC})
target_include_directories(${CPU_FEATURES_DOTNET}
        PUBLIC $<INSTALL_INTERFACE:${CMAKE_INSTALL_INCLUDEDIR}/${CPU_FEATURES_DOTNET}>
        )
if(PROCESSOR_IS_X86)
    if(APPLE)
        target_compile_definitions(${CPU_FEATURES_DOTNET} PRIVATE HAVE_SYSCTLBYNAME)
    endif()
endif()
add_library(CpuFeature::${CPU_FEATURES_DOTNET} ALIAS ${CPU_FEATURES_DOTNET})

#
# program : cpu_features_entry
#

add_executable(list_cpu_features src/utils/cpu_features_entry.c)
target_link_libraries(list_cpu_features PRIVATE ${CPU_FEATURES_DOTNET})
add_executable(CpuFeature::list_cpu_features ALIAS list_cpu_features)

copy_to_CpuFeaturesDotNet(${CPU_FEATURES_DOTNET_SHARED})
copy_to_CpuFeaturesDotNet(${CPU_FEATURES_DOTNET})