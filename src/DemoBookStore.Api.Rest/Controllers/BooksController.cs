using DemoBookStore.Application.Books.Commands.CreateBook;
using DemoBookStore.Application.Books.Commands.DeleteBook;
using DemoBookStore.Application.Books.Commands.ReviewBook;
using DemoBookStore.Application.Books.Commands.UpdateBookPrice;
using DemoBookStore.Application.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DemoBookStore.Api.Rest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{title}")]
        public async Task<IActionResult> GetBook(string title)
        {
            //var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
            //if (book == null) return NotFound();
            //return Ok(book);
            //var book = await Mediator.Send(new )
            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetBooksResponse>>> GetBooks(
            CancellationToken cancellationToken,
            [FromQuery] GetBooksQuery query
        ) => Ok(await _mediator.Send(query, cancellationToken));

        [HttpPost]
        public async Task<ActionResult<CreateBookResponse>> CreateBook(
            CancellationToken cancellationToken,
            CreateBookCommand createBookCommand)
        {
            var result = await _mediator.Send(createBookCommand, cancellationToken);
            return CreatedAtAction(nameof(BooksController.GetBook), new { title = result.Title }, result);
        }

        [HttpPost("{title}/pricing")]
        public async Task<IActionResult> UpdateBookPrice(
            CancellationToken cancellationToken,
            [FromBody] UpdateBookPriceCommand updatedBookPriceCommand)
        {
            await _mediator.Send(updatedBookPriceCommand, cancellationToken);
            return NoContent(); // TODO: Should return 201 and return Book? BookPrice?
        }

        [HttpPost("{title}/reviews")]
        public async Task<IActionResult> CreateBookReview(
            CancellationToken cancellationToken,
            [FromBody] ReviewBookCommand reviewBookCommand)
        {
            await _mediator.Send(reviewBookCommand, cancellationToken);
            return NoContent(); // TODO: Should return 201 and return Book? BookReview?
        }

        [HttpDelete("{title}")]
        public async Task<IActionResult> DeleteBook(
            CancellationToken cancellationToken,
            [FromRoute] string title)
        {
            await _mediator.Send(new DeleteBookCommand { Title = title }, cancellationToken);
            return NoContent();
        }
    }
}
