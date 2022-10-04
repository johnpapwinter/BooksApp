using BooksApp.DAO;
using BooksApp.DTO;
using BooksApp.Service;
using BooksApp.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Pages.Books
{
    public class AddModel : PageModel
    {
        private readonly IBookDAO bookDAO = new BookDAOImpl();
        private readonly IBookService bookService;

        public AddModel()
        {
            bookService = new BookServiceImpl(bookDAO);
        }

        internal BookDTO BookDto = new();
        public string ErrorMessage = "";
        public string SuccessMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            ErrorMessage = "";
            SuccessMessage = "";

            BookDto.Title = Request.Form["title"];
            BookDto.Author = Request.Form["author"];

            ErrorMessage = BookValidator.Validate(BookDto);

            if (!ErrorMessage.Equals(""))
            {
                return;
            }

            try
            {
                bookService.InsertBook(BookDto);
                Console.WriteLine("New book successfully inserted");

                Response.Redirect("Books/Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        private void ResetFields()
        {
            BookDto.Title = "";
            BookDto.Author = "";
        }
    }
}
