using ReservationService.Models;

namespace ReservationService.DTOs
{
    public static class ReservationDtoConversion
    {
        public static ReservationDtoDetailed Conversion(this Reservation reservation)
        {
            return new ReservationDtoDetailed(reservation.Id, reservation.BookId, null);
        }
    }
}
