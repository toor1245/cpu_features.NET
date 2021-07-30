using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CpuFeaturesDotNet.IO
{
    internal unsafe ref struct StackLineReader
    {
        private const short STACK_LINE_READER_BUFFER_SIZE = 1024;

        private fixed byte Buffer[STACK_LINE_READER_BUFFER_SIZE];

        public int FileDescriptor;
        public StringView StringView;
        public bool SkipMode;

        internal static void Initialize(out StackLineReader reader, int fileDescriptor)
        {
            reader.FileDescriptor = fileDescriptor;
            reader.StringView.Size = 0;
            reader.SkipMode = false;
            fixed (byte* ptr = reader.Buffer)
            {
                reader.StringView.Ptr = ptr;
            }
        }

        // Replaces the content of buffer with bytes from the file.
        internal static int LoadFullBuffer(ref StackLineReader reader)
        {
            fixed (byte* ptr = reader.Buffer)
            {
                var read = FileSystem.ReadFile(reader.FileDescriptor, ptr, (ulong)STACK_LINE_READER_BUFFER_SIZE);
                Debug.Assert(read >= 0);
                reader.StringView.Ptr = ptr;
                reader.StringView.Size = (ulong)read;
                return read;
            }
        }

        // Appends with bytes from the file to buffer, filling the remaining space.
        internal static int LoadMore(ref StackLineReader reader)
        {
            fixed (byte* bufferPtr = reader.Buffer)
            {
                var ptr = bufferPtr + reader.StringView.Size;
                var sizeToRead = (ulong)STACK_LINE_READER_BUFFER_SIZE - reader.StringView.Size;
                var read = FileSystem.ReadFile(reader.FileDescriptor, ptr, sizeToRead);
                Debug.Assert(read >= 0);
                Debug.Assert(read <= (int)sizeToRead);
                reader.StringView.Size += (ulong)read;
                return read;
            }
        }

        internal static int IndexOfEol(in StackLineReader reader)
        {
            return reader.StringView.IndexOfChar((byte)'\n');
        }


        // Relocate buffer's pending bytes at the beginning of the array and fills the
        // remaining space with bytes from the file.
        internal static int BringToFrontAndLoadMore(ref StackLineReader reader)
        {
            fixed (byte* bufferPtr = reader.Buffer)
            {
                if (reader.StringView.Size != 0 && reader.StringView.Ptr != bufferPtr)
                {
                    Unsafe.CopyBlock(bufferPtr, reader.StringView.Ptr, (uint)reader.StringView.Size);
                }

                reader.StringView.Ptr = bufferPtr;
                return LoadMore(ref reader);
            }
        }

        // Loads chunks of buffer size from disks until it contains a newline character
        // or end of file.
        internal static void SkipToNextLine(ref StackLineReader reader)
        {
            while (true)
            {
                var read = LoadFullBuffer(ref reader);
                if (read == 0)
                {
                    break;
                }

                var eol_index = IndexOfEol(in reader);
                if (eol_index < 0) continue;
                reader.StringView = reader.StringView.PopFront((ulong)(eol_index + 1));
                break;
            }
        }

        internal static LineResult CreateLineResult(bool eof, bool fullLine, in StringView view)
        {
            LineResult result;
            result.eof = eof;
            result.full_line = fullLine;
            result.line = view;
            return result;
        }

        // Helper methods to provide clearer semantic in StackLineReader_NextLine.
        internal static LineResult CreateEOFLineResult(StringView view)
        {
            return CreateLineResult(true, true, view);
        }

        internal static LineResult CreateTruncatedLineResult(StringView view)
        {
            return CreateLineResult(false, false, view);
        }

        internal static LineResult CreateValidLineResult(StringView view)
        {
            return CreateLineResult(false, true, view);
        }

        internal static LineResult NextLine(ref StackLineReader reader)
        {
            if (reader.SkipMode)
            {
                SkipToNextLine(ref reader);
                reader.SkipMode = false;
            }
            {
                var can_load_more = reader.StringView.Size < (ulong)STACK_LINE_READER_BUFFER_SIZE;
                var eol_index = IndexOfEol(reader);
                if (eol_index < 0 && can_load_more)
                {
                    var read = BringToFrontAndLoadMore(ref reader);
                    if (read == 0)
                    {
                        return CreateEOFLineResult(reader.StringView);
                    }

                    eol_index = IndexOfEol(reader);
                }

                if (eol_index < 0)
                {
                    reader.SkipMode = true;
                    return CreateTruncatedLineResult(reader.StringView);
                }

                {
                    var index = (ulong)eol_index;
                    var line = reader.StringView.KeepFront(index);
                    reader.StringView = reader.StringView.PopFront(index + 1UL);
                    return CreateValidLineResult(line);
                }
            }
        }
    }
}