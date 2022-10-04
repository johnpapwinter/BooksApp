using BooksApp.DAO;
using BooksApp.Model;
using BooksApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly IBookDAO bookDAO = new BookDAOImpl();
        private readonly IBookService? bookService;

        public List<BooksApp.Model.Book> Books = new();

        public IndexModel()
        {
            bookService = new BookServiceImpl(bookDAO);
        }

        public void OnGet()
        {
            try
            {
                Books = bookService!.FindAllBooks();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
