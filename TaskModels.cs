using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskSolver.Models
{
    public class TaskBaseSingleValue<T>{
        [Key]
        public int Id { get; set; }
        [Required]
        public T Value { get; set; }
    }

    public class Task1Number : TaskBaseSingleValue<int>{}
    public class Task4Number : TaskBaseSingleValue<int>{}
    public class Task5Symbol : TaskBaseSingleValue<string>{}
    public class Task6Date : TaskBaseSingleValue<DateTime>{}
    public class Task8String : TaskBaseSingleValue<string>{}
}