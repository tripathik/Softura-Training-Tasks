using System;
using System.Collections.Generic;
using System.Text;

namespace EFandLINQProject.Models
{
    public interface IRepo<T>
    {
        bool Add(T t);
        IList<T> GetAll();
        T Get(int id);
    }
}
