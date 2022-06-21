using System;
using CpuFeaturesDotNet.AArch64;

var aarch64Info = Aarch64Info.GetAarch64Info();

Console.WriteLine($"Implementer: {aarch64Info.Implementer}");
Console.WriteLine($"Part: {aarch64Info.Part}");
Console.WriteLine($"Revision: {aarch64Info.Revision}");
Console.WriteLine($"Variant: {aarch64Info.Variant}");
Console.WriteLine($"IsSupportedASIMD: {aarch64Info.Features.IsSupportedASIMD}");
Console.WriteLine($"IsSupportedCPUID: {aarch64Info.Features.IsSupportedCPUID}");
Console.WriteLine($"IsSupportedFP: {aarch64Info.Features.IsSupportedFP}");