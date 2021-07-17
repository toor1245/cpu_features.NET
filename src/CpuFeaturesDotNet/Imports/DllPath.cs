namespace CpuFeaturesDotNet.Imports
{
    internal static class DllPath
    {
        public static string Path = System.IO.Path.Combine("Imports", "cpu_features_dotnet");
#if OS_LINUX
        public const string CPU_FEATURES_DOTNET_DLL = "Imports/cpu_features_dotnet";
#elif OS_WINDOWS
        public const string CPU_FEATURES_DOTNET_DLL = "Imports\\cpu_features_dotnet";
#endif
    }
}