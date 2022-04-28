FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["StoreWeb/StoreWeb.csproj", "StoreWeb/"]
RUN dotnet restore "StoreWeb/StoreWeb.csproj"

#Copy the project files and build our release
COPY StoreWeb/ StoreWeb/
WORKDIR "/src/StoreWeb/"
RUN dotnet build "StoreWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreWeb.dll"]