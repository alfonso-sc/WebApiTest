using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Models;
using WebApiTest.Services;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        BookService bookService;
        public BookController(BookService _bookService)
        {
            bookService = _bookService;
        }

        [HttpGet("GetAllBooks")]
        public ActionResult<List<Book>> GetAllBooks()
        {
            return Ok(bookService.getAllBooks());
        }

        [HttpGet("GetBooksByAuthor")]
        public ActionResult<Book> GetOneGetBooksByAuthorBook(string author)
        {
            return Ok(bookService.GetBooksByAuthor(author));
        }


        [HttpGet("GetOneBook")]
        public ActionResult<Book> GetOneBook()
        {
            return Ok(bookService.getOneBook());
        }

        [HttpPost("AddBook")]
        public ActionResult<Music> AddBook(Book book)
        {
            return Ok(bookService.addBook(book));
        }

        [HttpDelete("DeleteBookById")]
        public ActionResult<bool> DeleteBook(int Id)
        {
            return bookService.deleteBookById(Id);
        }

        [HttpGet("GetBookById")]
        public ActionResult<Book> GetBookById(int Id)
        {
            Book? book = bookService.getBookById(Id);
            if (book != null)
            {
                return Ok(book);
            }
            // return StatusCode(418, "No book found with given Id");
            return BadRequest("No book found with given Id");

        }
    }
}
