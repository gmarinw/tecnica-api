using WebApiPruebaTecnica.Models;

namespace WebApiPruebaTecnica.Interfaces
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBook(Guid id);
        Task<bool> PutBook(Book book);
        Task<bool> PostBook(Book book);
        Task<bool> DeleteBook(Guid id);
    }
}
