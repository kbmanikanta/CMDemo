# Welcome to CMDemo

.NET Core Demo API with MongoDB and TDD with xUnit and Moq

## This application consists of:

#### Back-end / API
* Sample API using .NET Core MVC (build for .NETStandard1.6)
* Connects to MongoDB
* Autofac Dependency Injection
* TDD using xUnit and Moq
* Code can be run on either VS Code or Visual Studio

#### Front-end
* Angular2 application with angular-cli

## Requirements

The written code has been tested to build and run on Linux, MacOS and Windows with SDK "1.0.0-preview2-1-003177".

Moq is not currently compatible with .NETStandard. The package for .Net Core is not in NuGet, need to configure and get from another source feed. 

In order to get Moq (4.4.0-beta8) to work, need to add a new NuGet feed.
* https://www.myget.org/F/aspnet-contrib/api/v3/index.json

## Installation

### Back-end / API
```sh
$ dotnet restore
$ dotnet build
$ dotnet run
```
* http://localhost:8002/api/products
* http://localhost:8002/api/products?query={'id':1}
* http://localhost:8002/api/products?query={'price':{$gte:120,$lte:130}}
* http://localhost:8002/api/products?query={'attribute.fantastic.value':{$eq:true}}
* http://localhost:8002/api/products?query={'attribute.rating.value':{$gte:1.20,$lte:2.3}}

### Front-end
```sh
$ npm restore
$ npm start
```
* http://localhost:4200/products
