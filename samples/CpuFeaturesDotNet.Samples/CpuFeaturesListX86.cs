using Xunit.Abstractions;
using static CpuFeaturesDotNet.X86.CpuInfoX86;

namespace CpuFeaturesDotNet.Samples
{
    public class CpuFeaturesListX86 : Runner
    {
        private readonly ITestOutputHelper output;

        public CpuFeaturesListX86(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        protected override void Run()
        {
            output.WriteLine("brand_string   : {0}", BrandString);
            output.WriteLine("family         : {0}", Family);
            output.WriteLine("model          : {0}", Model);
            output.WriteLine("stepping       : {0}", Stepping);
            output.WriteLine("uarch          : {0}", Microarchitecture);
            output.WriteLine("\n");

            for (var i = 0; i < CacheInfoX86.Size; i++)
            {
                output.WriteLine("==========================================================");
                output.WriteLine("level           : {0}", CacheInfoX86.Levels[i].Level);
                output.WriteLine("cache_type      : {0}", CacheInfoX86.Levels[i].Type);
                output.WriteLine("cache_size      : {0}", CacheInfoX86.Levels[i].CacheSize);
                output.WriteLine("ways            : {0}", CacheInfoX86.Levels[i].Ways);
                output.WriteLine("line_size       : {0}", CacheInfoX86.Levels[i].LineSize);
                output.WriteLine("tlb_entries     : {0}", CacheInfoX86.Levels[i].TlbEntries);
                output.WriteLine("partitioning    : {0}", CacheInfoX86.Levels[i].Partitioning);
                output.WriteLine("==========================================================\n");
            }

            output.WriteLine("Is supported BMI1      : {0}", FeaturesX86.IsSupportedBMI1);
            output.WriteLine("Is supported AVX       : {0}", FeaturesX86.IsSupportedAVX);
            output.WriteLine("Is supported AVX2      : {0}", FeaturesX86.IsSupportedAVX2);
            output.WriteLine("Is supported AVX512F   : {0}", FeaturesX86.IsSupportedAVX512F);
        }
    }
}