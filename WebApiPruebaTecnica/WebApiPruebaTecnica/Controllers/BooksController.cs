using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPruebaTecnica.Data;
using WebApiPruebaTecnica.Interfaces;
using WebApiPruebaTecnica.Models;

namespace WebApiPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            IEnumerable<Book> books = await _booksService.GetBooks();
            return Ok(books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            Book book = await _booksService.GetBook(id);
            return Ok(book);
            //if (book == null)
            //{
            //    return NotFound();
            //}

            //return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid id, Book book)
        {
            
            if (id != book.Id)
            {
                return BadRequest();
            }
            else
            {
                bool res = await _booksService.PutBook(book);
            }

                return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
           
            bool res = await _booksService.PostBook(book);
            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            bool res = await _booksService.DeleteBook(id);
            //if (book == null)
            //{
            //    return NotFound();
            //}

          

            return NoContent();
        }

       
    }
}
