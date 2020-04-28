using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ToDoListApplication.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        void Delete(TEntity obj);
        void Update(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);        
    }
}
