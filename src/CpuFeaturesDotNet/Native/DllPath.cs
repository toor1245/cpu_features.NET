// Copyright (c) 2021 Nikolay Hohsadze 
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

namespace CpuFeaturesDotNet.Native
{
    internal static class DllPath
    {
#if OS_LINUX
        public const string X86_LIBRARY = "Native/x86-64/cpu_features_dotnet.linux-x86-64.so";
        public const string ARM_LIBRARY = "Native/Arm/libcpu_features_dotnet.so";
#elif OS_WINDOWS
        public const string X86_LIBRARY = "Native\\x86-64\\cpu_features_dotnet.win-x86-64.dll";
        public const string ARM_LIBRARY = "not_founds";
#elif OS_MAC
        public const string X86_LIBRARY = "not_founds";
        public const string ARM_LIBRARY = "not_founds";
#endif
    }
}