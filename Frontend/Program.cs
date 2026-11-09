using Backend;
using System.ComponentModel.Design;

var list = new DoublyLinkedList<string>();
var option = string.Empty;

do
{
    option = Menu();
    switch (option)
    {
        case "1":
            Console.Write("Enter value:");
            list.Insert(Console.ReadLine()!);
            break;
        case "2":
            Console.WriteLine(list);
            break;
        case "3":
            Console.WriteLine(list.ToStringReverse());
            break;

        case "4":
            list.SortDescending();
            Console.WriteLine("The list is now sorted in descending order.");
            Console.WriteLine(list);
            break;
        case "5":
            {
                var (modes, frequency) = list.Modes();
                if (modes.Count == 0)
                {
                    Console.WriteLine("The list is empty.");
                }
                else if (modes.Count == 1)
                {
                    Console.WriteLine($"The mode is {modes[0]}.");
                }
                else
                {
                    var allButLast = string.Join(", ", modes.Take(modes.Count - 1));
                    Console.WriteLine($"The modes are {allButLast} and {modes[^1]}.");
                }
                break;
            }
        case "6":
            {
                var occurrences = list.Occurrences();
                if (occurrences.Count == 0)
                {
                    Console.WriteLine("The list is empty.");
                }
                foreach (var (value, count) in occurrences)
                {
                    Console.WriteLine($"{value} {new string('*', count)}");
                }
                break;
            }
        case "7":
            {
                Console.Write("Enter value: ");
                var item = Console.ReadLine()!;
                Console.WriteLine(list.Contains(item)
                    ? $"The item '{item}' exists."
                    : $"The item '{item}' doesn't exist.");
                break;
            }

        case "8":
            {
                Console.Write("Enter value: ");
                var item = Console.ReadLine()!;
                Console.WriteLine(list.Remove(item)
                    ? $"One occurrence of '{item}' was removed."
                    : $"The item '{item}' doesn't exist.");
                break;
            }
        case "9":
            {
                Console.Write("Enter value: ");
                var item = Console.ReadLine()!;
                var removed = list.RemoveAll(item);
                Console.WriteLine(removed > 0
                    ? $"{removed} occurrence(s) of '{item}' removed."
                    : $"The item '{item}' doesn't exist.");
                break;
            }
        case "0":
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (option != "0");

string Menu()
{
    Console.WriteLine();
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show forward");
    Console.WriteLine("3. Show backward");
    Console.WriteLine("4. Show descending");
    Console.WriteLine("5. Show mode (s)");
    Console.WriteLine("6. Show chart");
    Console.WriteLine("7. Exists");
    Console.WriteLine("8. Remove one occurrence");
    Console.WriteLine("9. Remove all occurrence");
    Console.WriteLine("0. Exit");
    Console.WriteLine("Enter your option?");
    return Console.ReadLine()!;

}

