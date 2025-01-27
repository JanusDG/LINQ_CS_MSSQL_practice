using System.Linq;

using TaskSolver.Models;
using TaskSolver.Data;

namespace TaskSolver.Services{

    public class LinqTasksService : ILinqTasksService
    {

        public readonly TasksDbContext _context;
        
        public LinqTasksService(TasksDbContext tasksDbContext)
        {
            _context = tasksDbContext;
        }

        public void DoTask1()
        {
            using (_context)
            {
                
                for (int i = 0; i < 10; i++)
                {
                    // populate with entries if they do not exist
                    var existingEntry = _context.Task1NumbersTable.FirstOrDefault(t => t.Value == i);
                    if (existingEntry == null)
                    {
                        _context.Task1NumbersTable.Add(new Task1Number { Value = i }); 
                    }
                }

                _context.SaveChanges();
                Console.WriteLine("All number entries: ");
                _context.Task1NumbersTable
                    .Select(n => n.Value)
                    .ToList()
                    .ForEach(Console.WriteLine);

                Console.Write("Only even number entries: \n");
                _context.Task1NumbersTable
                    .Where(t => t.Value % 2 == 0)
                    .Select(n => n.Value)
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
        }

        public void DoTask2()
        {
            using (_context)
            {
                
                for (int i = -10; i < 20; i++)
                {
                    // populate with entries if they do not exist
                    var existingEntry = _context.Task1NumbersTable.FirstOrDefault(t => t.Value == i);
                    if (existingEntry == null)
                    {
                        _context.Task1NumbersTable.Add(new Task1Number { Value = i });
                    }
                }

                _context.SaveChanges();
                Console.WriteLine("All number entries: ");
                _context.Task1NumbersTable
                    .Select(n => n.Value)
                    .ToList()
                    .ForEach(Console.WriteLine);

                Console.Write("Only positive and less than 12 number entries: \n");
                _context.Task1NumbersTable.Where(t => t.Value > 0)
                    .Where(t => t.Value <= 11)
                    .Select(n => n.Value)
                    .ToList()
                    .ForEach(Console.WriteLine);
                
            }
        }
        public void DoTask3()
        {
            using (_context)
            {
                
                for (int i = -10; i < 20; i++)
                {
                    // populate with entries if they do not exist
                    var existingEntry = _context.Task1NumbersTable.FirstOrDefault(t => t.Value == i);
                    if (existingEntry == null)
                    {
                        _context.Task1NumbersTable.Add(new Task1Number { Value = i });
                    }

                }
                _context.SaveChanges();

                Console.WriteLine("All number entries: ");
                _context.Task1NumbersTable
                    .Select(n => n.Value)
                    .ToList()
                    .ForEach(Console.WriteLine);

                Console.Write("All number entries, whose square is more than 20: \n");
                _context.Task1NumbersTable
                    .Where(t => t.Value * t.Value > 20)
                    .Select(n => n.Value)
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
        }
        public void DoTask4()
        {
            using (_context)
            {
                
                for (int i = 1; i <= 10; i++)
                {
                    // populate with random amount of each number from 1 to 10
                    Random randomFrequencyGenerator = new Random();
                    int randomFrequency = randomFrequencyGenerator.Next(1, 3);
                    for (int j = 1; j <= randomFrequency; j++)
                    {
                        _context.Task4NumbersTable.Add(new Task4Number { Value = i });
                    }
                }

                _context.SaveChanges();
                Console.WriteLine("All number entries: ");
                _context.Task4NumbersTable
                    .Select(n => n.Value)
                    .ToList()
                    .ForEach(Console.WriteLine);

                Console.WriteLine("Frequencies of each number:");

                _context.Task4NumbersTable
                    .GroupBy(n => n.Value)
                    .ToDictionary(g => g.Key, g => g.Count())
                    .Select(kvp => $"The number {kvp.Key} appears {kvp.Value} times")
                    .ToList()
                    .ForEach(Console.WriteLine);

            }
        }
        public void DoTask5()
        {
            using (_context)
            {
                
                string alphabet = "abcdefghijklmnopqrstuvwxyz";
                foreach (char c in alphabet)
                {
                    // populate with random amount of each letter in the alphabet
                    Random randomFrequencyGenerator = new Random();
                    int randomFrequency = randomFrequencyGenerator.Next(1, 3);
                    for (int j = 1; j <= randomFrequency; j++)
                    {
                        _context.Task5SymbolsTable.Add(new Task5Symbol { Value = c.ToString() });
                    }
                }

                _context.SaveChanges();
                Console.WriteLine("All symbol entries: ");
                _context.Task5SymbolsTable
                    .ToList()
                    .ForEach(Console.WriteLine);

                Console.Write("Frequencies of each symbol: \n");
                _context.Task5SymbolsTable
                    .GroupBy(c => c.Value)
                    .Select(group => new
                    {
                        Character = group.Key,   // The grouped character value  
                        Count = group.Count()
                    })
                    .Select(kvp => $"Character {kvp.Character}: {kvp.Count} times")
                    .ToList()
                    .ForEach(Console.WriteLine); 

                
            }
        }
        public void DoTask6()
        {
            using (_context)
            {
                
                for (int i = 1; i <= 7; i++)
                {
                    // populate with first week of Feb 2025
                    var existingEntry = _context.Task6DatesTable.FirstOrDefault(t => t.Value == new DateTime(2025, 2, i));
                    if (existingEntry == null)
                    {
                        _context.Task6DatesTable.Add(new Task6Date { Value = new DateTime(2025, 2, i) });
                    }
                }

                _context.SaveChanges();
                Console.WriteLine("All date entries: ");
                _context.Task6DatesTable
                    .Select(d => d.Value.ToString("dd-MM-yyyy"))
                    .ToList()
                    .ForEach(Console.WriteLine);

                Console.WriteLine("All days of the week of the entries: ");
                _context.Task6DatesTable
                    .Select(d => d.Value.DayOfWeek.ToString())
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
        }
        public void DoTask7()
        {
            using (_context)
            {
                
                for (int i = 1; i <= 10; i++)
                {
                    // populate with random amount of each number from 1 to 10
                    Random randomFrequencyGenerator = new Random();
                    int randomFrequency = randomFrequencyGenerator.Next(1, 3);
                    for (int j = 1; j <= randomFrequency; j++)
                    {
                        _context.Task4NumbersTable.Add(new Task4Number { Value = i });
                    }
                }

                _context.SaveChanges();
                Console.WriteLine("All number entries: ");
                _context.Task4NumbersTable
                    .OrderBy(n => n.Value)
                    .Select(n => n.Value)
                    .ToList()
                    .ForEach(Console.WriteLine);
                
                Console.Write("Stats for each number: \n");
                _context.Task4NumbersTable
                    .GroupBy(c => c.Value)
                    .Select(group => new
                    {
                        Number = group.Key,
                        Sum = group.Key * group.Count(),
                        Count = group.Count()
                    })
                    .Select(item => $"Stats for number {item.Number}: it appears {item.Count} times and sum of same numbers are {item.Sum}")
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
        }
        public void DoTask8()
        {
            using (_context)
            {
                
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
                    _context.Task8StringsTable.Add(new Task8String { Value = word });
                }


                _context.SaveChanges();
                Console.WriteLine("All word entries: ");
                _context.Task8StringsTable
                    .Select(w => w.Value)
                    .ToList()
                    .ForEach(Console.WriteLine);
            
                Console.WriteLine("What is the start character?");
                char startChar = Console.ReadLine()[0];
                Console.WriteLine("What is the end character?");
                char endChar = Console.ReadLine()[0];

                Console.Write($"All words that start with {startChar} and end with {endChar}: \n");
                _context.Task8StringsTable
                            .AsEnumerable() // Brings the data into memory, and makes it the cs objects
                            .Where(w => w.Value.Trim()[0] == startChar &&
                                        w.Value.Trim()[w.Value.Trim().Length - 1] == endChar) // needs trimming because db value is char(256)
                            .Select(w => w.Value.Trim())
                            .ToList()
                            .ForEach(Console.WriteLine); 
            }
        }
        public void DoTask9()
        {
            using (_context)
            {
                
                for (int i = 78; i < 83; i++)
                {
                    // populate with entries if they do not exist
                    var existingEntry = _context.Task1NumbersTable.FirstOrDefault(t => t.Value == i);
                    if (existingEntry == null)
                    {
                        _context.Task1NumbersTable.Add(new Task1Number { Value = i });
                    }

                }
                _context.SaveChanges();

                Console.WriteLine("All number entries: ");
                _context.Task1NumbersTable.Select(n => n.Value)
                    .ToList()
                    .ForEach(Console.WriteLine);

                Console.Write("Only greater than 80 number entries: \n");
                _context.Task1NumbersTable
                    .Where(n => n.Value > 80)
                    .Select(n => n.Value)
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
        }
        public void DoTask10()
        {
            using (_context)
            {
                
                for (int i = 0; i < 10; i++)
                {
                    // populate with entries if they do not exist
                    var existingEntry = _context.Task1NumbersTable.FirstOrDefault(t => t.Value == i);
                    if (existingEntry == null)
                    {
                        _context.Task1NumbersTable.Add(new Task1Number { Value = i });
                    }

                }
                _context.SaveChanges();

                Console.WriteLine("How many entries to show?");
                string howMuchInput = Console.ReadLine();

                if (int.TryParse(howMuchInput, out int howMuchToTake))
                {
                    var firstNEntries = _context.Task1NumbersTable
                        .Take(howMuchToTake);
                    
                    firstNEntries
                        .Select(m => $"Member {m.Id}: {m.Value}")
                        .ToList()
                        .ForEach(Console.WriteLine);

                    Console.WriteLine("Input the value above you want to display the members of the List?");
                    string mimimalValueOfMemberInput = Console.ReadLine();

                    if (int.TryParse(mimimalValueOfMemberInput, out int mimimalValueOfMember))
                    {

                        Console.WriteLine("Resulting members are: ");
                        firstNEntries
                            .Where(m => m.Value > mimimalValueOfMember)
                            .Select(m => m.Value)
                            .ToList()
                            .ForEach(Console.WriteLine);
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
        }
    }
}