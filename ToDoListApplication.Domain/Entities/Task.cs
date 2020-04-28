using System;
using ToDoListApplication.Domain.Enums;

namespace ToDoListApplication.Domain.Entities
{
    public class Task
    {                     
        public int Id { get; set; }        
        public DateTime CreationDate { get; set; }         
        public DateTime DeliveryDate { get; set; }
        public DateTime LastInsertionDate { get; set; } 
        public TaskCategory Category { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
    }
}
