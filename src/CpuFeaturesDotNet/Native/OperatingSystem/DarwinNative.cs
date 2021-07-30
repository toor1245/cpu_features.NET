using System.Runtime.InteropServices;
using static CpuFeaturesDotNet.Native.DllPath;

namespace CpuFeaturesDotNet.Native.OperatingSystem
{
    internal static class DarwinNative
    {
        [DllImport(X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "darwin_sysctlbyname")]
        internal static extern bool GetDarwinSysCtlByName(string name);
    }
}