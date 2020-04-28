using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using ToDoListApplication.Domain.Entities;

namespace ToDoListApplication.Domain.Interfaces.Services
{
    public interface IPersonService : IServiceBase<Person>
    {
        void UploadImage(HttpPostedFileBase file);
        Dictionary<string, int> GetTotalPersonByGender();
        Dictionary<string, int> GetTotalPersonByAgeBrackets();
        Dictionary<string, int> GetTotalPersonWithAndWithoutTasks();
    }
}
