namespace BookService.DTOs
{
    public class BookDto
    {
        public BookDto(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
