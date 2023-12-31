﻿namespace Books.Repositories;

public interface IEntityRepository<T>
{
    void Add(T entity);
    void Update(T entity, int id);
    void DeleteById(int id);
    T GetById(int id);
    IEnumerable<T> GetAll();
}
