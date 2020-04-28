using System.ComponentModel.DataAnnotations;

namespace ToDoListApplication.Domain.Enums
{
    public enum TaskStatus
    {
        [Display(Name = "Pending")]
        Pending = 1,
        [Display(Name = "In Progress")]
        InProgress = 2,
        [Display(Name = "Completed")]
        Completed = 3
    }
}
