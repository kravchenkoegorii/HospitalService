# HospitalService RESTful Web Api

## Description

ASP NET Core WEB API with 3-layer architecture.

![AppSchema](/HospitalService/ArchPng.png)

I create a 'REST API' for doctors/patients data with 'CRUD' options. For authorization is used JWT Bearer.
The appllication is deployed on Azure Cloud. 
It uses Azure Service Bus to send messages to [HospitalService.MessageConsumer](https://github.com/kravchenkoegorii/HospitalService.MessageConsumer.git) about creating new Doctor/Patient.

## Technology stack

- **SDK:** `.NET 6`
- **Frameworks:** `ASP.NET Core`
- **Persistence:**
    - Database: `Azure Database for PostgreSQL`
    - ORM: `Entity Framework Core 6.0`
- **Authorization:** `JWT Bearer`
- **Presentation:** API Documentation: `Swagger`
- **Unit and Integration Testing:** `XUnit`, `Moq`
- **Programming languages:** `C#`
- **Tools & IDE:** `Visual Studio`, `Rider`, `Postman`

## Versions

- **.NET SDK:** `.NET 6.0.302`

## Online

- Github: https://github.com/kravchenkoegorii/HospitalService.git
- HospitalService: https://hospitalserviceapi.azurewebsites.net/swagger
