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

using System.Runtime.InteropServices;
using static CpuFeaturesDotNet.Native.Library;

namespace CpuFeaturesDotNet.Native.OperatingSystem
{
    internal static class WindowsNative
    {
        internal const int PF_XMMI_INSTRUCTIONS_AVAILABLE = 6;
        internal const int PF_XMMI64_INSTRUCTIONS_AVAILABLE = 10;
        internal const int PF_SSE3_INSTRUCTIONS_AVAILABLE = 13;

        [DllImport(SHARED_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "windows_is_processor_feature_present")]
        internal static extern bool GetWindowsIsProcessorFeaturePresent(int processorFeature);
    }
}