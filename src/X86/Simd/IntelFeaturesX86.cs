using static CpuFeaturesDotNet.X86.CpuInfoX86.FeaturesX86;

namespace CpuFeaturesDotNet.X86.Simd
{
    internal sealed class IntelFeaturesX86 : BaseSimdFeaturesX86
    {
        private readonly int _model;

        public IntelFeaturesX86(in LeafSimdX86 leafSimd, int model)
            : base(leafSimd)
        {
            _model = model;
        }

        protected override void SetAvx512Registers()
        {
            base.SetAvx512Registers();
            IsSupportedAVX512SecondFMA = FeaturesUtilsX86.HasSecondFMA(_model);
        }
    }
}