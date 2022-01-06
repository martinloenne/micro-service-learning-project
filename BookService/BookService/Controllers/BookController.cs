using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Interfaces;
using BookService.DTOs;
using BookService.Models;
using System.Net;

namespace BookService.Controllers
{

    [ApiController]
    [Route("book")]
    public class BookController : ControllerBase
    {

        private readonly IRepositoryBase<Book> bookRepository;
        //private readonly IPublishEndpoint MsgPublishEndpoint;

        public BookController(IRepositoryBase<Book> bookRepository)//, IPublishEndpoint MsgPublishEndpoint)
        {
            this.bookRepository = bookRepository;
            //this.MsgPublishEndpoint = MsgPublishEndpoint;
        }

        // POST /book
        [HttpPost]
        public async Task<ActionResult<BookDto>> Post(BookDto createBookDto)
        {
            Book book = new Book
            {
                Name = createBookDto.Name
            };
            await bookRepository.Create(book);
            //await MsgPublishEndpoint.Publish(new CatalogBookCreated(book.Id, book.Name, book.Description));
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        // PUT /book/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, BookDto updateBookDto)
        {
            Book book = await bookRepository.Get(id);
            if (book == null) { return NotFound(); }

            book.Name = updateBookDto.Name;
            await bookRepository.Update(book);

            //await MsgPublishEndpoint.Publish(new CatalogBookUpdated(existingBook.Id, existingBook.Name, existingBook.Description));

            return Ok();
        }

        // DELETE /book/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await bookRepository.Get(id);
            if (book == null) { return NotFound(); }
            await bookRepository.Remove(book.Id);

            //await MsgPublishEndpoint.Publish(new CatalogBookDeleted(id));

            return Ok();
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> Get()
        {
            var books = (await bookRepository.GetAll()).Select(book => book.Conversion());
            return Ok(books);
        }

        // GET /book/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetById(Guid id)
        {
            Book book = await bookRepository.Get(id);
            if (book == null) { return NotFound(); }
            return book.Conversion();
        }
    }
}
