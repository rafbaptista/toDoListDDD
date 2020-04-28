using System.Collections.Generic;
using ToDoListApplication.Domain.Enums;

namespace ToDoListApplication.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
        public string AvatarImagePath { get; set; } 
    }
}
