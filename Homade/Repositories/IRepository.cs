namespace Homade.Repositories;

public interface IRepository<T>
{
    T Create(T entity);
    T Get(int id);
    IEnumerable<T> GetAll();
    void Update(T entity);
    void Delete(int id);
}