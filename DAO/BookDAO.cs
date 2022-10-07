using System.Data.SqlClient;
using BooksApp.DAO.DBUtil;
using BooksApp.Model;

namespace BooksApp.DAO
{
    public class BookDAOImpl : IBookDAO
    {
        public List<Book> FindAllBooks()
        {
            List<Book> Books = new List<Book>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "SELECT * FROM BOOKS";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Book book = new Book();
                    book.Id = reader.GetInt32(0);
                    book.Title = reader.GetString(1);
                    book.Author = reader.GetString(2);
                    book.Year = reader.GetInt32(3);
                    book.Publisher = reader.GetString(4);
                    book.Room = reader.GetString(5);

                    Books.Add(book);
                }

                return Books;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }


        public Book? DeleteBook(Book? book)
        {
            if (book == null)
            {
                return null;
            }

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "DELETE FROM BOOKS WHERE ID=@id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", book.Id);

                int rowsAffected = command.ExecuteNonQuery();
                return (rowsAffected > 0) ? book : null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Book? FindBook(int id)
        {
            Book? book = null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "SELECT * FROM BOOKS WHERE ID=@id";

                using SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    book = new()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Author = reader.GetString(2),
                        Year = reader.GetInt32(3),
                        Publisher = reader.GetString(4),
                        Room = reader.GetString(5)
                };
                }

                return book;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }


        public void InsertBook(Book? book)
        {
            if (book == null)
            {
                return;
            }

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "INSERT INTO BOOKS (TITLE, AUTHOR, YEAR, PUBLISHER, ROOM) " 
                    + "VALUES (@title, @author, @year, @publisher, @room)";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@author", book.Author);
                command.Parameters.AddWithValue("@year", book.Year);
                command.Parameters.AddWithValue("@publisher", book.Publisher);
                command.Parameters.AddWithValue("@room", book.Room);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }


        public void UpdateBook(Book? book)
        {
            if (book == null)
            {
                return;
            }

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                conn!.Open();
                string sql = "UPDATE BOOKS SET TITLE=@title, AUTHOR=@author, YEAR=@year, "
                    + "PUBLISHER=@publisher, ROOM=@room WHERE ID=@id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@author", book.Author);
                command.Parameters.AddWithValue("@id", book.Id);
                command.Parameters.AddWithValue("@year", book.Year);
                command.Parameters.AddWithValue("@publisher", book.Publisher);
                command.Parameters.AddWithValue("@room", book.Room);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
