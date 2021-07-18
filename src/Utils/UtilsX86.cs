using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Imports;
using CpuFeaturesDotNet.X86;

[assembly: InternalsVisibleTo("CpuFeaturesDotNet.UnitTesting")]
namespace CpuFeaturesDotNet.Utils
{
    internal static class UtilsX86
    {
        [DllImport(DllPath.CPU_FEATURES_DOTNET_DLL, CallingConvention = CallingConvention.Cdecl)]
        internal static extern CpuMicroarchitectureX86 __uarch(Leaf leaf, int family, int model, int stepping);

        [DllImport(DllPath.CPU_FEATURES_DOTNET_DLL, CallingConvention = CallingConvention.Cdecl)]
        internal static extern Leaf cpuid(uint leafId, int ecx = 0);
    }
}