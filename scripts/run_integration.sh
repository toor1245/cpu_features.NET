#sudo apt-get remove packages-microsoft-prod
#sudo apt-get remove 'dotnet*' 'aspnet*' 'netstandard*'
#sudo apt-get install dotnet-sdk-5.0

sudo docker run --rm --privileged multiarch/qemu-user-static:register --reset
sudo docker run -it --rm toor1245/cpu_features-dotnet:manifest-arm32v7