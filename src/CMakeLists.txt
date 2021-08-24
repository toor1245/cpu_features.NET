set(CURRENT_PLATFORMS_DIR Native\\Platforms)
set(CSPROJ_BINARY_SHARED_PATH ${CPU_FEATURES_DOTNET_SHARED}.${PROCESSOR_OUTPUT_NAME}${LIBRARY_EXTENSION})
set(CSPROJ_BINARY_PATH ${CPU_FEATURES_DOTNET}.${PROCESSOR_OUTPUT_NAME}${LIBRARY_EXTENSION})

set(PLATFORM_TARGET AnyCPU)
set(PREFER_32BIT false)
set(IS_OPTIMIZE false)
set(NATIVE_LIB_SHARED_PATH ${CURRENT_PLATFORMS_DIR}\\${LIBRARY_OS}\\${LIBRARY_ARCHITECTURE}\\${CSPROJ_BINARY_SHARED_PATH})
set(NATIVE_LIB_PATH ${CURRENT_PLATFORMS_DIR}\\${LIBRARY_OS}\\${LIBRARY_ARCHITECTURE}\\${CSPROJ_BINARY_PATH})

configure_file(
        ${PROJECT_SOURCE_DIR}/cmake/CpuFeaturesDotNet.csproj.in
        ${CMAKE_CURRENT_SOURCE_DIR}/CpuFeaturesDotNet/CpuFeaturesDotNet.csproj
        @ONLY)