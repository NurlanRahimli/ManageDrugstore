using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Base
{
    public interface IRepository<T> where T : IEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(Predicate<T> filter = null);
        List<T> GetAll(Predicate<T> filter = null);
    }
}
