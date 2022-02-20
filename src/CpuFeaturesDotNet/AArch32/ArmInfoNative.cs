// Copyright (c) 2022 Mykola Hohsadze 
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

namespace CpuFeaturesDotNet.AArch32
{
    internal static class ArmInfoNative
    {
        [DllImport(Library.NATIVE_LIBRARY, EntryPoint = "GetArmInfoPort")]
        public static extern ArmInfo _GetArmInfo();

        [DllImport(Library.NATIVE_LIBRARY, EntryPoint = "GetArmCpuIdPort")]
        public static extern uint _GetArmCpuId(in ArmInfo info);
    }
}