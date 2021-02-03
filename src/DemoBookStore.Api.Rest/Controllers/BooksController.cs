using DemoBookStore.Api.Rest.Data;
using DemoBookStore.Api.Rest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoBookStore.Api.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks() => Ok(await _context.Books.ToListAsync());

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            if (book == null || !ModelState.IsValid) return BadRequest();
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(BooksController.GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, Book updatedBook)
        {
            if (updatedBook == null || !ModelState.IsValid) return BadRequest();

            var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
            if (book != null) return NotFound();

            _context.Entry(updatedBook).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
            if (book != null) return NotFound();
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
