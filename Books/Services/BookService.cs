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

    public Book? GetById(int id)
    {
        try
        {
            return _repository.GetById(id);
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    public string DisplayAllBooks() => CreateBooksView(_repository.GetAll());

    private static string CreateBooksView(IEnumerable<Book> books)
    {
        string output = String.Empty;
        if (!books.Any())
        {
            return "No books";
        }

        for (int i = 0; i < books.Count(); i++)
        {
            output += $"{i + 1}. " + books.ElementAt(i).ToString() + "\n";
        }

        return output;
    }

    internal void CreateBook(string author, string title, string genre, BookStatus status)
    {
        var book = new Book(author, title, genre, status);
        _repository.Add(book);
    }
}
