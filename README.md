# HaloOnline.Server

## Requirements
* Visual Studio 2013
* .NET Framework 4.5

## Projects

### HaloOnline.Server
A console application that hosts the webserver, the webservice and the log server.

### HaloOnline.Server.App
An AngularJS single page web application for managing the server.

### HaloOnline.Server.Common
An assembly for storing common types.

### HaloOnline.Server.Core.Http
An http webservice which handles authentication and gives external access to game data.

### HaloOnline.Server.Core.Repository
A database access layer for storing and retrieving data.

### HaloOnline.Server.Core.Log
A socket based log service.

### HaloOnline.Server.Model
An assembly containing the data model of the server.

## Frameworks and dependencies
* OWIN - Web server interface
* ASP.NET Web Api - HTTP webservice framework
* Autofac - Inversion of Control container
* OAuth - Authorization
* JSON Web Tokens - Bearer token format
* SQLite - Database
* Entity Framework - Object-relational mapper

## Getting started

* Compile the solution
* Deploy HaloOnline.Server.App
* Run HaloOnline.Server
* Open %HALODIR%\game.cfg
  * Edit EndpointsDispatcherDomain and EndpointsDispatcherPort
  * Edit AzureBinLogEndPoint
* Open %HALODIR%\maps\tags.dat
  * Swap the enum values of BACKEND_SESSION_ESTABLISHING and BACKEND_SESSION_ONLINE
  
* Optional
  * Compile a version of ElDorito that doesn't mess with account related values

## Todo list

* ~~Creating an assembly for storing persistent data with Entity Framework~~
* Creating an assembly for non persistent data like Chat, Presence, Parties and Matchmaking
* Waiting for a functional client
