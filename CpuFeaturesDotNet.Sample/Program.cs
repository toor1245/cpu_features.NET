using System;
using static CpuFeaturesDotNet.X86.CpuInfoX86;
using CacheInfoX86 = CpuFeaturesDotNet.X86.CpuInfoX86.CacheInfoX86;

namespace CpuFeaturesDotNet.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("brand_string   : {0}", BrandString);
            Console.WriteLine("family         : {0}", Family);
            Console.WriteLine("model          : {0}", Model);
            Console.WriteLine("stepping       : {0}", Stepping);
            Console.WriteLine("uarch          : {0}", Microarchitecture);
            Console.WriteLine();
            
            for (var i = 0; i < CacheInfoX86.Size; i++)
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("level           : {0}", CacheInfoX86.Levels[i].Level);
                Console.WriteLine("cache_type      : {0}", CacheInfoX86.Levels[i].Type);
                Console.WriteLine("cache_size      : {0}", CacheInfoX86.Levels[i].CacheSize);
                Console.WriteLine("ways            : {0}", CacheInfoX86.Levels[i].Ways);
                Console.WriteLine("line_size       : {0}", CacheInfoX86.Levels[i].LineSize);
                Console.WriteLine("tlb_entries     : {0}", CacheInfoX86.Levels[i].TlbEntries);
                Console.WriteLine("partitioning    : {0}", CacheInfoX86.Levels[i].Partitioning);
                Console.WriteLine("==========================================================\n");
            }
            
            Console.WriteLine("Is supported BMI1      : {0}", FeaturesX86.IsSupportedBMI1);
            Console.WriteLine("Is supported AVX       : {0}", FeaturesX86.IsSupportedAVX);
            Console.WriteLine("Is supported AVX2      : {0}", FeaturesX86.IsSupportedAVX2);
            Console.WriteLine("Is supported AVX512F   : {0}", FeaturesX86.IsSupportedAVX512F);
        }
    }
}