namespace CpuFeaturesDotNet.IO
{
    internal ref struct LineResult
    {
        public StringView line;
        public bool eof;
        public bool full_line;
    }
}