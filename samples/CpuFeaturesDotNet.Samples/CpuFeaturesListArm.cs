using System;
using CpuFeaturesDotNet.Aarch64.CpuInfo;
using CpuFeaturesDotNet.Native;
using CpuFeaturesDotNet.Native.OperatingSystem;
using Xunit.Abstractions;

namespace CpuFeaturesDotNet.Samples
{
    public class CpuFeaturesListArm : Runner
    {
        public CpuFeaturesListArm(ITestOutputHelper output) : base(output)
        {
            if (!OSNative.IsLinuxOrAndroid())
            {
                throw new NotSupportedException("Not supported OS At the moment shared library works only on Linux");
            }
        }

        protected override void Run()
        {
            OutputHelper.WriteLine(Architecture.IsArchArmAny() ? "It is ARM architecture" : "It is not ARM architecture");
            OutputHelper.WriteLine(CpuInfoAarch64.Implementer.ToString());
        }
    }
}