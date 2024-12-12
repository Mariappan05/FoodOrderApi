# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory in the container
WORKDIR /src

# Copy the project file and restore any dependencies (via `dotnet restore`)
COPY ["FoodOrderApi/FoodOrderApi.csproj", "FoodOrderApi/"]
RUN dotnet restore "FoodOrderApi/FoodOrderApi.csproj"

# Copy the rest of the application source code
COPY . .

# Set the working directory to the project folder
WORKDIR /src/FoodOrderApi

# Build the application in release mode
RUN dotnet build "FoodOrderApi.csproj" -c Release -o /app/build

# Publish the application to the /app/publish folder
FROM build AS publish
RUN dotnet publish "FoodOrderApi.csproj" -c Release -o /app/publish

# Use the runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

# Set the working directory to /app
WORKDIR /app

# Copy the published files from the build container
COPY --from=publish /app/publish .

# Expose ports 80 and 443
EXPOSE 80
EXPOSE 443

# Set the entry point for the container to run the application
ENTRYPOINT ["dotnet", "FoodOrderApi.dll"]
