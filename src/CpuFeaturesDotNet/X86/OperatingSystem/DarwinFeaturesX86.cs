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

using CpuFeaturesDotNet.Native.OperatingSystem;

namespace CpuFeaturesDotNet.X86.OperatingSystem
{
    internal sealed class DarwinFeaturesX86 : OsBaseFeaturesX86
    {
        public DarwinFeaturesX86(FeaturesX86 featuresX86)
            : base(featuresX86)
        {
        }

        public override void SetRegistersXcr0NotAvailable()
        {
            _featuresX86.IsSupportedSSE = DarwinNative.GetDarwinSysCtlByName("hw.optional.sse");
            _featuresX86.IsSupportedSSE2 = DarwinNative.GetDarwinSysCtlByName("hw.optional.sse2");
            _featuresX86.IsSupportedSSE3 = DarwinNative.GetDarwinSysCtlByName("hw.optional.sse3");
            _featuresX86.IsSupportedSSSE3 = DarwinNative.GetDarwinSysCtlByName("hw.optional.supplementalsse3");
            _featuresX86.IsSupportedSSE41 = DarwinNative.GetDarwinSysCtlByName("hw.optional.sse4_1");
            _featuresX86.IsSupportedSSE42 = DarwinNative.GetDarwinSysCtlByName("hw.optional.sse4_2");
        }
    }
}