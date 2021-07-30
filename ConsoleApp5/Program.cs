using System;
using CpuFeaturesDotNet.X86;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CpuInfoX86.BrandString);
            //Console.WriteLine(CpuInfoX86.FeaturesX86.IsSupportedCX8);
            //Console.WriteLine(CpuInfoX86.FeaturesX86.IsSupportedAVX);
        }
    }
}