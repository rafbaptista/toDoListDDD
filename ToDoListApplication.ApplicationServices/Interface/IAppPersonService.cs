using System.Collections.Generic;
using System.Web;
using ToDoListApplication.Domain.Entities;

namespace ToDoListApplication.ApplicationServices.Interface
{
    public interface IAppPersonService : IAppServiceBase<Person>
    {
        void UploadImage(HttpPostedFileBase file);
        Dictionary<string, int> GetTotalPersonByGender();
        Dictionary<string, int> GetTotalPersonByAgeBrackets();
        Dictionary<string, int> GetTotalPersonWithAndWithoutTasks();
    }
}
