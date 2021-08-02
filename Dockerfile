FROM ubuntu:20.04
RUN apt-get update && apt-get install -y curl

FROM mcr.microsoft.com/dotnet/runtime:5.0

RUN apt-get update && apt-get install -y \
    curl \
    gnupg \
    icu-devtools

ENV DOTNET_SDK_VERSION 5.0.102
RUN curl -SL --output dotnet.tar.gz https://dotnetcli.azureedge.net/dotnet/Runtime/$DOTNET_VERSION/dotnet-runtime-$DOTNET_VERSION-linux-arm.tar.gz \
    && dotnet_sha512='32eb73beb20e1bd4fa7eb35be779fa962df68921da14f9100a033911c40afc6c61ac99256b0d54cb35547f630bd7c0c7658b841224c9798e621bb7326ba0213e' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /dotnet \
    && tar -ozxf dotnet.tar.gz -C /dotnet \
    && rm dotnet.tar.gz

COPY bin/Release/netstandard1.0publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "NetCore.Docker.dll"]