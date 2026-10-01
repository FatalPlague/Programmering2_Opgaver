using Pr07_WebApi.Models;

namespace Pr07_WebApi.Contracts
{
    public interface IBookRepository
    {
        Task CreateBookAsync(Book bookToBeCreated);
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);

        Task UpdateBookAsync(Book bookToBeUpdated);
        Task DeleteBookByIdAsync(int id);
    }
}
