namespace CpuFeaturesDotNet.X86
{
    public static class CacheInfoX86
    {
        public sealed class CacheLevelInfoX86
        {
            public readonly int Level; // Cache level
            public readonly CacheTypeX86 Type; // Cache type
            public readonly int CacheSize; // Cache size in bytes
            public readonly int Ways; // Associativity, 0 undefined, 0xFF fully associative
            public readonly int LineSize; // Cache line size in bytes
            public readonly int TlbEntries; // Number of entries for TLB
            public readonly int Partitioning; // Number of lines per sector

            internal CacheLevelInfoX86() { }
            
            internal CacheLevelInfoX86(int level, CacheTypeX86 type, int size, int ways, int lineSize, int tlbEntries,
                int partitioning)
            {
                Level = level;
                Ways = ways;
                CacheSize = size;
                LineSize = lineSize;
                TlbEntries = tlbEntries;
                Partitioning = partitioning;
                Type = type;
            }
        }
    }
}