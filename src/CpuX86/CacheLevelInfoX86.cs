namespace CpuFeaturesDotNet.X86
{
    public struct CacheLevelInfoX86
    {
        public int level;
        public CacheTypeX86 cache_type;
        public int cache_size;           // Cache size in bytes
        public int ways;                 // Associativity, 0 undefined, 0xFF fully associative
        public int line_size;            // Cache line size in bytes
        public int tlb_entries;          // number of entries for TLB
        public int partitioning;         // number of lines per sector
    }
}