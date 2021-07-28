namespace CpuFeaturesDotNet.X86.Simd
{
    internal readonly ref struct LeafSimdX86
    {
        internal readonly LeafX86 leaf, leaf1, leaf7, leaf7_1;

        public LeafSimdX86(LeafX86 leaf, LeafX86 leaf1, LeafX86 leaf7, LeafX86 leaf7_1)
        {
            this.leaf = leaf;
            this.leaf1 = leaf1;
            this.leaf7 = leaf7;
            this.leaf7_1 = leaf7_1;
        }
    }
}