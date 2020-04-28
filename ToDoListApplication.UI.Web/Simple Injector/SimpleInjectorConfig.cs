using AutoMapper;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using ToDoListApplication.ApplicationServices.Interface;
using ToDoListApplication.ApplicationServices.Services;
using ToDoListApplication.Domain.Interfaces.Repositories;
using ToDoListApplication.Domain.Interfaces.Services;
using ToDoListApplication.Domain.Services;
using ToDoListApplication.Infrastructure.Context;
using ToDoListApplication.Infrastructure.Repositories;
using ToDoListApplication.UI.Web.AutoMapper;

namespace ToDoListApplication.UI.Web.Simple_Injector
{
    public class SimpleInjectorConfig
    {
        public static void RegisterDependencies()
        {
            //Create container
            var container = new Container();

            //register services

            //Application services
            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            container.Register<IAppPersonService, AppPersonService>();
            container.Register<IAppTaskService, AppTaskService>();

            //services
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));
            container.Register<IPersonService, PersonService>();
            container.Register<ITaskService, TaskService>();

            //repositories
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            container.Register<IPersonRepository, PersonRepository>();
            container.Register<ITaskRepository, TaskRepository>();                        

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
    }
}