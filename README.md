# cpu_features.NET

[![Linux Status][linux_svg]][linux_link]
[![Macos Status][macos_svg]][macos_link]
[![Windows Status][windows_svg]][windows_link]

[linux_svg]: https://github.com/toor1245/cpu_features.NET/actions/workflows/linux_x86-64.yml/badge.svg?branch=master

[linux_link]: https://github.com/toor1245/cpu_features.NET/actions/workflows/linux_x86-64.yml

[macos_svg]: https://github.com/toor1245/cpu_features.NET/actions/workflows/osx_x86-64.yml/badge.svg?branch=master

[macos_link]: https://github.com/toor1245/cpu_features.NET/actions/workflows/osx_x86-64.yml

[windows_svg]: https://github.com/toor1245/cpu_features.NET/actions/workflows/win_x86-64.yml/badge.svg?branch=master

[windows_link]: https://github.com/toor1245/cpu_features.NET/actions/workflows/win_x86-64.yml

.NET version of [google/cpu_features](https://github.com/google/cpu_features) for getting cpu info at runtime.

## Table of Contents

- [Design Rationale](#rationale)
- [Code samples](#codesample)
- [Running sample code](#usagesample)
- [What's supported](#support)
- [License](#license)

<a name="rationale"></a>

## Design Rationale

- **.NET Standard 1.3**
- **Simple to use.** See the snippets below for examples.
- **Extensible.** Easy to add missing features or architectures.
- **cpu_features.NET is suitable for implementing lib functions.**
- **Unit tested.**

<a name="codesample"></a>

## Code samples

### Checking features at runtime

Here's a simple example that executes a codepath if the CPU supports SSE4A instruction sets:

```cs
using System;
using CpuFeaturesDotNet.Native;
using CpuFeaturesDotNet.X86;

namespace CpuFeaturesDotNet.Samples
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            if (Architecture.IsArchX86())
            {
                ICpuInfoX86 cpuInfoX86 = new CpuInfoX86();
                bool sse4a = cpuInfoX86.Features.IsSupportedSSE4A;
                if (sse4a) 
                {
                    // Run optimized code.
                }
                else 
                {
                    // Run standard code.
                }
            }
        }
    }
}
```

### Caching for faster evaluation of complex checks

If you wish, you can read all the features at once into a global variable, and then query for the specific features you
care about.

### Rejecting poor hardware implementations based on microarchitecture

On x86, the first incarnation of a feature in a microarchitecture might not be the most efficient (e.g. AVX on Sandy
Bridge). We provide a function to retrieve the underlying microarchitecture so you can decide whether to use it.

Below, `hasFastAvx` is set to 1 if the CPU supports the AVX instruction set&mdash;but only if it's not Sandy Bridge.

```cs
using System;
using CpuFeaturesDotNet.Native;
using CpuFeaturesDotNet.X86;

namespace CpuFeaturesDotNet.Samples
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            ICpuInfoX86 info = new CpuInfoX86();
            MicroarchitectureX86 uarch = info.Microarchitecture;
            bool hasFastAvx = info.Features.IsSupportedAVX && uarch != MicroarchitectureX86.INTEL_SANDYBRIDGE;
        }
    }
}
```

This feature is currently available only for x86 microarchitectures.

<a name="usagesample"></a>

### Running sample code

Use `CpuFeaturesDotNet.Samples` for detection your CPU.

```shell
{
  "Family": 6,
  "Model": 142,
  "Stepping": 10,
  "BrandString": "Intel(R) Core(TM) i5-8250U CPU @ 1.60GHz\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000",
  "Microarchitecture": "INTEL_COFFEE_LAKE",
  "Features": {
    "IsSupportedAMX_BF16": false,
    "IsSupportedAMX_TILE": false,
    "IsSupportedAMX_INT8": false,
    "IsSupportedAVX": true,
    "IsSupportedAVX2": true,
    "IsSupportedAVX512F": false,
    "IsSupportedAVX512CD": false,
    "IsSupportedAVX512ER": false,
    "IsSupportedAVX512PF": false,
    "IsSupportedAVX512BW": false,
    "IsSupportedAVX512DQ": false,
    "IsSupportedAVX512VL": false,
    "IsSupportedAVX512IFMA": false,
    "IsSupportedAVX512VBMI": false,
    "IsSupportedAVX512VBMI2": false,
    "IsSupportedAVX512VNNI": false,
    "IsSupportedAVX512BITALG": false,
    "IsSupportedAVX512VPOPCNTDQ": false,
    "IsSupportedAVX512_4VNNIW": false,
    "IsSupportedAVX512_4VBMI2": false,
    "IsSupportedAVX512SecondFMA": false,
    "IsSupportedAVX512_4FMAPS": false,
    "IsSupportedAVX512_BF16": false,
    "IsSupportedAVX512_VP2INTERSECT": false,
    "IsSupportedSSE": true,
    "IsSupportedSSE2": true,
    "IsSupportedSSE3": true,
    "IsSupportedSSSE3": true,
    "IsSupportedSSE41": true,
    "IsSupportedSSE42": true,
    "IsSupportedSSE4A": false,
    "IsSupportedFPU": true,
    "IsSupportedTSC": true,
    "IsSupportedCX8": true,
    "IsSupportedCLFSH": true,
    "IsSupportedMMX": true,
    "IsSupportedAES": true,
    "IsSupportedERMS": true,
    "IsSupportedF16C": true,
    "IsSupportedFMA4": false,
    "IsSupportedFMA3": true,
    "IsSupportedVAES": false,
    "IsSupportedVPCLMULQDQ": false,
    "IsSupportedBMI1": true,
    "IsSupportedHLE": false,
    "IsSupportedBMI2": true,
    "IsSupportedRTM": false,
    "IsSupportedRDSEED": true,
    "IsSupportedCLFLUSHOPT": true,
    "IsSupportedCLWB": false,
    "IsSupportedPCLMULQDQ": true,
    "IsSupportedSMX": false,
    "IsSupportedSGX": false,
    "IsSupportedCX16": true,
    "IsSupportedSHA": false,
    "IsSupportedPOPCNT": true,
    "IsSupportedMOVBE": true,
    "IsSupportedRDRND": true,
    "IsSupportedDCA": false,
    "IsSupportedSS": true,
    "IsSupportedADX": true
  }
}
{
  "CacheLevelInfo": [
    {
      "Level": 1,
      "Type": "DATA",
      "CacheSize": 32768,
      "Ways": 8,
      "LineSize": 64,
      "TlbEntries": 64,
      "Partitioning": 1
    },
    {
      "Level": 1,
      "Type": "INSTRUCTION",
      "CacheSize": 32768,
      "Ways": 8,
      "LineSize": 64,
      "TlbEntries": 64,
      "Partitioning": 1
    },
    {
      "Level": 2,
      "Type": "UNIFIED",
      "CacheSize": 262144,
      "Ways": 4,
      "LineSize": 64,
      "TlbEntries": 1024,
      "Partitioning": 1
    },
    {
      "Level": 3,
      "Type": "UNIFIED",
      "CacheSize": 6291456,
      "Ways": 12,
      "LineSize": 64,
      "TlbEntries": 8192,
      "Partitioning": 1
    }
  ]
}
```

_Note: Before run `CpuFeaturesDotNet.Samples` you need build project through cmake._
```shell
cmake -S. -Bcmake-build-release -DCMAKE_BUILD_TYPE=Release
cmake --build cmake-build-release --target all -v
```

<a name="support"></a>

## What's supported

|         | x86³    | ARM     | AArch64 |
|---------|:-------:|:-------:|:-------:|
| Android | not yet | not yet | not yet |
| iOS     | N/A     | not yet | not yet |
| Linux   | yes²    | not yet | not yet |
| MacOs   | yes²    | N/A     | not yet |
| Windows | yes²    | not yet | not yet |
| FreeBSD | not yet | not yet | not yet |

1. **Features revealed from Linux.** We gather data from several sources depending on availability:
    + from glibc's
      [getauxval](https://www.gnu.org/software/libc/manual/html_node/Auxiliary-Vector.html)
    + by parsing `/proc/self/auxv`
    + by parsing `/proc/cpuinfo`
2. **Features revealed from CPU.** features are retrieved by using the `cpuid`
   instruction.
3. **Microarchitecture detection.** On x86 some features are not always implemented efficiently in hardware (e.g. AVX on
   Sandybridge). Exposing the microarchitecture allows the client to reject particular microarchitectures.

<a name="license"></a>

## License

The cpu_features.NET library is licensed under the terms of the Apache license. See [LICENSE](LICENSE) for more information.

