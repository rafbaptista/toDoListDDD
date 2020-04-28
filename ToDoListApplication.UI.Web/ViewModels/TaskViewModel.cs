using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.Domain.Enums;
using ToDoListApplication.UI.Web.Custom_Attributes.Validation_Attributes;

namespace ToDoListApplication.UI.Web.ViewModels
{
    public class TaskViewModel
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please inform a delivery date for the task")]        
        [DateTimeChecker(ErrorMessage = "Delivery date can't be less then the current date")]
        [DataType(DataType.Date)]        
        public DateTime DeliveryDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "Please choose a category for the task")]
        [EnumRequired(ErrorMessage = "Please choose a category for the task")]
        public TaskCategory Category { get; set; }

        [Required(ErrorMessage = "Please choose a status for the task")]
        [EnumRequired(ErrorMessage = "Please choose a status for the task")]
        public TaskStatus Status { get; set; }

        [Required(ErrorMessage = "Please write a description of the task")]
        [MaxLength(400, ErrorMessage = "Maximum of 400 characters")]
        [MinLength(2, ErrorMessage = "Minimum of 2 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please choose a person responsable for this task")]
        [DisplayName("Person responsable")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public SelectList PersonSelectList { get; set; }

        public string DeadLine
        {
            get
            {                                
                TimeSpan deadline = DeliveryDate.Subtract(DateTime.Now);
                if (deadline.Days > 0) return string.Format("{0:%d}d {0:%h}h {0:%m}m {0:%s}s", deadline);
                if (deadline.Hours > 0) return string.Format("{0:%h}h {0:%m}m {0:%s}s", deadline);
                if (deadline.Minutes > 0) return string.Format("{0:%m}m {0:%s}s", deadline);
                if (deadline.Seconds > 0) return string.Format("{0:%s}s", deadline);
                return "Expired";
            }
        }

    }
}

