using NUnit.Framework.Internal;

namespace Books.Tests;

[TestFixture]
public class BookTests
{
    [Test]
    public void Test_CreateBook_ShouldReturnTrue()
    {
        Assert.That(new Book("Author", "Title", "Genre", BookStatus.Reading), Is.InstanceOf<Book>());
    }
}
