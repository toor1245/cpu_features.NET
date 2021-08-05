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

using CpuFeaturesDotNet.IO;
using static CpuFeaturesDotNet.X86.CpuInfoX86.FeaturesX86;

namespace CpuFeaturesDotNet.X86.OperatingSystem
{
    internal class LinuxAndroidFeaturesX86 : OsBaseFeaturesX86
    {
        public override unsafe void SetRegistersXcr0NotAvailable()
        {
            var fileDescriptor = FileSystem.OpenFile("/proc/cpuinfo");
            if (fileDescriptor < 0)
            {
                return;
            }
            StackLineReader.Initialize(out var reader, fileDescriptor);
            var flagsInBytes = stackalloc byte[]
            {
                0x66, 0x6C, 0x61, 0x67, 0x73
            };
            var flags = StringView.GetString(flagsInBytes);
            while (true)
            {
                var result = StackLineReader.NextLine(ref reader);
                var line = result.line;
                StringView key = default, value = default;
                if (!StringView.GetAttributeKeyValue(line, ref key, ref value))
                {
                    continue;
                }

                if (!StringView.IsEquals(key, flags))
                {
                    continue;
                }
                
                IsSupportedSSE = HasSse(in value);
                IsSupportedSSE2 = HasSse2(in value);
                IsSupportedSSE3 = HasSse3(in value);
                IsSupportedSSSE3 = HasSsse3(in value);
                IsSupportedSSE41 = HasSse41(in value);
                IsSupportedSSE42 = HasSse42(in value);
                break;
            }
        }

        private static unsafe bool HasSse(in StringView value)
        {
            var sse = stackalloc byte[] { 0x73, 0x73, 0x65 };
            return StringView.HasWord(value, sse);
        }
        
        private unsafe bool HasSse2(in StringView value)
        {
            var sse2 = stackalloc byte[] { 0x73, 0x73, 0x65, 0x32 };
            return StringView.HasWord(value, sse2);
        }
        
        private unsafe bool HasSse3(in StringView value)
        {
            var sse3 = stackalloc byte[] { 0x73, 0x73, 0x65, 0x33 };
            return StringView.HasWord(value, sse3);
        }
        
        private unsafe bool HasSsse3(in StringView value)
        {
            var ssse3 = stackalloc byte[] { 0x73, 0x73, 0x73, 0x65, 0x33 };
            return StringView.HasWord(value, ssse3);
        }
        
        private unsafe bool HasSse41(in StringView value)
        {
            var sse41 = stackalloc byte[] { 0x73, 0x73, 0x65, 0x34, 0x31 };
            return StringView.HasWord(value, sse41);
        }
        
        private unsafe bool HasSse42(in StringView value)
        {
            var sse42 = stackalloc byte[] { 0x73, 0x73, 0x65, 0x34, 0x32 };
            return StringView.HasWord(value, sse42);
        }
    }
}