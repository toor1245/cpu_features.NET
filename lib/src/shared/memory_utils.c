#include "memory_utils.h"

void *_memchr(const void *buffer, int value, size_t max_count) {
  return memchr(buffer, value, max_count);
}

int _memcmp(const void *buffer1, const void *buffer2, size_t size) {
  return memcmp(buffer1, buffer2, size);
}
