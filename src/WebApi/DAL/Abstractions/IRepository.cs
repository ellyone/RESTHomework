using System;
using System.Collections.Generic;

namespace WebApi.DAL.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> GetAll();

        public T? Get(long id);

        public T? Add(T obj);

        public void Update(T obj);

        public void Delete(long id);
    }
}