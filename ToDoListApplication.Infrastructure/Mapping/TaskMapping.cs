using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using ToDoListApplication.Domain.Entities;

namespace ToDoListApplication.Infrastructure.Mapping
{
    public class TaskMapping : EntityTypeConfiguration<Task>
    {
        public TaskMapping()
        {
            HasKey(p => p.Id);

            Property(t => t.DeliveryDate)
                .IsRequired();

            Property(t => t.LastInsertionDate)
                .IsRequired();

            Property(t => t.Category)
                .IsRequired();

            Property(t => t.Status)
                .IsRequired();

            Property(t => t.PersonId)
                .IsRequired();

            Property(t => t.Description)
                .HasMaxLength(400)
                .IsRequired();
        }
    }
}
