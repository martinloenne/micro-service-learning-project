using BookContract;
using MassTransit;

namespace Fulfillment.Consumers
{
    public class BookLented : IConsumer<BookDtoDetailed>
    {
        public async Task Consume(ConsumeContext<BookDtoDetailed> consumeContext)
        {
            BookDtoDetailed bookMsg = consumeContext.Message;
            // TODO: Business logic with printing the book to the libary
            System.Diagnostics.Debug.WriteLine(bookMsg.Id, bookMsg.Name);
        }
    }
}
