FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app
EXPOSE 4013

# Copiar csproj e restaurar dependencias
COPY src/Services/ShopkeeperApi/ShopkeeperApi/ShopkeeperApi.csproj src/Services/ShopkeeperApi/ShopkeeperApi/
RUN dotnet restore

# Build da aplicacao
COPY . .
WORKDIR /src/src/Services/ShopkeeperApi/ShopkeeperApi
RUN dotnet publish --no-restore -c Release -o /app

# Build da imagem
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ShopkeeperApi.dll"]