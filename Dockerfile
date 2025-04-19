# Use the ASP.NET Core runtime image for .NET 10.0
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build stage with .NET SDK 10.0
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["Moinu_portfolio_Api/Moinu_portfolio_Api.csproj", "Moinu_portfolio_Api/"]
RUN dotnet restore "Moinu_portfolio_Api/Moinu_portfolio_Api.csproj"

# Copy all source
COPY . .

WORKDIR "/src/Moinu_portfolio_Api"
RUN dotnet build "Moinu_portfolio_Api.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "Moinu_portfolio_Api.csproj" -c Release -o /app/publish

# Final stage: runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Moinu_portfolio_Api.dll"]
