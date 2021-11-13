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

using CpuFeaturesDotNet.Native;
using Xunit;
#pragma warning disable 162

namespace CpuFeaturesDotNet.UnitTesting.Attributes
{
    public sealed class FactAarch64Attribute : FactAttribute
    {
        public FactAarch64Attribute()
        {
#if NETFRAMEWORK
            Skip = "Ignored on unsupported AArch64 architecture for .NET Framework";
            return;
#endif
            if (!Architecture.IsArchAarch64())
            {
                Skip = "Ignored on unsupported AArch64 architecture";
            }
        }
    }
}