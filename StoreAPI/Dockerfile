#Get base SDK Image from Microsoft
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#copy CSPROJ file and restore any dependencie (via Nuget)
#Added two docker files in this project. Instead of StoreAPI/StoreAPI.csproj copy StoreAPI.csproj
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["StoreAPI.csproj", "StoreAPI/"]
RUN dotnet restore "StoreAPI/StoreAPI.csproj"

#Copy the project files and build our release
#Replaced COPY . . with where the csproj is
COPY . ./StoreAPI/
WORKDIR "/src/StoreAPI"
RUN dotnet build "StoreAPI.csproj" -c Release -o /app/build

#Generate runtime image
FROM build AS publish
RUN dotnet publish "StoreAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreAPI.dll"]