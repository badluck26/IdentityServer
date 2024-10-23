# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["TechDaniels.IdentityServer.AdminAPI/TechDaniels.IdentityServer.AdminAPI.csproj", "TechDaniels.IdentityServer.AdminAPI/"]
COPY ["TechDaniels.IdentityServer.Core/TechDaniels.IdentityServer.Core.csproj", "TechDaniels.IdentityServer.Core/"]
COPY ["TechDaniels.IdentityServer.Domain/TechDaniels.IdentityServer.Domain.csproj", "TechDaniels.IdentityServer.Domain/"]
COPY ["TechDaniels.IdentityServer.Data/TechDaniels.IdentityServer.Data.csproj", "TechDaniels.IdentityServer.Data/"]
COPY ["TechDaniels.IdentityServer.Services/TechDaniels.IdentityServer.Services.csproj", "TechDaniels.IdentityServer.Services/"]
RUN dotnet restore "./TechDaniels.IdentityServer.AdminAPI/TechDaniels.IdentityServer.AdminAPI.csproj"
COPY . .
WORKDIR "/src/TechDaniels.IdentityServer.AdminAPI"
RUN dotnet build "./TechDaniels.IdentityServer.AdminAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "./TechDaniels.IdentityServer.AdminAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechDaniels.IdentityServer.AdminAPI.dll"]