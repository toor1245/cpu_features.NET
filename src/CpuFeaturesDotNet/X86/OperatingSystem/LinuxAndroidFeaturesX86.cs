using System.Runtime.CompilerServices;
using CpuFeaturesDotNet.IO;
using CpuFeaturesDotNet.Utils;
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
            while (true)
            {
                var result = StackLineReader.NextLine(ref reader);
                var line = result.line;
                StringView key = default, value = default;

                if (!StringView.GetAttributeKeyValue(line, ref key, ref value))
                {
                    continue;
                }
                
                if (!StringView.IsEquals(key, StringView.GetString(StringUtils.GetAsciiBytes("flags"))))
                {
                    continue;
                }

                IsSupportedSSE = StringView.HasWord(value, StringUtils.GetAsciiBytes("sse"));
                IsSupportedSSE2 = StringView.HasWord(value, StringUtils.GetAsciiBytes("sse2"));
                IsSupportedSSE3 = StringView.HasWord(value, StringUtils.GetAsciiBytes("sse3"));
                IsSupportedSSSE3 = StringView.HasWord(value, StringUtils.GetAsciiBytes("ssse3"));
                IsSupportedSSE41 = StringView.HasWord(value, StringUtils.GetAsciiBytes("sse4_1"));
                IsSupportedSSE42 = StringView.HasWord(value, StringUtils.GetAsciiBytes("sse4_2"));
                break;
            }
        }
    }
}