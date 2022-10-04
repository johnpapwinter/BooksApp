using BooksApp.DTO;

namespace BooksApp.Validator
{
    public class BookValidator
    {
        private BookValidator() { }

        public static string Validate(BookDTO? bookDTO)
        {
            if ((bookDTO!.Title!.Length == 0) || (bookDTO!.Author!.Length == 0))
            {
                return "Title and/or Author cannot be empty";
            }
            return "";
        }
    }
}
