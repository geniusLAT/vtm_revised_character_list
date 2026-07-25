# 1. Базовый образ runtime (Linux)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# 2. Образ SDK для сборки (Linux)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["vtmRevisedWebServer/vtmRevisedWebServer.csproj", "vtmRevisedWebServer/"]
RUN dotnet restore "vtmRevisedWebServer/vtmRevisedWebServer.csproj"
COPY . .
WORKDIR "/src/vtmRevisedWebServer"
RUN dotnet build "vtmRevisedWebServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 3. Публикация
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "vtmRevisedWebServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 4. Финальный образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "vtmRevisedWebServer.dll"]