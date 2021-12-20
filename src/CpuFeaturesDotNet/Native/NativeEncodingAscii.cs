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

namespace CpuFeaturesDotNet
{
    internal static class EncodingAsciiUtils
    {
        public static unsafe string GetString(sbyte* brandString, uint byteCount)
        {
            var brandChars = new char[byteCount];
            for (var i = 0; i < byteCount; i++)
            {
                brandChars[i] = (char)brandString[i];
            }

            return new string(brandChars);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe sbyte* GetAsciiBytes(string str)
        {
            var buffer = new sbyte[str.Length];
            fixed (sbyte* bufferPtr = buffer)
            fixed (char* strPtr = str)
            {
                Unsafe.CopyBlockUnaligned(bufferPtr, strPtr, (uint)str.Length);
                return bufferPtr;
            }
        }
    }
}