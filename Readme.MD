Communication to services in the host machine can access them using host.docker.internal. This is like accessing localhost (127.0.0.1) from the host machine.


Start SQL Server Container as 
$ docker run -d -p 1433:1433 -e sa_password=mystrongpassword0! -e ACCEPT_EULA=Y --name mssql microsoft/mssql-server-windows-express
This will start a continer on the local host.

Then we can build and serve this container with donet core api that can reference the sql server as host.docker.internal

docker run -p 5000:80 -e "DbConnectionString=Server=host.docker.internal,1433;Database=CmdApi;User=sa;Password=mystrongpassword0!;" --name myCmdApi1 cmdapi:latest



Sample: 

[
    {
        "id": 1,
        "howTo": "How to generate a migration in EF Core",
        "platform": ".Net Core EF",
        "commandLine": "dotnet ef migrations add <name of migration>"
    },
    {
        "id": 2,
        "howTo": "How to update the database (run migration)",
        "platform": ".Net Core EF",
        "commandLine": "dotnet ef database upate"
    },
    {
        "id": 4,
        "howTo": "How to run a .net core app",
        "platform": ".Net Core",
        "commandLine": "dotnet run"
    },
    {
        "id": 5,
        "howTo": "How to build a .net core app",
        "platform": ".Net Core",
        "commandLine": "dotnet build"
    }
]
