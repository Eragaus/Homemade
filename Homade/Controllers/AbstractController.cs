using Homade.Common;
using Homade.Models;
using Homade.Models.Notes;

namespace Homade.Controllers;

public abstract class AbstractController<TS, T>: IRest<T> where TS : IRest<T> where T: AbstractId
{
    protected abstract TS GetService();
    
    public T Create(T item)
    {
        return GetService().Create(item);
    }

    public T? GetById(Guid id)
    {
        return  GetService().GetById(id);
    }

    public List<T> GetAll()
    {
        return  GetService().GetAll();
    }

    public T Update(T item)
    {
        return  GetService().Update(item);
    }

    public bool Delete(Guid id)
    {
        return  GetService().Delete(id);
    }
}