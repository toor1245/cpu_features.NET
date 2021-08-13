#include <x86-64/cpuinfo_x86.h>

bool is_vendor(leaf_t leaf, const char* name) {
  const uint32_t ebx = *(const uint32_t*)(name);
  const uint32_t edx = *(const uint32_t*)(name + 4);
  const uint32_t ecx = *(const uint32_t*)(name + 8);
  return leaf.ebx == ebx && leaf.ecx == ecx && leaf.edx == edx;
}

#define CPUID(FAMILY, MODEL) ((((FAMILY)&0xFF) << 8) | ((MODEL)&0xFF))

X86Microarchitecture uarch(leaf_t leaf, int family, int model, int stepping) {
  if (is_vendor(leaf, CPU_FEATURES_DOTNET_VENDOR_GENUINE_INTEL)) {
    switch (CPUID(family, model)) {
      case CPUID(0x06, 0x1C):  // Intel(R) Atom(TM) CPU 230 @ 1.60GHz
      case CPUID(0x06, 0x35):
      case CPUID(0x06, 0x36):
      case CPUID(0x06, 0x70):  // https://en.wikichip.org/wiki/intel/atom/230
        // https://en.wikipedia.org/wiki/Bonnell_(microarchitecture)
        return INTEL_ATOM_BNL;
      case CPUID(0x06, 0x37):
      case CPUID(0x06, 0x4C):
        // https://en.wikipedia.org/wiki/Silvermont
        return INTEL_ATOM_SMT;
      case CPUID(0x06, 0x5C):
        // https://en.wikipedia.org/wiki/Goldmont
        return INTEL_ATOM_GMT;
      case CPUID(0x06, 0x0F):
      case CPUID(0x06, 0x16):
        // https://en.wikipedia.org/wiki/Intel_Core_(microarchitecture)
        return INTEL_CORE;
      case CPUID(0x06, 0x17):
      case CPUID(0x06, 0x1D):
        // https://en.wikipedia.org/wiki/Penryn_(microarchitecture)
        return INTEL_PNR;
      case CPUID(0x06, 0x1A):
      case CPUID(0x06, 0x1E):
      case CPUID(0x06, 0x1F):
      case CPUID(0x06, 0x2E):
        // https://en.wikipedia.org/wiki/Nehalem_(microarchitecture)
        return INTEL_NHM;
      case CPUID(0x06, 0x25):
      case CPUID(0x06, 0x2C):
      case CPUID(0x06, 0x2F):
        // https://en.wikipedia.org/wiki/Westmere_(microarchitecture)
        return INTEL_WSM;
      case CPUID(0x06, 0x2A):
      case CPUID(0x06, 0x2D):
        // https://en.wikipedia.org/wiki/Sandy_Bridge#Models_and_steppings
        return INTEL_SNB;
      case CPUID(0x06, 0x3A):
      case CPUID(0x06, 0x3E):
        // https://en.wikipedia.org/wiki/Ivy_Bridge_(microarchitecture)#Models_and_steppings
        return INTEL_IVB;
      case CPUID(0x06, 0x3C):
      case CPUID(0x06, 0x3F):
      case CPUID(0x06, 0x45):
      case CPUID(0x06, 0x46):
        // https://en.wikipedia.org/wiki/Haswell_(microarchitecture)
        return INTEL_HSW;
      case CPUID(0x06, 0x3D):
      case CPUID(0x06, 0x47):
      case CPUID(0x06, 0x4F):
      case CPUID(0x06, 0x56):
        // https://en.wikipedia.org/wiki/Broadwell_(microarchitecture)
        return INTEL_BDW;
      case CPUID(0x06, 0x4E):
      case CPUID(0x06, 0x55):
      case CPUID(0x06, 0x5E):
        // https://en.wikipedia.org/wiki/Skylake_(microarchitecture)
        return INTEL_SKL;
      case CPUID(0x06, 0x66):
        // https://en.wikipedia.org/wiki/Cannon_Lake_(microarchitecture)
        return INTEL_CNL;
      case CPUID(0x06, 0x7D):  // client
      case CPUID(0x06, 0x7E):  // client
      case CPUID(0x06, 0x9D):  // NNP-I
      case CPUID(0x06, 0x6A):  // server
      case CPUID(0x06, 0x6C):  // server
        // https://en.wikipedia.org/wiki/Ice_Lake_(microprocessor)
        return INTEL_ICL;
      case CPUID(0x06, 0x8C):
      case CPUID(0x06, 0x8D):
        // https://en.wikipedia.org/wiki/Tiger_Lake_(microarchitecture)
        return INTEL_TGL;
      case CPUID(0x06, 0x8F):
        // https://en.wikipedia.org/wiki/Sapphire_Rapids
        return INTEL_SPR;
      case CPUID(0x06, 0x8E):
        switch (stepping) {
          case 9:
            return INTEL_KBL;  // https://en.wikipedia.org/wiki/Kaby_Lake
          case 10:
            return INTEL_CFL;  // https://en.wikipedia.org/wiki/Coffee_Lake
          case 11:
            return INTEL_WHL;  // https://en.wikipedia.org/wiki/Whiskey_Lake_(microarchitecture)
          default:
            return X86_UNKNOWN;
        }
      case CPUID(0x06, 0x9E):
        if (stepping > 9) {
          // https://en.wikipedia.org/wiki/Coffee_Lake
          return INTEL_CFL;
        } else {
          // https://en.wikipedia.org/wiki/Kaby_Lake
          return INTEL_KBL;
        }
      default:
        return X86_UNKNOWN;
    }
  }
  if (is_vendor(leaf, CPU_FEATURES_DOTNET_VENDOR_AUTHENTIC_AMD)) {
    switch (CPUID(family, model)) {
      // https://en.wikichip.org/wiki/amd/cpuid
      case CPUID(0xF, 0x04):
      case CPUID(0xF, 0x05):
      case CPUID(0xF, 0x07):
      case CPUID(0xF, 0x08):
      case CPUID(0xF, 0x0C):
      case CPUID(0xF, 0x0E):
      case CPUID(0xF, 0x0F):
      case CPUID(0xF, 0x14):
      case CPUID(0xF, 0x15):
      case CPUID(0xF, 0x17):
      case CPUID(0xF, 0x18):
      case CPUID(0xF, 0x1B):
      case CPUID(0xF, 0x1C):
      case CPUID(0xF, 0x1F):
      case CPUID(0xF, 0x21):
      case CPUID(0xF, 0x23):
      case CPUID(0xF, 0x24):
      case CPUID(0xF, 0x25):
      case CPUID(0xF, 0x27):
      case CPUID(0xF, 0x2B):
      case CPUID(0xF, 0x2C):
      case CPUID(0xF, 0x2F):
      case CPUID(0xF, 0x41):
      case CPUID(0xF, 0x43):
      case CPUID(0xF, 0x48):
      case CPUID(0xF, 0x4B):
      case CPUID(0xF, 0x4C):
      case CPUID(0xF, 0x4F):
      case CPUID(0xF, 0x5D):
      case CPUID(0xF, 0x5F):
      case CPUID(0xF, 0x68):
      case CPUID(0xF, 0x6B):
      case CPUID(0xF, 0x6F):
      case CPUID(0xF, 0x7F):
      case CPUID(0xF, 0xC1):
        return AMD_HAMMER;
      case CPUID(0x10, 0x02):
      case CPUID(0x10, 0x04):
      case CPUID(0x10, 0x05):
      case CPUID(0x10, 0x06):
      case CPUID(0x10, 0x08):
      case CPUID(0x10, 0x09):
      case CPUID(0x10, 0x0A):
        return AMD_K10;
      case CPUID(0x11, 0x03):
        // http://developer.amd.com/wordpress/media/2012/10/41788.pdf
        return AMD_K11;
      case CPUID(0x12, 0x01):
        // https://www.amd.com/system/files/TechDocs/44739_12h_Rev_Gd.pdf
        return AMD_K12;
      case CPUID(0x14, 0x00):
      case CPUID(0x14, 0x01):
      case CPUID(0x14, 0x02):
        // https://www.amd.com/system/files/TechDocs/47534_14h_Mod_00h-0Fh_Rev_Guide.pdf
        return AMD_BOBCAT;
      case CPUID(0x15, 0x01):
        // https://en.wikichip.org/wiki/amd/microarchitectures/bulldozer
        return AMD_BULLDOZER;
      case CPUID(0x15, 0x02):
      case CPUID(0x15, 0x11):
      case CPUID(0x15, 0x13):
        // https://en.wikichip.org/wiki/amd/microarchitectures/piledriver
        return AMD_PILEDRIVER;
      case CPUID(0x15, 0x30):
      case CPUID(0x15, 0x38):
        // https://en.wikichip.org/wiki/amd/microarchitectures/steamroller
        return AMD_STREAMROLLER;
      case CPUID(0x15, 0x60):
      case CPUID(0x15, 0x65):
      case CPUID(0x15, 0x70):
        // https://en.wikichip.org/wiki/amd/microarchitectures/excavator
        return AMD_EXCAVATOR;
      case CPUID(0x16, 0x00):
        return AMD_JAGUAR;
      case CPUID(0x16, 0x30):
        return AMD_PUMA;
      case CPUID(0x17, 0x01):
      case CPUID(0x17, 0x11):
      case CPUID(0x17, 0x18):
      case CPUID(0x17, 0x20):
        // https://en.wikichip.org/wiki/amd/microarchitectures/zen
        return AMD_ZEN;
      case CPUID(0x17, 0x08):
        // https://en.wikichip.org/wiki/amd/microarchitectures/zen%2B
        return AMD_ZEN_PLUS;
      case CPUID(0x17, 0x31):
      case CPUID(0x17, 0x47):
      case CPUID(0x17, 0x60):
      case CPUID(0x17, 0x68):
      case CPUID(0x17, 0x71):
      case CPUID(0x17, 0x90):
      case CPUID(0x17, 0x98):
        // https://en.wikichip.org/wiki/amd/microarchitectures/zen_2
        return AMD_ZEN2;
      case CPUID(0x19, 0x01):
      case CPUID(0x19, 0x21):
      case CPUID(0x19, 0x30):
      case CPUID(0x19, 0x40):
      case CPUID(0x19, 0x50):
        // https://en.wikichip.org/wiki/amd/microarchitectures/zen_3
        return AMD_ZEN3;
      default:
        return X86_UNKNOWN;
    }
  }
  if (is_vendor(leaf, CPU_FEATURES_DOTNET_VENDOR_HYGON_GENUINE)) {
    switch (CPUID(family, model)) {
      case CPUID(0x18, 0x00):
        return AMD_ZEN;
    }
  }
  return X86_UNKNOWN;
}