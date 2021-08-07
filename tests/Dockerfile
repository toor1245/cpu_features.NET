#FROM multiarch/debian-debootstrap:armhf-buster-slim
FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim-arm32v7
RUN apt-get update && apt-get install -y curl gnupg icu-devtools
COPY bin/Release/net5.0/linux-arm/publish/ App/
RUN uname -a
WORKDIR /App
ENTRYPOINT [ "dotnet", "test", "CpuFeaturesDotNet.UnitTesting.dll" ]