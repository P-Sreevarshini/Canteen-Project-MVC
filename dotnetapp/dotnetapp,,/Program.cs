using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class Program
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public static void Main(string[] args)
    {
        string connectionString ="User ID=sa;password=examlyMssql@123; server=localhost;Database=appdb7;trusted_connection=false;Persist Security Info=False;Encrypt=False"
;

        // Create (INSERT)
        User newUser = new User { Name = "John Doe", Email = "john@example.com" };
        InsertUser(newUser, connectionString);

        // Read (SELECT)
        List<User> users = RetrieveUsers(connectionString);
        Console.WriteLine("Users in the database:");
        foreach (var user in users)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email}");
        }

        // Update (UPDATE)
        User userToUpdate = users.Find(u => u.Id == 1);
        if (userToUpdate != null)
        {
            userToUpdate.Email = "newemail@example.com";
            UpdateUser(userToUpdate, connectionString);
        }

        // Delete (DELETE)
        DeleteUser(1, connectionString);
    }

    // Insert user into the database
    public static void InsertUser(User user, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Retrieve all users from the database
    public static List<User> RetrieveUsers(string connectionString)
    {
        List<User> users = new List<User>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id, Name, Email FROM Users";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User user = new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString()
                };
                users.Add(user);
            }
            reader.Close();
        }
        return users;
    }

    // Update user in the database
    public static void UpdateUser(User user, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Users SET Email = @Email WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Id", user.Id);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    // Delete user from the database
    public static void DeleteUser(int userId, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Users WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", userId);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
