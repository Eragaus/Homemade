namespace Homade.Repositories;

public interface IRepository<T>
{
    T Create(T entity);
    T? Get(Guid id);
    IEnumerable<T> GetAll();
    void Update(T entity);
    void Delete(Guid id);
}