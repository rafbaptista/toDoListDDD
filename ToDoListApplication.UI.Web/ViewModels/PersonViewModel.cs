using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.Domain.Enums;
using ToDoListApplication.UI.Web.Custom_Attributes.Validation_Attributes;

namespace ToDoListApplication.UI.Web.ViewModels
{
    public class PersonViewModel
    {                                                   
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please inform a name")]
        [MaxLength(150, ErrorMessage = "Maximum of 150 characters")]
        [MinLength(2, ErrorMessage = "Minimum of 2 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please inform the age")]
        [Range(1,120,ErrorMessage = "Please inform a age between 1 and 120")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender must be informed")]
        [EnumRequired(ErrorMessage = "Gender must be informed")]
        public Gender Gender { get; set; }

        public IEnumerable<Task> Tasks { get; set; }

        [ImageChecker]
        [DisplayName("Upload a picture")]
        public HttpPostedFileBase AvatarImage { get; set; }

        public string AvatarImagePath { get; set; }
    }
}