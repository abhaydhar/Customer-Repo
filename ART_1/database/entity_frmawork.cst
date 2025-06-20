using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
}

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Your_Connection_String");
    }
}

public class EfCoreExample
{
    // CREATE
    public void AddEmployee(string name, string department)
    {
        using (var context = new AppDbContext())
        {
            var employee = new Employee
            {
                Name = name,
                Department = department
            };
            
            context.Employees.Add(employee);
            context.SaveChanges();
        }
    }

    // READ
    public void GetAllEmployees()
    {
        using (var context = new AppDbContext())
        {
            var employees = context.Employees.ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Department: {employee.Department}");
            }
        }
    }

    // UPDATE
    public void UpdateEmployeeDepartment(int id, string newDepartment)
    {
        using (var context = new AppDbContext())
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                employee.Department = newDepartment;
                context.SaveChanges();
            }
        }
    }

    // DELETE
    public void RemoveEmployee(int id)
    {
        using (var context = new AppDbContext())
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
        }
    }
}