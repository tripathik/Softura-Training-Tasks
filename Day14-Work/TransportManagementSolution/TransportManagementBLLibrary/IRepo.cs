using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementBLLibrary
{
   public interface IRepo<T>
    {
        void Add(T t);
        void Update(int id, T t);
        IEnumerable<T> GetAll(); //
        //ICollection<T> GetAll();
        T Get(int id);

        void Delete(int id);
    }
}