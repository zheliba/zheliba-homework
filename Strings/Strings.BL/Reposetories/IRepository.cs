using System.Collections.Generic;

namespace Strings.BL
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> GetAll();
        void Save();
        //void Add(T item);
        //T GetById(int id);
        //void Remove(T item);
    }
}