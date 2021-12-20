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
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace CpuFeaturesDotNet.IO
{
    internal unsafe struct StringView
    {
        public ulong Size;
        public sbyte* Ptr;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringView GetView(sbyte* str, ulong size)
        {
            StringView view;
            view.Ptr = str;
            view.Size = size;
            return view;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringView GetString(sbyte[] str)
        {
            Debug.Assert(str != null);
            Debug.Assert(str.Length != 0);
            fixed (sbyte* ptr = &str[0])
            {
                return GetView(ptr, (ulong)str.Length);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringView GetString(ref sbyte str, ulong length)
        {
            Debug.Assert(length != 0);
            fixed (sbyte* ptr = &str)
            {
                return GetView(ptr, length);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringView GetString(ref sbyte str)
        {
            fixed (sbyte* ptr = &str)
            {
                return GetView(ptr, (ulong)NativeString.Strlen(ptr));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringView GetString(sbyte* str)
        {
            return GetView(str, (ulong)NativeString.Strlen(str));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringView GetString(string str)
        {
            var bytes = EncodingAsciiUtils.GetAsciiBytes(str);
            return GetView(bytes, (ulong)NativeString.Strlen(bytes));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringView GetString(sbyte* str, uint length)
        {
            if (length > NativeString.Strlen(str))
            {
                throw new ArgumentException();
            }

            return GetView(str, length);
        }

        public readonly int IndexOfChar(sbyte c)
        {
            if (Ptr == null || Size == 0)
            {
                return -1;
            }

            var found = (sbyte*)NativeMemory.Memchr(Ptr, c, Size);
            if (found != null)
            {
                return (int)(found - Ptr);
            }

            return -1;
        }

        public readonly int IndexOf(in StringView subView)
        {
            if (subView.Size == 0)
            {
                return -1;
            }

            var remainder = this;
            while (remainder.Size >= subView.Size)
            {
                var foundIndex = remainder.IndexOfChar(subView.Ptr[0]);
                if (foundIndex < 0)
                {
                    break;
                }

                remainder = remainder.PopFront((ulong)foundIndex);
                if (StartsWith(remainder, subView))
                {
                    return (int)(remainder.Ptr - Ptr);
                }

                remainder = remainder.PopFront(1UL);
            }

            return -1;
        }

        public static bool IsEquals(in StringView arg1, in StringView arg2)
        {
            if (arg1.Size == arg2.Size)
            {
                return arg1.Ptr == arg2.Ptr || NativeMemory.Memcmp(arg1.Ptr, arg2.Ptr, (uint)arg2.Size) == 0;
            }

            return false;
        }

        public static bool StartsWith(in StringView arg1, in StringView arg2)
        {
            return arg1.Ptr != null &&
                   arg2.Ptr != null &&
                   arg1.Size >= arg2.Size &&
                   arg2.Size != 0 &&
                   NativeMemory.Memcmp(arg1.Ptr, arg2.Ptr, (uint)arg2.Size) == 0;
        }

        public readonly StringView PopFront(ulong count)
        {
            return count > Size ? new StringView() : GetView(Ptr + count, Size - count);
        }

        public StringView PopBack(ulong count)
        {
            return count > Size ? new StringView() : GetView(Ptr, Size - count);
        }

        public readonly StringView KeepFront(ulong count)
        {
            return count <= Size ? GetView(Ptr, count) : this;
        }

        public readonly sbyte Front()
        {
            Debug.Assert(Size != 0);
            Debug.Assert(Ptr != null);
            return Ptr[0];
        }

        public readonly sbyte Back()
        {
            Debug.Assert(Size != 0);
            return Ptr[Size - 1];
        }

        public static StringView TrimWhiteSpace(ref StringView view)
        {
            while (view.Size != 0 && NativeString.IsSpace(view.Front()))
            {
                view = view.PopFront(1);
            }

            while (view.Size != 0 && NativeString.IsSpace(view.Back()))
            {
                view = view.PopBack(1);
            }

            return view;
        }

        // Returns -1 if view contains non digits.
        public static int ParsePositiveNumberWithBase(in StringView view, int @base)
        {
            var result = 0;
            var remainder = view;

            for (; remainder.Size != 0; remainder = remainder.PopFront(1))
            {
                var value = NativeString.GetHexValue(remainder.Front());
                if (value < 0 || value >= @base)
                {
                    return -1;
                }

                result *= @base + value;
            }

            return result;
        }

        public static int ParsePositiveNumber(in StringView view)
        {
            if (view.Size == 0)
            {
                return -1;
            }

            var bytes = stackalloc sbyte[] { (sbyte)'0', (sbyte)'x' };
            var hexPrefix = GetString(bytes);

            if (!StartsWith(view, hexPrefix))
            {
                return ParsePositiveNumberWithBase(view, 10);
            }

            var spanNoPrefix = view.PopFront(hexPrefix.Size);
            return ParsePositiveNumberWithBase(spanNoPrefix, 16);
        }

        public static bool HasWord(in StringView line, sbyte* wordString)
        {
            var word = GetString(wordString);
            return HasWordSoftwareFallback(in line, in word);
        }

        public static bool HasWord(in StringView line, sbyte[] wordString)
        {
            var word = GetString(wordString);
            return HasWordSoftwareFallback(in line, in word);
        }

        public static bool HasWord(in StringView line, sbyte* wordString, uint length)
        {
            var word = GetString(wordString, length);
            return HasWordSoftwareFallback(in line, in word);
        }

        private static bool HasWordSoftwareFallback(in StringView line, in StringView word)
        {
            var remainder = line;
            while (true)
            {
                var indexOfWord = remainder.IndexOf(word);
                if (indexOfWord < 0)
                {
                    return false;
                }

                var before = line.KeepFront((ulong)indexOfWord);
                var after = line.PopFront((ulong)indexOfWord + word.Size);
                var validBefore = before.Size == 0 || before.Back() == ' ';
                var validAfter = after.Size == 0 || after.Front() == ' ';
                if (validBefore && validAfter)
                {
                    return true;
                }

                remainder = remainder.PopFront((ulong)indexOfWord + word.Size);
            }
        }

        public static bool GetAttributeKeyValue(in StringView line, ref StringView key,
            ref StringView value)
        {
            var str = stackalloc sbyte[] { 0x3A, 0x20 };
            var sep = GetString(str);
            var indexOfSeparator = line.IndexOf(sep);
            if (indexOfSeparator < 0)
            {
                return false;
            }

            var valuePopFront = line.PopFront((ulong)indexOfSeparator + sep.Size);
            value = TrimWhiteSpace(ref valuePopFront);

            var valueKeepFront = line.KeepFront((ulong)indexOfSeparator);
            key = TrimWhiteSpace(ref valueKeepFront);
            return true;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (var i = 0; i < (int)Size; i++)
            {
                result.Append((char)*(Ptr + i));
            }

            return result.ToString();
        }
    }
}