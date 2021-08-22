cmake_minimum_required(VERSION 3.8)

project(CpuFeaturesDotNet VERSION 0.0.1 LANGUAGES C)

# option() honors normal variables.
# see: https://cmake.org/cmake/help/git-stage/policy/CMP0077.html
if(POLICY CMP0077)
    cmake_policy(SET CMP0077 NEW)
endif()

add_subdirectory(lib)