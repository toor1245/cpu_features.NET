# Find dotnet cli
find_program(DOTNET_CLI NAMES dotnet)
if(NOT DOTNET_CLI)
    message(FATAL_ERROR "Check for dotnet Program: not found")
else()
    message(STATUS "Found dotnet Program: ${DOTNET_CLI}")
endif()

# Must be an absolute path
option(CPU_FEATURES_DOTNET_PACKAGE_OUTPUT_PATH "${PROJECT_BINARY_DIR}/dotnet/packages")

file(MAKE_DIRECTORY ${CPU_FEATURES_DOTNET_PACKAGE_OUTPUT_PATH})

#
#  CpuFeaturesDotNet Runtime Package
#

set(CPU_FEATURES_DOTNET_RUNTIME ${CPU_FEATURES_DOTNET_NAME}.runtime.${CPU_FEATURES_DOTNET_RID})

set(CPU_FEATURES_RUNTIME_DIR ${CPU_FEATURES_DOTNET_PACKAGE_OUTPUT_PATH}/${CPU_FEATURES_DOTNET_RUNTIME})
file(MAKE_DIRECTORY ${CPU_FEATURES_RUNTIME_DIR})

configure_file(
        ../cmake/templates/${CPU_FEATURES_DOTNET_NAME}.runtime.csproj.in
        ${CPU_FEATURES_RUNTIME_DIR}/${CPU_FEATURES_DOTNET_RUNTIME}.csproj.in
        @ONLY
)

file(GENERATE
    OUTPUT ${CPU_FEATURES_RUNTIME_DIR}/$<CONFIG>/${CPU_FEATURES_DOTNET_RUNTIME}.csproj.in
    INPUT  ${CPU_FEATURES_RUNTIME_DIR}/${CPU_FEATURES_DOTNET_RUNTIME}.csproj.in
)

add_custom_command(
        OUTPUT ${CPU_FEATURES_RUNTIME_DIR}/${CPU_FEATURES_DOTNET_RUNTIME}.csproj
        COMMAND ${CMAKE_COMMAND} -E copy ./$<CONFIG>/${CPU_FEATURES_DOTNET_RUNTIME}.csproj.in ${CPU_FEATURES_DOTNET_RUNTIME}.csproj
        DEPENDS
            ${CPU_FEATURES_RUNTIME_DIR}/$<CONFIG>/${CPU_FEATURES_DOTNET_RUNTIME}.csproj.in
        WORKING_DIRECTORY ${CPU_FEATURES_RUNTIME_DIR}
)

add_custom_command(
        OUTPUT ${CPU_FEATURES_RUNTIME_DIR}/timestamp
        COMMAND ${DOTNET_CLI} build -c Release /p:Platform=x64 ${CPU_FEATURES_DOTNET_RUNTIME}.csproj
        COMMAND ${DOTNET_CLI} pack -c Release ${CPU_FEATURES_DOTNET_RUNTIME}.csproj
        DEPENDS
            ${CPU_FEATURES_RUNTIME_DIR}/${CPU_FEATURES_DOTNET_RUNTIME}.csproj
            ${CPU_FEATURES_DOTNET}
        BYPRODUCTS
            ${CPU_FEATURES_RUNTIME_DIR}/bin
            ${CPU_FEATURES_RUNTIME_DIR}/obj
        COMMENT "Generate ${CPU_FEATURES_DOTNET_RUNTIME} package"
        WORKING_DIRECTORY ${CPU_FEATURES_RUNTIME_DIR}
)

add_custom_target(cpu_features_dotnet_runtime_package
        DEPENDS
            ${CPU_FEATURES_RUNTIME_DIR}/timestamp
        WORKING_DIRECTORY ${CPU_FEATURES_RUNTIME_DIR}
)

#
#  CpuFeaturesDotNet Package
#

set(CPU_FEATURES_DOTNET_DIR ${CMAKE_CURRENT_SOURCE_DIR}/${CPU_FEATURES_DOTNET_NAME})

configure_file(
        ../cmake/templates/${CPU_FEATURES_DOTNET_NAME}.csproj.in
        ${CPU_FEATURES_DOTNET_DIR}/${CPU_FEATURES_DOTNET_NAME}.csproj.in
        @ONLY
)

add_custom_command(
        OUTPUT ${CPU_FEATURES_DOTNET_DIR}/${CPU_FEATURES_DOTNET_NAME}.csproj
        COMMAND ${CMAKE_COMMAND} -E copy ${CPU_FEATURES_DOTNET_DIR}/${CPU_FEATURES_DOTNET_NAME}.csproj.in ${CPU_FEATURES_DOTNET_DIR}/${CPU_FEATURES_DOTNET_NAME}.csproj
        DEPENDS
            ${CPU_FEATURES_DOTNET_DIR}/${CPU_FEATURES_DOTNET_NAME}.csproj.in
        WORKING_DIRECTORY ${CPU_FEATURES_DOTNET_DIR}
)


add_custom_command(
        OUTPUT ${CPU_FEATURES_DOTNET_DIR}/timestamp
        COMMAND ${DOTNET_CLI} build -c Release ${CPU_FEATURES_DOTNET_NAME}.csproj
        COMMAND ${DOTNET_CLI} pack -c Release ${CPU_FEATURES_DOTNET_NAME}.csproj
        DEPENDS
            ${CPU_FEATURES_DOTNET_DIR}/${CPU_FEATURES_DOTNET_NAME}.csproj
            cpu_features_dotnet_runtime_package
        BYPRODUCTS
            ${CPU_FEATURES_DOTNET_DIR}/bin
            ${CPU_FEATURES_DOTNET_DIR}/obj
        COMMENT "Generate ${CPU_FEATURES_DOTNET_NAME} package"
        WORKING_DIRECTORY ${CPU_FEATURES_DOTNET_DIR}
)

add_custom_target(cpu_features_dotnet_package
        DEPENDS
            ${CPU_FEATURES_DOTNET_DIR}/timestamp
        WORKING_DIRECTORY ${CPU_FEATURES_DOTNET_DIR}
)

#
#  Install CpuFeaturesDotnet package to tests and samples projects
#

configure_file(
        ../cmake/templates/Nuget.Config.in
        ${CMAKE_CURRENT_SOURCE_DIR}/../NuGet.Config
)

message(${CPU_FEATURES_RUNTIME_DIR})

set(LOG_SAMPLES_FILE "${CPU_FEATURES_RUNTIME_DIR}/log_samples.txt")
set(LOG_TESTS_FILE "${CPU_FEATURES_RUNTIME_DIR}/log_tests.txt")

add_custom_command(OUTPUT ${LOG_SAMPLES_FILE}
        COMMAND ${DOTNET_CLI} add package ${CPU_FEATURES_DOTNET_NAME} -s ${CPU_FEATURES_DOTNET_PACKAGE_OUTPUT_PATH}
        WORKING_DIRECTORY ${CMAKE_CURRENT_SOURCE_DIR}/../samples/CpuFeaturesDotNet.Samples
)

add_custom_command(OUTPUT ${LOG_TESTS_FILE}
        COMMAND ${DOTNET_CLI} add package ${CPU_FEATURES_DOTNET_NAME} -s ${CPU_FEATURES_DOTNET_PACKAGE_OUTPUT_PATH}
        WORKING_DIRECTORY ${CMAKE_CURRENT_SOURCE_DIR}/../tests
)

add_custom_target(add_nuget_package_to_tests
        DEPENDS ${LOG_SAMPLES_FILE} ${LOG_TESTS_FILE}
        WORKING_DIRECTORY ${CPU_FEATURES_DOTNET_DIR}
)
