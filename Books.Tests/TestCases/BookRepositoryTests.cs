﻿using Books.Models;
using Books.Repositories;

namespace Books.Tests;
[TestFixture]
public class BookRepositoryTests
{
    readonly BookRepositoryInMemory repository = new();
    [OneTimeSetUp]
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
    public void GetById_NonExistingId_ShouldThrowInvalidOperationException()
    {
        Assert.That(() => repository.GetById(-1), Throws.InvalidOperationException);
    }

    [Test]
    public void Update_ExistingBook_ShouldUpdateInDatabase()
    {
        var book = new Book("Test", "Test", "Test", Enums.BookStatus.Dropped);
        repository.Update(book, 1);
        Assert.That(repository.GetById(1), Is.EqualTo(book));
    }

    [Test]
    public void Delete_ExistingBook_ShouldDeleteFromDatabase()
    {
        var book = new Book("Test", "Test", "Test", Enums.BookStatus.Dropped);
        repository.Add(book);
        repository.DeleteById(2);
        Assert.That(repository.Count(), Is.EqualTo(1));
    }

    [Test]
    public void GetAll_ShouldReturnAllBooks()
    {
        var book = new Book("Test", "Test", "Test", Enums.BookStatus.Dropped);
        repository.Add(book);
        var books = repository.GetAll();
        Assert.That(books.Count(), Is.EqualTo(2));
    }
}
