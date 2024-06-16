#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "."]
COPY ["src/SimpleCliniq.Api/SimpleCliniqApi.csproj", "src/SimpleCliniq.Api/"]
COPY ["src/SimpleCliniq.Common.Application/SimpleCliniq.Common.Application.csproj", "src/SimpleCliniq.Common.Application/"]
COPY ["src/SimpleCliniq.Common.Domain/SimpleCliniq.Common.Domain.csproj", "src/SimpleCliniq.Common.Domain/"]
COPY ["src/SimpleCliniq.Common.Infrastructure/SimpleCliniq.Common.Infrastructure.csproj", "src/SimpleCliniq.Common.Infrastructure/"]
COPY ["src/SimpleCliniq.Common.Presentation/SimpleCliniq.Common.Presentation.csproj", "src/SimpleCliniq.Common.Presentation/"]
COPY ["src/SimpleCliniq.Module.Core.Domain/SimpleCliniq.Module.Core.Domain.csproj", "src/SimpleCliniq.Module.Core.Domain/"]
COPY ["src/SimpleCliniq.Module.Core.Infrastructure/SimpleCliniq.Module.Core.Infrastructure.csproj", "src/SimpleCliniq.Module.Core.Infrastructure/"]
COPY ["src/SimpleCliniq.Module.Core.Presentation/SimpleCliniq.Module.Core.Presentation.csproj", "src/SimpleCliniq.Module.Core.Presentation/"]
RUN dotnet restore "./src/SimpleCliniq.Api/SimpleCliniqApi.csproj"
COPY . .
WORKDIR "/src/src/SimpleCliniq.Api"
RUN dotnet build "./SimpleCliniqApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SimpleCliniqApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleCliniqApi.dll"]