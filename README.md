# dotnetcore-mongo-bookstore

A Sample Application to demonstrate working with NoSQL via MongoDB from an Angular-DotnetCore application. This solution helps you to quickly get started working with MongoDB database integration in ASP.NET Core, all while following the best practices and a Clean Architecture.

# What is MongoDB?

MongoDB is an open-source cross platform document-oriented database. It stores data records in the form of JSON-like structures and is classified as a NoSQL data store. It also supports scalability and replication and is one of the most popular options for NoSQL data store usecases.

# What does this solution offer?

This solution helps you get a clear picture about how to configure and connect to any MongoDB server/database and perform basic CRUD operations. The solution is built using Angular SPA hosted in ASP.NET Core so that you can find the solution in action just by running it.

# Features

1. Layered architecture with seperated UI, Core and Contracts libraries
2. DB Interactions built using Repository pattern and follows all SOLID principles
3. Angular UI which facilitates CRUD operations performed over the database
4. API validates payload using Fluent Validations
5. Docker scripts included making the solution container deployment ready
6. One command setup using Docker-Compose, file included

# How to get started

To get started, just pull the solution into your local directory and run the below command in your Terminal / Command-Line (requires a running Docker setup)

```
> docker-compose up --force-recreate --build
```

Once the container is up, visit http://localhost:5000 in your local browser. You should see the application running as below:

![MongoBookStore in Action](assets/bookstore.png?raw=true "MongoBookStore solution")

# Show your Support 

Leave a Star if you find the solution useful. If you find the article helpful, support me by:

<a href="https://www.buymeacoffee.com/referbruv" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" height="41" width="174"></a>

For more detailed articles and how-to guides, visit https://referbruv.com