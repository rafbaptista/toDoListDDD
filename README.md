# To Do List Application

## Interface

This is a very simple application, where you can register a person, with name, age, gender and optionally upload a picture, and then you can create a task and assign to that person.

Each task has a description, category, status, delivery date and a person responsable for it, which can be chosen by the user at any time.

## Technologies 

Although very simple, this project was built using a lot of technologies, some of them just for knowledge and didactic purposes:

• .NET Framework 4.6.1  
• ASP.NET MVC 5  
• SQL Server  
• Entity Framework Code First 6.4  
• Fluent API (Mapping)
• Bootstrap 4.4.1  
• AutoMapper 7.0.1  
• Chart.js 2.9.3  
• Simple Injector 4.9.2  

## Architecture

For didactic purposes, this project was built based on DDD (Domain Driven Design), whose objective is to facilite the implementation of complex rules and processes, diving responsabilities by layers and being independent of the technology used.  

This solution is divided into:  

#### Presentation

Responsable for the startup project, contains the views that will be rendered to the user and also for receiving all HTTP requests and direct them to a service to perform an action.

#### Domain

Responsable for implementing classes which will be mapped to the database, in addition to obtaining interfaces and enums declarations

#### Service

Responsable for keeping the business rules, validations and communication with the repository classes

#### Infrastructure

Responsable for persistence with the database, configurations about context, databases initializers
