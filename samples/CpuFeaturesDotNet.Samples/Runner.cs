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
            Run();
        }

        protected virtual void Run() { }
    }
}