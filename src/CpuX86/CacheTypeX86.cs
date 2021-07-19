namespace CpuFeaturesDotNet.X86
{
    public enum CacheTypeX86
    {
        NULL = 0,
        DATA = 1,
        INSTRUCTION = 2,
        UNIFIED = 3,
        TLB = 4,
        DTLB = 5,
        STLB = 6,
        PREFETCH = 7
    }
}