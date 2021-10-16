// Copyright (c) 2021 Nikolay Hohsadze 
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Runtime.InteropServices;
using CpuFeaturesDotNet.Native;

namespace CpuFeaturesDotNet.IO
{
    internal static unsafe class FileSystem
    {
        [DllImport(Library.SHARED_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "open_file")]
        public static extern int OpenFile(string fileName);

        [DllImport(Library.SHARED_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "read_file")]
        public static extern int ReadFile(int fileDescriptor, byte* buffer, ulong bufferSize);

        [DllImport(Library.SHARED_LIBRARY, CallingConvention = CallingConvention.Cdecl, EntryPoint = "close_file")]
        public static extern void CloseFile(int fileDescriptor);
    }
}