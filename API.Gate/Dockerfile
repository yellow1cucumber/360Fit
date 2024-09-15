FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
USER app
EXPOSE 7070
EXPOSE 7071

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

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Gate.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./API.Gate/certs/360Fit-API-pfx-dev.pfx /https/certs/360Fit-API-pfx-dev.pfx
RUN chmod 644 /https/certs/360Fit-API-pfx-dev.pfx
ENTRYPOINT ["dotnet", "API.Gate.dll"]
