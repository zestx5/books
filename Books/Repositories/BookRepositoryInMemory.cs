using Books.Models;

namespace Books.Repositories;

public class BookRepositoryInMemory : IEntityRepository<Book>
{
    private readonly List<Book> _bookRepository = new();

    public int Count() => _bookRepository.Count;

    public void Add(Book entity)
    {
        _bookRepository.Add(entity);
    }

    public void Delete(Book entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> GetAll()
    {
        throw new NotImplementedException();
    }

    public Book GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Book entity)
    {
        throw new NotImplementedException();
    }
}
