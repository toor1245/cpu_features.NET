namespace CpuFeaturesDotNet.Libs
{
    internal static class DllPath
    {
#if OS_LINUX || OS_MAC
        public const string CPU_FEATURES_DOTNET_DLL = "Libs/cpu_features_dotnet.so";
#elif OS_WINDOWS
        public const string CPU_FEATURES_DOTNET_DLL = "Libs\\cpu_features_dotnet.dll";
#endif
    }
}