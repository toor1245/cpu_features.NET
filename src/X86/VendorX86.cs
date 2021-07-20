using System.Runtime.CompilerServices;
using CpuFeaturesDotNet.Utils;

namespace CpuFeaturesDotNet.X86
{
    internal static class VendorX86
    {
        internal const string GENUINE_INTEL = "GenuineIntel";
        internal const string AUTHENTIC_AMD = "AuthenticAMD";
        internal const string HYGON_GENUINE = "HygonGenuine";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsAMDMicroarchitecture(Leaf leaf)
        {
            return UtilsX86.IsVendor(leaf, AUTHENTIC_AMD) || 
                   UtilsX86.IsVendor(leaf, HYGON_GENUINE);
        }
    }
}