using System;
using WebApi.DAL.Abstractions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DAL.Repositories
{
    public class EFRepository<T> : IRepository<T> where T:BaseEntity
    {
        private readonly DataContext _dataContext;
        public EFRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _dataContext.Set<T>().ToList();
        }

        public T? Get(long id)
        {
            var tmp = _dataContext.Set<T>().FirstOrDefault(x => x.ID == id);
            return _dataContext.Set<T>().FirstOrDefault(x => x.ID == id);
        }

        public T Add(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            var entity2 = _dataContext.Set<T>().FirstOrDefault(x => x.ID == entity.ID);
            if (entity2 != null)
            {
                entity2 = entity;
                _dataContext.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var entity = _dataContext.Set<T>().FirstOrDefault(x => x.ID == id);
            if (entity != null)
            {
                _dataContext.Set<T>().Remove(entity);
                _dataContext.SaveChanges();
            }
        }
    }
}