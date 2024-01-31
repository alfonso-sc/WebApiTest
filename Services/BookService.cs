using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Services
{
    public class BookService
    {

        List<Book> OurBooks = new List<Book>
            {
            new Book
            {
                Id = 1,
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                Genre = "Fiction",
                PageCount = 281,
                ReleaseDate = new DateOnly(1960, 7, 11),
                CurrentRanking = 1
            },
            new Book
            {
                Id = 2,
                Title = "1984",
                Author = "George Orwell",
                Genre = "Dystopian Fiction",
                PageCount = 328,
                ReleaseDate = new DateOnly(1949, 6, 8),
                CurrentRanking = 2
            },
            new Book
            {
                Id = 3,
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                Genre = "Romance",
                PageCount = 279,
                ReleaseDate = new DateOnly(1813, 1, 28),
                CurrentRanking = 3
            },
            new Book
            {
                Id = 4,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Genre = "Fiction",
                PageCount = 180,
                ReleaseDate = new DateOnly(1925, 4, 10),
                CurrentRanking = 4
            },
            new Book
            {
                Id = 5,
                Title = "Harry Potter and the Philosopher's Stone",
                Author = "J.K. Rowling",
                Genre = "Fantasy",
                PageCount = 223,
                ReleaseDate = new DateOnly(1997, 6, 26),
                CurrentRanking = 5
            },
            new Book
            {
                Id = 6,
                Title = "The Catcher in the Rye",
                Author = "J.D. Salinger",
                Genre = "Fiction",
                PageCount = 224,
                ReleaseDate = new DateOnly(1951, 7, 16),
                CurrentRanking = 6
            },
            new Book
            {
                Id = 7,
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                Genre = "Fantasy",
                PageCount = 310,
                ReleaseDate = new DateOnly(1937, 9, 21),
                CurrentRanking = 7
            },
            new Book
            {
                Id = 8,
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                Genre = "Fiction",
                PageCount = 281,
                ReleaseDate = new DateOnly(1960, 7, 11),
                CurrentRanking = 8
            },
            new Book
            {
                Id = 9,
                Title = "Lord of the Flies",
                Author = "William Golding",
                Genre = "Fiction",
                PageCount = 224,
                ReleaseDate = new DateOnly(1954, 9, 17),
                CurrentRanking = 9
            },
            new Book
            {
                Id = 10,
                Title = "Moby-Dick",
                Author = "Herman Melville",
                Genre = "Adventure",
                PageCount = 624,
                ReleaseDate = new DateOnly(1851, 10, 18),
                CurrentRanking = 10
            }
        };

        public List<Book> getAllBooks()
        {
            return OurBooks;
        }

        public Book getOneBook()
        {
            return OurBooks[0];
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            return OurBooks.FindAll((book) => book.Author == author);
        }

        public Book addBook(Book book)
        {
            OurBooks.Add(book);
            return book;
        }

        public bool deleteBookById(int Id)
        {
            if (OurBooks.Any((b) => b.Id.Equals(Id)))
            {
                Book? book = OurBooks.FirstOrDefault((b) => b.Id.Equals(Id));
                return OurBooks.Remove(book!);
            }

            return false;
        }

        public Book? getBookById(int Id)
        {
            Book? book = OurBooks.Find((b) => b.Id == Id);
            return book;
        }
    }
}
