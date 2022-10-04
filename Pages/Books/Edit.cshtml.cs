using BooksApp.DAO;
using BooksApp.DTO;
using BooksApp.Model;
using BooksApp.Service;
using BooksApp.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksApp.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly IBookDAO bookDAO = new BookDAOImpl();
        private readonly IBookService bookService;

        public EditModel()
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
                book = bookService!.FindBook(id);
                BookDto = ConvertToDto(book!);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }


        public void OnPost()
        {
            ErrorMessage = "";

            BookDto.Id = int.Parse(Request.Form["id"]);
            BookDto.Title = Request.Form["title"];
            BookDto.Author = Request.Form["author"];

            ErrorMessage = BookValidator.Validate(BookDto);

            if (!ErrorMessage.Equals(""))
            {
                return;
            }

            try
            {
                bookService!.UpdateBook(BookDto);
                Response.Redirect("/Books/Index");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        private BookDTO ConvertToDto(Book book)
        {
            BookDTO bookDTO = new BookDTO();
            bookDTO.Id = book.Id;
            bookDTO.Title = book.Title;
            bookDTO.Author = book.Author;

            return bookDTO;
        }
    }
}
