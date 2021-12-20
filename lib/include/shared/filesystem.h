#ifndef CPU_FEATURES_DOTNET_FILESYSTEM_H
#define CPU_FEATURES_DOTNET_FILESYSTEM_H

#include <stddef.h>
#include <stdint.h>

#include "cpu_features_macros.h"

CPU_FEATURES_DOTNET_START_CPP_NAMESPACE

// Same as linux "open(filename, O_RDONLY)", retries automatically on EINTR.
int open_file(const char* filename);

// Same as linux "read(file_descriptor, buffer, buffer_size)", retries
// automatically on EINTR.
int read_file(int file_descriptor, void* buffer, size_t buffer_size);

// Same as linux "close(file_descriptor)".
void close_file(int file_descriptor);

CPU_FEATURES_DOTNET_END_CPP_NAMESPACE

#endif //CPU_FEATURES_DOTNET_FILESYSTEM_H
