using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CpuFeaturesDotNet.Utils;

namespace CpuFeaturesDotNet.IO
{
    internal unsafe struct StringView
    {
        public ulong Size;
        public byte* Ptr;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringView GetView(byte* str, ulong size)
        {
            StringView view;
            view.Ptr = str;
            view.Size = size;
            return view;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringView GetString(byte* str)
        {
            return GetView(str, StringUtils.str_len(str));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringView GetString(byte* str, uint length)
        {
            if (length > StringUtils.str_len(str))
            {
                throw new ArgumentException();
            }
            return GetView(str, length);
        }

        public readonly int IndexOfChar(byte c)
        {
            if (Ptr == null || Size == 0)
            {
                return -1;
            }

            var found = (byte*) MemoryUtils.memchr(Ptr, c, (uint)Size);
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
                return arg1.Ptr == arg2.Ptr || MemoryUtils.memcmp(arg1.Ptr, arg2.Ptr, (uint)arg2.Size) == 0;
            }

            return false;
        }

        public static bool StartsWith(in StringView arg1, in StringView arg2)
        {
            return arg1.Ptr != null &&
                   arg2.Ptr != null &&
                   arg1.Size >= arg2.Size &&
                   arg2.Size != 0 &&
                   MemoryUtils.memcmp(arg1.Ptr, arg2.Ptr, (uint)arg2.Size) == 0;
        }

        public readonly StringView PopFront(ulong count)
        {
            return count > Size ? new StringView() : GetView(Ptr, Size - count);
        }

        public StringView PopBack(ulong count)
        {
            return count > Size ? new StringView() : GetView(Ptr, Size - count);
        }

        public readonly StringView KeepFront(ulong count)
        {
            return count <= Size ? GetView(Ptr, count) : this;
        }

        public readonly byte Front()
        {
            Debug.Assert(Size != 0);
            Debug.Assert(Ptr != null);
            return Ptr[0];
        }

        public readonly byte Back()
        {
            Debug.Assert(Size != 0);
            return Ptr[Size - 1];
        }

        public static StringView TrimWhiteSpace(ref StringView view)
        {
            while (view.Size != 0 && StringUtils.is_space(view.Front()))
            {
                view = view.PopFront(1);
            }

            while (view.Size != 0 && StringUtils.is_space(view.Back()))
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
                var value = StringUtils.hex_value(remainder.Front());
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

            var bytes = stackalloc byte[] { (byte)'0', (byte)'x' };
            var hexPrefix = GetString(bytes);

            if (!StartsWith(view, hexPrefix))
            {
                return ParsePositiveNumberWithBase(view, 10);
            }

            var spanNoPrefix = view.PopFront(hexPrefix.Size);
            return ParsePositiveNumberWithBase(spanNoPrefix, 16);
        }

        public static bool HasWord(in StringView line, byte* wordString)
        {
            var word = GetString(wordString);
            return HasWordSoftwareFallback(in line, in word);
        }

        public static bool HasWord(in StringView line, byte* wordString, uint length)
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
            var str = stackalloc byte[] { (byte)':', (byte)' ' };
            var sep = GetString(str);
            var indexOfSeparator = line.IndexOf(sep);
            if (indexOfSeparator < 0)
            {
                return false;
            }

            var valuePopFront = line.PopFront((ulong)indexOfSeparator + sep.Size);
            value = TrimWhiteSpace(ref valuePopFront);

            var valueKeepFront = line.KeepFront((ulong)indexOfSeparator + sep.Size);
            key = TrimWhiteSpace(ref valueKeepFront);
            return true;
        }
    }
}