using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TaskModels;
using System.Globalization;

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
            "Server=localhost;Database=Db4Tasks;User Id=SA;Password=;TrustServerCertificate=True;");
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
                switch (taskNumberInt)
                {
                    case 0:
                        var culture = CultureInfo.GetCultureInfo("en-US");
                        Console.WriteLine($"Culture Name: {culture.Name}");
                        break;
                    case 1:
                        using (var task1DbContext = new TasksDbContext())
                        {
                            task1DbContext.Database.EnsureCreated();

                            for (int i = 0; i < 10; i++)
                            {
                                // populate with entries if they do not exist
                                var existingEntry = task1DbContext.Task1NumbersTable.FirstOrDefault(t => t.Value == i);
                                if (existingEntry == null)
                                {
                                    task1DbContext.Task1NumbersTable.Add(new Task1Number { Value = i }); // create new instance, because you might need it later
                                    task1DbContext.SaveChanges();
                                }

                            }

                            Console.WriteLine("All number entries: ");
                            var numbers = task1DbContext.Task1NumbersTable.Select(n => n.Value).ToList();
                            foreach (var number in numbers)
                            {
                                Console.WriteLine($"{number}");
                            }

                            Console.Write("Only even number entries: \n");
                            var evenNumbers = task1DbContext.Task1NumbersTable.Where(t => t.Value % 2 == 0).Select(n => n.Value).ToList();
                            foreach (var even in evenNumbers)
                            {
                                Console.WriteLine($"{even}");
                            }
                        }
                        break;
                    case 2:
                        using (var task2DbContext = new TasksDbContext())
                        {
                            task2DbContext.Database.EnsureCreated();

                            for (int i = -10; i < 20; i++)
                            {
                                // populate with entries if they do not exist
                                var existingEntry = task2DbContext.Task1NumbersTable.FirstOrDefault(t => t.Value == i);
                                if (existingEntry == null)
                                {
                                    task2DbContext.Task1NumbersTable.Add(new Task1Number { Value = i });
                                    task2DbContext.SaveChanges();
                                }

                            }

                            Console.WriteLine("All number entries: ");
                            var numbers = task2DbContext.Task1NumbersTable.Select(n => n.Value).ToList();
                            foreach (var number in numbers)
                            {
                                Console.WriteLine($"{number}");
                            }

                            Console.Write("Only positive and less than 12 number entries: \n");
                            var positiveNumbers = task2DbContext.Task1NumbersTable.Where(t => t.Value > 0)
                                                                                .Where(t => t.Value <= 11)
                                                                                .Select(n => n.Value)
                                                                                .ToList();
                            foreach (var positive in positiveNumbers)
                            {
                                Console.WriteLine($"{positive}");
                            }
                        }
                        break;
                    case 3:
                        using (var task3DbContext = new TasksDbContext())
                        {
                            task3DbContext.Database.EnsureCreated();

                            for (int i = -10; i < 20; i++)
                            {
                                // populate with entries if they do not exist
                                var existingEntry = task3DbContext.Task1NumbersTable.FirstOrDefault(t => t.Value == i);
                                if (existingEntry == null)
                                {
                                    task3DbContext.Task1NumbersTable.Add(new Task1Number { Value = i });
                                    task3DbContext.SaveChanges();
                                }

                            }

                            Console.WriteLine("All number entries: ");
                            var numbers = task3DbContext.Task1NumbersTable.Select(n => n.Value).ToList();
                            foreach (var number in numbers)
                            {
                                Console.WriteLine($"{number}");
                            }

                            Console.Write("All number entries, whose square is more than 20: \n");
                            var numbersWithBigSquare = task3DbContext.Task1NumbersTable
                                                                    .Where(t => t.Value * t.Value > 20)
                                                                    .Select(n => n.Value)
                                                                    .ToList();
                            foreach (var numberWithBigSquare in numbersWithBigSquare)
                            {
                                Console.WriteLine($"{numberWithBigSquare}");
                            }
                        }
                        break;
                    case 4:
                        using (var task4DbContext = new TasksDbContext())
                        {
                            task4DbContext.Database.EnsureCreated();

                            for (int i = 1; i <= 10; i++)
                            {
                                // populate with random amount of each number from 1 to 10
                                Random randomFrequencyGenerator = new Random();
                                int randomFrequency = randomFrequencyGenerator.Next(1, 3);
                                for (int j = 1; j <= randomFrequency; j++)
                                {
                                    task4DbContext.Task4NumbersTable.Add(new Task4Number { Value = i });
                                    task4DbContext.SaveChanges();
                                }
                            }

                            Console.WriteLine("All number entries: ");
                            var numbers = task4DbContext.Task4NumbersTable.ToList();
                            foreach (var number in numbers)
                            {
                                Console.WriteLine($"ID: {number.Id}, Value: {number.Value}");
                            }

                            Dictionary<int, int> frequencyCounter = new Dictionary<int, int>();
                            for (int i = 1; i <= 10; i++)
                            {
                                var count = task4DbContext.Task4NumbersTable
                                    .Where(n => n.Value == i)
                                    .Count();
                                frequencyCounter[i] = count;
                            }

                            Console.Write("Frequencies of each number: \n");
                            foreach (var kvp in frequencyCounter)
                            {
                                Console.WriteLine($"The number {kvp.Key} appears {kvp.Value} times");
                            }
                        }
                        break;
                    case 5:
                        using (var task5DbContext = new TasksDbContext())
                        {
                            task5DbContext.Database.EnsureCreated();

                            string alphabet = "abcdefghijklmnopqrstuvwxyz";
                            foreach (char c in alphabet)
                            {
                                // populate with random amount of each letter in the alphabet
                                Random randomFrequencyGenerator = new Random();
                                int randomFrequency = randomFrequencyGenerator.Next(1, 3);
                                for (int j = 1; j <= randomFrequency; j++)
                                {
                                    task5DbContext.Task5SymbolsTable.Add(new Task5Symbol { Value = c.ToString() });
                                    task5DbContext.SaveChanges();
                                }
                            }

                            Console.WriteLine("All symbol entries: ");
                            var symbols = task5DbContext.Task5SymbolsTable.ToList();
                            foreach (var symbol in symbols)
                            {
                                Console.WriteLine($"ID: {symbol.Id}, Value: {symbol.Value}");
                            }

                            var charFrequencies = task5DbContext.Task5SymbolsTable
                                        .GroupBy(c => c.Value)
                                        .Select(group => new
                                        {
                                            Character = group.Key,   // The grouped character value  
                                            Count = group.Count()
                                        }); // returns the IQueryable<AnonymousType<char, int>>

                            Console.Write("Frequencies of each symbol: \n");
                            foreach (var item in charFrequencies)
                            {
                                Console.WriteLine($"Character {item.Character}: {item.Count} times");
                            }
                        }
                        break;
                    case 6:
                        using (var task6DbContext = new TasksDbContext())
                        {
                            task6DbContext.Database.EnsureCreated();

                            for (int i = 1; i <= 7; i++)
                            {
                                // populate with first week of Feb 2025
                                var existingEntry = task6DbContext.Task6DatesTable.FirstOrDefault(t => t.Value == new DateTime(2025, 2, i));
                                if (existingEntry == null)
                                {
                                    task6DbContext.Task6DatesTable.Add(new Task6Date { Value = new DateTime(2025, 2, i) });
                                    task6DbContext.SaveChanges();
                                }
                            }

                            Console.WriteLine("All date entries: ");
                            var dates = task6DbContext.Task6DatesTable.Select(d => d.Value).ToList();
                            foreach (var date in dates)
                            {
                                Console.WriteLine($"{date}");
                            }

                            Console.WriteLine("All days of the week of the entries: ");
                            var dayOfTheWeeks = task6DbContext.Task6DatesTable.Select(d => d.Value.DayOfWeek.ToString()).ToList();
                            foreach (var dayOfTheWeek in dayOfTheWeeks)
                            {
                                Console.WriteLine($"{dayOfTheWeek}");
                            }
                        }
                        break;
                    case 7:
                        using (var task7DbContext = new TasksDbContext())
                        {
                            task7DbContext.Database.EnsureCreated();

                            for (int i = 1; i <= 10; i++)
                            {
                                // populate with random amount of each number from 1 to 10
                                Random randomFrequencyGenerator = new Random();
                                int randomFrequency = randomFrequencyGenerator.Next(1, 3);
                                for (int j = 1; j <= randomFrequency; j++)
                                {
                                    task7DbContext.Task4NumbersTable.Add(new Task4Number { Value = i });
                                    task7DbContext.SaveChanges();
                                }
                            }

                            Console.WriteLine("All number entries: ");
                            var numbers = task7DbContext.Task4NumbersTable
                                                        .OrderBy(n => n.Value)
                                                        .Select(n => n.Value)
                                                        .ToList();
                            foreach (var number in numbers)
                            {
                                Console.WriteLine($"{number}");
                            }

                            var numberSumOfSameFrequencies = task7DbContext.Task4NumbersTable
                                        .GroupBy(c => c.Value)
                                        .Select(group => new
                                        {
                                            Number = group.Key,
                                            Sum = group.Key * group.Count(),
                                            Count = group.Count()
                                        });

                            Console.Write("Stats for each number: \n");
                            foreach (var item in numberSumOfSameFrequencies)
                            {
                                Console.WriteLine($"Stats for number {item.Number}: it appears {item.Count} times and sum of same numbers are {item.Sum}");
                            }
                        }
                        break;
                    case 8:
                        using (var task8DbContext = new TasksDbContext())
                        {
                            task8DbContext.Database.EnsureCreated();

                            string alphabet = "abcdefghijklmnopqrstuvwxyz";
                            Random randomLengthGenerator = new Random();
                            // populate with 3 randomly generated "words"
                            for (int j = 1; j <= 3; j++)
                            {
                                int length = randomLengthGenerator.Next(5, 10);
                                char[] charArr = new char[length];
                                for (int i = 0; i < length; i++)
                                {
                                    charArr[i] = alphabet[randomLengthGenerator.Next(alphabet.Length)];
                                }
                                string word = new string(charArr);
                                task8DbContext.Task8StringsTable.Add(new Task8String { Value = word });
                                task8DbContext.SaveChanges();
                            }


                            Console.WriteLine("All word entries: ");
                            var words = task8DbContext.Task8StringsTable
                                                                .Select(w => w.Value)
                                                                .ToList();
                            foreach (var word in words)
                            {
                                Console.WriteLine($"{word.Trim()}");
                            }
                            Console.WriteLine("What is the start character?");
                            char startChar = Console.ReadLine()[0];
                            Console.WriteLine("What is the end character?");
                            char endChar = Console.ReadLine()[0];

                            var specifirWord = task8DbContext.Task8StringsTable
                                        .AsEnumerable() // Brings the data into memory, and makes it the cs objects
                                        .Where(w => w.Value.Trim()[0] == startChar &&
                                                    w.Value.Trim()[w.Value.Trim().Length - 1] == endChar) // needs trimming because db value is char(256)
                                        .Select(w => w.Value.Trim())
                                        .ToList(); ;

                            Console.Write($"All words that start with {startChar} and end with {endChar}: \n");
                            foreach (var item in specifirWord)
                            {
                                Console.WriteLine($"{item}");
                            }
                        }
                        break;
                    case 9:
                        using (var task9DbContext = new TasksDbContext())
                        {
                            task9DbContext.Database.EnsureCreated();

                            for (int i = 78; i < 83; i++)
                            {
                                // populate with entries if they do not exist
                                var existingEntry = task9DbContext.Task1NumbersTable.FirstOrDefault(t => t.Value == i);
                                if (existingEntry == null)
                                {
                                    task9DbContext.Task1NumbersTable.Add(new Task1Number { Value = i });
                                    task9DbContext.SaveChanges();
                                }

                            }

                            Console.WriteLine("All number entries: ");
                            var numbers = task9DbContext.Task1NumbersTable.Select(n => n.Value).ToList();
                            foreach (var number in numbers)
                            {
                                Console.WriteLine($"{number}");
                            }

                            Console.Write("Only greater than 80 number entries: \n");
                            var positiveNumbers = task9DbContext.Task1NumbersTable.Where(n => n.Value > 80)
                                                                                .Select(n => n.Value)
                                                                                .ToList();
                            foreach (var positive in positiveNumbers)
                            {
                                Console.WriteLine($"{positive}");
                            }
                        }
                        break;
                    case 10:
                        using (var task10DbContext = new TasksDbContext())
                        {
                            task10DbContext.Database.EnsureCreated();

                            for (int i = 0; i < 10; i++)
                            {
                                // populate with entries if they do not exist
                                var existingEntry = task10DbContext.Task1NumbersTable.FirstOrDefault(t => t.Value == i);
                                if (existingEntry == null)
                                {
                                    task10DbContext.Task1NumbersTable.Add(new Task1Number { Value = i });
                                    task10DbContext.SaveChanges();
                                }

                            }

                            Console.WriteLine("How many entries to show?");
                            string howMuchInput = Console.ReadLine();

                            if (int.TryParse(howMuchInput, out int howMuchToTake))
                            {
                                var firstNEntries = task10DbContext.Task1NumbersTable.Take(howMuchToTake);
                                foreach (var entry in firstNEntries.ToList())
                                {
                                    Console.WriteLine($"Member {entry.Id}: {entry.Value}");
                                }

                                Console.WriteLine("Input the value above you want to display the members of the List?");
                                string mimimalValueOfMemberInput = Console.ReadLine();

                                if (int.TryParse(mimimalValueOfMemberInput, out int mimimalValueOfMember))
                                {

                                    Console.WriteLine("Resulting members are: ");
                                    var filteredByMinimum = firstNEntries.Where(m => m.Value > mimimalValueOfMember).ToList();

                                    foreach (var entry in filteredByMinimum)
                                    {
                                        Console.WriteLine($"Member {entry.Id}: {entry.Value}");
                                    }


                                }
                                else
                                {
                                    Console.WriteLine("Invalid number. Please enter a valid integer.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid number. Please enter a valid integer.");
                            }
                        }
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