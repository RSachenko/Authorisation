using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KT1_3
{
    public static class DatabaseHelper
    {
        private const string ConnectionString = "Data Source=DESKTOP-8604I9P\\SQLEXPRESS;Initial Catalog=flights;Integrated Security=True";

        public static bool ValidateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        public static void AddUser(string username, string password, string name, string lastName, string patronymic)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "INSERT INTO Users (Username, Password, Name, LastName, Patronymic) VALUES (@Username, @Password, @Name, @LastName, @Patronymic)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Patronymic", patronymic);
                    command.ExecuteNonQuery();
                }
            }
        }
        public static bool UserExists(string username)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public static List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Orders";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                flightDirection = Convert.ToString(reader["flightDirection"]),
                                flightId = Convert.ToInt32(reader["flightId"]),
                                airplane = Convert.ToString(reader["airplane"]),
                                airline = Convert.ToString(reader["airline"]),
                                arrivalTime = Convert.ToString(reader["arrivalTime"]),
                                departureTime = Convert.ToString(reader["departureTime"])
                            };
                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }
    }
}
