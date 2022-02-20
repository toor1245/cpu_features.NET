#ifndef CPU_FEATURES_DOTNET_CPU_FEATURES_PORT_MACROS_H
#define CPU_FEATURES_DOTNET_CPU_FEATURES_PORT_MACROS_H

#include "cpu_features_macros.h"

////////////////////////////////////////////////////////////////////////////////
// DllImport
////////////////////////////////////////////////////////////////////////////////
#if defined(CPU_FEATURES_OS_WINDOWS)
#ifdef CPU_FEATURES_DOTNET_DLL
#define CPU_FEATURES_DOTNET_DLL_EXPORT __declspec(dllexport)
#else
#define CPU_FEATURES_DOTNET_DLL_EXPORT __declspec(dllimport)
#endif
#else
#define CPU_FEATURES_DOTNET_DLL_EXPORT
#endif // CPU_FEATURES_OS_WINDOWS

#endif // CPU_FEATURES_DOTNET_CPU_FEATURES_PORT_MACROS_H
