namespace Books;

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
}
