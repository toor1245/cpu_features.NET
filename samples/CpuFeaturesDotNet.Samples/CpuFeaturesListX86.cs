using Xunit.Abstractions;
using static CpuFeaturesDotNet.X86.CpuInfoX86;

namespace CpuFeaturesDotNet.Samples
{
    public class CpuFeaturesListX86 : Runner
    {
        public CpuFeaturesListX86(ITestOutputHelper output)
            : base(output) { }

        protected override void Run()
        {
            OutputHelper.WriteLine("brand_string    : {0}", BrandString);
            OutputHelper.WriteLine("family          : {0}", Family);
            OutputHelper.WriteLine("model           : {0}", Model);
            OutputHelper.WriteLine("stepping        : {0}", Stepping);
            OutputHelper.WriteLine("uarch           : {0}", Microarchitecture);
            OutputHelper.WriteLine("\n");

            OutputHelper.WriteLine("Cache info X86");
            for (var i = 0; i < CacheInfoX86.Size; i++)
            {
                OutputHelper.WriteLine("==========================================================");
                OutputHelper.WriteLine("level           : {0}", CacheInfoX86.Levels[i].Level);
                OutputHelper.WriteLine("cache_type      : {0}", CacheInfoX86.Levels[i].Type);
                OutputHelper.WriteLine("cache_size      : {0}", CacheInfoX86.Levels[i].CacheSize);
                OutputHelper.WriteLine("ways            : {0}", CacheInfoX86.Levels[i].Ways);
                OutputHelper.WriteLine("line_size       : {0}", CacheInfoX86.Levels[i].LineSize);
                OutputHelper.WriteLine("tlb_entries     : {0}", CacheInfoX86.Levels[i].TlbEntries);
                OutputHelper.WriteLine("partitioning    : {0}", CacheInfoX86.Levels[i].Partitioning);
                OutputHelper.WriteLine("==========================================================\n");
            }

            OutputHelper.WriteLine("Is supported SSE       : {0}", FeaturesX86.IsSupportedSSE);
            OutputHelper.WriteLine("Is supported SSE2      : {0}", FeaturesX86.IsSupportedSSE2);
            OutputHelper.WriteLine("Is supported SSE3      : {0}", FeaturesX86.IsSupportedSSE3);
            OutputHelper.WriteLine("Is supported SSSE3     : {0}", FeaturesX86.IsSupportedSSSE3);
            OutputHelper.WriteLine("Is supported SSE41     : {0}", FeaturesX86.IsSupportedSSE41);
            OutputHelper.WriteLine("Is supported SSE42     : {0}", FeaturesX86.IsSupportedSSE42);
            OutputHelper.WriteLine("Is supported BMI1      : {0}", FeaturesX86.IsSupportedBMI1);
            OutputHelper.WriteLine("Is supported AVX       : {0}", FeaturesX86.IsSupportedAVX);
            OutputHelper.WriteLine("Is supported AVX2      : {0}", FeaturesX86.IsSupportedAVX2);
            OutputHelper.WriteLine("Is supported AVX512F   : {0}", FeaturesX86.IsSupportedAVX512F);
        }
    }
}