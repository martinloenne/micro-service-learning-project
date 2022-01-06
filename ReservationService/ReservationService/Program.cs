using ReservationService.Models;
using Repository.Configuration;
using ReservationService.DataAccessLayer;
using ServiceBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Database
// TODO: Address needs to be in settings
builder.Services.StartMongoDatabase<Reservation>("reservations", "reservation", "mongodb://localhost:27017"); // The parametre specifies model type and the collection in the database

// Add DataAccessLayer
// TODO: Address needs to be in settings
builder.Services.AddHttpClient<BookDataAccess>(layer => { layer.BaseAddress = new Uri("https://localhost:7189"); });

// Add MassTransit RabbitMQ Bus
// TODO: Address needs to be in settings
builder.Services.AccessRabbitMqBus("localhost", "Reservation");

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
