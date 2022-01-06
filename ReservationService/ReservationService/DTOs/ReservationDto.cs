namespace ReservationService.DTOs
{
    public class ReservationDto
    {
        public ReservationDto(string bookId)
        {
            BookId = bookId;
        }

        public string BookId { get; set; }
    }
}
