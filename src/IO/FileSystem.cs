using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Native;

namespace CpuFeaturesDotNet.IO
{
    internal static unsafe class FileSystem
    {
        [DllImport(DllPath.X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "open_file")]
        internal static extern int OpenFile(string fileName);

        [DllImport(DllPath.X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "read_file")]
        internal static extern int ReadFile(int fileDescriptor, byte* buffer, ulong bufferSize);

        [DllImport(DllPath.X86_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "close_file")]
        internal static extern void CloseFile(int fileDescriptor);
    }
}