dotnet --version
dotnet build "src/CpuFeaturesDotNet" -c Release --force
dotnet test "tests" -c Release