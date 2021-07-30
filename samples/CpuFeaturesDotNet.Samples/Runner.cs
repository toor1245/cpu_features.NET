using System;
using CpuFeaturesDotNet.Native;
using Xunit;
using Xunit.Abstractions;

namespace CpuFeaturesDotNet.Samples
{
    public class Runner
    {
        protected readonly ITestOutputHelper OutputHelper;
        
        public Runner(ITestOutputHelper output)
        {
            OutputHelper = output;
        }
        
        [Fact]
        public void StartRunner()
        {
            if (!Architecture.IsArchX86())
            {
                throw new NotSupportedException("Your target CPU architecture is not X86");
            }
            Run();
        }

        protected virtual void Run() { }
    }
}