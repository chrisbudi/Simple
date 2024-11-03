# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src


# Copy the Directory.Build.props file
COPY ["Directory.Build.props", "/src/"]


# Copy project files
COPY ["src/SimpleCliniq.Api/SimpleCliniq.csproj", "src/SimpleCliniq.Api/"]
COPY ["src/SimpleCliniq.Module.Core.Infrastructure/SimpleCliniq.Module.Core.Infrastructure.csproj", "src/SimpleCliniq.Module.Core.Infrastructure/"]
COPY ["src/SimpleCliniq.Common.Application/Simple.Common.Application.csproj", "src/SimpleCliniq.Common.Application/"]
COPY ["src/SimpleCliniq.Common.Domain/Simple.Common.Domain.csproj", "src/SimpleCliniq.Common.Domain/"]
COPY ["src/SimpleCliniq.Common.Infrastructure/Simple.Common.Infrastructure.csproj", "src/SimpleCliniq.Common.Infrastructure/"]
COPY ["src/SimpleCliniq.Common.Presentation/Simple.Common.Presentation.csproj", "src/SimpleCliniq.Common.Presentation/"]
COPY ["src/SimpleCliniq.Module.Core.Domain/SimpleCliniq.Module.Core.Domain.csproj", "src/SimpleCliniq.Module.Core.Domain/"]
COPY ["src/SimpleCliniq.Module.Core.Presentation/SimpleCliniq.Module.Core.Presentation.csproj", "src/SimpleCliniq.Module.Core.Presentation/"]
COPY ["src/SimpleCliniq.Module.Core.Application/SimpleCliniq.Module.Core.Application.csproj", "src/SimpleCliniq.Module.Core.Application/"]
COPY ["src/SimpleCliniq.Module.Users.Infrastructure/SimpleCliniq.Module.Users.Infrastructure.csproj", "src/SimpleCliniq.Module.Users.Infrastructure/"]
COPY ["src/SimpleCliniq.Module.Users.Application/SimpleCliniq.Module.Users.Application.csproj", "src/SimpleCliniq.Module.Users.Application/"]
COPY ["src/SimpleCliniq.Module.Users.Domain/SimpleCliniq.Module.Users.Domain.csproj", "src/SimpleCliniq.Module.Users.Domain/"]
COPY ["src/SimpleCliniq.Module.Users.IntegrationEvents/SimpleCliniq.Module.Users.IntegrationEvents.csproj", "src/SimpleCliniq.Module.Users.IntegrationEvents/"]
COPY ["src/SimpleCliniq.Module.Users.Presentation/SimpleCliniq.Module.Users.Presentation.csproj", "src/SimpleCliniq.Module.Users.Presentation/"]
RUN dotnet restore "./src/SimpleCliniq.Api/SimpleCliniq.csproj"
COPY . .
WORKDIR "/src/src/SimpleCliniq.Api"
RUN dotnet build "./SimpleCliniq.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SimpleCliniq.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleCliniq.dll"]