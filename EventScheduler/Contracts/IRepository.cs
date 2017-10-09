using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EventScheduler
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Update(int id);

        T Get(int id);


        void Delete(int id);

        IList<T> Get(Expression<Func<T, bool>> filter = null);
    }
}
