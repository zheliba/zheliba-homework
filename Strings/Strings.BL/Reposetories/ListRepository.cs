using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Strings.BL
{
    public class ListRepository<T> : IRepository<T> where T : IEntity
    {
        List<T> _items = new();
        readonly string pathToItems = "..\\" + typeof(T).Name + "s.json";

        public IEnumerable<T> GetAll()
        {
            using StreamReader r = new(pathToItems);
            string json = r.ReadToEnd();
            _items = JsonConvert.DeserializeObject<List<T>>(json);
            return _items;
        }

        public void Save()
        {
            using StreamWriter itemData = new(pathToItems, false);          
            itemData.WriteLine(JsonConvert.SerializeObject(_items, Formatting.Indented));          
        }

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public void Add(T item)
        {
            
            item.Id = _items.Any() ?
                _items.Max(item => item.Id) + 1
                : 1;

            _items.Add(item);
            using StreamWriter itemData = new(pathToItems, true);
            itemData.WriteLine(JsonConvert.SerializeObject(item));
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }


    }
}
