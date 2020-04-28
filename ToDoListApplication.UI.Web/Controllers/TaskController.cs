using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.UI.Web.ViewModels;
using ToDoListApplication.UI.Web.Extension_Methods;
using ToDoListApplication.ApplicationServices.Interface;
using ToDoListApplication.Domain.Enums;

namespace ToDoListApplication.UI.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly IAppTaskService _taskService;
        private readonly IAppPersonService _personService;

        public TaskController(IAppTaskService taskService, IAppPersonService personService)
        {
            _taskService = taskService;
            _personService = personService;
        }

        public ActionResult Index()
        {           
            var taskViewModel = this.ConvertEntity<IEnumerable<Task>, IEnumerable<TaskViewModel>>(_taskService.GetAll());
            return View(taskViewModel);
        }


        public ActionResult Details(int id)
        {
            Task task = _taskService.GetById(id);
            TaskViewModel taskViewModel = this.ConvertEntity<Task, TaskViewModel>(_taskService.GetById(id));
            return View(taskViewModel);
        }

        public ActionResult Create()
        {
            var model = new TaskViewModel
            {
                PersonSelectList = new SelectList(_personService.GetAll(), "Id", "Name"),
                DeliveryDate = DateTime.Now.AddDays(1)
            };
            return View("Form", model);
        }


        public ActionResult Edit(int id)
        {
            TaskViewModel taskViewModel = this.ConvertEntity<Task, TaskViewModel>(_taskService.GetById(id));
            taskViewModel.PersonSelectList = new SelectList(_personService.GetAll(), "Id", "Name");
            return View("Form", taskViewModel);
        }

        public ActionResult Delete(int id)
        {
            TaskViewModel taskViewModel = this.ConvertEntity<Task, TaskViewModel>(_taskService.GetById(id));
            return View(taskViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = _taskService.GetById(id);
            _taskService.Delete(task);
            return RedirectToAction(nameof(TaskController.Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveOrUpdate(TaskViewModel taskViewModel)
        {
            if (ModelState.IsValid)
            {
                Task task = this.ConvertEntity<TaskViewModel, Task>(taskViewModel);
                if (task.Id > 0)
                {
                    _taskService.Update(task);
                }
                else
                {
                    _taskService.Add(task);
                }
                return RedirectToAction(nameof(PersonController.Index));
            }
            taskViewModel.PersonSelectList = new SelectList(_personService.GetAll(), "Id", "Name");
            return View("Form", taskViewModel);
        }

        public ActionResult Pending()
        {
            var pendingTasks = _taskService.GetPendingTasksByLastInsertionDateAsc();
            var pendingTasksViewModel = this.ConvertEntity<IEnumerable<Task>, IEnumerable<TaskViewModel>>(pendingTasks);
            return View("PendingTasks", pendingTasksViewModel);
        }

        public ActionResult InProgress()
        {
            var inProgressTasks = _taskService.GetInProgressTasksByLastInsertionDateAsc();
            var inProgressTasksViewModel = this.ConvertEntity<IEnumerable<Task>, IEnumerable<TaskViewModel>>(inProgressTasks);
            return View("InProgressTasks", inProgressTasksViewModel);
        }

        public ActionResult Completed()
        {
            //if (ControllerContext.IsChildAction) { }
            var completedTasks = _taskService.GetCompletedTasksByLastInsertionDateAsc();
            var completedTasksViewModel = this.ConvertEntity<IEnumerable<Task>, IEnumerable<TaskViewModel>>(completedTasks);
            return View("CompletedTasks", completedTasksViewModel);
        }

        public ActionResult ChangeStatus(int taskId, TaskStatus newStatus)
        {
            try
            {
                _taskService.ChangeStatus(taskId, newStatus);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
                return RedirectToAction("Index", "Home");
            }

        }

    }
}
