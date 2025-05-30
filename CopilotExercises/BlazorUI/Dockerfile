# BlazorUI Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the BlazorUI project file
COPY ["BlazorUI.csproj", "./"]

# When building from the docker-compose context, Backend project will be available
COPY ["Backend/Backend.csproj", "../Backend/"]

# Restore dependencies for BlazorUI (which references Backend)
RUN dotnet restore "BlazorUI.csproj"

# Copy all source code
COPY . .
COPY Backend/ ../Backend/

# Build the BlazorUI project
RUN dotnet build "BlazorUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "BlazorUI.dll"]