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

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Native;

namespace CpuFeaturesDotNet
{
    internal static unsafe class NativeString
    {
        [DllImport(Library.SHARED_LIBRARY, CallingConvention = CallingConvention.StdCall, EntryPoint = "_strlen")]
        private static extern int _Strlen(sbyte* buffer);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Strlen(sbyte* buffer)
        {
            Debug.Assert(buffer != null);
            return _Strlen(buffer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Strlen(ref sbyte buffer)
        {
            fixed (sbyte* pBuffer = &buffer)
            {
                Debug.Assert(pBuffer != null);
                return _Strlen(pBuffer);
            }
        }

        public static bool IsSpace(sbyte c)
        {
            return c == ' ' || c == '\t' || c == '\r' || c == '\n' || c == '\f' ||
                   c == '\v';
        }

        public static int GetHexValue(sbyte c)
        {
            if (c >= '0' && c <= '9') return c - '0';
            if (c >= 'a' && c <= 'f') return c - 'a' + 10;
            if (c >= 'A' && c <= 'F') return c - 'A' + 10;
            return -1;
        }
    }
}