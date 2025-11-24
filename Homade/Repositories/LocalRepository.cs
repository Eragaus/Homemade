using System.IO;
using System.Text.Json;

namespace Homade.Repositories;

public class LocalRepository<T>: IRepository<T> where T: class, new()
{
    private readonly string _file = $"{typeof(T).Name}.json";
    private List<T> _items = [];
    private int _nextId = 1;

    public LocalRepository()
    {
        if (File.Exists(_file))
        {
            _items = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(_file)) ?? new List<T>();
            _nextId = _items.Count == 0 
                ? 1 
                : _items.Max(i => (int)typeof(T).GetProperty("Id").GetValue(i)) + 1;
        }
    }

    public T Create(T entity)
    {
        typeof(T).GetProperty("Id").SetValue(entity, _nextId++);
        _items.Add(entity);
        Save();
        return entity;
    }

    public IEnumerable<T> GetAll() => _items;
    
    public T Get(int id) => _items.FirstOrDefault(x => (int)typeof(T)?.GetProperty("Id").GetValue(x) == id);

    public void Update(T entity) => Save();
    
    public void Delete(int id)
    {
        _items.RemoveAll(x => (int)typeof(T).GetProperty("Id").GetValue(x) == id);
        Save();
    }

    private void Save()
    {
        File.WriteAllText(_file, JsonSerializer.Serialize(_items, new JsonSerializerOptions() { WriteIndented = true }));
    }
}