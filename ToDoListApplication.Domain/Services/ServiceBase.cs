using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ToDoListApplication.Domain.Interfaces.Repositories;
using ToDoListApplication.Domain.Interfaces.Services;

namespace ToDoListApplication.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);            
        }

        public void Delete(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
     
        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
                          
    }
}
