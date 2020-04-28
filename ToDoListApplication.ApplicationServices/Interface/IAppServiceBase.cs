using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ToDoListApplication.Domain.Entities;

namespace ToDoListApplication.ApplicationServices.Interface
{
    public interface IAppServiceBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        void Delete(TEntity obj);
        void Update(TEntity obj);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);        
    }
}
