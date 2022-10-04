using System.Data.SqlClient;

namespace BooksApp.DAO.DBUtil
{
    public class DBHelper
    {
        private static SqlConnection? conn;

        private DBHelper() { }

        public static SqlConnection? GetConnection()
        {
            try
            {
                string url = "Data Source=LAPTOP-7DQF5DH6\\SQLEXPRESS;Initial Catalog=BooksDB;Integrated Security=True";

                conn = new SqlConnection(url);
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public static void CloseConnection()
        {
            conn?.Close();
        }
    }
}
