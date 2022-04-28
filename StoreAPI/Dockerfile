#Get base SDK Image from Microsoft and expose port 80 hostport on docker compose can be different
#Expose 1433 for db
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 1433

#copy CSPROJ file and restore any dependencie (via Nuget)
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["StoreAPI/StoreAPI.csproj", "StoreAPI/"]
RUN dotnet restore "StoreAPI/StoreAPI.csproj"

#Copy the project files and build our release
COPY StoreAPI/ StoreAPI/ 
WORKDIR "/src/StoreAPI"
RUN dotnet build "StoreAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreAPI.csproj" -c Release -o /app/publish

#Generate runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreAPI.dll"]