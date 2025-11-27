using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice2.DAO
{
    internal abstract class BaseDao<T>
    {
        protected string request = "";
        public abstract T Save(T entity);
        public abstract bool Update(T entity);
        public abstract List<T> GetAll(int? id = null);
        public abstract T? getOneById(int id);

        public abstract bool DeleteById(int id) ;
    }
}
