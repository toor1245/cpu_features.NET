#ifndef CPU_FEATURES_DOTNET_CPUINFO_X86_H
#define CPU_FEATURES_DOTNET_CPUINFO_X86_H

#include <stdbool.h>
#include <stdlib.h>

#include "cpuid_x86.h"
#include "memory.h"

CPU_FEATURES_DOTNET_START_CPP_NAMESPACE

// CPUID Vendors
#define CPU_FEATURES_DOTNET_VENDOR_GENUINE_INTEL "GenuineIntel"
#define CPU_FEATURES_DOTNET_VENDOR_AUTHENTIC_AMD "AuthenticAMD"
#define CPU_FEATURES_DOTNET_VENDOR_HYGON_GENUINE "HygonGenuine"

typedef enum {
  X86_UNKNOWN,
  INTEL_CORE,        // CORE
  INTEL_PNR,         // PENRYN
  INTEL_NHM,         // NEHALEM
  INTEL_ATOM_BNL,    // BONNELL
  INTEL_WSM,         // WESTMERE
  INTEL_SNB,         // SANDYBRIDGE
  INTEL_IVB,         // IVYBRIDGE
  INTEL_ATOM_SMT,    // SILVERMONT
  INTEL_HSW,         // HASWELL
  INTEL_BDW,         // BROADWELL
  INTEL_SKL,         // SKYLAKE
  INTEL_ATOM_GMT,    // GOLDMONT
  INTEL_KBL,         // KABY LAKE
  INTEL_CFL,         // COFFEE LAKE
  INTEL_WHL,         // WHISKEY LAKE
  INTEL_CNL,         // CANNON LAKE
  INTEL_ICL,         // ICE LAKE
  INTEL_TGL,         // TIGER LAKE
  INTEL_SPR,         // SAPPHIRE RAPIDS
  AMD_HAMMER,        // K8  HAMMER
  AMD_K10,           // K10
  AMD_K11,           // K11
  AMD_K12,           // K12
  AMD_BOBCAT,        // K14 BOBCAT
  AMD_PILEDRIVER,    // K15 PILEDRIVER
  AMD_STREAMROLLER,  // K15 STREAMROLLER
  AMD_EXCAVATOR,     // K15 EXCAVATOR
  AMD_BULLDOZER,     // K15 BULLDOZER
  AMD_JAGUAR,        // K16 JAGUAR
  AMD_PUMA,          // K16 PUMA
  AMD_ZEN,           // K17 ZEN
  AMD_ZEN_PLUS,      // K17 ZEN+
  AMD_ZEN2,          // K17 ZEN 2
  AMD_ZEN3,          // K19 ZEN 3
} X86Microarchitecture;

CPU_FEATURES_DOTNET_DLL_EXPORT X86Microarchitecture __uarch(leaf_t leaf,
                                                            int family,
                                                            int model,
                                                            int stepping);
CPU_FEATURES_DOTNET_DLL_EXPORT char* __brand_string(char* brand_string);
CPU_FEATURES_DOTNET_DLL_EXPORT bool __is_vendor(leaf_t leaf, const char* name);

CPU_FEATURES_DOTNET_END_CPP_NAMESPACE

#endif  // CPU_FEATURES_DOTNET_CALL_CPUINFO_X86_H
