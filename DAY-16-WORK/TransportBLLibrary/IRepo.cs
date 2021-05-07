using System;
using System.Collections.Generic;
using System.Text;

namespace TransportBLLibrary
{
    public interface IRepo<T>
    {
        bool Add(T t);
        bool Update(T t);
        ICollection<T> GetAll();
    }
    public interface IRepos<T>
    {
        bool Add(T t);
        ICollection<T> GetAll();
        bool UpdateDriverStatus(T t);
        bool UpdateDriverPhone(int id, T t);

    }
}
