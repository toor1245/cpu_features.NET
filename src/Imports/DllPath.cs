namespace CpuFeaturesDotNet.Imports
{
    internal static class DllPath
    {
#if OS_LINUX || OS_MAC
        public const string CPU_FEATURES_DOTNET_DLL = "Imports/cpu_features_dotnet.so";
#elif OS_WINDOWS
        public const string CPU_FEATURES_DOTNET_DLL = "Imports\\cpu_features_dotnet.dll";
#endif
    }
}