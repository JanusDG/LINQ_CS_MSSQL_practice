using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

using TaskSolver.Models;
using TaskSolver.Data;
using TaskSolver.Services;


class Program
{
    static void Main()
    {
        Console.WriteLine("Which task would you like to run?(1-30):");
        string taskNumber = Console.ReadLine();

        if (int.TryParse(taskNumber, out int taskNumberInt))
        {
            if (taskNumberInt >= 1 && taskNumberInt <= 30)
            {
                var context = new TasksDbContext();
                context.Database.EnsureCreated();
                var tasksService = new LinqTasksService(context);

                switch (taskNumberInt)
                    {
                        case 1:
                            tasksService.DoTask1();                            
                            break;
                        case 2:
                            tasksService.DoTask2();                            
                            break;
                        case 3:
                            tasksService.DoTask3();                            
                            break;
                        case 4:
                            tasksService.DoTask4();                            
                            break;
                        case 5:
                            tasksService.DoTask5();                            
                            break;
                        case 6:
                            tasksService.DoTask6();                            
                            break;
                        case 7:
                            tasksService.DoTask7();                            
                            break;
                        case 8:
                            tasksService.DoTask8();                            
                            break;
                        case 9:
                            tasksService.DoTask9();                            
                            break;
                        case 10:
                            tasksService.DoTask10();
                            
                            break;
                        
                        default:
                            Console.WriteLine("Task not yet implemented");
                            break;
                    }
            }
            else
            {
                Console.WriteLine("The number is out of the valid range (1 to 30).");
            }
        }
        else
        {
            Console.WriteLine("Invalid task number. Please enter a valid integer.");
        }
    }
}