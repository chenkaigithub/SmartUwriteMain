using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.DocDatabase
{
    public interface IBaseDao<T>
    {
        List<T> Query();
        T GetDetail();
        bool Add();
        bool Upgrade();
        bool Del();

        bool Add(T t);
        bool Upgrade(T t);
        bool Del(T t);
    }
}
