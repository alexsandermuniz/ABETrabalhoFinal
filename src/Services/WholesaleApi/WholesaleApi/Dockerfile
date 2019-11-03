FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS build-env
WORKDIR /app
EXPOSE 4012

# Copiar csproj e restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Build da aplicacao
COPY . ./
RUN dotnet publish -c Release -o out

# Build da imagem
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "WholesaleApi.dll"]