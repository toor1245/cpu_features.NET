namespace CpuFeaturesDotNet.X86.Simd
{
    internal readonly ref struct LeafSimd
    {
        internal readonly Leaf leaf, leaf1, leaf7, leaf7_1;

        public LeafSimd(Leaf leaf, Leaf leaf1, Leaf leaf7, Leaf leaf7_1)
        {
            this.leaf = leaf;
            this.leaf1 = leaf1;
            this.leaf7 = leaf7;
            this.leaf7_1 = leaf7_1;
        }
    }
}