#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["API.Facultad/API.Facultad.csproj", "API.Facultad/"]
COPY ["Api.Facultad.Application/Api.Facultad.Application.csproj", "Api.Facultad.Application/"]
COPY ["Api.Facultad.Domain/Api.Facultad.Domain.csproj", "Api.Facultad.Domain/"]
COPY ["Api.Facultad.Infraestructure/Api.Facultad.Infraestructure.csproj", "Api.Facultad.Infraestructure/"]
RUN dotnet restore "./API.Facultad/./API.Facultad.csproj"
COPY . .
WORKDIR "/src/API.Facultad"
RUN dotnet build "./API.Facultad.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.Facultad.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Facultad.dll"]