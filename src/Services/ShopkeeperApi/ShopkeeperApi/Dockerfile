FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 4013

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src

# Copiar csproj e restaurar dependencias
COPY src/Services/ShopkeeperApi/ShopkeeperApi.sln .
COPY src/Services/ShopkeeperApi/ShopkeeperApi/ShopkeeperApi.csproj src/Services/ShopkeeperApi/ShopkeeperApi/
WORKDIR /src/Services/ShopkeeperApi
RUN dotnet restore

# Build da aplicacao
COPY . .
WORKDIR /src/src/Services/ShopkeeperApi/ShopkeeperApi
RUN dotnet publish --no-restore -c Release -o /app

# Build da imagem
FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ShopkeeperApi.dll"]