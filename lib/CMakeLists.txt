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