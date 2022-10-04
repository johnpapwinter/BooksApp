using BooksApp.DAO;
using BooksApp.DTO;
using BooksApp.Model;

namespace BooksApp.Service
{
    public class BookServiceImpl : IBookService
    {
        private readonly IBookDAO bookDAO;

        public BookServiceImpl(IBookDAO bookDAO)
        {
            this.bookDAO = bookDAO;
        }


        public Book? DeleteBook(BookDTO? bookDTO)
        {
            if (bookDTO == null)
            {
                return null;
            }

            Book? book;
            book = ConvertToBook(bookDTO);

            try
            {
                return bookDAO.DeleteBook(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }


        public List<Book> FindAllBooks()
        {
            try
            {
                return bookDAO.FindAllBooks();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return new List<Book>();
            }
        }

        public Book? FindBook(int id)
        {
            try
            {
                return bookDAO.FindBook(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }


        public void InsertBook(BookDTO? bookDTO)
        {
            if (bookDTO == null)
            {
                return;
            }

            Book? book;
            book = ConvertToBook(bookDTO);

            try
            {
                bookDAO.InsertBook(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }


        public void UpdateBook(BookDTO? bookDTO)
        {
            if (bookDTO == null)
            {
                return;
            }

            Book? book;
            book = ConvertToBook(bookDTO);

            try
            {
                bookDAO.UpdateBook(book);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }


        private Book? ConvertToBook(BookDTO bookDTO)
        {
            if (bookDTO == null)
            {
                return null;
            }

            return new Book
            {
                Id = bookDTO.Id,
                Title = bookDTO.Title,
                Author = bookDTO.Author
            };
        }
    }
}
