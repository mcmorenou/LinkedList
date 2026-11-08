using Backend;
using System.ComponentModel.Design;

var list  = new DoublyLinkedList<string>();
var option  = string.Empty;

do
{
    option = Menu();
    switch (option)
    {
        case "1":
            Console.Write("Enter value:");
            list.InsertAtBeginning(Console. ReadLine()!);
            break;
        case "2":
            Console.Write("Enter value:");
            list.InsertAtEnd(Console.ReadLine()!);
            break;
        case "3":
            Console.Write("Enter value:");
            var item = Console.ReadLine()!;
            Console.WriteLine(list.Contains(item)
                ? $"The item: '{item}'exists!"
                : $"The item: '{item}'doesn't exists!");
            break;
                
        case "8":
            Console.WriteLine(list);
            break;
        case "9":
            Console.WriteLine(list.ToStringReverse());
            break;


        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (option != "0");

string Menu()
{
    Console.WriteLine("1. Insert at beginning");
    Console.WriteLine("2. Insert at end");
    Console.WriteLine("3. Contains");
    Console.WriteLine("4. Remove");
    Console.WriteLine("5. Reverse");
    Console.WriteLine("6. Insert");
    Console.WriteLine("7. Order");
    Console.WriteLine("8. Show list");
    Console.WriteLine("9. Show reverselist");
    Console.WriteLine("0. Exit");
    Console.WriteLine("Enter your option?");
    return Console.ReadLine()!;


}

