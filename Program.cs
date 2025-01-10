using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using TaskModels;


public class TasksDbContext : DbContext
{
    public DbSet<Task1Number> Task1NumbersTable { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=Db4Tasks;User Id=SA;Password=;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

class Program
{
    static void Main()
    {
        using (var task1DbContext = new TasksDbContext())
        {
            task1DbContext.Database.EnsureCreated();

            for (int i = 0; i < 10; i++)
            {   
                // populate with entries if they do not exist
                var existingEntry = task1DbContext.Task1NumbersTable.FirstOrDefault(t => t.Value == i);
                if (existingEntry == null)
                {
                    task1DbContext.Task1NumbersTable.Add(new Task1Number { Value = i });
                    task1DbContext.SaveChanges();
                }
                
            }
            
            Console.WriteLine("All number entries: ");
            var numbers = task1DbContext.Task1NumbersTable.ToList();
            foreach (var number in numbers )
            {
                Console.WriteLine($"ID: {number.Id}, Value: {number.Value}");
            }
            
            Console.Write("Only even number entries: \n");
            var evenNumbers = task1DbContext.Task1NumbersTable.Where(t => t.Value % 2 == 0).ToList();
            foreach (var even in evenNumbers )
            {
                Console.WriteLine($"ID: {even.Id}, Value: {even.Value}");
            }
        }
    }
}
