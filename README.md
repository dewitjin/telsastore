# StoreProject

1. A database containing customer and item information.
2. A backend service for payment calculation.
3. A single-page web application to take customer inputs and display payments.

For simplicity, the backend service seeds the database with hardcoded customer and item information when it first starts.

## Installation

Replace taxjar token id with new one. Read: https://developers.taxjar.com/api/reference/

This will start the store API image, consisting of both API and SQL Database.<br />
<br />Clone repo.
<br />cd .\StoreAPI
<br />docker compose up

<br />To view api index: http://localhost:8080/welcome
<br />Should see: ["Store API Version 1.0.0"]

<br />To view api customers: http://localhost:8080/api/customers
<br />Should see: [{"id":1,"name":"Gail Windsor","addressID":1},{"id":2,"name":"James Bond","addressID":2}]

<br />cd .\StoreWeb
<br />docker compose up

<br />To view api index: http://localhost:7070/
<br />Should see: Telsa Order Page

![telsaIndex](https://user-images.githubusercontent.com/6993716/165230296-0f7b87fe-2a66-4770-be98-04714c35c8f1.PNG)

<br />Order Confirmation:

![orderResult](https://user-images.githubusercontent.com/6993716/165857824-d6c8429b-ab15-42b6-bed9-055f7db4d18f.PNG)


## Other

To check server:
<br />Use Microsoft SQL Management Studio or SQL Server Object Explorer
<br />Connect using: 
<br />server name: localhost,1433 
<br />login: SA
<br />password: Ilovetelsa1212

Connection string:
<br />Server=localhost,1433;Initial Catalog=Store;Persist Security Info=True;User ID =SA;Password=Ilovetelsa1212

To start with new migration:
<br /> Delete migration folder in project.
<br /> Use Visual Studio, run add-migration initial in command line. This will add new Migrations folder.

Useful commands for testing image without docker file:
<br />Run a sql image to test:
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Ilovetelsa1212" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2019-latest

Reminder:
<br />-p 8080:80 binds container's tcp port 80 to host port 8080.

Debugging:
<br /> When switching from local to docker image development: change connection strings (web api project), and change APIBaseUrl (web project).


