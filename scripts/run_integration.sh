#!/usr/bin/env bash

docker run --rm --privileged multiarch/qemu-user-static:register --reset
docker run -it --rm toor1245/cpu_features-dotnet:manifest-arm32v7