using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.Domain.Enums;
using ToDoListApplication.Domain.Interfaces.Repositories;
using ToDoListApplication.Domain.Interfaces.Services;

namespace ToDoListApplication.Domain.Services
{
    public class TaskService : ServiceBase<Task>, ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
            :base(taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void ChangeStatus(int taskId, TaskStatus newStatus)
        {
            Task task = GetById(taskId);
            task.Status = newStatus;
            Update(task);
        }

        public IEnumerable<Task> GetCompletedTasksByLastInsertionDateAsc()
        {
            return _taskRepository.GetAll().Where(t => t.Status == TaskStatus.Completed).OrderBy(t => t.LastInsertionDate).ToList();            
        }

        public IEnumerable<Task> GetCompletedTasksByLastInsertionDateDesc()
        {
            return _taskRepository.GetAll().Where(t => t.Status == TaskStatus.Completed).OrderByDescending(t => t.LastInsertionDate).ToList();
        }

        public IEnumerable<Task> GetInProgressTasksByLastInsertionDateAsc()
        {
            return _taskRepository.GetAll().Where(t => t.Status == TaskStatus.InProgress).OrderBy(t => t.LastInsertionDate).ToList();
        }

        public IEnumerable<Task> GetInProgressTasksByLastInsertionDateDesc()
        {
            return _taskRepository.GetAll().Where(t => t.Status == TaskStatus.InProgress).OrderByDescending(t => t.LastInsertionDate).ToList();
        }

        public IEnumerable<Task> GetPendingTasksByLastInsertionDateAsc()
        {
            return _taskRepository.GetAll().Where(t => t.Status == TaskStatus.Pending).OrderBy(t => t.LastInsertionDate).ToList();
        }

        public IEnumerable<Task> GetPendingTasksByLastInsertionDateDesc()
        {
            return _taskRepository.GetAll().Where(t => t.Status == TaskStatus.Pending).OrderByDescending(t => t.LastInsertionDate).ToList();
        }

        public IEnumerable<Task> GetPendingTasks(params Expression<Func<Task, object>>[] properties)
        {
            return _taskRepository.GetPendingTasks(properties);
        }

        public Dictionary<string,int> GetTotalTasksByStatus() {
            var taskList = _taskRepository.GetAll().Select(t => t.Status);

            return new Dictionary<string, int>
            {
                {"Pending", taskList.Count(t => t == TaskStatus.Pending) },
                {"InProgress", taskList.Count(t => t == TaskStatus.InProgress) },
                {"Completed", taskList.Count(t => t == TaskStatus.Completed) },
            };
        }

        public Dictionary<string, int> GetTotalTasksByCategory()
        {
            var taskList = _taskRepository.GetAll().Select(t => t.Category);

            return new Dictionary<string, int>
            {
                {"House", taskList.Count(t => t == TaskCategory.House) },
                {"Important", taskList.Count(t => t == TaskCategory.Important) },
                {"School", taskList.Count(t => t == TaskCategory.School) },
                {"Sports", taskList.Count(t => t == TaskCategory.Sports) },
                {"Work", taskList.Count(t => t == TaskCategory.Work) },
            };
        }

        public Dictionary<string, int> GetTotalTasksByDeliveryDate()
        {
            var deliveryDateList = _taskRepository.GetAll().Where(t => t.DeliveryDate >= DateTime.Now).Select(t => t.DeliveryDate);
            var currentDay = DateTime.Now;

            return new Dictionary<string, int>
            {
                {"upTo7days", deliveryDateList.Count(t => (t - currentDay) <= TimeSpan.FromDays(7) ) },
                {"upTo15days", deliveryDateList.Count(t => (t - currentDay) <= TimeSpan.FromDays(15) && (t - currentDay > TimeSpan.FromDays(7)) ) },
                {"upTo30days", deliveryDateList.Count(t => (t - currentDay) <= TimeSpan.FromDays(30)  && (t - currentDay > TimeSpan.FromDays(15))) },
                {"moreThan30days", deliveryDateList.Count(t => (t - currentDay) > TimeSpan.FromDays(30) ) }                                                               
            };
        }

    }
}
