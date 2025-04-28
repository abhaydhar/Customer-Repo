using System;
using System.Data;
using System.Data.SqlClient;

public class AdoNetExample
{
    private readonly string _connectionString;

    public AdoNetExample(string connectionString)
    {
        _connectionString = connectionString;
    }

    // CREATE
    public void CreateEmployee(string name, string department)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            const string query = @"INSERT INTO Employees (Name, Department) 
                                   VALUES (@Name, @Department)";
            
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Department", department);
                
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    // READ
    public void ReadEmployees()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            const string query = "SELECT * FROM Employees";
            
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Department: {reader["Department"]}");
                    }
                }
            }
        }
    }

    // UPDATE
    public void UpdateEmployee(int id, string newDepartment)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            const string query = @"UPDATE Employees 
                                   SET Department = @Department 
                                   WHERE Id = @Id";
            
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Department", newDepartment);
                
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    // DELETE
    public void DeleteEmployee(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            const string query = "DELETE FROM Employees WHERE Id = @Id";
            
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}