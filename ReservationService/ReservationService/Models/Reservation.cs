using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Repository.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ReservationService.Models
{
    public class Reservation : IEntity
    {
        // Common for all models across all microservices is that that they need a ID as defined by IEntity
        public Guid Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string BookId { get; set; }
    }
}
