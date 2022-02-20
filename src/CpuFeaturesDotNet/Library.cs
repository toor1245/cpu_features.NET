// Copyright (c) 2022 Mykola Hohsadze 
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace CpuFeaturesDotNet
{
    internal static class Library
    {
#if X64 && OS_LINUX
        public const string NATIVE_LIBRARY = "Native/Platforms/linux/x86-64/cpu_features_dotnet.x64.so";
#elif X64 && OS_WINDOWS
        public const string NATIVE_LIBRARY = "Native\\Platforms\\win\\x86-64\\cpu_features_dotnet.x64.dll";
#elif X64 && OS_MAC
        public const string NATIVE_LIBRARY = "Native/Platforms/darwin/x86-64/cpu_features_dotnet.x64.dylib";
#elif ARM32 && OS_WINDOWS
        public const string NATIVE_LIBRARY = "Native\\Platforms\\win\\aarch32\\cpu_features_dotnet.aarch32.dll";
#elif ARM32 && OS_LINUX
        public const string NATIVE_LIBRARY = "Native/Platforms/linux/aarch32/cpu_features_dotnet.aarch32.so";
#elif ARM64 && OS_WINDOWS
        public const string NATIVE_LIBRARY = "Native\\Platforms\\win\\aarch64\\cpu_features_dotnet.aarch64.dll";
#elif ARM64 && OS_LINUX
        public const string NATIVE_LIBRARY = "Native/Platforms/linux/aarch64/cpu_features_dotnet.aarch64.so";
#elif ARM64 && OS_MAC
        public const string NATIVE_LIBRARY = "Native/Platforms/darwin/aarch64/cpu_features_dotnet.aarch64.dylib";
#endif
    }
}