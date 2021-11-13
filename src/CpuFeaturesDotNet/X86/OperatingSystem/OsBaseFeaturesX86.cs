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

using System;
using CpuFeaturesDotNet.Native.OperatingSystem;

namespace CpuFeaturesDotNet.X86.OperatingSystem
{
    internal abstract class OsBaseFeaturesX86
    {
        protected readonly FeaturesX86 _featuresX86;

        public OsBaseFeaturesX86(FeaturesX86 featuresX86)
        {
            _featuresX86 = featuresX86;
        }
        
        public abstract void SetRegistersXcr0NotAvailable();

        public virtual bool HasAvx512Registers(uint xcr0Eax)
        {
            return FeaturesHelperX86.HasZmmOsXSave(xcr0Eax);
        }

        internal static OsBaseFeaturesX86 GetFeaturesX86(FeaturesX86 featuresX86)
        {
            if (OSNative.IsWindows())
            {
                return new WindowsFeaturesX86(featuresX86);
            }

            if (OSNative.IsDarwin())
            {
                return new DarwinFeaturesX86(featuresX86);
            }

            if (OSNative.IsLinuxOrAndroid())
            {
                return new LinuxAndroidFeaturesX86(featuresX86);
            }

            if (OSNative.IsFreeBsd())
            {
                return new FreeBsdFeaturesX86(featuresX86);
            }

            throw new NotSupportedException("Not supported Operating System");
        }
    }
}