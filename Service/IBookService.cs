using BooksApp.DTO;
using BooksApp.Model;

namespace BooksApp.Service
{
    public interface IBookService
    {
        List<Book> FindAllBooks();
        Book? FindBook(int id);
        void InsertBook(BookDTO? bookDTO);
        void UpdateBook(BookDTO? bookDTO);
        Book? DeleteBook(BookDTO? bookDTO);
    }
}
