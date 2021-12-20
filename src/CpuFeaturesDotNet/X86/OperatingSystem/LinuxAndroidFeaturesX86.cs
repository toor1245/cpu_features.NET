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

namespace CpuFeaturesDotNet.X86.OperatingSystem
{
    internal class LinuxAndroidFeaturesX86 : OsBaseFeaturesX86
    {
        public LinuxAndroidFeaturesX86(FeaturesX86 featuresX86)
            : base(featuresX86)
        {
        }

        public override void SetRegistersXcr0NotAvailable()
        {
            var fileDescriptor = FileSystem.OpenFile("/proc/cpuinfo");
            if (fileDescriptor < 0)
            {
                return;
            }

            StackLineReader.Initialize(out var reader, fileDescriptor);
            var flagsInBytes = new sbyte[]
            {
                0x66,
                0x6C,
                0x61,
                0x67,
                0x73
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

                _featuresX86.IsSupportedSSE = HasSse(in value);
                _featuresX86.IsSupportedSSE2 = HasSse2(in value);
                _featuresX86.IsSupportedSSE3 = HasSse3(in value);
                _featuresX86.IsSupportedSSSE3 = HasSsse3(in value);
                _featuresX86.IsSupportedSSE41 = HasSse41(in value);
                _featuresX86.IsSupportedSSE42 = HasSse42(in value);
                break;
            }
        }

        private static unsafe bool HasSse(in StringView value)
        {
            var sse = stackalloc sbyte[] { 0x73, 0x73, 0x65 };
            return StringView.HasWord(value, sse);
        }

        private static unsafe bool HasSse2(in StringView value)
        {
            var sse2 = stackalloc sbyte[] { 0x73, 0x73, 0x65, 0x32 };
            return StringView.HasWord(value, sse2);
        }

        private static unsafe bool HasSse3(in StringView value)
        {
            var sse3 = stackalloc sbyte[] { 0x73, 0x73, 0x65, 0x33 };
            return StringView.HasWord(value, sse3);
        }

        private static unsafe bool HasSsse3(in StringView value)
        {
            var ssse3 = stackalloc sbyte[] { 0x73, 0x73, 0x73, 0x65, 0x33 };
            return StringView.HasWord(value, ssse3);
        }

        private static unsafe bool HasSse41(in StringView value)
        {
            var sse41 = stackalloc sbyte[] { 0x73, 0x73, 0x65, 0x34, 0x31 };
            return StringView.HasWord(value, sse41);
        }

        private static unsafe bool HasSse42(in StringView value)
        {
            var sse42 = stackalloc sbyte[] { 0x73, 0x73, 0x65, 0x34, 0x32 };
            return StringView.HasWord(value, sse42);
        }
    }
}