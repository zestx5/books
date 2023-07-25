using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Books.UserInterface;

public class MenuHandler
{
    public static void Start()
    {
        string menu = """
        =============== Menu ===============
        1. Add book 
        2. View all books
        3. Edit book info
        4. Change status
        5. Delete book
        6. Exit
        ====================================
        """;

        Console.WriteLine(menu);
        Console.WriteLine();

        var userSelect = UserInputHandler.GetIntegerInput("Enter your choice (1-6): ");
        Resolve(userSelect)();
    }

    private static Action Resolve(int input) => input switch
    {
        1 => CreateBook,
        2 => DisplayAllBooks,
        3 => EditBook,
        4 => ChangeStatus,
        5 => DeleteBook,
        6 => Exit,
        _ => InvalidOption
    };

    private static void InvalidOption()
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
        Start();
    }

    private static void DisplayAllBooks()
    {
        Console.WriteLine("WIP");
        Start();
    }

    private static void EditBook()
    {
        Console.WriteLine("WIP");
        Start();
    }

    private static void ChangeStatus()
    {
        Console.WriteLine("WIP");
        Start();
    }

    private static void DeleteBook()
    {
        Console.WriteLine("WIP");
        Start();
    }

    private static void Exit()
    {
        Console.WriteLine("Exiting the application...");
        Environment.Exit(0);
    }

    private static void CreateBook()
    {
        Console.WriteLine("WIP");
        Start();
    }

}
