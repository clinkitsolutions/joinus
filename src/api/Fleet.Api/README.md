# Fleet Backend

This folder contains the backend for the take-home exercise.

# Technical Details

The backend consists of a .NET 6.0 project and uses EF Core 6.0 against an SQLite provider. Make sure you have the .NET 6.0 SDK installed. Then navigate to the API project folder and run `dotnet run` or `dotnet watch run` on the project.

The `Fleet.Vehicles` project contains the core classes needed to support the exposed endpoints under `Fleet.Api`. All models, repositories, view models, and services are contained within this project.

A seeded database, `fleet.db`, is already included in the solution under the `Fleet.Api` folder. You may use any SQLite browser to browse through the database. You can convert this to any database provider you want if you wish to, be it in-memory or otherwise.

# Task

For the backend part of the exercise, you are to add a few endpoints to support a new feature: end-of-day vehicle logs. A file will be sent to the backend which contains a list of vehicles and their last known location and timestamp. You will need to save these information so that it can be displayed in the map afterwards.

You may choose to implement this however you like: use any NuGet packages, rewrite the project in your framework of choice, restructure the solution, split it into microservices, change the database provider, combine it into a single project, or whatever your imagination can produce.

You may choose to focus 100% of your energy on the backend, in which case, please provide sample Postman requests. You may go above and beyond the basic requirements to demonstrate in-depth technical knowledge and product design chops.