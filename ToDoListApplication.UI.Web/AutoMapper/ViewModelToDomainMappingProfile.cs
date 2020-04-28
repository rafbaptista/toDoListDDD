using AutoMapper;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.UI.Web.ViewModels;

namespace ToDoListApplication.UI.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            string imagesFolder = "/Content/assets/images/";
            string initialAvatar = "/Content/assets/images/initialAvatar.png";

            //If the user didn't upload a picture, sets the picture to the initial avatar when converting to a Person object and saving data
            CreateMap<PersonViewModel, Person>()
                .ForMember(dest => dest.AvatarImagePath, x => x.MapFrom(src => imagesFolder + src.AvatarImage.FileName))
                .AfterMap((src, dest) =>
                     dest.AvatarImagePath = dest.AvatarImagePath == null ? dest.AvatarImagePath = initialAvatar : dest.AvatarImagePath
            );                
            CreateMap<TaskViewModel, Task>();          
        }
    }
}