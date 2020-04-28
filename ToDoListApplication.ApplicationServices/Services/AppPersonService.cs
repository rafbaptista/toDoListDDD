using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using ToDoListApplication.ApplicationServices.Interface;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.Domain.Interfaces.Repositories;
using ToDoListApplication.Domain.Interfaces.Services;

namespace ToDoListApplication.ApplicationServices.Services
{
    public class AppPersonService : AppServiceBase<Person>, IAppPersonService
    {
        private readonly IPersonService _personService;

        public AppPersonService(IPersonService personService)
            : base(personService)
        {
            _personService = personService;
        }

        public Dictionary<string, int> GetTotalPersonByAgeBrackets()
        {
            return _personService.GetTotalPersonByAgeBrackets();
        }

        public Dictionary<string, int> GetTotalPersonByGender()
        {
            return _personService.GetTotalPersonByGender();
        }

        public Dictionary<string, int> GetTotalPersonWithAndWithoutTasks()
        {
            return _personService.GetTotalPersonWithAndWithoutTasks();
        }

        public void UploadImage(HttpPostedFileBase file)
        {
            _personService.UploadImage(file);
        }
    }
}
