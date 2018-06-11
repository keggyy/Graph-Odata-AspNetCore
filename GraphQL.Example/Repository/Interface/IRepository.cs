using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Example.Repository.Interface
{
    public interface IRepository<T>
    {
        T Get(int id);
        T Get(string name);
        List<T> GetAll();
        T Add(T entity);
    }
}
