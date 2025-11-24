using Homade.Common;
using Homade.Models;

namespace Homade.Services;

public abstract class AbstractRestService<T>: IRest<T> where T : AbstractId
{
    private readonly List<T> _items = [];
    
    public T Create(T item)
    {
        _items.Add(item);
        return item;
    }

    public T? GetById(Guid id)
    {
        return _items.Find(x => x.Id == id);
    }

    public List<T> GetAll()
    {
        return _items.ToList();
    }

    public T Update(T item)
    {
        var index = _items.FindIndex(x => x.Id == item.Id);
        if (index == -1)
        {
            throw new KeyNotFoundException($"Item with id {item.Id} not found.");
        }
        _items[index] = item;
        return item;
    }

    public bool Delete(Guid id)
    {
        var existing = GetById(id);
        return existing != null && _items.Remove(existing);
    }
}