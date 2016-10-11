# Welcome to CMDemo

ASP.NET Core Demo API with MongoDB and TDD with xUnit and Moq

## This application consists of:

* Sample API using ASP.NET Core MVC
* Connects to MongoDB
* Autofac Dependency Injection
* TDD using xUnit and Moq
* Code can be run on either VS Code or Visual Studio

## How to

* http://localhost:8002/api/products
* http://localhost:8002/api/products?query={'id':1}
* http://localhost:8002/api/products?query={'price':{$gte:120,$lte:130}}
* http://localhost:8002/api/products?query={'attribute.fantastic.value':{$eq:true}}
* http://localhost:8002/api/products?query={'attribute.rating.value':{$gte:1.20,$lte:2.3}}

## Overview

## Run & Deploy

* dotnet restore
* dotnet build
* dotnet run
