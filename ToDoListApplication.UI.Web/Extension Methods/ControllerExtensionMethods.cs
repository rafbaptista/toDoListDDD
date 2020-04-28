using AutoMapper;
using System.Web.Mvc;

namespace ToDoListApplication.UI.Web.Extension_Methods
{
    public static class ControllerExtensionMethods
    {
        public static TDestination ConvertEntity<TSource, TDestination>(this Controller controller, TSource obj)
        {            
            return Mapper.Map<TDestination>(obj);
        }         
    }
}