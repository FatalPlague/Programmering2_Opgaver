using Microsoft.EntityFrameworkCore;
using Pr07_WebApi.Contracts;
using Pr07_WebApi.Models;

namespace Pr07_WebApi.Persistence
{
    public class BookRepository : IBookRepository
    {
        private readonly WebApiContext _context;

        public BookRepository(WebApiContext context)
        {
            _context = context;
        }
        public async Task CreateBookAsync(Book book)
        {
            if (book != null)
               await _context.Books.AddAsync(book);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            List<Book> books = await _context.Books
                .AsNoTracking()
                .ToListAsync();

            return books;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            Book? book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }
        public async Task UpdateBookAsync(Book book)
        {
            Book? bookToBeUpdated = null;
            try
            {
                bookToBeUpdated = await GetBookByIdAsync(book.Id);

                if (bookToBeUpdated != null)
                {
                    bookToBeUpdated.Title = book.Title;
                    bookToBeUpdated.Author = book.Author;
                    bookToBeUpdated.Year = book.Year;
                    bookToBeUpdated.SalesPrice = book.SalesPrice;
                    bookToBeUpdated.PurchasePrice = book.PurchasePrice;

                    _context.Update(bookToBeUpdated);

                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                {
                    throw new NullReferenceException();
                }
            }
        }

        public async Task DeleteBookByIdAsync(int id)
        {
            Book book = null;

            int rowsAffected = await _context.Books.Where(b => b.Id == id).ExecuteDeleteAsync();

            if (rowsAffected == 0)
                throw new Exception();
        } 
    }
}
