namespace BookService.DTOs
{
    public class BookDtoDetailed
    {
        public BookDtoDetailed(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
