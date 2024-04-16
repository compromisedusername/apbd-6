# apbd-6 API application
## Other DBs
For working on your local machine change property `ConnectionStrings` in `appsettings.json`. 
See more on: https://www.connectionstrings.com/

## Using DB in Docker 
1. Install Docker
3. Pull Image
```bash
docker pull mcr.microsoft.com/mssql/server:latest
```
3. Start container
```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Adminxyz22#' -p 1433:1433 -d mcr.microsoft.com/mssql/server:latest -n sql1
```
4. Run mssqli CLI
```bash
sudo docker exec -it sql1 "bash"
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Adminxyz22#"
```
5.Create database in mssql CLI:
```bash
CREATE DATABASE apbd
GO

```
6. Create table in mssqli CLI:
```bash
USE apbd
GO
CREATE TABLE Animal (IdAnimal int  NOT NULL IDENTITY(1,1), Name nvarchar(200)  NOT NULL, Description nvarchar(200)  NULL, Category nvarchar(200)  NOT NULL, Area nvarchar(200)  NOT NULL, CONSTRAINT IdAnimal
GO
```
7. Fetch your own data
  in mssqli CLI:
```bash
INSERT INTO Animal VALUES ('ExampleName','ExampleDesc','ExampleCat','ExampleArea')
GO
```
8. Run API application

