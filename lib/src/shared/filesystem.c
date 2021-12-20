#include "filesystem.h"
#include <errno.h>
#include <fcntl.h>
#include <stdlib.h>
#include <sys/stat.h>
#include <sys/types.h>

#if defined(_MSC_VER)
#include <io.h>
int open_file(const char* filename) {
  int fd = -1;
  _sopen_s(&fd, filename, _O_RDONLY, _SH_DENYWR, _S_IREAD);
  return fd;
}

int read_file(int file_descriptor, void* buffer, size_t buffer_size) {
  return _read(file_descriptor, buffer, (unsigned int)buffer_size);
}

void close_file(int file_descriptor) {
  _close(file_descriptor);
}
#else
#include <unistd.h>

int open_file(const char* filename) {
  int result;
  do {
    result = open(filename, O_RDONLY);
  } while (result == -1L && errno == EINTR);
  return result;
}

void close_file(int file_descriptor) { close(file_descriptor); }

int read_file(int file_descriptor, void* buffer,
                         size_t buffer_size) {
  int result;
  do {
    result = read(file_descriptor, buffer, buffer_size);
  } while (result == -1L && errno == EINTR);
  return result;
}
#endif