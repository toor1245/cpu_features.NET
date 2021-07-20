using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Native;

namespace CpuFeaturesDotNet.Utils
{
    internal static unsafe class MemoryUtils
    {
        [DllImport(DllPath.CPU_FEATURES_DOTNET_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int __memcmp(IntPtr buffer1, IntPtr buffer2, uint size);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Compare(void* buffer1, void* buffer2, uint size)
        {
            return __memcmp((IntPtr)buffer1, (IntPtr)buffer2, size);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Compare(IntPtr buffer1, IntPtr buffer2, uint size)
        {
            return __memcmp(buffer1, buffer2, size);
        }
    }
}