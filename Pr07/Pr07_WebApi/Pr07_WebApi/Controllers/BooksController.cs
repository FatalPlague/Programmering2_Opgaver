using Mapster;
using Microsoft.AspNetCore.Mvc;
using Pr07_WebApi.Contracts;
using Pr07_WebApi.DTOs;
using Pr07_WebApi.Models;

namespace Pr07_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            List<Book> books = await _bookRepository.GetAllBooksAsync();

            ////mapper books liste til bookDtos liste med mapster
            List<BookDto> bookDtos = books.Adapt<List<BookDto>>();

            ////mapper book object til BookDto objekt uden mapster
            //List<BookDto> bookDtos = new List<BookDto>();
            //foreach (Book book in books)
            //{
            //    bookDtos.Add(new BookDto
            //    {
            //        Id = book.Id,
            //        Title = book.Title,
            //        Author = book.Author,
            //        Year = book.Year,
            //        SalesPrice = book.SalesPrice
            //    });
            //}
            
            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            if (id <= 0)
                return BadRequest("Id skal være over 0");

            Book book = await _bookRepository.GetBookByIdAsync(id);
            
            if (book == null)
                return NotFound("Bog findes ikke");

            ////mapper book til bookDto med Maspter
            //bookDto = book.Adapt<BookDto>();

            ////mapper book til bookDto uden mapster
            BookDto bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Year = book.Year,
                SalesPrice = book.SalesPrice
            };




            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            book.Id = 0;
            
            await _bookRepository.CreateBookAsync(book);

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (id <= 0 || id != book.Id)
                return BadRequest();

            try
            {
                await _bookRepository.UpdateBookAsync(book);
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                    {
                        return NotFound();
                    }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                await _bookRepository.DeleteBookByIdAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return Ok();


        }
    }
}
