using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.UI.Web.ViewModels;

namespace ToDoListApplication.UI.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Person, PersonViewModel>()
                .ForMember(dest => dest.AvatarImagePath, x => x.MapFrom(src => src.AvatarImagePath));

            CreateMap<Task, TaskViewModel>();
        }
    }
}