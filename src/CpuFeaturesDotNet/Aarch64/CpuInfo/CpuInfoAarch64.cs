using System;
using CpuFeaturesDotNet.Native;

namespace CpuFeaturesDotNet.Aarch64.CpuInfo
{
    public static unsafe class CpuInfoAarch64
    {
        public static CpuTypeAarch64 Implementer { get; }
        public static int Variant { get; }
        public static int Part { get; }
        public static int Revision { get; }

        static CpuInfoAarch64()
        {
            if (Architecture.IsArchAarch64())
            {
                throw new NotSupportedException();
            }
        }

        public static void GetCpuInfoAarch64()
        {
            
        }

        private static void GetImplementer()
        {
            
        }
    }
}