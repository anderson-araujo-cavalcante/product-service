# product-service

Repository for products domain. 

## Current Entities

|Entity|Description|
|------|-----------|
|Category|Represents the category group that the product belongs to|
|Product|Represents the basic information of the product.|

### Database 📂

Currently this API uses MySql(8.0) as a database.

### Web Reference

ASP.NET Core MVC CORE (.Net8)

### API Reference

ASP.NET Core Web API (.Net8)

## Local Usage

Execute script ([initialDatabaseScript file](https://github.com/anderson-araujo-cavalcante/product-service/tree/main/api-product/database)) to create database and entities;
Run solution api ([api-product.sln](https://github.com/anderson-araujo-cavalcante/product-service/tree/main/api-product)) to make routes available.
Run solution web ([WK.Web.sln](https://github.com/anderson-araujo-cavalcante/product-service/tree/main/web/WK.Web)) to upload the application.

### In Progress

- Add Tests
- Add FluentValidation
- Docker compose config