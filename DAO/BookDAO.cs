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
                        Author = reader.GetString(2)
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
                string sql = "INSERT INTO BOOKS (TITLE, AUTHOR) VALUES (@title, @author)";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@author", book.Author);

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
                string sql = "UPDATE BOOKS SET TITLE=@title, AUTHOR=@author WHERE ID=@id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@author", book.Author);
                command.Parameters.AddWithValue("@id", book.Id);

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
