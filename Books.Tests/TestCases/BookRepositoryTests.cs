using Books.Models;
using Books.Repositories;

namespace Books.Tests;
[TestFixture]
public class BookRepositoryTests
{
    readonly BookRepositoryInMemory repository = new();
    [SetUp]
    public void Init()
    {
        var book = new Book("Author", "Title", "Genre", Enums.BookStatus.Dropped);
        repository.Add(book);
    }

    [Test]
    public void Add_Book_ShouldBeAddedToDatabase()
    {
        Assert.That(repository.Count(), Is.EqualTo(1));
    }

    [Test]
    public void GetById_ExistingId_ShouldReturnBook()
    {
        var book = new Book("Author", "Title", "Genre", Enums.BookStatus.Dropped);
        Assert.That(repository.GetById(1), Is.EqualTo(book));
    }

    [Test]
    public void Update_ExistingBook_ShouldUpdateInDatabase()
    {
    }

    [Test]
    public void Delete_ExistingBook_ShouldDeleteFromDatabase()
    {
    }

    [Test]
    public void GetAll_ShouldReturnAllBooks()
    {
    }

}
