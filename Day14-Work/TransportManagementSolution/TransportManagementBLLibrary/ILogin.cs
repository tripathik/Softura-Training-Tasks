using System;
using System.Collections.Generic;
using System.Text;

namespace TransportManagementBLLibrary
{
   public interface ILogin<T>
    {
        bool Login(T t);
        void Add(T t);
    }
}                                  