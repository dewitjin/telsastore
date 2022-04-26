# StoreProject

1. A database containing customer and item information.
2. A backend service for payment calculation.
3. A single-page web application to take customer inputs and display payments.

For simplicity, the backend service seeds the database with hardcoded customer and item information when it first starts.

## Installation

Replace taxjar token id with new one. Read: https://developers.taxjar.com/api/reference/

This will start the store API image, consisting of both API and SQL Database.
Clone repo.
cd .\StoreAPI
docker compose up

To view api index: http://localhost:8080/welcome
Should see: ["Store API Version 1.0.0"]

cd .\StoreWeb
docker compose up

To view api index: http://localhost:7070/
Should see: Telsa Order Page

![telsaIndex](https://user-images.githubusercontent.com/6993716/165230296-0f7b87fe-2a66-4770-be98-04714c35c8f1.PNG)

## Other

To check server:
Use Microsoft SQL Management Studio or SQL Server Object Explorer
Connect using: 
server name: localhost 
login: SA
password: Ilovetelsa1212

Connection string:
Server=localhost,1433;Initial Catalog=Store;Persist Security Info=True;User ID =SA;Password=Ilovetelsa1212

Useful commands for testing image without docker file:
Run a sql image to test:
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Ilovetelsa1212" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2019-latest

Reminder:
-p 8080:80 binds container's tcp port 80 to host port 8080.


