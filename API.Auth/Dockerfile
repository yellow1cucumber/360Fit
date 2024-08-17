FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["API.Auth/API.Auth.csproj", "API.Auth/"]
COPY ["DAL/DAL.csproj", "DAL/"]
COPY ["Domain.Core/Domain.Core.csproj", "Domain.Core/"]
RUN dotnet restore "./API.Auth/API.Auth.csproj"
COPY . .
WORKDIR "/src/API.Auth"
RUN dotnet build "./API.Auth.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Auth.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Auth.dll"]