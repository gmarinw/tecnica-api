using Microsoft.EntityFrameworkCore;
using WebApiPruebaTecnica.Data;
using WebApiPruebaTecnica.Interfaces;
using WebApiPruebaTecnica.Models;

namespace WebApiPruebaTecnica.Business
{
    public class BooksService : IBooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {

            IEnumerable<Book> books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetBook(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            return book;
        }

        public async Task<bool> PutBook(Book book)
        {
            int res = 0;
            if (BookExists(book.Id))
            {
                _context.Entry(book).State = EntityState.Modified;

                try
                {
                    res = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return false;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                return false;
            }

            return res > 0 ? true : false;
        }

        public async Task<bool> PostBook(Book book)
        {
            _context.Books.Add(book);
            int res = await _context.SaveChangesAsync();
            return res > 0 ? true : false;
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            Book book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            int res = await _context.SaveChangesAsync();
            return res > 0 ? true : false;
        }

        private bool BookExists(Guid id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

    }
}
