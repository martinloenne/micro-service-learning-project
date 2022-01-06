using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using ReservationService.Models;
using ReservationService.DTOs;
using ReservationService.DataAccessLayer;
using MassTransit;
using BookContract;

namespace ReservationService.Controllers
{
    [Route("reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IRepositoryBase<Reservation> reseravtionRepository;
        BookDataAccess bookDataAccess;
        private readonly IPublishEndpoint msgPublishEndpoint;

        public ReservationController(IRepositoryBase<Reservation> reseravtionRepository, BookDataAccess bookDataAccess, IPublishEndpoint msgPublishEndpoint)
        {
            this.reseravtionRepository = reseravtionRepository;
            this.bookDataAccess = bookDataAccess;
            this.msgPublishEndpoint = msgPublishEndpoint;
        }

        // POST /reservation
        [HttpPost]
        public async Task<ActionResult<ReservationDto>> Post(ReservationDto createReseverationDto)
        {
            Reservation reservation = new Reservation
            {
                BookId = createReseverationDto.BookId
            };
            await reseravtionRepository.Create(reservation);

            BookDto rentedBook = await bookDataAccess.GetBookById(createReseverationDto.BookId);

            // Publish a message with the rented/loaned book
            await msgPublishEndpoint.Publish(new BookDtoDetailed(createReseverationDto.BookId, rentedBook.Name));

            return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);
        }

        // PUT /reservation/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ReservationDto updateReservationDto)
        {
            Reservation reservation = await reseravtionRepository.Get(id);
            if (reservation == null) { return NotFound(); }

            reservation.BookId = updateReservationDto.BookId;
            await reseravtionRepository.Update(reservation);

            // TODO: Update Msg
            return Ok();
        }

        // DELETE /reservation/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var reservation = await reseravtionRepository.Get(id);
            if (reservation == null) { return NotFound(); }
            await reseravtionRepository.Remove(reservation.Id);

            // TODO: Remove reservation
            return Ok();
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDtoDetailed>>> Get()
        {
            List<ReservationDtoDetailed> result = new List<ReservationDtoDetailed>();

            var reservations = (await reseravtionRepository.GetAll()).Select(r => r.Conversion());
            
            // Get all the books
            foreach (ReservationDtoDetailed res in reservations) {
                BookDto rentedBook = await bookDataAccess.GetBookById(res.RentedBook.Id);
                result.Add(new ReservationDtoDetailed(res.Id, res.RentedBook.Id, rentedBook.Name));
            };

            return Ok(result);
        }

        // GET /reservation/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDtoDetailed>> GetById(Guid id)
        {
            Reservation reservation = await reseravtionRepository.Get(id);
            if (reservation == null) { return NotFound(); }
            BookDto rentedBook = await bookDataAccess.GetBookById(reservation.BookId);
            ReservationDtoDetailed result = new ReservationDtoDetailed(reservation.Id, reservation.BookId, rentedBook.Name);
            return result;
        }
    }
}
