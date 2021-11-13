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
using CpuFeaturesDotNet.Utils;
using static CpuFeaturesDotNet.X86.CpuInfoX86;

namespace CpuFeaturesDotNet.X86.OperatingSystem
{
    internal unsafe class FreeBsdFeaturesX86 : OsBaseFeaturesX86
    {
        public FreeBsdFeaturesX86(FeaturesX86 featuresX86)
            : base(featuresX86)
        {
        }

        public override void SetRegistersXcr0NotAvailable()
        {
            var fileDescriptor = FileSystem.OpenFile("/var/run/dmesg.boot");
            if (fileDescriptor < 0) return;

            StackLineReader.Initialize(out var reader, fileDescriptor);
            var features = stackalloc byte[]
            {
                0x14,
                0x14,
                0x2E,
                0x41,
                0x3D,
                0x4A,
                0x4B,
                0x48,
                0x41,
                0x49,
                0x3D
            };
            var features2 = stackalloc byte[]
            {
                0x14,
                0x14,
                0x2E,
                0x41,
                0x3D,
                0x4A,
                0x4B,
                0x48,
                0x41,
                0x49,
                0x20,
                0x3D
            };
            var sse = StringUtils.GetAsciiBytes("SSE");
            var sse2 = StringUtils.GetAsciiBytes("SSE2");
            var sse3 = StringUtils.GetAsciiBytes("SSE3");
            var ssse3 = StringUtils.GetAsciiBytes("SSSE3");
            var sse41 = StringUtils.GetAsciiBytes("SSE4.1");
            var sse42 = StringUtils.GetAsciiBytes("SSE4.2");

            while (true)
            {
                var result = StackLineReader.NextLine(ref reader);
                var line = result.line;
                var isFeature = StringView.StartsWith(in line, StringView.GetString(features));
                var isFeature2 = StringView.StartsWith(in line, StringView.GetString(features2));

                if (isFeature || isFeature2)
                {
                    for (var i = 0; i < (int) line.Size; i++)
                    {
                        var b = &line.Ptr[i];
                        if (*b == '<' || *b == '>' || *b == ',') *b = (byte) ' ';
                    }

                    if (isFeature)
                    {
                        _featuresX86.IsSupportedSSE = StringView.HasWord(in line, sse);
                        _featuresX86.IsSupportedSSE2 = StringView.HasWord(in line, sse2);
                    }

                    if (isFeature2)
                    {
                        _featuresX86.IsSupportedSSE3 = StringView.HasWord(in line, sse3);
                        _featuresX86.IsSupportedSSE3 = StringView.HasWord(in line, ssse3);
                        _featuresX86.IsSupportedSSE41 = StringView.HasWord(in line, sse41);
                        _featuresX86.IsSupportedSSE42 = StringView.HasWord(in line, sse42);
                    }
                }

                if (result.eof) break;
            }

            FileSystem.CloseFile(fileDescriptor);
        }
    }
}