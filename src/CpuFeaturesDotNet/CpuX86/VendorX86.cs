using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Imports;

namespace CpuFeaturesDotNet.X86
{
    internal static class VendorX86
    {
        internal const string GENUINE_INTEL = "GenuineIntel";
        internal const string AUTHENTIC_AMD = "AuthenticAMD";

        [DllImport(DllPath.CPU_FEATURES_DOTNET_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static extern bool __is_vendor(Leaf leaf, string name);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsVendor(Leaf leaf, string vendor)
        {
            return __is_vendor(leaf, vendor);
        }
    }
}