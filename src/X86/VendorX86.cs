using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static CpuFeaturesDotNet.Native.DllPath;

namespace CpuFeaturesDotNet.X86
{
    internal static class VendorX86
    {
        private const string GENUINE_INTEL = "GenuineIntel";
        private const string AUTHENTIC_AMD = "AuthenticAMD";
        private const string HYGON_GENUINE = "HygonGenuine";

        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "__is_vendor")]
        private static extern bool IsVendor(Leaf leaf, string name);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsAMDVendor(Leaf leaf)
        {
            return IsVendor(leaf, AUTHENTIC_AMD) ||
                   IsVendor(leaf, HYGON_GENUINE);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsIntelVendor(Leaf leaf)
        {
            return IsVendor(leaf, GENUINE_INTEL);
        }
    }
}