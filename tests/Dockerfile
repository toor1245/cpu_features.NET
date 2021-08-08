FROM multiarch/debian-debootstrap:armhf-buster-slim
RUN apt-get update && apt-get install -y curl gnupg icu-devtools
FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim-arm32v7
COPY bin/Release/net5.0/linux-arm/publish/ App/
RUN uname -a
WORKDIR /App
#RUN dotnet test CpuFeaturesDotNet.UnitTesting.dll
ENTRYPOINT [ "dotnet", "test", "CpuFeaturesDotNet.UnitTesting.dll" ]