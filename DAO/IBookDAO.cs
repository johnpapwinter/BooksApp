using BooksApp.Model;

namespace BooksApp.DAO
{
    public interface IBookDAO
    {
        Book? FindBook(int id);
        List<Book> FindAllBooks();
        void InsertBook(Book? book);
        void UpdateBook(Book? book);
        Book? DeleteBook(Book? book);
    }
}
