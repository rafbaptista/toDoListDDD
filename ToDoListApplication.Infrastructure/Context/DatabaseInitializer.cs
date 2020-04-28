using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ToDoListApplication.Domain.Entities;
using ToDoListApplication.Domain.Enums;

namespace ToDoListApplication.Infrastructure.Context
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists <ToDoListApplicationContext>
    {
        protected override void Seed(ToDoListApplicationContext context)
        {
            var listPerson = new List<Person>()
            {
                new Person() {Name = "William", Age = 25, Gender = Gender.Male, AvatarImagePath = "/Content/assets/images/avatar1.png"},
                new Person() {Name = "Barbara", Age = 60, Gender = Gender.Female, AvatarImagePath = "/Content/assets/images/avatar4.jpg"},
                new Person() {Name = "Lonnie", Age = 44, Gender = Gender.Female, AvatarImagePath = "/Content/assets/images/avatar5.png"},
                new Person() {Name = "Dennis", Age = 21, Gender = Gender.Male, AvatarImagePath = "/Content/assets/images/avatar2.jpg"},
                new Person() {Name = "John", Age = 17, Gender = Gender.Male, AvatarImagePath = "/Content/assets/images/avatar3.jpg"},
                new Person() {Name = "Lisa", Age = 62, Gender = Gender.Female, AvatarImagePath = "/Content/assets/images/initialAvatar.png"},
            };

            var listTask = new List<Task>()
            {
                new Task() {Description = "Feed the cats", Status = TaskStatus.Completed, Category = TaskCategory.School, DeliveryDate = DateTime.Now.AddDays(3),Person = listPerson[0]},
                new Task() {Description = "Travel to Rio de Janeiro", Status = TaskStatus.Pending, Category = TaskCategory.Important, DeliveryDate = DateTime.Now.AddDays(90),Person = listPerson[1]},
                new Task() {Description = "Take out the trash", Status = TaskStatus.InProgress, Category = TaskCategory.House, DeliveryDate = DateTime.Now.AddDays(1),Person = listPerson[2]},
                new Task() {Description = "Learn how to code", Status = TaskStatus.Pending, Category = TaskCategory.School, DeliveryDate = DateTime.Now.AddDays(14),Person = listPerson[3]},
                new Task() {Description = "Finish Friends", Status = TaskStatus.InProgress, Category = TaskCategory.Important, DeliveryDate = DateTime.Now.AddDays(27),Person = listPerson[1]},
                new Task() {Description = "Play soccer with John", Status = TaskStatus.Pending, Category = TaskCategory.Sports, DeliveryDate = DateTime.Now.AddDays(3),Person = listPerson[0]},
                new Task() {Description = "Finish paper", Status = TaskStatus.InProgress, Category = TaskCategory.Work, DeliveryDate = DateTime.Now.AddDays(2),Person = listPerson[1]},
                                
            };

            listPerson.ForEach(p => context.Person.Add(p));
            listTask.ForEach(t => context.Tasks.Add(t));
            
            base.Seed(context); 
        }
    }
}
