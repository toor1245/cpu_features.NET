# cpu_features.NET

[![NuGet](https://img.shields.io/nuget/v/cpu_features.NET.svg)](https://www.nuget.org/packages/cpu_features.NET/) 
[![Downloads](https://img.shields.io/nuget/dt/cpu_features.NET.svg)](https://www.nuget.org/packages/cpu_features.NET/)
[![Stars](https://img.shields.io/github/stars/toor1245/cpu_features.NET?color=brightgreen)](https://github.com/toor1245/cpu_features.NET/stargazers)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://www.nuget.org/packages/cpu_features.NET/)

[![Run tests](https://github.com/toor1245/cpu_features.NET/actions/workflows/run-tests.yml/badge.svg)](https://github.com/toor1245/cpu_features.NET/actions/workflows/run-tests.yml)

.NET version of [google/cpu_features](https://github.com/google/cpu_features) for getting cpu info at runtime.

## Table of Contents

- [Design Rationale](#rationale)
- [Code samples](#codesample)
- [Running sample code](#usagesample)
- [What's supported](#support)
- [License](#license)

<a name="rationale"></a>

## Design Rationale

- **.NET Standard 1.1**
- **Simple to use.** See the snippets below for examples.
- **cpu_features.NET is suitable for implementing lib functions.**

<a name="codesample"></a>

## Code samples

### Checking features at runtime

Here's a simple example that executes a codepath if the CPU supports SSE4A instruction sets:

```cs
using System;
using CpuFeaturesDotNet.X86;

namespace CpuFeaturesDotNet.Samples
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            X86Info x86Info = X86Info.GetX86Info();
            bool sse4a = x86Info.Features.IsSupportedSSE4A;
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
```

### Caching for faster evaluation of complex checks

If you wish, you can read all the features at once into a global variable, and then query for the specific features you
care about.

```cs
using System;
using CpuFeaturesDotNet.X86;

namespace CpuFeaturesDotNet.Samples
{
    public class Program
    {
        public static X86Info X86Info = X86Info.GetX86Info();
        
        public static void Main(string[] args) 
        {
            X86Microarchitecture uarch = X86Info.GetX86Microarchitecture(info);
            bool hasFastAvx = info.Features.IsSupportedAVX && uarch != X86Microarchitecture.INTEL_SANDYBRIDGE;
        }
    }
}
```

### Rejecting poor hardware implementations based on microarchitecture

On x86, the first incarnation of a feature in a microarchitecture might not be the most efficient (e.g. AVX on Sandy
Bridge). We provide a function to retrieve the underlying microarchitecture so you can decide whether to use it.

Below, `hasFastAvx` is set to 1 if the CPU supports the AVX instruction set&mdash;but only if it's not Sandy Bridge.

```cs
using System;
using CpuFeaturesDotNet.X86;

namespace CpuFeaturesDotNet.Samples
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            X86Info info = X86Info.GetX86Info();
            X86Microarchitecture uarch = X86Info.GetX86Microarchitecture(info);
            bool hasFastAvx = info.Features.IsSupportedAVX && uarch != X86Microarchitecture.INTEL_SANDYBRIDGE;
        }
    }
}
```

This feature is currently available only for x86 microarchitectures.

<a name="usagesample"></a>

### Running sample code

Use `CpuFeaturesDotNet.Samples` for detection your CPU.

```shell
CpuFeaturesDotNet.Samples.CpuFeaturesListX64.StartRunner

{
  "Features": {
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
    "IsSupportedSSE": true,
    "IsSupportedSSE2": true,
    "IsSupportedSSE3": true,
    "IsSupportedSSSE3": true,
    "IsSupportedSSE4_1": true,
    "IsSupportedSSE4_2": true,
    "IsSupportedSSE4A": false,
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
    "IsSupportedAVX512_SECOND_FMA": false,
    "IsSupportedAVX512_4FMAPS": false,
    "IsSupportedAVX512_BF16": false,
    "IsSupportedAVX512_VP2INTERSECT": false,
    "IsSupportedAMX_BF16": false,
    "IsSupportedAMX_TILE": false,
    "IsSupportedAMX_INT8": false,
    "IsSupportedPCLMULQDQ": true,
    "IsSupportedSMX": false,
    "IsSupportedSGX": false,
    "IsSupportedCX16": true,
    "IsSupportedSHA": false,
    "IsSupportedDPOPCNT": true,
    "IsSupportedDMOVBE": true,
    "IsSupportedDRDRND": true,
    "IsSupportedDCA": false,
    "IsSupportedSS": true,
    "IsSupportedADX": true
  },
  "Family": 6,
  "Model": 142,
  "Stepping": 10,
  "Vendor": "GenuineIntel",
  "BrandString": "Intel(R) Core(TM) i5-8250U CPU @ 1.60GHz"
}
{
  "Size": 4,
  "Levels": [
    {
      "Level": 1,
      "CacheType": "CPU_FEATURE_CACHE_DATA",
      "CacheSize": 32768,
      "Ways": 8,
      "LineSize": 64,
      "TlbEntries": 64,
      "Partitioning": 1
    },
    {
      "Level": 1,
      "CacheType": "CPU_FEATURE_CACHE_INSTRUCTION",
      "CacheSize": 32768,
      "Ways": 8,
      "LineSize": 64,
      "TlbEntries": 64,
      "Partitioning": 1
    },
    {
      "Level": 2,
      "CacheType": "CPU_FEATURE_CACHE_UNIFIED",
      "CacheSize": 262144,
      "Ways": 4,
      "LineSize": 64,
      "TlbEntries": 1024,
      "Partitioning": 1
    },
    {
      "Level": 3,
      "CacheType": "CPU_FEATURE_CACHE_UNIFIED",
      "CacheSize": 6291456,
      "Ways": 12,
      "LineSize": 64,
      "TlbEntries": 8192,
      "Partitioning": 1
    },
    {
      "Level": 0,
      "CacheType": "CPU_FEATURE_CACHE_NULL",
      "CacheSize": 0,
      "Ways": 0,
      "LineSize": 0,
      "TlbEntries": 0,
      "Partitioning": 0
    },
    {
      "Level": 0,
      "CacheType": "CPU_FEATURE_CACHE_NULL",
      "CacheSize": 0,
      "Ways": 0,
      "LineSize": 0,
      "TlbEntries": 0,
      "Partitioning": 0
    },
    {
      "Level": 0,
      "CacheType": "CPU_FEATURE_CACHE_NULL",
      "CacheSize": 0,
      "Ways": 0,
      "LineSize": 0,
      "TlbEntries": 0,
      "Partitioning": 0
    },
    {
      "Level": 0,
      "CacheType": "CPU_FEATURE_CACHE_NULL",
      "CacheSize": 0,
      "Ways": 0,
      "LineSize": 0,
      "TlbEntries": 0,
      "Partitioning": 0
    },
    {
      "Level": 0,
      "CacheType": "CPU_FEATURE_CACHE_NULL",
      "CacheSize": 0,
      "Ways": 0,
      "LineSize": 0,
      "TlbEntries": 0,
      "Partitioning": 0
    },
    {
      "Level": 0,
      "CacheType": "CPU_FEATURE_CACHE_NULL",
      "CacheSize": 0,
      "Ways": 0,
      "LineSize": 0,
      "TlbEntries": 0,
      "Partitioning": 0
    }
  ]
}
```

_Note: Before run `CpuFeaturesDotNet.Samples` you need build project through cmake._
```shell
cmake -S. -Bcmake-build-release -DCMAKE_BUILD_TYPE=Release
cmake --build cmake-build-release --target all -v
```

Detailed instruction see [Local-Nuget-package-building](https://github.com/toor1245/cpu_features.NET/wiki/Local-Nuget-package-building#configure-c-project)

<a name="support"></a>

## What's supported

| Runtime / OS           | x86³        | ARM         | AArch64     |
|------------------------|:-----------:|:-----------:|:-----------:|
| .NET Framework Windows | in progress | N/A         | N/A         |
| .NET Core Windows      | yes²        | not yet     | not yet     |
| .NET Core Linux        | yes²        | in progress | in progress |
| .NET Core macOS        | yes²        | not yet     | not yet     |
| .NET Core FreeBSD      | not yet     | not yet     | not yet     |
| Mono Windows           | not yet     | not yet     | not yet     |
| Mono Linux             | not yet     | not yet     | not yet     |
| Mono macOS             | not yet     | N/A         | not yet     |
| Mono FreeBSD           | not yet     | not yet     | not yet     |
| Mono Android           | not yet     | not yet     | not yet     |
| Mono iOS               | N/A         | N/A         | not yet     |

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

