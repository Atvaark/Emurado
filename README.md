# HaloOnline.Server

## Requirements
* Visual Studio 2013
* .NET Framework 4.5

## Projects

### HaloOnline.Server
A console application that hosts the webservice and the log server.

### HaloOnline.Server.App
A single page web application for managing the server.

### HaloOnline.Server.Core.Http
An http webservice which handles authentication and gives external access to game data.

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

* Creating an assembly for storing persistent data with Entity Framework Code First
* Creating an assembly for non persistent data like Chat, Presence, Parties and Matchmaking
* Waiting for a functional client
