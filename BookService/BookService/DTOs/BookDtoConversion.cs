using BookService.Models;


namespace BookService.DTOs
{
    public static class BookDtoConversion
    {
        public static BookDto Conversion(this Book book)
        {
            return new BookDto(book.Name);
        }
    }
}
