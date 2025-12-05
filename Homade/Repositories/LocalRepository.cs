using System.IO;
using System.Text.Json;
using Homade.Config;
using Homade.Models;

namespace Homade.Repositories;

public class LocalRepository<T> : IRepository<T> where T : AbstractId, new()
{
    private readonly string _filePath = $"{typeof(T).Name}.json";
    private readonly List<T> _items;

    public LocalRepository()
    {
        if (File.Exists(_filePath))
        {
            var content = File.ReadAllText(_filePath);
            _items = JsonSerializer.Deserialize<List<T>>(content)
                     ?? [];
        }
        else
        {
            _items = [];
        }
    }

    public T Create(T entity)
    {
        if (entity.Id == Guid.Empty)
            entity.Id = Guid.NewGuid();

        _items.Add(entity);
        Save();
        return entity;
    }

    public IEnumerable<T> GetAll() => _items;

    public T? Get(Guid id) =>
        _items.FirstOrDefault(i => i.Id == id);  // <-- properly nullable

    public void Update(T entity)
    {
        var index = _items.FindIndex(i => i.Id == entity.Id);
        if (index != -1)
        {
            _items[index] = entity;
            Save();
        }
    }

    public void Delete(Guid id)
    {
        _items.RemoveAll(i => i.Id == id);
        Save();
    }

    private void Save()
    {
        File.WriteAllText(
            _filePath,
            JsonSerializer.Serialize(_items, JsonConfig.Options)
        );
    }
}