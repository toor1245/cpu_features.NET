#
# install cpu_features
#

if(NOT TARGET cpu_features)
configure_file(
        ../cmake/templates/cpu_features.CMakeLists.txt.in
        ../cpu_features-download/CMakeLists.txt
)

execute_process(
        COMMAND ${CMAKE_COMMAND} -G "${CMAKE_GENERATOR}" .
        RESULT_VARIABLE result
        WORKING_DIRECTORY ${CMAKE_BINARY_DIR}/cpu_features-download)

if(result)
    message(FATAL_ERROR "CMake step for cpu_features failed: ${result}")
endif()

execute_process(
        COMMAND ${CMAKE_COMMAND} --build .
        RESULT_VARIABLE result
        WORKING_DIRECTORY ${CMAKE_BINARY_DIR}/cpu_features-download)

if(result)
    message(FATAL_ERROR "Build step for cpu_features failed: ${result}")
endif()

add_subdirectory(${CMAKE_BINARY_DIR}/cpu_features-src
        ${CMAKE_BINARY_DIR}/cpu_features-build
        EXCLUDE_FROM_ALL)
endif()

macro(setup_include_and_definitions TARGET_NAME)
    target_include_directories(${TARGET_NAME}
            PUBLIC $<BUILD_INTERFACE:${CMAKE_CURRENT_SOURCE_DIR}/include>
            )
endmacro()

macro(add_cpu_features_headers_and_sources HDRS_LIST_NAME SRCS_LIST_NAME)
    list(APPEND ${HDRS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/include/cpu_features_port_macros.h)
    list(APPEND ${HDRS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/include/cpuinfo_arm_port.h)
    file(GLOB IMPL_SOURCES CONFIGURE_DEPENDS "${CMAKE_CURRENT_SOURCE_DIR}/src/impl_*.c")
    list(APPEND ${SRCS_LIST_NAME} ${IMPL_SOURCES})
    if (CPU_FEATURES_DOTNET_PROCESSOR_IS_X86)
        list(APPEND ${HDRS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/include/cpuinfo_x86_port.h)
    elseif (CPU_FEATURES_DOTNET_PROCESSOR_IS_ARM)
        list(APPEND ${HDRS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/include/cpuinfo_arm_port.h)
    elseif (CPU_FEATURES_DOTNET_PROCESSOR_IS_AARCH64)
        list(APPEND ${HDRS_LIST_NAME} ${CMAKE_CURRENT_SOURCE_DIR}/include/cpuinfo_aarch64_port.h)
    else ()
        message(FATAL_ERROR "Unsupported CPU_FEATURES_DOTNET_ARCH ${CMAKE_SYSTEM_PROCESSOR}")
    endif ()
endmacro()

macro(copy_to_CpuFeaturesDotNet TARGET_NAME)
    add_custom_command(TARGET ${TARGET_NAME} POST_BUILD
            COMMAND ${CMAKE_COMMAND} -E copy_if_different
            ${CMAKE_BINARY_DIR}/lib/${CPU_FEATURES_DOTNET_CONFIG_BIN_DIR}${TARGET_NAME}.${CPU_FEATURES_DOTNET_PROCESSOR_OUTPUT_NAME}${CPU_FEATURES_DOTNET_LIBRARY_EXTENSION} ${CPU_FEATURES_DOTNET_NATIVE_DIR}
            )
endmacro()

#
# library : cpu_features_dotnet
#

set(CPU_FEATURES_DOTNET_HDRS)
set(CPU_FEATURES_DOTNET_SRCS)
add_cpu_features_headers_and_sources(CPU_FEATURES_DOTNET_HDRS CPU_FEATURES_DOTNET_SRCS)
add_library(${CPU_FEATURES_DOTNET} SHARED ${CPU_FEATURES_DOTNET_HDRS} ${CPU_FEATURES_DOTNET_SRCS})
set_target_properties(${CPU_FEATURES_DOTNET} PROPERTIES PREFIX "")
set_target_properties(${CPU_FEATURES_DOTNET} PROPERTIES OUTPUT_NAME "${CPU_FEATURES_DOTNET}.${CPU_FEATURES_DOTNET_PROCESSOR_OUTPUT_NAME}")
set_target_properties(${CPU_FEATURES_DOTNET} PROPERTIES PUBLIC_HEADER "${CPU_FEATURES_DOTNET_HDRS}")
setup_include_and_definitions(${CPU_FEATURES_DOTNET})
target_link_libraries(${CPU_FEATURES_DOTNET} PUBLIC ${CMAKE_DL_LIBS})
target_link_libraries(${CPU_FEATURES_DOTNET} PUBLIC cpu_features)
set_property(TARGET ${CPU_FEATURES_DOTNET} PROPERTY POSITION_INDEPENDENT_CODE ${BUILD_PIC})
target_include_directories(${CPU_FEATURES_DOTNET}
        PUBLIC $<INSTALL_INTERFACE:${CMAKE_INSTALL_INCLUDEDIR}/${CPU_FEATURES_DOTNET}>
        )
add_library(CpuFeature::${CPU_FEATURES_DOTNET} ALIAS ${CPU_FEATURES_DOTNET})

copy_to_CpuFeaturesDotNet(${CPU_FEATURES_DOTNET})