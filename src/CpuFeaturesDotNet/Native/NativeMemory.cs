// Copyright (c) 2021 Nikolay Hohsadze 
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Native;

namespace CpuFeaturesDotNet
{
    internal static unsafe class NativeMemory
    {
        [DllImport(Library.SHARED_LIBRARY, CallingConvention = CallingConvention.StdCall, EntryPoint = "_memchr")]
        private static extern void* _Memchr(void* buffer, int value, ulong maxCount);

        [DllImport(Library.SHARED_LIBRARY, CallingConvention = CallingConvention.StdCall, EntryPoint = "_memcmp")]
        private static extern int _Memcmp(void* buffer1, void* buffer2, ulong size);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void* Memchr(void* buffer, int value, ulong maxCount)
        {
            return _Memchr(buffer, value, maxCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void* Memchr(ref byte buffer, int value, ulong maxCount)
        {
            fixed (byte* pBuffer = &buffer)
            {
                return _Memchr(pBuffer, value, maxCount);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Memcmp(void* buffer1, void* buffer2, ulong size)
        {
            return _Memcmp(buffer1, buffer2, size);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Memcmp(ref byte buffer1, ref byte buffer2, ulong size)
        {
            fixed (byte* pBuffer1 = &buffer1)
            fixed (byte* pBuffer2 = &buffer2)
            {
                return _Memcmp(pBuffer1, pBuffer2, size);
            }
        }
    }
}