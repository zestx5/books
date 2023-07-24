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

    public void DeleteById(int id)
    {
        _bookRepository.RemoveAt(id - 1);
    }

    public IEnumerable<Book> GetAll()
    {
        throw new NotImplementedException();
    }

    public Book GetById(int id)
    {
        var idx = id - 1;
        try
        {
            return _bookRepository[idx];
        }
        catch
        {
            throw new InvalidOperationException("Not found");
        }
    }

    public void Update(Book entity, int id)
    {
        try
        {
            _bookRepository[id - 1] = entity;
        }
        catch
        {
            throw new InvalidOperationException("Not found");
        }
    }
}
