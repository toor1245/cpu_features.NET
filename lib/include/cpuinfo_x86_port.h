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

#ifndef CPU_FEATURES_DOTNET_CPUINFO_X86_PORT_H
#define CPU_FEATURES_DOTNET_CPUINFO_X86_PORT_H

#include "cpu_features_port_macros.h"
#include "cpuinfo_x86.h"

CPU_FEATURES_DOTNET_DLL_EXPORT void GetX86InfoPort(char brand_string[49], char vendor[13], int *model, int *stepping,
                                                   int *family, int *features_raw1, int *features_raw2);

CPU_FEATURES_DOTNET_DLL_EXPORT void GetX86CacheInfoPort(int *size, CacheLevelInfo *levels);

CPU_FEATURES_DOTNET_DLL_EXPORT X86Microarchitecture GetX86MicroarchitecturePort(const X86Info *info);

CPU_FEATURES_DOTNET_DLL_EXPORT void FillX86BrandStringPort(char brand_string[49]);

#endif // CPU_FEATURES_DOTNET_CPUINFO_X86_PORT_H
