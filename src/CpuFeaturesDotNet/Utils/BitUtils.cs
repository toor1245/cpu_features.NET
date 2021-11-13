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
    internal static unsafe class BitUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBitSet(uint register, int bit)
        {
            return ((register >> bit) & 0x1) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ExtractBitRange(uint register, uint msb, uint lsb)
        {
            var bits = msb - lsb + 1UL;
            var mask = (1UL << (int)bits) - 1UL;
            return (uint)((register >> (int)lsb) & mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetByteArrayFromRegister(uint* byteArray, uint register)
        {
            for (var i = 0; i < 4; ++i)
            {
                byteArray[i] = ExtractBitRange(register, (uint)((i + 1) * 8), (uint)(i * 8));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ContainsValidInfo(uint register)
        {
            return (register & (1U << 31)) == 0;
        }
    }
}