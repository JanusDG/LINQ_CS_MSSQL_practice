using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskModels
{
    // CREATE TABLE Task1NumbersTable (Id INT IDENTITY(1,1) PRIMARY KEY, Value INT UNIQUE); 
    [Index(nameof(Value), IsUnique = true)]
    public class Task1Number
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
}