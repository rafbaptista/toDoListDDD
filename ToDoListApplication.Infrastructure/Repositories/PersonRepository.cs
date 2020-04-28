using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.Domain.Interfaces.Repositories;

namespace ToDoListApplication.Infrastructure.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {                              
    }
}
