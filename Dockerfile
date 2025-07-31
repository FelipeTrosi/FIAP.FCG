#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /src

# restore
COPY ["scr/FIAP.FCG.API/FIAP.FCG.API.csproj", "FIAP.FCG.API"]
RUN dotnet restore 'FIAP.FCG.API/FIAP.FCG.API.csproj'

COPY ["scr/FIAP.FCG.Infrastructure/FIAP.FCG.Infrastructure.csproj", "FIAP.FCG.Infrastructure"]
RUN dotnet restore 'FIAP.FCG.Infrastructure/FIAP.FCG.Infrastructure.csproj'

# build
COPY ["scr/FIAP.FCG.API", "FIAP.FCG.API/"]
WORKDIR scr/FIAP.FCG.API
RUN dotnet build 'FIAP.FCG.API/FIAP.FCG.API.csproj' -c Release -o /app/build

# publish
FROM build AS publish
WORKDIR scr/FIAP.FCG.API
RUN dotnet publish 'FIAP.FCG.API/FIAP.FCG.API.csproj' -c Release -o /app/publish

# run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FIAP.FCG.API.dll"]