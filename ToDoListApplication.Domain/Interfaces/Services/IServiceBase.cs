using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ToDoListApplication.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        void Delete(TEntity obj);
        void Update(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);        
    }
}
