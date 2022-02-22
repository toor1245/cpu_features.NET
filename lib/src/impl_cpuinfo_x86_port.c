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

#include "cpu_features_macros.h"

#if defined(CPU_FEATURES_ARCH_X86)
#include "cpuinfo_x86_port.h"
#include "copy.inl"

X86Microarchitecture GetX86MicroarchitecturePort(const X86Info *info) {
    return GetX86Microarchitecture(info);
}

void FillX86BrandStringPort(char *brand_string) {
    FillX86BrandString(brand_string);
}

void GetX86InfoPort(char brand_string[49], char vendor[13], int *model, int *stepping,
                    int *family, X86Features *features) {
    X86Info info = GetX86Info();
    *model = info.model;
    *stepping = info.stepping;
    *family = info.family;
    *features = info.features;
    Copy(brand_string, info.brand_string, 48);
    Copy(vendor, info.vendor, 12);
    brand_string[48] = '\0';
    vendor[12] = '\0';
}

void GetX86CacheInfoPort(int *size, CacheLevelInfo *levels) {
    CacheInfo cacheInfo = GetX86CacheInfo();
    *size = cacheInfo.size;
    Copy((char *) levels, (const char *) cacheInfo.levels, sizeof(CacheLevelInfo) * 10);
}
#endif  // CPU_FEATURES_ARCH_X86
