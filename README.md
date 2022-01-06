# Microservice Learning Project - Libary architecture

A learning project made as a very simple libary architecture. 
 
## Functionality
- CRUD operations on the API.
- MongoDB Repository.
- MassTransit w/ RabbitMQ consumer and subscriber for async communication.
  - Decoupled repository and masstransit to be made as nuget packages in order to be used by all microservices.
- DataAccess layer for synchronous HTTP communication.

## Deployment

To spin up RabbitMQ and the MongoDB database: docker-compose up -d

## Built With

- REST APIs with C#.
- Docker w/ Compose.
- MassTransit w/ RabbitMQ.
- MongoDB database.
- Tried using the new Visual Studio 2022 (So smooth now that it is 64-bit) for these projects.
- With the help from the online teacher Julio Casal, his lessons showed me how the communication between microservices worked.

### Todo
- Refactor and finish ReservationService functionality.
- gRPC.
- OAuth 2.0 authentication micro-service.
- Kubernetes.
- Dapper w/ SQL Database.
- Asynchronous Propagation of data.
- Test frontend.
