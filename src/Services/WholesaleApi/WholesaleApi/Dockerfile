FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 4012

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src

# Copiar csproj e restaurar dependencias
COPY src/Services/WholesaleApi/WholesaleApi.sln .
COPY src/Services/WholesaleApi/WholesaleApi/WholesaleApi.csproj src/Services/WholesaleApi/WholesaleApi/
RUN dotnet restore WholesaleApi.sln

# Build da aplicacao
COPY . .
WORKDIR /src/src/Services/WholesaleApi/WholesaleApi
RUN dotnet publish --no-restore -c Release -o /app

# Build da imagem
FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WholesaleApi.dll"]