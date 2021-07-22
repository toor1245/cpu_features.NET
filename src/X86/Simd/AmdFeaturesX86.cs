using CpuFeaturesDotNet.Utils;
using static CpuFeaturesDotNet.X86.CpuInfoX86.FeaturesX86;

namespace CpuFeaturesDotNet.X86.Simd
{
    internal sealed class AmdFeaturesX86 : BaseSimdFeaturesX86
    {
        private readonly Leaf _leafExtFeatures;

        public AmdFeaturesX86(in LeafSimd leafSimd, Leaf leafExtFeatures)
            : base(leafSimd)
        {
            _leafExtFeatures = leafExtFeatures;
        }

        protected override void SetAvxRegisters()
        {
            base.SetAvxRegisters();
            IsSupportedFMA4 = BitUtils.IsBitSet(_leafExtFeatures.ecx, 16);
            IsSupportedSSE4A = BitUtils.IsBitSet(_leafExtFeatures.ecx, 6);
        }
    }
}