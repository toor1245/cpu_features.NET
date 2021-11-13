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

using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace CpuFeaturesDotNet
{
    internal static unsafe class StringUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte* GetAsciiBytes(string str)
        {
            var chars = Encoding.UTF8.GetBytes(str);
            var bytes = Encoding.Convert(Encoding.UTF8, Encoding.ASCII, chars);
            return (byte*)Unsafe.AsPointer(ref bytes);
        }

        public static ulong str_len(byte* str)
        {
            if (str == null)
            {
                return 0;
            }
            byte* charPtr;

            for (charPtr = str; ((uint)charPtr & (IntPtr.Size - 1)) != 0; charPtr++)
            {
                if (*charPtr == (byte)'\0')
                {
                    return (ulong)(charPtr - str);
                }
            }

            var longwordPtr = (uint*)charPtr;
            var himagic = 0x80808080U;
            var lomagic = 0x01010101U;
            if (IntPtr.Size > 4)
            {
                himagic = (himagic << 16 << 16) | himagic;
                lomagic = (lomagic << 16 << 16) | lomagic;
            }

            while (true)
            {
                var longword = *longwordPtr++;
                if (((longword - lomagic) & ~longword & himagic) == 0)
                {
                    continue;
                }

                var cp = (byte*)(longwordPtr - 1);

                if (cp[0] == 0)
                {
                    return (ulong)(cp - str);
                }

                if (cp[1] == 0)
                {
                    return (ulong)(cp - str + 1);
                }

                if (cp[2] == 0)
                {
                    return (ulong)(cp - str + 2);
                }

                if (cp[3] == 0)
                {
                    return (ulong)(cp - str + 3);
                }

                if (IntPtr.Size <= 4)
                {
                    continue;
                }

                if (cp[4] == 0)
                {
                    return (ulong)(cp - str + 4);
                }

                if (cp[5] == 0)
                {
                    return (ulong)(cp - str + 5);
                }

                if (cp[6] == 0)
                {
                    return (ulong)(cp - str + 6);
                }

                if (cp[7] == 0)
                {
                    return (ulong)(cp - str + 7);
                }
            }
        }

        public static bool is_space(byte c)
        {
            return c == ' ' || c == '\t' || c == '\r' || c == '\n' || c == '\f' ||
                   c == '\v';
        }

        public static int hex_value(byte c)
        {
            if (c >= '0' && c <= '9') return c - '0';
            if (c >= 'a' && c <= 'f') return c - 'a' + 10;
            if (c >= 'A' && c <= 'F') return c - 'A' + 10;
            return -1;
        }
    }
}