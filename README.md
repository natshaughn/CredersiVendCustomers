# Credersi-vend Customers
A component of the Jan 2023 S&A Academy software testing bootcamp showcase.<br>

[db context](https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-7.0),
[dotnet ef](https://learn.microsoft.com/en-us/ef/core/cli/dotnet),
[entity framework core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli),
[migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli),
[properties](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties)<br>

## Overview
The fictional company *Credersi-vend* previously developed a back-office C# application
called *Credersi-vend Customers* for managing their corporate customer details.

## Install entity framework tool for database construction 
`dotnet tool install --global dotnet-ef`<br>

## Construct database using migrations
`dotnet ef --project src/VendDatabase migrations add InitialCreate`<br>
`dotnet ef --project src/VendDatabase database update`<br>

## To run the console program
`dotnet run --project src/VendCustomers`<br>

## .NET solution commands
These commands were used during project construction:<br>
`dotnet new gitignore`<br>
`dotnet new classlib --output src/VendDatabase`<br>
`dotnet add src/VendDatabase package Microsoft.EntityFrameworkCore.Design`<br>
`dotnet new classlib --output src/VendObjects`<br>
`dotnet new console --output src/VendCustomers`<br>
`dotnet add src/VendCustomers reference src/VendObjects/VendObjects.csproj`<br>
`dotnet add src/VendObjects reference src/VendDatabase/VendDatabase.csproj`<br>
`dotnet new sln`<br>
`dotnet sln add src/VendDatabase/VendDatabase.csproj`<br>
`dotnet sln add src/VendObjects/VendObjects.csproj`<br>
`dotnet sln add src/VendCustomers/VendCustomers.csproj`<br>
<br>
Getting started with the entity framework core:<br>
`dotnet add src/VendDatabase package Microsoft.EntityFrameworkCore.Sqlite`<br>
