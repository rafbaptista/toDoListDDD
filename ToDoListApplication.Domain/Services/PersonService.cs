using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.Domain.Enums;
using ToDoListApplication.Domain.Interfaces.Repositories;
using ToDoListApplication.Domain.Interfaces.Services;

namespace ToDoListApplication.Domain.Services
{
    public class PersonService : ServiceBase<Person>, IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
            :base(personRepository)
        {
            _personRepository = personRepository;
        }

        public void UploadImage(HttpPostedFileBase file)
        {
            string fileName = Path.GetFileName(file.FileName);           
            string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/assets/images"), fileName);
            file.SaveAs(fullPath);            
        }  
        
        public Dictionary<string,int> GetTotalPersonByGender()
        {
            var listGenders = _personRepository.GetAll().Select(p => p.Gender);
            int totalMale = listGenders.Count(p => p == Gender.Male);
            int totalFemale = listGenders.Count(p => p == Gender.Female);

            return new Dictionary<string, int>
            {
                { "TotalMales", totalMale },
                { "TotalFemales", totalFemale }
            };
        }

        public Dictionary<string, int> GetTotalPersonByAgeBrackets()
        {
            var listAges = _personRepository.GetAll().Select(p => p.Age);
            
            return new Dictionary<string, int>
            {
                {"firstBracket", listAges.Where(p => p >= 0 && p <= 18).Count() },
                {"secondBracket", listAges.Where(p => p >= 19 && p <= 40).Count() },
                {"thirdBracket", listAges.Where(p => p >= 40 && p <= 60).Count() },
                {"fourthBracket", listAges.Where(p => p >= 61).Count() }
            };
        }

        public Dictionary<string,int> GetTotalPersonWithAndWithoutTasks()
        {
            var personList = _personRepository.GetAll().Select(p => p.Tasks.Count);
            return new Dictionary<string, int>
            {
                {"withTasks", personList.Count(x => x > 0) },
                {"withoutTasks", personList.Count(x => x == 0) },
            };
        }

    }
}
