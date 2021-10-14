FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY PlexBackend.Core/*.csproj ./PlexBackend.Core/
COPY PlexBackend.WebApi/*.csproj ./PlexBackend.WebApi/
COPY PlexBackend.Infrastructure/*.csproj ./PlexBackend.Infrastructure/
RUN dotnet restore

# After restoring the projects, copy everything else and build app
COPY PlexBackend.Core/. ./PlexBackend.Core/
COPY PlexBackend.WebApi/. ./PlexBackend.WebApi/
COPY PlexBackend.Infrastructure/. ./PlexBackend.Infrastructure/

WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "PlexBackend.WebApi.dll"]