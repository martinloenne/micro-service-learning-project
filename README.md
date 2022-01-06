# Microservice Learning Project - Libary architecture

A microservice learning project made as a very simple libary architecture. 

BookService contains all the books in the libary, where as the ReservationService contains all reservations of books. When a book is rented through the reservation service a GUID for the book needs to be supplied.

To learn synchronous calls I made it so when getting a reservation, the service will make a synchronous call to bookService to fetch the books information to fill out the model for the books in the reservation.

To learn asynchronous communcation I made it so when a reservation is made a message is published and consumed by the FufillmentService. The though being that the fufillment service will handle all the logistics of getting the book to the customer.

![alt text](https://github.com/martinloenne/micro-service-learning-project/blob/master/diagram.png)
 
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
- .Net 6.0
- Docker w/ Compose.
- MassTransit w/ RabbitMQ.
- MongoDB database.
- Tried using the new Visual Studio 2022 (So smooth now that it is 64-bit) for these projects.
- With the help from the online teacher Julio Casal, his lessons showed me how the communication between microservices worked.

### Todo
- [ ]  Refactor and finish ReservationService functionality.
- [ ]  gRPC.
- [ ]  OAuth 2.0 authentication micro-service.
- [ ]  Kubernetes.
- [ ]  Dapper w/ SQL Database.
- [ ]  Asynchronous Propagation of data.
- [ ]  Test frontend.
- [ ]  API Gateway.
- [ ]  Azure.
- [ ]  Implement HTTP call retries with exponential backoff with Polly.
