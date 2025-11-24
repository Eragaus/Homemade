using Homade.Models.Notes;

namespace Homade.Common;

public interface IRest<T>
{
    T Create(T item);
    
    T? GetById(Guid id);
    
    List<T> GetAll();
    
    T Update(T item);
    
    bool Delete(Guid id);
}