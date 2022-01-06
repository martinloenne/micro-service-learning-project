using BookContract;

namespace ReservationService.DTOs
{
    public class ReservationDtoDetailed
    {
        public ReservationDtoDetailed(Guid id, string rentedBookId, string? bookName)
        {
            Id = id;
            RentedBook = new BookDtoDetailed(rentedBookId, bookName);
        }

        public Guid Id { get; set; }

        public BookDtoDetailed RentedBook { get; set; }
    }
}
