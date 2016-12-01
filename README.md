# Welcome to CMDemo

ASP.NET Core Demo API with MongoDB and TDD with xUnit and Moq

## This application consists of:

* Sample API using ASP.NET Core MVC (build on .NETStandard1.6)
* Connects to MongoDB
* Autofac Dependency Injection
* TDD using xUnit and Moq
* Code can be run on either VS Code or Visual Studio

## Overview

The written code has been tested to build and run on Linux, MacOS and Windows.

Moq is not currently compatible with .NETStandard. The package for .Net Core is not in NuGet, need to configure and get from another source feed. 

In order to get Moq (4.4.0-beta8) to work, need to add a new NuGet feed.
* https://www.myget.org/F/aspnet-contrib/api/v3/index.json

## Run & Deploy

* dotnet restore
* dotnet build
* dotnet run

## How to

* http://localhost:8002/api/products
* http://localhost:8002/api/products?query={'id':1}
* http://localhost:8002/api/products?query={'price':{$gte:120,$lte:130}}
* http://localhost:8002/api/products?query={'attribute.fantastic.value':{$eq:true}}
* http://localhost:8002/api/products?query={'attribute.rating.value':{$gte:1.20,$lte:2.3}}
