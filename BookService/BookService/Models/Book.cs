using Repository.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BookService.Models
{
    public class Book : IEntity // IEntity is derived from our repository
    {
        // Common for all models across all microservices is that that they need a ID as defined by IEntity
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }
    }
}
