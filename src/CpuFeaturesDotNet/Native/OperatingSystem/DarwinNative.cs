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

using System;
using System.Runtime.InteropServices;
using static CpuFeaturesDotNet.Native.Library;

namespace CpuFeaturesDotNet.Native.OperatingSystem
{
    internal static class DarwinNative
    {
#if OS_MAC
        private const string DARWIN_LIBRARY_LIBC = "libc"; 

        [DllImport(DARWIN_LIBRARY_LIBC)]
        private static extern int sysctlbyname(string name, out int intVal, ref IntPtr length, IntPtr newp, IntPtr newLen);

        public static bool GetDarwinSysCtlByName(string name)
        {
            var enabledLength = (IntPtr) IntPtr.Size;
            var failure = sysctlbyname(name, out var enabled, ref enabledLength, IntPtr.Zero, (IntPtr) 0);
            return failure != 0 && Convert.ToBoolean(enabled);
        }
#else
        public static bool GetDarwinSysCtlByName(string name) => false;
#endif
    }
}