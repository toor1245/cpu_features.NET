using Xunit;
using Xunit.Sdk;

namespace CpuFeaturesDotNet.Samples
{
    public class Runner
    {
        [Fact]
        public void StartRunner()
        {
            if (GetType() == typeof(Runner))
            {
                throw new XunitException();
            }
            
            Run();
        }

        protected virtual void Run() { }
    }
}