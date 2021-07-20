namespace CpuFeaturesDotNet.Native
{
    internal static class DllPath
    {
#if OS_LINUX || OS_MAC
        public const string CPU_FEATURES_DOTNET_DLL = "Native/x86-64/cpu_features_dotnet.unix-x86-64.so";
#elif OS_WINDOWS
        public const string CPU_FEATURES_DOTNET_DLL = "Native\\x86-64\\cpu_features_dotnet.win-x86-64.dll";
#endif
    }
}