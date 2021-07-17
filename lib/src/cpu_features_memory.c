#include <cpu_features_memory.h>

void __memcpy(void* dest, void* src, int byte_count) {
  memcpy(dest, src, byte_count);
}

bool __memcmp(void* buf1, void* buf2, size_t size) {
  return memcmp(buf1, buf2, size);
}
