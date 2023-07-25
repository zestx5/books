using Books.Enums;
using Books.Models;
using Books.Repositories;
using Books.Services;

namespace Books.UserInterface;

public class MenuHandler
{
    private readonly BookService _bookService;

    public MenuHandler(IEntityRepository<Book> repository)
    {
        _bookService = new BookService(repository);
    }

    public void Start()
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
        ResolveMenu(userSelect)();
    }

    private Action ResolveMenu(int input) => input switch
    {
        1 => CreateBook,
        2 => DisplayAllBooks,
        3 => EditBook,
        4 => ChangeStatus,
        5 => DeleteBook,
        6 => Exit,
        _ => InvalidOption
    };

    private void InvalidOption()
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
        Start();
    }

    private void DisplayAllBooks()
    {
        var books = _bookService.DisplayAllBooks();
        if (books.Equals("No books"))
        {
            Console.WriteLine(books);
            AskExitApp();
        }
        Console.WriteLine(books);
        AskExitApp();
    }

    private void AskExitApp()
    {
        var exit = UserInputHandler.GetYesNoInput("Exit app ?");
        if (exit)
        {
            Exit();
        }
        Start();
    }

    private void EditBook()
    {
        Console.WriteLine("Select book");
        var id = UserInputHandler.GetIntegerInput("Enter book id: ");
        var book = _bookService.GetById(id);
        if (book != null)
        {
            book = EditBookMenu(book);
            _bookService.EditBook(book, id);
            Start();
        }
        Console.WriteLine("No book");
        AskExitApp();
    }

    private static Book EditBookMenu(Book book)
    {
        var bookInfo = $"""
        1. {book.Author} - Author
        2. {book.Title} - Title
        3. {book.Genre} - Genre
        4. {book.Status} - Status
        5. Save
        """;

        while (true)
        {
            bookInfo = $"""
        1. {book.Author} - Author
        2. {book.Title} - Title
        3. {book.Genre} - Genre
        4. {book.Status} - Status
        5. Save
        """;

            Console.WriteLine(bookInfo);
            var userSelect = UserInputHandler.GetIntegerInput("Enter your choice (1-5): ");
            switch (userSelect)
            {
                case 1:
                    var author = UserInputHandler.GetStringInput("Enter author: ");
                    book.Author = author;
                    break;
                case 2:
                    var title = UserInputHandler.GetStringInput("Enter title: ");
                    book.Title = title;
                    break;
                case 3:
                    var genre = UserInputHandler.GetStringInput("Enter genre: ");
                    book.Genre = genre;
                    break;
                case 4:
                    var status = AskForStatus();
                    book.Status = status;
                    break;
                case 5:
                    return book;
            }
        }
    }

    private void ChangeStatus()
    {
        Console.WriteLine("Select book");
        var id = UserInputHandler.GetIntegerInput("Enter book id: ");
        var book = _bookService.GetById(id);
        if (book != null)
        {
            DisplayBookById(id);
            var status = AskForStatus();
            book.Status = status;
            _bookService.EditBook(book, id);
            Start();
        }
        Console.WriteLine("No book");
        AskExitApp();
    }

    private void DisplayBookById(int id)
    {
        var book = _bookService.GetById(id);
        Console.WriteLine(book);
    }

    private void DeleteBook()
    {
        Console.WriteLine("WIP");
        Start();
    }

    private void Exit()
    {
        Console.WriteLine("Exiting the application...");
        Environment.Exit(0);
    }

    private void CreateBook()
    {
        var author = UserInputHandler.GetStringInput("Enter author: ");
        var title = UserInputHandler.GetStringInput("Enter title: ");
        var genre = UserInputHandler.GetStringInput("Enter genre: ");
        var status = AskForStatus();
        _bookService.CreateBook(author!, title!, genre!, status);
        DisplayAllBooks();
    }

    private static BookStatus AskForStatus()
    {
        Console.WriteLine("Select status");
        var menu = """
        1. Reading
        2. Read
        3. Dropped
        """;

        while (true)
        {
            Console.WriteLine(menu);
            var status = UserInputHandler.GetIntegerInput("Select status (1-3): ");
            switch (status)
            {
                case 1:
                    return BookStatus.Reading;
                case 2:
                    return BookStatus.Read;
                case 3:
                    return BookStatus.Dropped;

            }
        }

    }


}
