namespace CpuFeaturesDotNet.Native
{
    internal static class DllPath
    {
#if OS_LINUX || OS_MAC
        public const string X86_LIBRARY = "Native/x86-64/cpu_features_dotnet.linux-x86-64.so";
#elif OS_WINDOWS
        public const string X86_LIBRARY = "Native\\x86-64\\cpu_features_dotnet.win-x86-64.dll";
#endif
    }
}