using BookContract;
using ReservationService.DTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace ReservationService.DataAccessLayer
{
    public class BookDataAccess
    {
        private readonly HttpClient httpClient;

        public BookDataAccess(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<BookDto> GetBookById(string id)
        {
            try
            {
                BookDto book = await httpClient.GetFromJsonAsync<BookDto>("/book/" + id);
                if (book == null) { return null; }  // TODO
                Console.WriteLine(book.Name);
                return book;
            }
            catch (HttpRequestException) // Non success
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is not valid
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }
            return null;
        }
    }
}
