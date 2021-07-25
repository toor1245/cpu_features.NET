using System.Security;

namespace CpuFeaturesDotNet.Utils
{
    internal static unsafe class MemoryUtils
    {
        public static void* memchr(void* src_void, int c, uint length)
        {
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

        public static unsafe int memcmp(void* ptr1, void* ptr2, uint byteCount)
        {
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