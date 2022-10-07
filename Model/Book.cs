namespace BooksApp.Model
{
    public class Book : IdentifiableEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }
        public string? Publisher { get; set; }
        public string? Room { get; set; }
    }
}
