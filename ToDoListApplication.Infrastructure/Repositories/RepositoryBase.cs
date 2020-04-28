using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDoListApplication.Domain.Interfaces.Repositories;
using ToDoListApplication.Infrastructure.Context;

namespace ToDoListApplication.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ToDoListApplicationContext db = new ToDoListApplicationContext();                                

        public void Add(TEntity obj)
        {
            db.Set<TEntity>().Add(obj);           
            db.SaveChanges();
        }

        public void Delete(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {                           
            return db.Set<TEntity>().Find(id);
        }      

        public void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
                                    
    }
}
