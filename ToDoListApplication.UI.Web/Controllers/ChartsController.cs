using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoListApplication.Domain.Interfaces.Services;

namespace ToDoListApplication.UI.Web.Controllers
{
    public class ChartsController : Controller
    {
        private readonly IPersonService _personService;
        private readonly ITaskService _taskService;

        public ChartsController(IPersonService personService, ITaskService taskService)
        {
            _personService = personService;
            _taskService = taskService;
        }
        
        public ActionResult Index()
        {
            var teste = DateTime.Now - new DateTime(2020, 04, 25);

            return View();
        }    

        [HttpPost]
        public JsonResult GetTotalPersonByGender()
        {                        
            var genderInformation = _personService.GetTotalPersonByGender();            
            return Json(genderInformation);            
        }

        [HttpPost]
        public JsonResult GetTotalPersonByAgeBracket()
        {                        
            var ageInformation = _personService.GetTotalPersonByAgeBrackets();                                                
            return Json(ageInformation);
        }

        [HttpPost]
        public JsonResult GetTotalPersonWithAndWithoutTasks()
        {
            var tasksInformation = _personService.GetTotalPersonWithAndWithoutTasks();
            return Json(tasksInformation);
        }

        [HttpPost]
        public JsonResult GetTotalTasksByStatus() {
            var taskStatus = _taskService.GetTotalTasksByStatus();
            return Json(taskStatus);
        }

        [HttpPost]
        public JsonResult GetTotalTasksByCategory()
        {
            var tasksCategory = _taskService.GetTotalTasksByCategory();
            return Json(tasksCategory);
        }

        [HttpPost]
        public JsonResult GetTotalTasksByDeliveryDate()
        {
            var tasksDeliveryDate = _taskService.GetTotalTasksByDeliveryDate();
            return Json(tasksDeliveryDate);
        }
       
    }
}