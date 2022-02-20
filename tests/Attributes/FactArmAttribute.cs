using System.Runtime.InteropServices;
using Xunit;

namespace CpuFeaturesDotNet.Testing.Attributes
{
    public sealed class FactArmAttribute : FactAttribute
    {
        public FactArmAttribute()
        {
            if (RuntimeInformation.OSArchitecture != Architecture.Arm)
            {
                Skip = "Ignored on unsupported Arm architecture";
            }
        }
    }
}