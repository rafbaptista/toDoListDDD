using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ToDoListApplication.ApplicationServices.Interface;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.Domain.Enums;
using ToDoListApplication.Domain.Interfaces.Services;

namespace ToDoListApplication.ApplicationServices.Services
{
    public class AppTaskService : AppServiceBase<Task>, IAppTaskService
    {
        private readonly ITaskService _taskService;

        public AppTaskService(ITaskService taskService)
            :base(taskService)
        {
            _taskService = taskService;
        }

        public void ChangeStatus(int taskId, TaskStatus newStatus)
        {
            _taskService.ChangeStatus(taskId, newStatus);
        }

        public IEnumerable<Task> GetCompletedTasksByLastInsertionDateAsc()
        {
            return _taskService.GetCompletedTasksByLastInsertionDateAsc();
        }

        public IEnumerable<Task> GetCompletedTasksByLastInsertionDateDesc()
        {
            return _taskService.GetCompletedTasksByLastInsertionDateDesc();
        }

        public IEnumerable<Task> GetInProgressTasksByLastInsertionDateAsc()
        {
            return _taskService.GetInProgressTasksByLastInsertionDateAsc();
        }

        public IEnumerable<Task> GetInProgressTasksByLastInsertionDateDesc()
        {
            return _taskService.GetInProgressTasksByLastInsertionDateDesc();
        }
       
        public IEnumerable<Task> GetPendingTasksByLastInsertionDateAsc()
        {
            return _taskService.GetPendingTasksByLastInsertionDateAsc();
        }

        public IEnumerable<Task> GetPendingTasksByLastInsertionDateDesc()
        {
            return _taskService.GetPendingTasksByLastInsertionDateDesc();
        }

        public IEnumerable<Task> GetPendingTasks(params Expression<Func<Task, object>>[] properties)
        {
            return _taskService.GetPendingTasks(properties);
        }

        public Dictionary<string, int> GetTotalTasksByStatus()
        {
            return _taskService.GetTotalTasksByStatus();
        }

        public Dictionary<string, int> GetTotalTasksByCategory()
        {
            return _taskService.GetTotalTasksByCategory();
        }

        public Dictionary<string, int> GetTotalTasksByDeliveryDate()
        {
            return _taskService.GetTotalTasksByDeliveryDate();
        }
    }
}
