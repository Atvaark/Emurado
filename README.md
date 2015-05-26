# Emurado
A Halo Online backend emulator for the very first leaked build.

## Requirements
* Visual Studio 2013
* .NET Framework 4.5

## Projects

### HaloOnline.Server
A console application that hosts the webserver, the webservice and the log server.

### HaloOnline.Server.App
An AngularJS single page web application for account management.

### HaloOnline.Server.Common
An assembly for storing common types.

### HaloOnline.Server.Core.Http
An http webservice which handles authentication and gives external access to game data.

### HaloOnline.Server.Core.Repository
An access layer for storing and retrieving data.

### HaloOnline.Server.Core.Scheduler
A project for recurring tasks such as matchmaking.

### HaloOnline.Server.Core.Log
A socket based log service.

### HaloOnline.Server.Model
An assembly containing the DTO classes expected by the client.

## Frameworks and dependencies
* OWIN - Web server interface
* ASP.NET Web Api - HTTP webservice framework
* Autofac - Inversion of Control container
* OAuth - Authorization
* JSON Web Tokens - Bearer token format
* SQLite - Database
* Entity Framework - Object-relational mapper
* Quartz - Scheduling
