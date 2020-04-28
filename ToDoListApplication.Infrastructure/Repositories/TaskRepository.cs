using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.Domain.Enums;
using ToDoListApplication.Domain.Interfaces.Repositories;

namespace ToDoListApplication.Infrastructure.Repositories
{
    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {        
        public IEnumerable<Task> GetPendingTasks(params Expression<Func<Task, object>>[] properties)
        {
            IQueryable<Task> set = db.Tasks;

            foreach (var property in properties)
            {
                set = set.Include(property);
            }

            return set.Where(t => t.Status == TaskStatus.Pending).ToList();
        }
              
     
    }
}
