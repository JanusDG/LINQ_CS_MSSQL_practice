using System;
using Microsoft.EntityFrameworkCore;
using TaskSolver.Models;

namespace TaskSolver.Data
{
    
    public class TasksDbContext : DbContext
    {
        public DbSet<Task1Number> Task1NumbersTable { get; set; }
        public DbSet<Task4Number> Task4NumbersTable { get; set; }
        public DbSet<Task5Symbol> Task5SymbolsTable { get; set; }
        public DbSet<Task6Date> Task6DatesTable { get; set; }
        public DbSet<Task8String> Task8StringsTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=Db4Tasks;User Id=SA;Password=&e!dXne};TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task1Number>()
                .HasAlternateKey(t => t.Value); //  essentially a unique constraint in the database.

            modelBuilder.Entity<Task6Date>()
                .HasAlternateKey(t => t.Value);
                
        }
    }
}