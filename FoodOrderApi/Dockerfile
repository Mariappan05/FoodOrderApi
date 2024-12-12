# Use .NET 8 SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy the project file and restore dependencies
COPY ["FoodOrderApi/FoodOrderApi.csproj", "FoodOrderApi/"]
RUN dotnet restore "FoodOrderApi/FoodOrderApi.csproj"

# Copy the rest of the application code
COPY . .

WORKDIR "/src/FoodOrderApi"

# Build the application
RUN dotnet build "FoodOrderApi.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "FoodOrderApi.csproj" -c Release -o /app/publish

# Use .NET 8 runtime for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the published app
COPY --from=publish /app/publish .

# Set the entry point
ENTRYPOINT ["dotnet", "FoodOrderApi.dll"]
