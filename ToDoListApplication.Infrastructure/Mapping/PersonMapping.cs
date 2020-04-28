using System.Data.Entity.ModelConfiguration;
using ToDoListApplication.Domain.Entities;

namespace ToDoListApplication.Infrastructure.Mapping
{
    public class PersonMapping : EntityTypeConfiguration<Person>
    {
        public PersonMapping()
        {
            HasKey(p => p.Id);

            HasMany(p => p.Tasks).WithRequired(x => x.Person);

            Property(p => p.Name)
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.Gender)
                .IsRequired();                
        }
    }
}
