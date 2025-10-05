# Etapa base: imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5001
ENV ASPNETCORE_HTTP_PORTS=3000

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar os .csproj primeiro
COPY FIAP.FCG.API/FIAP.FCG.API.csproj FIAP.FCG.API/
COPY FIAP.FCG.Domain/FIAP.FCG.Domain.csproj FIAP.FCG.Domain/
COPY FIAP.FCG.Infrastructure/FIAP.FCG.Infrastructure.csproj FIAP.FCG.Infrastructure/
COPY FIAP.FCG.Service/FIAP.FCG.Service.csproj FIAP.FCG.Service/

# Restaurar dependências
RUN dotnet restore FIAP.FCG.API/FIAP.FCG.API.csproj

# Copiar o restante dos arquivos
COPY FIAP.FCG.API/ FIAP.FCG.API/
COPY FIAP.FCG.Domain/ FIAP.FCG.Domain/
COPY FIAP.FCG.Infrastructure/ FIAP.FCG.Infrastructure/
COPY FIAP.FCG.Service/ FIAP.FCG.Service/

# Build
WORKDIR /src/FIAP.FCG.API
RUN dotnet build FIAP.FCG.API.csproj -c Release -o /app/build

# Etapa de publish
FROM build AS publish
WORKDIR /src/FIAP.FCG.API
RUN dotnet publish FIAP.FCG.API.csproj -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development


ENTRYPOINT ["dotnet", "FIAP.FCG.API.dll"]
