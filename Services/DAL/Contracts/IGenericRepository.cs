using System.Collections.Generic;

namespace Services.DAL.Contracts
{
    internal interface IGenericRepository <T>
    {
        void Insert(T obj);
        IEnumerable<T> GetAll();
    }
}
