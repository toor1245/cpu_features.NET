using System;
using CpuFeaturesDotNet.Aarch64.CpuInfo;
using CpuFeaturesDotNet.Native;
using Xunit.Abstractions;

namespace CpuFeaturesDotNet.Samples
{
    public class CpuFeaturesListArm : Runner
    {
        public CpuFeaturesListArm(ITestOutputHelper output) : base(output)
        {
            if (!Architecture.IsArchArm())
            {
                throw new NotSupportedException("Your target CPU architecture is not ARM");
            }
        }

        protected override void Run()
        {
            OutputHelper.WriteLine($"implementer: {CpuInfoAarch64.Implementer.ToString()}");
            OutputHelper.WriteLine($"part_number: {CpuInfoAarch64.Part.ToString()}");
        }
    }
}