using Backend;
using System.ComponentModel.Design;

var list  = new SinglyLinkedList<string>();
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
            Console.WriteLine(list);
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
    Console.WriteLine("3. Show list");
    Console.WriteLine("0. Exit");
    Console.WriteLine("Enter your option?");
    return Console.ReadLine()!;


}

