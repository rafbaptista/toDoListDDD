using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.Domain.Enums;

namespace ToDoListApplication.Domain.Interfaces.Services
{
    public interface ITaskService : IServiceBase<Task>
    {
        IEnumerable<Task> GetPendingTasksByLastInsertionDateAsc();
        IEnumerable<Task> GetPendingTasksByLastInsertionDateDesc();
        IEnumerable<Task> GetPendingTasks(params Expression<Func<Task, object>>[] properties);

        IEnumerable<Task> GetInProgressTasksByLastInsertionDateAsc();
        IEnumerable<Task> GetInProgressTasksByLastInsertionDateDesc();

        IEnumerable<Task> GetCompletedTasksByLastInsertionDateAsc();
        IEnumerable<Task> GetCompletedTasksByLastInsertionDateDesc();        

        void ChangeStatus(int taskId, TaskStatus newStatus);
        Dictionary<string, int> GetTotalTasksByStatus();
        Dictionary<string, int> GetTotalTasksByCategory();
        Dictionary<string, int> GetTotalTasksByDeliveryDate();
    }
}
