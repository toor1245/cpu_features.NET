using System.Runtime.CompilerServices;
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
            var flags = stackalloc byte[]
            {
                0x42,
                0x6C,
                0x3D,
                0x43,
                0x49
            };
            StackLineReader.Initialize(out var reader, fileDescriptor);
            var featuresString = stackalloc byte[6]
            {
                0x49,
                0x49,
                0x41,
                0x00,
                0x00,
                0x00
            };

            while (true)
            {
                var result = StackLineReader.NextLine(ref reader);
                var line = result.line;
                StringView key = default, value = default;

                if (!StringView.GetAttributeKeyValue(line, ref key, ref value))
                {
                    continue;
                }

                if (!StringView.IsEquals(key, StringView.GetString(flags)))
                {
                    continue;
                }

                IsSupportedSSE = StringView.HasWord(value, featuresString, 3);
                IsSupportedSSE2 = HasSse2(in value, featuresString);
                IsSupportedSSE3 = HasSse3(in value, featuresString);
                IsSupportedSSSE3 = HasSsse3(in value, featuresString);
                IsSupportedSSE41 = HasSse41(in value, featuresString);
                IsSupportedSSE42 = HasSse42(in value, featuresString);
                break;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe bool HasSse2(in StringView value, byte* featuresString)
        {
            featuresString[3] = 0x20;
            return StringView.HasWord(value, featuresString, 4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe bool HasSse3(in StringView value, byte* featuresString)
        {
            featuresString[3] = 0x21;
            return StringView.HasWord(value, featuresString, 4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe bool HasSsse3(in StringView value, byte* featuresString)
        {
            featuresString[2] = 0x49;
            featuresString[3] = 0x41;
            featuresString[4] = 0x21;
            return StringView.HasWord(value, featuresString, 5);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe bool HasSse41(in StringView value, byte* featuresString)
        {
            featuresString[2] = 0x41;
            featuresString[3] = 0x22;
            featuresString[4] = 0x5F;
            featuresString[5] = 0x1F;
            return StringView.HasWord(value, featuresString, 6);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe bool HasSse42(in StringView value, byte* featuresString)
        {
            featuresString[5] = 0x20;
            return StringView.HasWord(value, featuresString, 6);
        }
    }
}