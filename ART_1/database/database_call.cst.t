using System;
using System.Data;
using System.Data.SqlClient;

public class AdoNetExampleForProducts
{
    private readonly string _connectionString;

    public AdoNetExampleForProducts(string connectionString)
    {
        _connectionString = connectionString;
    }

    // CREATE
    public void CreateProduct(string name, decimal price)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            const string query = @"INSERT INTO Products (Name, Price) 
                                   VALUES (@Name, @Price)";
            
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Price", price);
                
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    // READ
    public void ReadProducts()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            const string query = "SELECT * FROM Products";
            
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Price: {reader["Price"]}");
                    }
                }
            }
        }
    }

    // UPDATE
    public void UpdateProduct(int id, decimal newPrice)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            const string query = @"UPDATE Products 
                                   SET Price = @Price 
                                   WHERE Id = @Id";
            
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Price", newPrice);
                
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    // DELETE
    public void DeleteProduct(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            const string query = "DELETE FROM Products WHERE Id = @Id";
            
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
