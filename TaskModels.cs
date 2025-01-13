using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskModels
{
    [Index(nameof(Value), IsUnique = true)]
    public class Task1Number
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Value { get; set; }
    }

    public class Task4Number
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Value { get; set; }
    }

    public class Task5Symbol
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }
    }

    [Index(nameof(Value), IsUnique = true)]
    public class Task6Date
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Value { get; set; }
    }

    public class Task8String
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }
    }
}