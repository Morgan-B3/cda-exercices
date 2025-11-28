using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3.DAO
{
    internal interface IBaseDAO<T>
    {
        T Save(T entity);
        T Update(T entity);
        bool Delete(int id);
        T? GetById(int id);
        List<T> GetAll(int? id = null);

    }
}
