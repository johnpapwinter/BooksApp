using BooksApp.DAO;
using BooksApp.DTO;
using BooksApp.Model;
using BooksApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Pages.Books
{
    public class RemoveModel : PageModel
    {
        private readonly IBookDAO bookDAO = new BookDAOImpl();
        private readonly IBookService bookService;

        public RemoveModel()
        {
            bookService = new BookServiceImpl(bookDAO);
        }

        internal BookDTO BookDto = new BookDTO();
        public string ErrorMessage = "";

        public void OnGet()
        {
            try
            {
                Book? book;

                int id = int.Parse(Request.Query["id"]);
                BookDto.Id = id;
                book = bookService!.DeleteBook(BookDto);
                Response.Redirect("/Books/Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }
    }
}
