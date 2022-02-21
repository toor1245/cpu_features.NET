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

#ifndef CPU_FEATURES_DOTNET_CPUINFO_AARCH64_PORT_H
#define CPU_FEATURES_DOTNET_CPUINFO_AARCH64_PORT_H

#include "cpu_features_port_macros.h"
#include "cpuinfo_aarch64.h"

CPU_FEATURES_DOTNET_DLL_EXPORT Aarch64Info GetAarch64InfoPort(void);

#endif // CPU_FEATURES_DOTNET_CPUINFO_AARCH64_PORT_H
