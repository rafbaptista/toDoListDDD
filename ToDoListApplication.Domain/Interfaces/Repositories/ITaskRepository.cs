using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.Domain.Enums;

namespace ToDoListApplication.Domain.Interfaces.Repositories
{
    public interface ITaskRepository : IRepositoryBase<Task>
    {                
        IEnumerable<Task> GetPendingTasks(params Expression<Func<Task, object>>[] properties);        
    }
}
