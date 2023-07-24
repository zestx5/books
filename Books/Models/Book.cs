using Books.Enums;

namespace Books.Models;

public class Book
{
    public Book(string author, string title, string genre, BookStatus status)
    {
        Author = author;
        Title = title;
        Genre = genre;
        Status = status;
    }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public BookStatus Status { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Book book &&
               Author == book.Author &&
               Title == book.Title &&
               Genre == book.Genre;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Author, Title, Genre);
    }

    public override string ToString()
    {
        return $"{this.Author}, {this.Title}, {this.Genre}, {this.Status}";
    }
}
