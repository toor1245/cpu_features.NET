namespace CpuFeaturesDotNet.Native
{
    internal static class DllPath
    {
#if OS_LINUX
        public const string X86_LIBRARY = "Native/x86-64/cpu_features_dotnet.linux-x86-64.so";
        public const string ARM_LIBRARY = "Native/Arm/cpu_features_dotnet.linux-arm.so";
#elif OS_WINDOWS
        public const string X86_LIBRARY = "Native\\x86-64\\cpu_features_dotnet.win-x86-64.dll";
        public const string ARM_LIBRARY = "not_founds";
#elif OS_MAC
        public const string X86_LIBRARY = "not_founds";
        public const string ARM_LIBRARY = "not_founds";
#endif
    }
}