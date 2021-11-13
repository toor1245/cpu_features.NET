using System.Collections.Generic;

namespace CpuFeaturesDotNet.X86
{
    public interface ICacheInfoX86
    {
        List<CacheLevelInfoX86> CacheLevelInfo { get; }
    }
}