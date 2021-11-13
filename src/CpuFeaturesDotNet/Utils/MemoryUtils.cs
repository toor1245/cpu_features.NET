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

namespace CpuFeaturesDotNet
{
    internal static unsafe class MemoryUtils
    {
        public static void* memchr(void* src_void, int c, uint length)
        {
            if (src_void == null || length == 0)
            {
                return null;
            }
            var src = (byte*)src_void;

            while (length-- > 0)
            {
                if (*src == c)
                {
                    return src;
                }
                src++;
            }
            return null;
        }

        public static int memcmp(void* ptr1, void* ptr2, uint byteCount)
        {
            if (ptr1 == null || ptr2 == null || byteCount == 0)
            {
                return 0;
            }
            var s1 = (byte*)ptr1;
            var s2 = (byte*)ptr2;

            while (byteCount-- > 0)
            {
                if (*s1++ != *s2++)
                {
                    return s1[-1] < s2[-1] ? -1 : 1;
                }
            }
            return 0;
        }
    }
}