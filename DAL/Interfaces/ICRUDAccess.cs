using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ICRUDAccess<T>
    {
        T Get(T obj);
        void Create(T obj);
        void Update(T obj);
        void Delete(int index);
        T Read(int index);
        T GetLatestEntry();
    }
}
