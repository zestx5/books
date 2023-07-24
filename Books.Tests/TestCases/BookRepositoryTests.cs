using Books.Models;
using Books.Repositories;

namespace Books.Tests;
[TestFixture]
public class BookRepositoryTests
{
    readonly BookRepositoryInMemory repository = new();

    [Test]
    public void Add_Book_ShouldBeAddedToDatabase()
    {
        var book = new Book("Author", "Title", "Genre", Enums.BookStatus.Dropped);
        repository.Add(book);
        Assert.That(repository.Count(), Is.EqualTo(1));
    }

    [Test]
    public void GetById_ExistingId_ShouldReturnBook()
    {
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
