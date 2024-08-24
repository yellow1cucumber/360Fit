# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["360Fit/API.Gate/API.Gate.csproj", "360Fit/API.Gate/"]
COPY ["360Fit/DAL/DAL.csproj", "360Fit/DAL/"]
COPY ["360Fit/Domain.ClienLogging/Domain.ClientLogging.csproj", "360Fit/Domain.ClienLogging/"]
COPY ["360Fit/Domain.Core/Domain.Core.csproj", "360Fit/Domain.Core/"]
COPY ["360Fit/Infrastructure.DTO/Infrastructure.DTO.csproj", "360Fit/Infrastructure.DTO/"]
RUN dotnet restore "./360Fit/API.Gate/API.Gate.csproj"
COPY . .
WORKDIR "/src/360Fit/API.Gate"
RUN dotnet build "./API.Gate.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Gate.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Gate.dll"]