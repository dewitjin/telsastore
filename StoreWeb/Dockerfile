#Get base SDK Image from Microsoft and expose port 80 hostport on docker compose can be different
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

#copy CSPROJ file and restore any dependencie (via Nuget)
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["StoreWeb.csproj", "StoreWeb/"]
RUN dotnet restore "StoreWeb/StoreWeb.csproj"

#Copy the project files and build our release
COPY . ./StoreWeb/
WORKDIR "/src/StoreWeb"
RUN dotnet build "StoreWeb.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "StoreWeb.csproj" -c Release -o /app/publish

#Generate runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreWeb.dll"]