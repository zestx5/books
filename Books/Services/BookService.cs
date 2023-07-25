using Books.Enums;
using Books.Models;
using Books.Repositories;

namespace Books.Services;

public class BookService
{
    private readonly IEntityRepository<Book> _repository;

    public BookService(IEntityRepository<Book> repository) => _repository = repository;

    public void EditBook(Book book, int id) => _repository.Update(book, id);

    public void DeleteBook(int id) => _repository.DeleteById(id);

    public Book DisplayById(int id) => _repository.GetById(id);

    public string DisplayAllBooks() => CreateBooksView(_repository.GetAll());

    private static string CreateBooksView(IEnumerable<Book> books)
    {
        string output = String.Empty;
        if (!books.Any())
        {
            return "No books";
        }

        foreach (var book in books)
        {
            output += book.ToString() + "\n";
        }

        return output;
    }

    internal void CreateBook(string author, string title, string genre, BookStatus status)
    {
        var book = new Book(author, title, genre, status);
        _repository.Add(book);
    }
}
