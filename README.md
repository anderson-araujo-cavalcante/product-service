# product-service

> Repository for products domain. 

## Current Entities

|Entity|Description|
|------|-----------|
|Category|Represents the category group that the product belongs to|
|Product|Represents the basic information of the product.|

## Web Reference

ASP.NET Core MVC CORE (.Net8)

## API Reference

ASP.NET Core Web API (.Net8)

## Database 📂

- Currently this API uses MySql(8.0) as a database.  
    ports:
      - "3306:3306"
    environment:
      - MYSQL_DATABASE=Product
      - MYSQL_PASSWORD=wk123!
      - MYSQL_USER=wk
      - MYSQL_ROOT_PASSWORD=123456
- ORM Entity Framework Core 8

## Local Usage

**Database**
1. When running the application, migrate will be executed, which will create the entities automatically;
2. another option, execute script ([initialDatabaseScript file](https://github.com/anderson-araujo-cavalcante/product-service/tree/main/api-product/database)) to create database and entities;

**API**
1. Run solution api ([api-product.sln](https://github.com/anderson-araujo-cavalcante/product-service/tree/main/api-product)) to make routes available.

**Web**
1. Run solution web ([WK.Web.sln](https://github.com/anderson-araujo-cavalcante/product-service/tree/main/web/WK.Web)) to upload the application.

## In Progress

- Add Tests
- Add FluentValidation
- Docker compose config
