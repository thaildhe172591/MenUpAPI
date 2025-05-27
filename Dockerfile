# Use the official .NET runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SkinShopAPI/SkinShopAPI.csproj", "SkinShopAPI/"]
RUN dotnet restore "SkinShopAPI/SkinShopAPI.csproj"
COPY . .
WORKDIR "/src/SkinShopAPI"
RUN dotnet build "SkinShopAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkinShopAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkinShopAPI.dll"]
