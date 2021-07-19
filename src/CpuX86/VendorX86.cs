using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Imports;

namespace CpuFeaturesDotNet.X86
{
    internal static class VendorX86
    {
        internal const string GENUINE_INTEL = "GenuineIntel";
        internal const string AUTHENTIC_AMD = "AuthenticAMD";
        internal const string HYGON_GENUINE = "HygonGenuine";

        [DllImport(DllPath.CPU_FEATURES_DOTNET_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "__is_vendor")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern bool IsVendor(Leaf leaf, string name);

        internal static bool IsAMDMicroarchitecture(Leaf leaf)
        {
            return IsVendor(leaf, AUTHENTIC_AMD) || 
                   IsVendor(leaf, HYGON_GENUINE);
        }
    }
}